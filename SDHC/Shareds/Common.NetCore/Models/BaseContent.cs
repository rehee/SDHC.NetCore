using Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Common.NetCore.Models
{
  public abstract class BaseContent : AbstractBaseContent
  {
    [Key]
    [BaseProperty]
    public override long Id { get; set; }

    [BaseProperty]
    [ForeignKey("ThisParent")]
    public override long? ParentId { get; set; }

    [IgnoreEdit]
    public virtual BaseContent ThisParent { get; set; }

    [IgnoreEdit]
    [NotMapped]
    public override IContentModel Parent
    {
      get
      {
        var p = (IContentModel)this.ThisParent;
        if (p == null && this.ParentId.HasValue && ParentId.Value > 0)
        {
          p = Crud.Find<IContentModel>(baseIContentModelType, ParentId.Value);
        }
        return p;
      }
    }
  }
}
