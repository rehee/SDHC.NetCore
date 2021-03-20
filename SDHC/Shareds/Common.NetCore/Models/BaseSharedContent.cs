using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.NetCore.Models
{
  public abstract class BaseSharedContent : BaseModel, ISharedContent
  {
    [HideEdit]
    public int Lang { get; set; }
  }
}
