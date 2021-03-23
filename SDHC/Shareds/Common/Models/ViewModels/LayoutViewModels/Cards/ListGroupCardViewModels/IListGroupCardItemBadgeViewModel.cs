using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ViewModels
{
  public interface IListGroupCardItemBadgeViewModel
  {
    bool IsLink { get; }
    string Url { get; set; }
    string Icon { get; set; }
    string Value { get; set; }
  }
  public class BaseListGroupCardItemBadgeViewModel : IListGroupCardItemBadgeViewModel
  {
    public virtual bool IsLink => !String.IsNullOrWhiteSpace(Url);
    public virtual string Url { get; set; }
    public virtual string Icon { get; set; }
    public virtual string Value { get; set; }
  }
}
