using Common.Models.ViewModels;

namespace SDHC.UserAndRoles.Models
{
  public class LoginModel : ILoginRequest
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }
}
