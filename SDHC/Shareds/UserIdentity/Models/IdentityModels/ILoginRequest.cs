using System;
using System.Collections.Generic;
using System.Text;

namespace UserIdentity.Models.IdentityModels
{
  public interface ILoginRequest
  {
    string Username { get; set; }
    string Password { get; set; }
  }

}
