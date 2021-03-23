using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ViewModels
{
  public interface IRemoveLoginViewModel
  {
    string LoginProvider { get; set; }
    string ProviderKey { get; set; }
  }
}
