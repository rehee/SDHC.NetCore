using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ViewModels
{
  public interface IManageLoginsViewModel<T, K>
  {
    IList<T> CurrentLogins { get; set; }

    IList<K> OtherLogins { get; set; }
  }
}
