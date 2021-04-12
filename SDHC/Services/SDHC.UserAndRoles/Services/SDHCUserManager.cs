using Common.Cruds;
using Common.Models;
using Common.Models.ViewModels;
using Common.NetCore.Models;
using Common.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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
    private readonly ICrud crud;
    public SDHCUserManager(
      ISDHCMemberService<TUser, IdentityResult, Claim, ClaimsPrincipal, UserLoginInfo, IUserValidator<TUser>, IUserTwoFactorTokenProvider<TUser>> _SDHCMemberService,
      ISDHCSignInService<TUser, IdentityResult, Claim, SignInResult, ClaimsPrincipal, AuthenticationProperties, AuthenticationScheme, ExternalLoginInfo> _SDHCSignInService,
      ICrud crud)
    {
      this.SDHCMemberService = _SDHCMemberService;
      this.SDHCSignInService = _SDHCSignInService;
      this.crud = crud;
    }
    public Task<TUser> GetUserAsnc(string loginId)
    {
      return Task<TUser>.Run(() =>
   {
     var upper = loginId.ToUpper();
     var user = crud.Read<TUser>(b => b.NormalizedEmail == upper).FirstOrDefault();
     if (user != null)
     {
       return user;

     }
     return crud.Read<TUser>(b => b.NormalizedUserName == upper).FirstOrDefault();

   });



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
      return await this.SDHCMemberService.GetRolesAsync(user as TUser);
    }

    public async Task<bool> Login(ILoginViewModel model)
    {
      var user = await GetUserAsnc(model.Email);
      if (user == null)
        return false;

      await this.SDHCSignInService.SignInAsync(user, true);
      //var result = await this.SDHCSignInService.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, false);
      //if (result)
      //{
      //  await this.
      //}
      //return result.Succeeded;
      return true;
    }
    public async Task LogOff()
    {
      await this.SDHCSignInService.SignOutAsync();
    }
  }


}
