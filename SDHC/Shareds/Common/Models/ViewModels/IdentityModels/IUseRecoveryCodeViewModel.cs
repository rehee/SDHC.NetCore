namespace Common.Models.ViewModels
{
  public interface ICodeBased
  {
    string Code { get; set; }
  }
  public interface IUseRecoveryCodeViewModel : ICodeBased
  {
    string ReturnUrl { get; set; }
  }
  public interface IVerifyAuthenticatorCodeViewModel : IVerifyCodeViewModel
  {
    bool RememberMe { get; set; }
  }
  public interface IVerifyCodeViewModel : IUseRecoveryCodeViewModel
  {
    bool RememberBrowser { get; set; }
  }
}
