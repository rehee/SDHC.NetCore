using Common.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services
{
  public interface IWWWRoot
  {
    static string WWWRoot { get; }
  }
  public interface IAdminTempleteRoot : IWWWRoot
  {
    public string GetWWWRoot();
  }
}
