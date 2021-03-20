using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.NetCore.Models.ViewModels
{
  public class UserCreateView : IPassModel
  {
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string FullType { get; set; }
    public string ThisAssembly { get; set; }
    public List<ContentProperty> Properties { get; set; } = new List<ContentProperty>();
    public IEnumerable<string> SelectedRoles { get; set; } = new List<string>();
    public IEnumerable<RoleNameAndUser> Roles { get; set; }
  }
}
