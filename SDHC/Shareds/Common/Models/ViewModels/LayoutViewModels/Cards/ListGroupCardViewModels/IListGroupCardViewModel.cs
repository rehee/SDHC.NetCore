using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ViewModels
{
  public interface IListGroupCardViewModel
  {
    IEnumerable<IListGroupCardItemViewModel> Items { get; set; }
    IListGroupCardItemViewModel HeaderItem { get; set; }
    bool ShowHeaderButton { get; set; }
    IListGroupCardItemViewModel HeaderButton { get; set; }
    bool IsLoading { get; set; }
    string CurrentUrl { get; set; }
  }

  public class BaseListGroupCardViewModel: IListGroupCardViewModel
  {
    public virtual IEnumerable<IListGroupCardItemViewModel> Items { get; set; }
    public virtual IListGroupCardItemViewModel HeaderItem { get; set; }
    public virtual bool ShowHeaderButton { get; set; }
    public virtual IListGroupCardItemViewModel HeaderButton { get; set; }
    public virtual bool IsLoading { get; set; }
    public string CurrentUrl { get; set; }
  }

}
