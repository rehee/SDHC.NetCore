using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.NetCore.Blazor.Components
{
  public interface IRefresh
  {
    void Refresh();
    Task RefreshAsync();
  }
}
