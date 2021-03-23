using Common.Models.ViewModels;
using Common.NetCore.Blazor.Components;
using Common.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System.Threading.Tasks;

namespace Common.NetCore.Blazor.Layouts
{
  public class ContentLayoutBase : SDHCLayoutBase
  {
    [Inject]
    IContentListService ListService { get; set; }
    [Inject]
    NavigationManager nav { get; set; }

    [CascadingParameter]
    public MainLayout MainLayout { get; set; }
    public string url { get; set; }

    public long? ParentId { get; set; }


    public IListGroupCardViewModel ContentList { get; set; } = new BaseListGroupCardViewModel();



    
    public async Task RefreshList()
    {
      ContentList.IsLoading = true;
      StateHasChanged();
      try
      {
        ContentList = await ListService.GetContentsByParent(ParentId);

      }
      finally
      {
        await Task.Delay(250);
        ContentList.IsLoading = false;
        StateHasChanged();
      }
    }
    protected override void OnInitialized()
    {
      base.OnInitialized();
      nav.LocationChanged += LocationChanged;
      RefreshList();
    }
    void LocationChanged(object sender, LocationChangedEventArgs e)
    {
      var a = this;
      StateHasChanged();
    }
    void Dispose()
    {
      nav.LocationChanged -= LocationChanged;
    }
  }
}
