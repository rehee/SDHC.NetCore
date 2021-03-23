using Common.Models.ViewModels;
using Common.NetCore.Blazor.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.NetCore.Blazor.Layouts
{
  public class FooterBase : SDHCComponentBase
  {
    [Parameter]
    public ICopyRight Model { get; set; }
  }
}
