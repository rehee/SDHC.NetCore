using System;
using System.Collections.Generic;
using System.Text;

namespace UserIdentity.Models.ManageViewModels
{
  public interface IManageLoginsViewModel<T, K>
  {
    IList<T> CurrentLogins { get; set; }

    IList<K> OtherLogins { get; set; }
  }
}
