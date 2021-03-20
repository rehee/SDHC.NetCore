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
    Task<IUserBase> CheckLoginRequest(ILoginRequest login);
    Task<IUserBase> CreateUser(IRegisterWithNameViewModel login);
  }
  public interface ISDHCUserManager<TUser> : ISDHCUserManager where TUser : IUserBase
  {
    new Task<TUser> GetUserAsnc(string loginId);
    new Task<TUser> CheckLoginRequest(ILoginRequest login);
    new Task<TUser> CreateUser(IRegisterWithNameViewModel login);
  }
}
