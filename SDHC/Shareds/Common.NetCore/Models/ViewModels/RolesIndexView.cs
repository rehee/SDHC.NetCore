using System;
using System.Collections.Generic;
using System.Text;

namespace Common.NetCore.Models.ViewModels
{
  public class RolesIndexView
  {
    public IEnumerable<RoleNameAndUser> RoleAndUsers { get; set; }
    public IEnumerable<SDHCUser> Users { get; set; }

  }
}
