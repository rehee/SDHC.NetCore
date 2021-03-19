using System;
using System.Collections.Generic;
using System.Text;
using UserIdentity.Models.IdentityModels;

namespace UserIdentity.Models.ManageViewModels
{
  public interface IPhotoBased
  {
    string PhoneNumber { get; set; }
  }
  public interface IVerifyPhoneNumberViewModel : IPhotoBased, ICodeBased
  {
  }

  public interface IEnumCodesBased
  {
    IEnumerable<string> Codes { get; set; }
  }
}
