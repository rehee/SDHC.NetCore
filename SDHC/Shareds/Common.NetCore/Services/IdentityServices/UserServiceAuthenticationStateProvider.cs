using Common.Models.ViewModels;
using Common.NetCore.Models;
using Common.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.NetCore.Services
{
  public interface IUserServiceStateProvider : IUserService
  {

  }
  public class UserServiceAuthenticationStateProvider : IUserServiceStateProvider
  {
    private readonly AuthenticationStateProvider access;
    private readonly ISDHCUserManager<SDHCUser> userManager;

    public UserServiceAuthenticationStateProvider(AuthenticationStateProvider access, ISDHCUserManager<SDHCUser> userManager)
    {
      this.access = access;
      this.userManager = userManager;
    }
    public async Task<IUserSummaryView> GetCurrentUser()
    {
      var user = (await access.GetAuthenticationStateAsync()).User?.Identity;

      if (user == null || !user.IsAuthenticated)
      {
        return null;
      }
      
      var baseUser = await userManager.GetUserAsnc(user.Name);
      if (baseUser == null)
      {
        return null;
      }
      var roles = await userManager.GetUserRole(baseUser);
      return new BaseUserSummaryView(baseUser.UserName, baseUser.Email, baseUser.Avatar, roles ?? null);
    }
  }
}
