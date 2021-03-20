using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ViewModels
{
  public class ItemKeyAndName
  {
    public string Key { get; set; } = "";
    public string DisplayName { get; set; } = "";
    public ItemKeyAndName(string key, string displayName = null)
    {
      Key = key;
      if (string.IsNullOrEmpty(displayName))
      {
        DisplayName = key;
      }
      else
      {
        DisplayName = displayName;
      }
    }
  }
}
