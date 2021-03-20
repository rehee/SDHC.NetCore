using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
  public interface IUserBase : IDisplayName, IStringKey
  {
    string GetUserName();
    string GetEmail();
  }
}
