using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserIdentity.Models.IdentityModels;
using UserIdentity.Services;

namespace UserIdentity.Services
{

  public interface ISDHCUserManager
  {
    Task<IUserBase> GetUserAsnc(string loginId);
    Task<bool> CheckLoginRequest(ILoginRequest login);
    Task<IUserBase> CreateUser(IRegisterWithNameViewModel login);
  }
}
