using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.NetCore.Models.ViewModels
{
  public class SharedLinkView
  {
    public string Value { get; }
    public string ReferenceName { get; }
    public IEnumerable<ISharedLink> Models { get; set; }
    public SharedLinkView(string value, string listName)
    {
      Value = value;
      ReferenceName = listName;
    }
    public SharedLinkView(IEnumerable<ISharedLink> models, string listName)
    {
      Models = models;
      ReferenceName = listName;
    }
    public string ListName => $"List_{ReferenceName}";
    public string AppName => $"App_{ReferenceName}";

  }
}
