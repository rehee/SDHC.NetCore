using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ViewModels
{
  public interface ICopyRight
  {
    string CopyRightTime { get; set; }
    string DisplayName { get; set; }
    string Text { get; set; }
    bool ShowVersion { get; set; }
    string Version { get; set; }
    string Url { get; set; }
  }
  public class BasicCopyRight : ICopyRight
  {
    public string CopyRightTime { get; set; }
    public string DisplayName { get; set; }
    public string Text { get; set; }
    public bool ShowVersion { get; set; }
    public string Version { get; set; }
    public string Url { get; set; }
  }
}
