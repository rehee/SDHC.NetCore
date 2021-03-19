using UserIdentity.Models.IdentityModels;

namespace SDHC.JWT.Models
{
  public class LoginItem : ILoginRequest
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }
}
