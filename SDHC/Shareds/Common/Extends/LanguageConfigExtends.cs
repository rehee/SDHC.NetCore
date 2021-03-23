using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Configs
{
  public static class LanguageConfigExtends
  {

    public static LanguageConfig DefaultLanguage(this LanguageSetting setting)
    {
      if (setting == null || setting.LanguageConfigs == null)
        return null;
      return setting.LanguageConfigs.FirstOrDefault(b => b.IsDefault);
    }
    public static LanguageConfig GetLanguageConfig(this LanguageSetting setting, int? input)
    {
      if (!input.HasValue || setting.LanguageConfigs == null)
        goto GetDefaultKey;
      return setting.LanguageConfigs.FirstOrDefault(b => b.Key == input.Value);

      GetDefaultKey:
      return setting.DefaultLanguage();
    }
  }
}
