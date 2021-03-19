using System;
using System.Collections.Generic;
using System.Text;
using UserIdentity;
using UserIdentity.Models.IdentityModels;

namespace SDHC.JWT.Services
{
  public interface IUserService
  {
    bool IsValid(ILoginRequest req);
  }

  public class UserService : IUserService
  {
    //模拟测试，默认都是人为验证有效
    public bool IsValid(ILoginRequest req)
    {
      return true;
    }
  }
}
