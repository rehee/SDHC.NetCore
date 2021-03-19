using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
  public interface IInt64Key
  {
    Int64 Id { get; set; }
  }
  public interface IStringKey
  {
    String Id { get; set; }
  }
  public interface IDisplayName
  {
    string DisplayName();
  }
}
