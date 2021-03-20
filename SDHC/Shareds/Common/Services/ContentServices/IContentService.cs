using Common.Models;
using Common.Models.ViewModels;
using SDHC.Common.Cruds;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.ContentServices
{
  public interface IContentService : ICrudContent
  {
    void CreateContent(IContentModel input, long? parentId = null);
    void UpdateContent(IContentModel input);
    void UpdateContent(ContentPostModel input);
    void MoveContent(long contentId, long? parentId);
    IEnumerable<IContentModel> GetAllChildContent(long? parentId, int? langKey = null);
    ContentTableHtmlView GetContentTableHtmlView(long? parentId, int? langKey = null);
    IContentModel GetContent(long? id);
    IContentModel GetContent(string urls, int lang);
    ContentPostModel GetPreCreate(long? id, string fullTypeAndAssembly, int? langKey);
    ContentPostViewModel GetContentPostViewModel(string url);
    string GetContentFullUrl(IContentModel model);
    ContentListView GetContentListView(long? id, int parentLevel = 0, int? langKey = null);
    void GetContentListView(IContentModel model, ContentListView parent, int parentLevel = 0, int sortChildLevel = 4);
    long? UpdateContentOrder(IEnumerable<ContentSortPostModel> inputs);

    ContentIndexViewModel<T> GetContentIndexViewModelByIdOrLang<T>(long? id, int? langKey, IList<string> roles) where T : IContentModel;

    Task<ContentPostViewModal> GetContentViewModel(long id, string outKey = "");

    Task Update(ContentPostModelSummary model);
  }
}
