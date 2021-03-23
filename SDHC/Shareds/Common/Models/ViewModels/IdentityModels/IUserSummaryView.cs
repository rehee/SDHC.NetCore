using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Models.ViewModels
{
  public interface IUserSummaryView
  {
    string UserName { get; }
    string Email { get; }
    string Avata { get; }
    IEnumerable<string> Roles { get; }
  }
  public class BaseUserSummaryView : IUserSummaryView
  {
    public BaseUserSummaryView(string userName = "", string email = "", string avata = "", IEnumerable<string> roles = null)
    {
      this.UserName = userName;
      this.Email = email;
      this.Avata = avata;
      this.Roles = roles ?? Enumerable.Empty<string>();
    }
    public string UserName { get; }
    public string Email { get; }
    public string Avata { get; }
    public IEnumerable<string> Roles { get; }
  }
}
