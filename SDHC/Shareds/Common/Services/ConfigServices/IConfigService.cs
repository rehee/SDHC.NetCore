using Common.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.ConfigServices
{
  public interface IConfigService
  {
    SystemConfig Systems { get; set; }
    Func<string, string> GetSetting { get; set; }
  }
}
