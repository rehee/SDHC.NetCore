using Common.Models.ViewModels;
using Common.NetCore.Blazor.Components;
using Common.NetCore.Blazor.Layouts;
using Common.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Collections.Generic;

namespace SDHC.Areas.Admin.Pages
{
  public class IndexPage : SDHCComponentBase
  {
    [Inject]
    private IContentService service { get; set; }
    [Inject]
    private ILayoutService layoutService { get; set; }

    [Parameter]
    public long? id { get; set; }
    private long? thisId { get; set; }
    private long? parentId { get; set; }

    [CascadingParameter]
    protected ContentLayout Layout { get; set; }

    protected override void OnInitialized()
    {

      base.OnInitialized();
      
      thisId = id;
      getParentId();
    }

    private void getParentId()
    {
      long? parentId = null;
      if (thisId == 0)
      {
        parentId = null;
      }
      else
      {
        var page = service.GetContent(thisId);
        if (page == null)
        {
          parentId = null;
        }
        else
        {
          parentId = (page.ParentId.HasValue && page.ParentId.Value > 0) ? page.ParentId : null;
        }
      }
      if (parentId != this.parentId)
      {
        this.parentId = parentId;
        Layout.ParentId = this.parentId;
        Layout.RefreshList();
      }

    }

    protected override void OnParametersSet()
    {
      if (thisId != id)
      {
        thisId = id;

        getParentId();
      }
    }
  }
}
