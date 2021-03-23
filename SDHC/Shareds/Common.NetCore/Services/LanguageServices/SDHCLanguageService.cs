using Common.Configs;
using Common.Services;
using Microsoft.Extensions.Options;
using System;

namespace Common.NetCore.Services
{
  public class SDHCLanguageService : ISDHCLanguageService
  {
    private readonly ISessionService sessionService;

    private readonly LanguageSetting input;


    public SDHCLanguageService(IOptions<LanguageSetting> input, ISessionService sessionService)
    {
      this.input = input.Value;
      this.sessionService = sessionService;
    }
    public Func<int?> GetLang
    {
      get
      {
        return () => sessionService.GetInt(input.SessionKey);
      }
    }

    public Action<int?> SetLang
    {
      get
      {
        return (b) =>
        {
          if (b.HasValue)
          {
            sessionService.SetInt(input.SessionKey, b.Value);
          }
          else
          {
            sessionService.SetSession(input.SessionKey, null);
          }

        };
      }
    }

    public LanguageSetting LangConfigs => input;
  }
}
