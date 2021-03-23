using Common.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services
{
  public interface ISDHCLanguageService
  {
    Func<int?> GetLang { get; }
    Action<int?> SetLang { get; }
    LanguageSetting LangConfigs { get; }
  }
}
