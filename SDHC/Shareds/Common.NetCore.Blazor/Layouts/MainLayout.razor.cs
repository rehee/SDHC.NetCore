using Common.Models.ViewModels;
using Common.NetCore.Blazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.NetCore.Blazor.Layouts
{
  public class MainLayoutBase : SDHCLayoutBase
  {
    
    [CascadingParameter]
    public RootLayout Root { get; set; }

    public IEnumerable<INavigationItem> BreadCrumb { get; set; }
    public string Title { get; set; }

    protected override void OnInitialized()
    {
      base.OnInitialized();
      var area = Area;
      
      
    }
  }
}
