using Common.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.NetCore.Services
{
  public class SessionService : ISessionService
  {
    IHttpContextAccessor acce { get; set; }
    ISession session => thisSession();

    Func<ISession> thisSession { get; }

    public SessionService(IHttpContextAccessor acce)
    {
      this.acce = acce;
      thisSession = () => acce != null && acce.HttpContext != null && acce.HttpContext.Session != null ? acce.HttpContext.Session : null;
    }
    public Func<string, string> GetString => (key) =>
    {
      if (session == null)
      {
        return null;
      }
      return session.GetString(key);
    };
    public Func<string, int?> GetInt => (key) =>
    {
      if (session == null)
      {
        return null;
      }
      return session.GetInt32(key);
    };

    public Action<string, object> SetSession => (key, value) =>
    {
      if (session == null)
      {
        return;
      }
      session.SetString(key, value.MyTryConvert<string>());
    };
    public Action<string, string> SetString => (key, value) =>
    {
      if (session == null)
      {
        return;
      }
      session.SetString(key, value);
    };
    public Action<string, int> SetInt => (key, value) =>
    {
      if (session == null)
      {
        return;
      }
      session.SetInt32(key, value);
    };
  }
}
