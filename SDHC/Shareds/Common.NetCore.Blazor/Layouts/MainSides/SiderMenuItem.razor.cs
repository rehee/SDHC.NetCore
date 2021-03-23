using Common.Models.ViewModels;
using Common.NetCore.Blazor.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.NetCore.Blazor.Layouts
{
  public class SiderMenuItemBase : SDHCComponentBase
  {
    [Inject]
    private NavigationManager NavigationManager { get; set; }

    [Parameter]
    public INavigationItem Item { get; set; }

    protected bool isChildrenActive { get; set; } = false;

    protected void itemIsActived()
    {
      isChildrenActive = true;
      StateHasChanged();
    }

    [Parameter]
    public Action ItemIsActived { get; set; }

    protected override void OnInitialized()
    {
      if (ItemIsActived == null)
      {
        return;
      }
      var activeUrl = $"{NavigationManager.BaseUri.Substring(0, NavigationManager.BaseUri.Length - 1)}{Item.Url}";
      if (Item.ActiveFullPath)
      {
        if (NavigationManager.Uri.Equals(activeUrl, StringComparison.InvariantCultureIgnoreCase))
        {
          ItemIsActived();
        }
      }
      else
      {
        var length = NavigationManager.Uri.IndexOf(activeUrl, StringComparison.InvariantCultureIgnoreCase);
        if (length == 0)
        {
          ItemIsActived();
        }
      }
    }
  }
}
