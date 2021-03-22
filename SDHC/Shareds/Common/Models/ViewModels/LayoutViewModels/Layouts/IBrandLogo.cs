using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ViewModels
{
  public interface IBrandLogo
  {
    string Url { get; set; }
    string Image { get; set; }
    string ALT { get; set; }
    string DisplayText { get; set; }
  }
  public class BaseBrandLogo: IBrandLogo
  {
    public string Url { get; set; }
    public string Image { get; set; }
    public string ALT { get; set; }
    public string DisplayText { get; set; }
  }
}
