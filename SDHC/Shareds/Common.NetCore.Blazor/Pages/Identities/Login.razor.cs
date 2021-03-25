using Common.NetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Models.ViewModels;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using Common.Services;
using Common.Models;
using System.Threading.Tasks;
using Common.NetCore;
namespace Common.NetCore.Blazor.Pages.Identities
{
  public class LoginBase : SDHCComponentBase
  {
    protected LoginViewModel Model { get; set; } = new LoginViewModel();

    [Inject]
    public Common.Services.ISDHCUserManager userManager { get; set; }
    protected async Task Onsubmit(EditContext editContext)
    {
      var v = editContext.Validate();
      var value = await userManager.Login(Model);
    }
  }
}
