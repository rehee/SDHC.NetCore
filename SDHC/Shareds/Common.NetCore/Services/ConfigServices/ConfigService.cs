using Common.Configs;
using Common.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace Common.NetCore.Services
{
  public class ConfigService : IConfigService
  {
    private readonly SystemConfig config;
    private readonly IConfiguration configuration;
    private readonly AdminAreaConfig adminArea;
    private readonly LanguageSetting languageSetting;
    private readonly IAdminTempleteRoot adminTemplete;
    public ConfigService(
      IConfiguration configuration,
      IOptions<SystemConfig> config,
      IOptions<AdminAreaConfig> adminArea,
      IOptions<LanguageSetting> languageSetting,
      IAdminTempleteRoot adminTemplete)
    {
      this.config = config.Value;
      this.adminArea = adminArea.Value;
      this.configuration = configuration;
      this.languageSetting = languageSetting.Value;
      this.adminTemplete = adminTemplete;
    }

    public SystemConfig Systems => config ?? new SystemConfig();
    public AdminAreaConfig AdminArea => adminArea ?? new AdminAreaConfig();
    public LanguageSetting Language => languageSetting ?? new LanguageSetting();
    public Func<string, string> GetSetting
    {
      get
      {
        return (key) =>
        {
          return GetTypeSetting<string>(key);
        };
      }
    }
    private Func<string> getAdminTemplete
    {
      get
      {
        return () => adminTemplete.GetWWWRoot();
      }
    }
    public string AdminTemplete => getAdminTemplete();

    public T GetTypeSetting<T>(string key)
    {
      if (String.IsNullOrWhiteSpace(key) || configuration == null)
      {
        return default;
      }
      try
      {
        return configuration.GetSection(key).Get<T>();
      }
      catch
      {
        return default;
      }

    }
  }
}
