using Common.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services
{
  public interface IConfigService
  {
    SystemConfig Systems { get; }
    AdminAreaConfig AdminArea { get; }
    LanguageSetting Language { get; }
    Func<string, string> GetSetting { get; }
    T GetTypeSetting<T>(string key);
  }
}
