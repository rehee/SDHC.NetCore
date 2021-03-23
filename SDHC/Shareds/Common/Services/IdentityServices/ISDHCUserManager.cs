using Common.Models;
using Common.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Services
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

    Task<IEnumerable<string>> GetUserRole(IUserBase user);
  }
}
