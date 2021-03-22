using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ViewModels
{
  public interface IAdminSideBarViewModel
  {
    IEnumerable<INavigationItem> NavItems { get; set; }
    IBrandLogo Logo { get; set; }
    IUserBrief User { get; set; }
  }
  public class BaseAdminSideBarViewModel : IAdminSideBarViewModel
  {
    public virtual IEnumerable<INavigationItem> NavItems { get; set; }
    public virtual IBrandLogo Logo { get; set; }
    public virtual IUserBrief User { get; set; }
  }
}
