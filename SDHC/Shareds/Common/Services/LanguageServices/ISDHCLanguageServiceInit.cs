using SDHC.Common.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.LanguageServices
{
  public interface ISDHCLanguageServiceInit
  {
    LanguageConfig config { get; }
    string LanguageKey { get; }
    Func<string, object> getSession { get; }
    Action<string, object> setSession { get; }
  }
}
