using System;
using System.Collections.Generic;
using System.Text;

namespace Common.NetCore.Models.ViewModels
{
  public class RoleNameAndUser
  {
    public string Id { get; set; }
    public string RoleName { get; set; }
    public string RoleDisplayName { get; set; }
    public int Users { get; set; }
  }
}
