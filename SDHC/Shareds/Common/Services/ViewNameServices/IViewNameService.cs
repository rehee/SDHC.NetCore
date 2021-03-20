using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.ViewNameServices
{
  public interface IViewNameService
  {
    string ViewName(ILanguage model);
    string ViewName(ContentPostModel model);
    string ViewName(ContentPostViewModal model);
    string ViewName(ContentPropertyIndex model);
  }
}
