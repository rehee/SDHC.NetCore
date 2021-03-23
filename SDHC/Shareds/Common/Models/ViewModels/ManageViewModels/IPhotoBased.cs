using System.Collections.Generic;

namespace Common.Models.ViewModels
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
