using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Models.ViewModels
{
  public interface INavigationItem
  {
    bool IsNavHeader { get; set; }
    string Url { get; set; }
    string Icon { get; set; }
    bool ActiveFullPath { get; set; }
    string DisplayName { get; set; }
    bool HasSubNavigationItem { get; }
    IEnumerable<INavigationItem> SubNavigationItem { get; set; }
    bool HasBadge { get; }
    string Badge { get; set; }
    string BadgeValue { get; set; }
    bool IsActive { get; set; }
  }

  public class BaseNavigationItem : INavigationItem
  {
    public virtual bool IsNavHeader { get; set; } = false;
    public virtual string Url { get; set; } = "";
    public virtual string Icon { get; set; } = "";
    public virtual string DisplayName { get; set; } = "";

    public virtual bool HasSubNavigationItem => SubNavigationItem != null && SubNavigationItem.Any();

    public virtual IEnumerable<INavigationItem> SubNavigationItem { get; set; }

    public virtual bool HasBadge => !String.IsNullOrEmpty(Badge) || !String.IsNullOrEmpty(BadgeValue);

    public virtual bool ActiveFullPath { get; set; } = false;
    public virtual string Badge { get; set; } = "";
    public virtual string BadgeValue { get; set; } = "";
    public virtual bool IsActive { get; set; }
  }
}
