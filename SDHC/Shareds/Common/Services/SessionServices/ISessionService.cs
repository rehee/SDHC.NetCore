using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services
{
  public interface ISessionService
  {
    Func<string, string> GetString { get; }
    Func<string, int?> GetInt { get; }
    Action<string, object> SetSession { get; }
    Action<string, string> SetString { get; }
    Action<string, int> SetInt { get; }
  }
}
