using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Configs
{
  public class LanguageSetting
  {
    public List<LanguageConfig> LanguageConfigs { get; set; } = Enumerable.Empty<LanguageConfig>().ToList();
    public string SessionKey { get; set; }
  }
  public class LanguageConfig
  {
    public int Key { get; set; }
    public string Value { get; set; }
    public string DisplayName { get; set; }
    public bool IsDefault { get; set; }
    public string Icon { get; set; } = "far fa-file";
  }
}
