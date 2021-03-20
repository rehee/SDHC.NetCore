using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Models
{
  public abstract class AbstractPostViewModal<T> where T : IPostModel
  {
    public int Lang { get; }
    private Dictionary<string, ContentPropertyIndex> list { get; set; } = new Dictionary<string, ContentPropertyIndex>();
    public T Model { get; }
    public AbstractPostViewModal(T model, string outerKey = null, int? lang = null)
    {
      Model = model;
      var index = 0;
      OutIndex = outerKey;
      if (lang == null && model is ISharedContent)
      {
        lang = (model as ISharedContent).Lang;
      }
      Lang = lang ?? 0;
      foreach (var property in Model.Properties)
      {
        list.Add(property.Key, new ContentPropertyIndex(property, index, outerKey, lang, Model.Id, model.FullType, model.ThisAssembly));
        index++;
      }
    }
    public IEnumerable<ContentPropertyIndex> ContentPropertyIndexs => list.Values;
    public ContentPropertyIndex GetContentPropertyByName(string key)
    {
      if (list.ContainsKey(key))
        return list[key];
      return null;
    }
    public string GetValueByName(string key)
    {
      var p = GetContentPropertyByName(key);
      if (p == null)
        return null;
      switch (p.Property.EditorType)
      {
        case EnumInputType.DropDwon:
          return String.Join(",", p.Property.SelectItems.Where(b => b.Select).Select(b => b.Value));
        case EnumInputType.FileUpload:
          var path = p.Property.Value.ImagePath().GetUrlPath();
          return path;
      }
      return p.Property.Value;
    }
    public string GetModalNameByName(string key)
    {
      var p = GetContentPropertyByName(key);
      return p?.ModalName ?? "";
    }
    public string GetModalRefreshByName(string key)
    {
      var p = GetContentPropertyByName(key);
      return p?.ModalRefresh ?? "";
    }
    public string GetModalReviewByName(string key)
    {
      var p = GetContentPropertyByName(key);
      return p?.ModalReview ?? "";
    }

    public string OutIndex { get; }
    public string OutMakr => String.IsNullOrEmpty(OutIndex) ? $"" : $"{OutIndex}.";
  }
}
