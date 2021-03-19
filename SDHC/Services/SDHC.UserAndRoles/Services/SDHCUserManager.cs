using Common.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using SDHC.UserAndRoles.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserIdentity.Models.IdentityModels;
using UserIdentity.Services;

namespace SDHC.UserAndRoles.Services
{
  public class SDHCUserManager<TUser> : ISDHCUserManager where TUser : SDHCUser, new()
  {
    public ISDHCMemberService<IdentityResult, Claim, ClaimsPrincipal, UserLoginInfo> SDHCMemberService;
    public ISDHCSignInService< IdentityResult, Claim, SignInResult, ClaimsPrincipal, AuthenticationProperties, AuthenticationScheme, ExternalLoginInfo> SDHCSignInService;
    public SDHCUserManager(
      ISDHCMemberService<IdentityResult, Claim, ClaimsPrincipal, UserLoginInfo> _SDHCMemberService,
      ISDHCSignInService<IdentityResult, Claim, SignInResult, ClaimsPrincipal, AuthenticationProperties, AuthenticationScheme, ExternalLoginInfo> _SDHCSignInService)
    {
      this.SDHCMemberService = _SDHCMemberService;
      this.SDHCSignInService = _SDHCSignInService;
    }
    public async Task<IUserBase> GetUserAsnc(string loginId)
    {
      var user = await this.SDHCMemberService.FindByEmailAsync(loginId);
      if (user != null)
      {
        return user;

      }
      user = await this.SDHCMemberService.FindByNameAsync(loginId);
      if (user != null)
      {
        return user;
      }
      return null;
    }
    public async Task<bool> CheckLoginRequest(ILoginRequest login)
    {
      var user = await this.GetUserAsnc(login.Username) as TUser;
      if (user == null)
      {
        return false;
      }
      var isCorrectPassword = await this.SDHCMemberService.CheckPasswordAsync(user, login.Password);
      return isCorrectPassword;
    }

    public async Task<IUserBase> CreateUser(IRegisterWithNameViewModel login)
    {
      var user = await this.GetUserAsnc(login.Email);
      if (user != null)
      {
        return null;
      }
      if (!String.IsNullOrWhiteSpace(login.UserName))
      {
        user = await this.GetUserAsnc(login.UserName);
        if (user != null)
        {
          return null;
        }
      }
      user = new TUser();
      var result = await this.CreateUser(login);
      return result;
    }


  }
}
