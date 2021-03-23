using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ViewModels
{
  public interface IIndexViewModel<T>
  {
    bool HasPassword { get; set; }

    IList<T> Logins { get; set; }

    string PhoneNumber { get; set; }

    bool TwoFactor { get; set; }

    bool BrowserRemembered { get; set; }

    string AuthenticatorKey { get; set; }
  }
}
