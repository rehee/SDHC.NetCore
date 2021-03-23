using Common.Models.ViewModels;
using Common.NetCore.Blazor.Components;
using Common.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Collections.Generic;

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
    
    protected override void OnInitialized()
    {
      JsRuntime.InvokeVoidAsync("JsFunctions.setBodyClass", "");
      base.OnInitialized();
      var root = layoutService.GetAdminRootViewModel(configService.AdminArea.AdminArea);
      CopyRignt = root.CopyRignt;
      HeaderNavigationItems = root.HeaderNavigationItems;
      SiderBar = root.SiderBar;
    }

  }
}
