using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.NetCore.Models
{
  public abstract class BaseSharedLink : BaseSharedContent, ISharedLink
  {
    [InputType(EditorType = EnumInputType.Number)]
    public int DisplayOrder { get; set; }

    [InputType(EditorType = EnumInputType.Bool)]
    public bool Displayed { get; set; }

    [HideEdit]
    public long? RelatedId { get; set; }

  }
}
