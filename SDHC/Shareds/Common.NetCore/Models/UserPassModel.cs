using Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.NetCore.Models
{
  public class UserPassModel : IdentityUser, IPassModel
  {
    public string FullType { get; set; }
    public string ThisAssembly { get; set; }
    public List<ContentProperty> Properties { get; set; } = new List<ContentProperty>();
  }
}
