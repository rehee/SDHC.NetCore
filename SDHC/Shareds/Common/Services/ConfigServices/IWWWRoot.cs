using Common.Configs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services
{
  public interface IWWWRoot
  {
    string WWWRoot { get; }
  }
  public interface IAdminTempleteRoot: IWWWRoot
  {
  }
}
