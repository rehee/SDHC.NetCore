using System;
using System.Collections.Generic;
using System.Text;
using UserIdentity.Models.IdentityModels;

namespace SDHC.UserAndRoles.Models
{
  public class LoginModel : ILoginRequest
  {
    public string Username { get; set; }
    public string Password { get; set; }
  }
}
