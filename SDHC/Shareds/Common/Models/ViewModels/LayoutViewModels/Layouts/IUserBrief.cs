using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ViewModels
{
  public interface IUserBrief
  {
    string Avatar { get; set; }
    string Url { get; set; }
    string Alt { get; set; }
    string DisplayName { get; set; }
  }
  public class BaseUserBrief : IUserBrief
  {
    public virtual string Avatar { get; set; }
    public virtual string Url { get; set; }
    public virtual string Alt { get; set; }
    public virtual string DisplayName { get; set; }
  }
}
