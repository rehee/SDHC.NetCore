using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.SecretServices
{
  public interface ISecretService
  {
    string Encrypt(string inputString, bool base32 = true);
    string Decrypt(string inputString, bool base32 = true);
  }
}
