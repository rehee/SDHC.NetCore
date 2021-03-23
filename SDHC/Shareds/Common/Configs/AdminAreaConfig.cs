using Common.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Configs
{
  public class AdminAreaConfig
  {
    public string AdminArea { get; set; } = "Admin";
    public string LogoUrl { get; set; } = $"/";
    public string LogoImage { get; set; } = $"/_content/Common.NetCore.Blazor/img/AdminLTELogo.png";
    public string LogoDisplayText { get; set; } = $"SDHC Admin";
    public string LogoALT { get; set; } = $"SDHC";

    public List<INavigationItem> NavigationItem { get; set; } = Enumerable.Empty<INavigationItem>().ToList();
    public List<INavigationItem> Menu { get; set; } = Enumerable.Empty<INavigationItem>().ToList();
  }
}
