using Common.Models.ViewModels;
using Common.NetCore.Blazor.Components;
using Common.NetCore.Blazor.Layouts;
using Common.Services.ContentServices;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace SDHC.Areas.Admin.Pages
{
  public class IndexPage : SDHCComponentBase
  {
    [Inject]
    private IContentService service { get; set; }


    [Parameter]
    public long? id { get; set; }
    private long? thisId { get; set; }
    private long? parentId { get; set; }

    [CascadingParameter]
    protected ContentLayout Layout { get; set; }

    protected override void OnInitialized()
    {

      base.OnInitialized();
      var root = new BaseRootViewModel()
      {
        HeaderNavigationItems = new List<INavigationItem>(){
        new BaseNavigationItem()
        {
          DisplayName = "Home",
          Url = "/Admin",
          Icon = "fa-tachometer-alt",
          ActiveFullPath = true,
        }
      },
        SiderBar = new BaseAdminSideBarViewModel()
        {
          NavItems = new List<INavigationItem>(){
        new BaseNavigationItem()
        {
          DisplayName = "DashBoard",
          Url = "/Admin",
          Icon = "fa-tachometer-alt",
          ActiveFullPath = true,
        },
        new BaseNavigationItem()
        {
          DisplayName = "Page1",
          Url = "/Admin/Page/1",
          Icon = "fa-tachometer-alt",
          ActiveFullPath = true,
        },
        new BaseNavigationItem()
        {
          DisplayName = "Page2",
          Url = "/Admin/Page/2",
          Icon = "fa-tachometer-alt",
          ActiveFullPath = true,
        }
      },
          Logo = new BaseBrandLogo()
          {
            Url = "/Admin",
            DisplayText = "SDHC",
            Image = "/admin/dist/img/AdminLTELogo.png"
          },
          User = new BaseUserBrief()
          {
            Alt = "User Image",
            Avatar = "/Admin/dist/img/user2-160x160.jpg",
            DisplayName = "Alexander Pierce"
          }
        }
      };
      Layout.MainLayout.Root.CopyRignt = root.CopyRignt;
      Layout.MainLayout.Root.HeaderNavigationItems = root.HeaderNavigationItems;
      Layout.MainLayout.Root.SiderBar = root.SiderBar;
      Layout.MainLayout.Root.Refresh();
      thisId = id;
      getParentId();
    }

    private void getParentId()
    {
      long? parentId = null;
      if (thisId == 0)
      {
        parentId = null;
      }
      else
      {
        var page = service.GetContent(thisId);
        if (page == null)
        {
          parentId = null;
        }
        else
        {
          parentId = (page.ParentId.HasValue && page.ParentId.Value > 0) ? page.ParentId : null;
        }
      }
      if (parentId != this.parentId)
      {
        this.parentId = parentId;
        Layout.ParentId = this.parentId;
        Layout.RefreshList();
      }

    }

    protected override void OnParametersSet()
    {
      if (thisId != id)
      {
        thisId = id;

        getParentId();
      }
    }
  }
}
