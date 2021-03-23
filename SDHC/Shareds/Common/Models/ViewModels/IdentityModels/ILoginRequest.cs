using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ViewModels
{
  public interface ILoginRequest
  {
    string Username { get; set; }
    string Password { get; set; }
  }

}
