using Common.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services
{
  public interface IUserService
  {
    IUserSummaryView GetCurrentUser();
  }
}
