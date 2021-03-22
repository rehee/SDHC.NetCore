using Common.Configs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Common.Services.SecretServices
{
  public class SecretService : ISecretService
  {
    private byte[] deKey { get; }
    private byte[] deIV { get; }
    public SecretService(SystemConfig config)
    {
      deKey = Encoding.Default.GetBytes(config.SecretdeKey);
      deIV = Encoding.Default.GetBytes(config.SecretdeIV);
    }

    public string Encrypt(string inputString, bool base32 = true)
    {
      MemoryStream ms = new MemoryStream();
      DESCryptoServiceProvider key = new DESCryptoServiceProvider();
      //SymmetricAlgorithm key = SymmetricAlgorithm.Create();

      CryptoStream encStream = new CryptoStream(ms, key.CreateEncryptor(deKey, deIV), CryptoStreamMode.Write);
      StreamWriter sw = new StreamWriter(encStream);

      sw.WriteLine(inputString);
      sw.Close();
      encStream.Close();

      byte[] buffer = ms.ToArray();
      ms.Close();
      var result = Convert.ToBase64String(buffer);

      if (base32)
      {
        return Base32.Encode(buffer);
      }
      return result;
    }

    public string Decrypt(string cypherText, bool base32 = true)
    {

      string text;
      if (base32)
        text = Convert.ToBase64String(Base32.Decode(cypherText));
      else
        text = cypherText;
      MemoryStream ms = new MemoryStream(Convert.FromBase64String(text));
      DESCryptoServiceProvider key = new DESCryptoServiceProvider();
      //SymmetricAlgorithm key = SymmetricAlgorithm.Create();

      CryptoStream encStream = new CryptoStream(ms, key.CreateDecryptor(deKey, deIV), CryptoStreamMode.Read);
      StreamReader sr = new StreamReader(encStream);

      string val = sr.ReadLine();

      sr.Close();
      encStream.Close();
      ms.Close();
      return val;
    }
  }
}
