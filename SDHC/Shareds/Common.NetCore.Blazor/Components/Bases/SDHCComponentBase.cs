using Common.NetCore.Blazor.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.NetCore.Blazor.Components
{
  public class SDHCComponentBase : ComponentBase, IAreaBased, IRefresh, IIsLoading
  {
    [Parameter]
    public string Area { get; set; }
    [Parameter]
    public bool IsLoading { get; set; }
    public void Refresh()
    {
      this.StateHasChanged();
    }
    public Task RefreshAsync()
    {
      return Task.Run(() => this.StateHasChanged());
    }
    public override Task SetParametersAsync(ParameterView parameters)
    {
      return base.SetParametersAsync(parameters);
    }
    protected override void BuildRenderTree(RenderTreeBuilder builder)
    {
      base.BuildRenderTree(builder);
    }
    protected override void OnAfterRender(bool firstRender)
    {
      base.OnAfterRender(firstRender);
    }
    protected override Task OnAfterRenderAsync(bool firstRender)
    {
      return base.OnAfterRenderAsync(firstRender);
    }
    protected override void OnInitialized()
    {
      base.OnInitialized();
    }
    protected override Task OnInitializedAsync()
    {
      return base.OnInitializedAsync();
    }
    protected override void OnParametersSet()
    {
      base.OnParametersSet();
    }
    protected override Task OnParametersSetAsync()
    {
      return base.OnParametersSetAsync();
    }
    protected override bool ShouldRender()
    {
      return base.ShouldRender();
    }
  }
}
