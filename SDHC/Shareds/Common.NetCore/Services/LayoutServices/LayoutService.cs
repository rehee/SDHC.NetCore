using Common.Models.ViewModels;
using Common.Services;
using System.Collections.Generic;
using System.Linq;

namespace Common.NetCore.Services
{
  public class LayoutService : ILayoutService
  {
    private readonly IConfigService config;
    private readonly IUserService userService;

    public LayoutService(IConfigService config, IUserService userService)
    {
      this.config = config;
      this.userService = userService;
    }
    private IBrandLogo getAdminLogo(string area)
    {
      return new BaseBrandLogo()
      {
        Url = $"/{area}config.AdminArea.LogoUrl",
        Image = config.AdminArea.LogoImage,
        DisplayText = config.AdminArea.LogoDisplayText,
        ALT = config.AdminArea.LogoALT,
      };
    }
    private IUserBrief getUserBrief()
    {
      var currentUser = userService.GetCurrentUser();
      return new BaseUserBrief()
      {
        Alt = currentUser?.UserName ?? "",
        Avatar = currentUser?.Avata ?? "/_content/Common.NetCore.Blazor/img/user2-160x160.jpg",
        DisplayName = currentUser?.UserName
      };
    }
    private IEnumerable<INavigationItem> getLeftNavigation()
    {
      if (config.AdminArea.NavigationItem.Any())
      {
        return config.AdminArea.NavigationItem.ToArray();
      }
      var list = new List<INavigationItem>(){
        new BaseNavigationItem()
        {
          DisplayName = "Home",
          Url = $"/{config.AdminArea.AdminArea}",
          Icon = "fa-tachometer-alt",
          ActiveFullPath = true,
        }
      };
      list.Add(new BaseNavigationItem()
      {
        DisplayName = "Content",
        Icon = "far fa-file",
        ActiveFullPath = false,
        IsNavHeader = true,
      });
      var langs = config.Language.LanguageConfigs;
      if (config.Language.LanguageConfigs.Any())
      {
        foreach (var lang in config.Language.LanguageConfigs)
        {
          list.Add(new BaseNavigationItem()
          {
            DisplayName = $"{lang.DisplayName}{(lang.IsDefault ? " (Default) " : "")}",
            Url = $"/{config.AdminArea.AdminArea}/Contents/{lang.Value}",
            Icon = lang.Icon,
            ActiveFullPath = false,
          });
        }
      }
      else
      {
        list.Add(new BaseNavigationItem()
        {
          DisplayName = "Index",
          Url = $"/{config.AdminArea.AdminArea}/Contents/0",
          Icon = "fa-tachometer-alt",
          ActiveFullPath = false,
        });
      }

      return list.ToArray();
    }
    private IEnumerable<INavigationItem> getMenu()
    {
      var result = new List<INavigationItem>();
      if (config.AdminArea.Menu.Any())
      {
        return config.AdminArea.Menu.ToArray();
      }
      else
      {
        result.Add(new BaseNavigationItem()
        {
          DisplayName = "Home",
          Url = $"/{config.AdminArea.AdminArea}",
        });
      }
      return result;
    }
    public IRootViewModel GetAdminRootViewModel(string area)
    {

      return new BaseRootViewModel()
      {
        HeaderNavigationItems = new List<INavigationItem>(){
        new BaseNavigationItem()
        {
          DisplayName = "Home",
          Url = "/Admin",
          Icon = "fa-tachometer-alt",
          ActiveFullPath = true,
        },
        new BaseNavigationItem()
        {
          DisplayName = "Login",
          Url = "/Admin/Login",
          Icon = "fa-tachometer-alt",
          ActiveFullPath = true,
        }
      },
        SiderBar = new BaseAdminSideBarViewModel()
        {
          NavItems = getLeftNavigation(),
          Logo = getAdminLogo(area),
          User = getUserBrief(),
        }
      };
    }
  }
}
