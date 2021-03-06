using Common.NetCore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SDHC.Models
{
  [AllowChildren(ChildrenType = new Type[] { typeof(BaseContentModel) })]
  public class BaseContentModel : BaseContent
  {
    [InputType(EditorType = EnumInputType.FileUpload)]
    public string FF { get; set; }
    [InputType(EditorType = EnumInputType.Text)]
    public string FF2 { get; set; }
  }
}
