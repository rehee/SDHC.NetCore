using Common.Models.ViewModels;
using Common.NetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.NetCore.Blazor.Layouts
{
  public class RootLayoutBase : SDHCLayoutBase, IRootViewModel
  {
    public IEnumerable<INavigationItem> HeaderNavigationItems { get; set; }
    public IAdminSideBarViewModel SiderBar { get; set; }
    public ICopyRight CopyRignt { get; set; }
  }
}
