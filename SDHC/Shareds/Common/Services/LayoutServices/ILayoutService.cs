using Common.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
  public interface ILayoutService
  {
    Task<IRootViewModel> GetAdminRootViewModel(string area);
  }
}
