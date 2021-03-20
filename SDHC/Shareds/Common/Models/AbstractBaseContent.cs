using SDHC.Common.Cruds;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;

namespace Common.Models
{
  public abstract class AbstractBaseContent : IContentModel
  {
    protected static Type baseIContentModelType { get; set; }
    protected static ICrud Crud { get; } = GetCrud();
    protected static Func<ICrud> GetCrud { get; set; } = () => null;
    public static void Init<BaseIContentType>(Func<ICrud> getCrud) where BaseIContentType : class, IContentModel
    {
      GetCrud = getCrud;
      baseIContentModelType = typeof(BaseIContentType);
    }
    public AbstractBaseContent()
    {
      if (Id <= 0)
      {
        this.CreateTime = DateTime.UtcNow;
        this.DisplayOrder = Crud.Read<IContentModel>(baseIContentModelType, b => true).Count() + 1;
      }
    }

    [BaseProperty]
    [HideEdit]
    public int Lang { get; set; }
    [BaseProperty]
    public virtual long Id { get; set; }
    [BaseProperty]
    public virtual string Title
    {
      get
      {
        return this._title;
      }
      set
      {
        var t = String.IsNullOrEmpty(value) || String.IsNullOrWhiteSpace(value) ? Guid.NewGuid().ToString() : value.Trim();
        t = t.Replace('/', '_').Replace(" ", "-");
        this.Url = System.Uri.EscapeUriString(t);
        this._title = t;
      }
    }

    public virtual IContentModel Parent { get; set; }

    protected virtual string _title { get; set; }
    [IgnoreEdit]
    public virtual string Url
    {
      get; set;
    }

    protected long _displayOrder { get; set; }

    [BaseProperty]
    public long DisplayOrder
    {
      get
      {
        if (this.Id == 0)
          return Crud.Read<IContentModel>(baseIContentModelType, b => true).Count() + 1;
        return this._displayOrder;
      }
      set
      {
        _displayOrder = value;
      }
    }

    protected DateTime? _createTime { get; set; }

    [BaseProperty]
    public virtual DateTime? CreateTime
    {
      get
      {
        if (this.Id <= 0)
        {
          return DateTime.UtcNow;
        }
        return _createTime;
      }
      set
      {
        _createTime = value;
      }
    }

    [BaseProperty]
    public virtual long? ParentId { get; set; }

    //[IgnoreEdit]
    //public virtual IContentModel ThisParent { get; set; }




    [IgnoreEdit]
    protected virtual IEnumerable<IContentModel> _parents { get; set; }

    [IgnoreEdit]
    public virtual IEnumerable<IContentModel> Parents
    {
      get
      {
        if (_parents != null)
          return _parents;
        var list = new List<IContentModel>();
        var p = this.Parent;
        do
        {
          if (p == null)
          {
            break;
          }
          list.Add(p);
          p = p.Parent;
        } while (p != null);
        _parents = list;
        return list;
      }
    }
    public virtual string DisplayName()
    {
      return String.IsNullOrEmpty(this.Title) ? this.Id.ToString() : this.Title;
    }
    public override string ToString()
    {
      return this.DisplayName();
    }

    [IgnoreEdit]
    public virtual IEnumerable<IContentModel> Children
    {
      get
      {
        return Crud.Read<IContentModel>(baseIContentModelType, b => b.ParentId == this.Id)
          .OrderBy(b => b.DisplayOrder).ToList();
      }
    }
  }
}
