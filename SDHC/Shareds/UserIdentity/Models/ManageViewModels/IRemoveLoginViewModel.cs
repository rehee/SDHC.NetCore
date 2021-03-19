using System;
using System.Collections.Generic;
using System.Text;

namespace UserIdentity.Models.ManageViewModels
{
  public interface IRemoveLoginViewModel
  {
    string LoginProvider { get; set; }
    string ProviderKey { get; set; }
  }
}
