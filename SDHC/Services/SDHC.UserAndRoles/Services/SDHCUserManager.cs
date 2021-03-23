using Common.Models;
using Common.Models.ViewModels;
using Common.NetCore.Models;
using Common.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SDHC.UserAndRoles.Services
{
  public class SDHCUserManager<TUser> : ISDHCUserManager<TUser> where TUser : SDHCUser, new()
  {
    public ISDHCMemberService<TUser, IdentityResult, Claim, ClaimsPrincipal, UserLoginInfo, IUserValidator<TUser>, IUserTwoFactorTokenProvider<TUser>>
      SDHCMemberService;
    public ISDHCSignInService<TUser, IdentityResult, Claim, SignInResult, ClaimsPrincipal, AuthenticationProperties, AuthenticationScheme, ExternalLoginInfo>
      SDHCSignInService;
    public SDHCUserManager(
      ISDHCMemberService<TUser, IdentityResult, Claim, ClaimsPrincipal, UserLoginInfo, IUserValidator<TUser>, IUserTwoFactorTokenProvider<TUser>> _SDHCMemberService,
      ISDHCSignInService<TUser, IdentityResult, Claim, SignInResult, ClaimsPrincipal, AuthenticationProperties, AuthenticationScheme, ExternalLoginInfo> _SDHCSignInService)
    {
      this.SDHCMemberService = _SDHCMemberService;
      this.SDHCSignInService = _SDHCSignInService;
    }
    public async Task<TUser> GetUserAsnc(string loginId)
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


    public async Task<TUser> CheckLoginRequest(ILoginRequest login)
    {
      var user = await this.GetUserAsnc(login.Username) as TUser;
      if (user == null)
      {
        return null;
      }
      var isCorrectPassword = await this.SDHCMemberService.CheckPasswordAsync(user, login.Password);
      return user;
    }

    public async Task<TUser> CreateUser(IRegisterWithNameViewModel login)
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
      user.Email = login.Email;
      user.UserName = login.UserName;

      var result = await SDHCMemberService.CreateAsync(user, login.Password);
      if (result.Succeeded)
      {
        user = await SDHCMemberService.FindByNameAsync(user.UserName);
        return user;
      }
      return null;
    }

    async Task<IUserBase> ISDHCUserManager.GetUserAsnc(string loginId)
    {
      return await this.GetUserAsnc(loginId);
    }
    async Task<IUserBase> ISDHCUserManager.CheckLoginRequest(ILoginRequest login)
    {
      return await this.CheckLoginRequest(login);
    }
    async Task<IUserBase> ISDHCUserManager.CreateUser(IRegisterWithNameViewModel login)
    {
      return await this.CreateUser(login);
    }

    public TUser CurrentUser()
    {
      return null;
    }
    public async Task<IEnumerable<string>> GetUserRole(IUserBase user)
    {
      return await this.SDHCMemberService.GetRolesAsync(null);
    }
  }


}
