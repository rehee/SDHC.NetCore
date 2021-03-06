using Common.Models;
using Common.NetCore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common.NetCore.Extends.ViewModels
{
  public static class SharedLinkViewExtend
  {
    public static SharedLinkView GetSharedLinkView<T>(this AbstractPostViewModal<T> model, string key) where T : IPostModel
    {
      return model.GetSharedLinkPost<T>(key).View;
    }
    public static SharedLinkView GetSharedLinkView(this ContentPropertyIndex model)
    {
      return model.GetSharedLinkPost(model.Lang).View;
    }
    public static SharedLinkView GetSharedLinkView(this ContentProperty model)
    {
      return model.GetSharedLinkPost().View;
    }

    public static SharedLinkPost GetSharedLinkPost<T>(this AbstractPostViewModal<T> model, string key) where T : IPostModel
    {
      return model.GetContentPropertyByName(key).Property.GetSharedLinkPost(model.Lang);
    }
    public static SharedLinkPost GetSharedLinkPost(this ContentPropertyIndex model, int? lang = null)
    {
      return model.Property.GetSharedLinkPost(lang.HasValue ? lang : model.Lang);
    }
    public static SharedLinkPost GetSharedLinkPost(this ContentProperty model, int? lang = null)
    {

      var type = model.RelatedType;
      var allowChild = type.GetCustomAttribute<AllowChildrenAttribute>();
      var header = allowChild?.TableList ?? Enumerable.Empty<string>();
      var image = allowChild?.TableList ?? Enumerable.Empty<string>();
      var models = PassModeConvert.GetSharedLinks(type, lang, model.IsSingleRecord, model.IsLinkedRecord, model.ModelId);
      var result = new SharedLinkPost
      {
        Headers = header,
        Images = image,
        Models = models,
        Lang = lang,
        TypeName = type?.FullName,
        AssemblyName = type?.Assembly.FullName,
        IsRelated = model.IsLinkedRecord,
        RelatedId = model.ModelId,
        View = new SharedLinkView(Newtonsoft.Json.JsonConvert.SerializeObject(models), model.Key)
      };
      return result;
    }

    public static IEnumerable<T> GetModels<T>(this SharedLinkPost model, Func<T, bool> where = null, Func<T, int> orderBy = null, bool asc = true) where T : ISharedLink
    {
      if (where == null)
      {
        where = b => b.Displayed;
      }
      if (orderBy == null)
      {
        orderBy = b => b.DisplayOrder;
      }
      var query = model.Models.Where(b => where((T)b)).Select(b => (T)b);
      if (asc)
      {
        return query.OrderBy(orderBy);
      }
      return query.OrderByDescending(orderBy);
    }
  }
}
