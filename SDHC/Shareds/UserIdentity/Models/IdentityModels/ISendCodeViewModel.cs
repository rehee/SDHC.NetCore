using System;
using System.Collections.Generic;
using System.Text;

namespace UserIdentity.Models.IdentityModels
{
  public interface IConfigProvider<T>
  {
    string SelectedProvider { get; set; }

    ICollection<T> Providers { get; set; }
  }
  public interface ISendCodeViewModel<T> : IConfigProvider<T>
  {

    string ReturnUrl { get; set; }

    bool RememberMe { get; set; }
  }
}
