using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.NetCore.Blazor
{
  public class Program
  {
    public static string WWWRoot { get; private set; } = 
      $"/_content/{typeof(Program).Assembly.FullName.Split(',').FirstOrDefault()}";
  }
}
