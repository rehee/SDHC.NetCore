using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.NetCore.Blazor.Components
{
  public class SDHCLayoutBase : LayoutComponentBase, IAreaBased, IRefresh
  {
    public IDictionary<string, object> RouteValue
    {
      get
      {
        if (this.Body == null || this.Body.Target == null)
        {
          return null;
        }
        var routeView = this.Body.Target as RouteView;
        if (routeView == null)
        {
          return null;
        }

        return routeView.RouteData.RouteValues.ToList().ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
      }
    }
    protected override void OnInitialized()
    {
      base.OnInitialized();

      Area = GetRouteValue<string>("Area");
    }
    public virtual T GetRouteValue<T>(string key)
    {
      if (RouteValue == null)
      {
        return default(T);
      }
      var confirmedKey = RouteValue.Keys.FirstOrDefault(b => b.Equals(key, StringComparison.InvariantCultureIgnoreCase));
      if (String.IsNullOrWhiteSpace(confirmedKey))
      {
        return default(T);
      }
      var value = RouteValue[key];
      return value.MyTryConvert<T>();
    }
    public string Area { get; set; }
    public void Refresh()
    {
      this.StateHasChanged();
    }

    public Task RefreshAsync()
    {
      return Task.Run(() => this.StateHasChanged());
    }
  }
}
