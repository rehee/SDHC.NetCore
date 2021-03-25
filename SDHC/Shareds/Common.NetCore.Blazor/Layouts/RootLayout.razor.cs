using Common.Models.ViewModels;
using Common.NetCore.Blazor.Components;
using Common.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
namespace Common.NetCore.Blazor.Layouts
{
  public class RootLayoutBase : SDHCLayoutBase, IRootViewModel
  {
    [Inject]
    private ILayoutService layoutService { get; set; }
    [Inject]
    private IConfigService configService { get; set; }

    public IEnumerable<INavigationItem> HeaderNavigationItems { get; set; }
    public IAdminSideBarViewModel SiderBar { get; set; }
    public ICopyRight CopyRignt { get; set; }
    [Inject]
    protected IJSRuntime JsRuntime { get; set; }

    protected override async Task OnInitializedAsync()
    {
      //await JsRuntime.InvokeVoidAsync("JsFunctions.setBodyClass", "");
      var root = await layoutService.GetAdminRootViewModel(configService.AdminArea.AdminArea);

      CopyRignt = root.CopyRignt;
      HeaderNavigationItems = root.HeaderNavigationItems;
      SiderBar = root.SiderBar;
      await base.OnInitializedAsync();
    }
    //protected override void OnAfterRender(bool firstRender)
    //{
    //  base.OnAfterRender(firstRender);
    //  if (firstRender)
    //  {
    //    var root = layoutService.GetAdminRootViewModel(configService.AdminArea.AdminArea).GetAsyncValue();

    //    CopyRignt = root.CopyRignt;
    //    HeaderNavigationItems = root.HeaderNavigationItems;
    //    SiderBar = root.SiderBar;

    //  }
    //}
    //protected override async Task OnAfterRenderAsync(bool firstRender)
    //{
    //  var root = await layoutService.GetAdminRootViewModel(configService.AdminArea.AdminArea);

    //  CopyRignt = root.CopyRignt;
    //  HeaderNavigationItems = root.HeaderNavigationItems;
    //  SiderBar = root.SiderBar;
    //  await base.OnAfterRenderAsync(firstRender);
    //}


  }
}
