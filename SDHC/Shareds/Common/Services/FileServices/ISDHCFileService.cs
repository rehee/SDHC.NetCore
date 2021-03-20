using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.FileServices
{
  public interface ISDHCFileService
  {
    bool SaveFile(object input, out string filePath, string extraPath = "");
    void DeleteFile(string filePath, out bool success);
    string BasePath { get; }
  }
}
