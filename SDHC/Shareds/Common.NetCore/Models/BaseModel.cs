using Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.NetCore.Models
{
  public abstract class BaseModel : AbstractBaseModel
  {
    [Key]
    [BaseProperty]
    public override long Id { get; set; }
  }

}
