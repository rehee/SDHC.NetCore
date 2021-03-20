using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
  public interface IPassModel
  {
    List<ContentProperty> Properties { get; set; }
  }
  public interface IPostModel : IPassModel, IInt64Key
  {
    string FullType { get; set; }
    string ThisAssembly { get; set; }
  }
}
