using Microsoft.AspNetCore.Authorization;
using Common.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.NetCore.Attributes
{
  public class AdminAttribute : AuthorizeAttribute
  {
    private static SystemConfig systemConfig { get; } = config();
    private static Func<SystemConfig> config { get; set; } = () => null;
    private static Func<string, string> getSetting { get; set; } = (key) => String.Empty;
    public static void Init(Func<SystemConfig> config, Func<string, string> getSetting)
    {
      AdminAttribute.config = config;
      AdminAttribute.getSetting = getSetting;
    }
    public AdminAttribute(string adminRole)
    {
      if (!systemConfig.AdminFree)
      {
        var adminRoleForSetting = getSetting($"Roles:{adminRole}");
        var DefaultadminRole = systemConfig.AdminRole;
        var supperUser = systemConfig.SuperUserRole;
        var roleLists = new List<string>();
        if (!String.IsNullOrEmpty(adminRoleForSetting))
        {
          roleLists.AddRange(adminRoleForSetting.Split(',')
            .Select(b => b.Trim())
            .Where(b => !String.IsNullOrEmpty(b)));
        }
        if (!String.IsNullOrEmpty(DefaultadminRole))
        {
          roleLists.AddRange(DefaultadminRole.Split(',')
            .Select(b => b.Trim())
            .Where(b => !String.IsNullOrEmpty(b)));
        }
        if (!String.IsNullOrEmpty(supperUser))
        {
          roleLists.AddRange(supperUser.Split(',')
            .Select(b => b.Trim())
            .Where(b => !String.IsNullOrEmpty(b)));
        }
        var uniqRoles = roleLists.GroupBy(b => b).Select(b => b.Key);
        this.Roles = String.Join(",", uniqRoles);
      }
      if (!String.IsNullOrEmpty(systemConfig.AdminPolicy))
      {
        this.Policy = systemConfig.AdminPolicy;
      }
    }
  }
}
