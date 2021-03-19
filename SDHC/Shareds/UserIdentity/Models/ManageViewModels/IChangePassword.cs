using System;
using System.Collections.Generic;
using System.Text;

namespace UserIdentity.Models.ManageViewModels
{
  public interface IChangePasswordBase
  {
    string NewPassword { get; set; }
    string ConfirmPassword { get; set; }
  }
  public interface IChangePassword : IChangePasswordBase
  {
    string OldPassword { get; set; }
  }
}
