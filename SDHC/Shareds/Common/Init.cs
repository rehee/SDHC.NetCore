using Common.Models;
using Common.Models.ViewModels;
using Common.Services.ModelServices;
using Common.Services.SecretServices;
using Common.Configs;
using Common.Cruds;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
  public static class Init
  {
    public static void Setup<BaseIContentType>(
      Func<ICrud> getCrud, Func<ISecretService> getSecretService,
      Func<string> getContentViewPath, Func<string> getContentPageUrl,
      SaveFile getSaveFile, DeleteFile getDeleteFile,
      Func<SystemConfig> config, Func<IModelService> modelService)
      where BaseIContentType : class, IContentModel
    {
      ContentPostViewModel.Init(getContentViewPath, getContentPageUrl);
      MyReflectExtends.Init(getCrud);
      AbstractBaseContent.Init<BaseIContentType>(getCrud);
      PassModeConvert.Init(getSaveFile, getDeleteFile, getCrud, getSecretService);
      TypeExtends.Init<BaseIContentType>(config, modelService);
    }
  }
}
