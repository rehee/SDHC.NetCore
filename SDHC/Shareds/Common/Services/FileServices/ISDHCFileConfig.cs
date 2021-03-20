using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.FileServices
{
  public interface ISDHCFileConfig
  {
    string BasePath { get; }
    string FileUploadPath { get; set; }
    bool AllowedInputTypes(Type type);
    IDictionary<Type, SDHCSaveAble> AllowedInputTypeMap { get; }
  }
}
