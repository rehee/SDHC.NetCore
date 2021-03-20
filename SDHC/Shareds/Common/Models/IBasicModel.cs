using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
  public interface IBasicModel : IInt64Key, IDisplayName
  {
    string Title { get; set; }
  }
}
