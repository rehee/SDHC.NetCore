using Common.Models.ViewModels;
using Common.NetCore.Models;
using Common.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.NetCore.Services
{
  public class UserService : IUserService
  {
    private readonly IHttpContextAccessor access;
    private readonly ISDHCUserManager<SDHCUser> userManager;

    public UserService(IHttpContextAccessor access, ISDHCUserManager<SDHCUser> userManager)
    {
      this.access = access;
      this.userManager = userManager;
    }
    public IUserSummaryView GetCurrentUser()
    {
      var user = access?.HttpContext?.User?.Identity ?? null;
      if (user == null || !user.IsAuthenticated)
      {
        return null;
      }
      var baseUser = userManager.GetUserAsnc(user.Name).GetAsyncValue();
      if (baseUser == null)
      {
        return null;
      }
      var roles = userManager.GetUserRole(baseUser).GetAsyncValue();
      return new BaseUserSummaryView(baseUser.UserName, baseUser.Email, baseUser.Avatar, roles ?? null);
    }
  }
}
