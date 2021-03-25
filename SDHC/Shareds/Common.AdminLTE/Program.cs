using Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.AdminLTE
{
  public class Program : IAdminTempleteRoot
  {
    public string WWWRoot { get; private set; } =
      $"/_content/{typeof(Program).Assembly.FullName.Split(',').FirstOrDefault()}";
  }
}
