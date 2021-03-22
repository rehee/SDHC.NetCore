using Common.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.LanguageServices
{
  public interface ISDHCLanguageService
  {
    string LanguageKey { get; }
    Func<int> GetLang { get; }
    Action<int> SetLang { get; }
    IEnumerable<LanguageSetting> LangConfigs { get; }
  }
}
