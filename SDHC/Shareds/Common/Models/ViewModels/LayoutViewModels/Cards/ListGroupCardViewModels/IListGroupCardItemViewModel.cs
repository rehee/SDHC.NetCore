using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Models.ViewModels
{
  public interface IListGroupCardItemViewModel
  {
    string Icon { get; set; }
    bool ShowIcon { get; }
    string DisplayName { get; set; }
    string Url { get; set; }
    bool ShowBadge { get; }
    IEnumerable<IListGroupCardItemBadgeViewModel> Badges { get; set; }
  }
  public class BaseListGroupCardItemViewModel : IListGroupCardItemViewModel
  {
    public virtual string Icon { get; set; }

    public virtual bool ShowIcon => !String.IsNullOrEmpty(Icon);

    public virtual string DisplayName { get; set; }
    public virtual string Url { get; set; }

    public virtual bool ShowBadge => Badges != null && Badges.Any();

    public virtual IEnumerable<IListGroupCardItemBadgeViewModel> Badges { get; set; }
  }
}
