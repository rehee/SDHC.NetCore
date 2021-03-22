using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ViewModels
{
  public interface IRootViewModel
  {
    IEnumerable<INavigationItem> HeaderNavigationItems { get; set; }
    IAdminSideBarViewModel SiderBar { get; set; }
    ICopyRight CopyRignt { get; set; }
  }
  public class BaseRootViewModel : IRootViewModel
  {
    public virtual IEnumerable<INavigationItem> HeaderNavigationItems { get; set; }
    public virtual IAdminSideBarViewModel SiderBar { get; set; }
    public virtual ICopyRight CopyRignt { get; set; }
  }
}
