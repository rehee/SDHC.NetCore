using System;
using System.Collections.Generic;
using System.Text;

namespace UserIdentity.Models.IdentityModels
{
  public interface IEmailPasswordBased : IEmailBasedViewModel
  {
    string Password { get; set; }
  }
  public interface ILoginViewModel : IEmailBasedViewModel
  {
    bool RememberMe { get; set; }
  }
  public interface IRegisterViewModel : IEmailBasedViewModel
  {
    string ConfirmPassword { get; set; }
  }
  public interface IRegisterWithNameViewModel : IRegisterViewModel
  {
    string UserName { get; set; }
  }
  public interface IResetPasswordViewModel : IRegisterViewModel, ICodeBased
  {

  }

}
