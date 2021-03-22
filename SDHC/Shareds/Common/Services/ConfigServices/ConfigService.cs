using Common.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.ConfigServices
{
  public class ConfigService : IConfigService
  {
    public SystemConfig Systems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Func<string, string> GetSetting { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
  }
}
