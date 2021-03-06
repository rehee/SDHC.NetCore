using Common.Models;
using Common.Models.ViewModels;
using Common.Cruds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Services
{
  public class ContentService : CrudContent, IContentService, IContentListService
  {
    public ContentService(ICrudInit container, IConfigService configService) : base(container)
    {
      this.configService = configService;
    }
    private IConfigService configService;
    public void CreateContent(IContentModel input, long? parentId = null)
    {
      if (parentId.HasValue)
      {
        var parent = Read(BaseIContentModelType, b => b.Id == parentId.Value);
        if (parent != null)
        {
          input.ParentId = parentId.Value;
        }
      }
      Create(input);
    }
    public void UpdateContent(IContentModel input)
    {
      Update(BaseIContentModelType, input);
    }
    public void UpdateContent(ContentPostModel input)
    {
      var content = Find(BaseIContentModelType, input.Id, out ISave db);
      if (content == null)
      {
        return;
      }
      input.ConvertToBaseModel(content);
      db.SaveChanges();
    }
    public void MoveContent(long contentId, long? parentId)
    {
      var content = Find(BaseIContentModelType, contentId);
      if (content == null)
        return;
      var parent = parentId.HasValue ? Find(BaseIContentModelType, parentId.Value) : null;

      (content as IContentModel).ParentId = parent != null ? parentId : null;
      Update(BaseIContentModelType, content as IInt64Key);
    }
    public IEnumerable<IContentModel> GetAllChildContent(long? parentId, int? langKey = null)
    {
      if (parentId.HasValue)
      {
        return Read<IContentModel>(BaseIContentModelType,
        b => b.ParentId == parentId)
        .AsQueryable();
      }
      return Read<IContentModel>(BaseIContentModelType,
        b => (b.ParentId.HasValue == false || b.ParentId == 0) && b.Lang == langKey)
        .AsQueryable();
    }
    public ContentTableHtmlView GetContentTableHtmlView(long? parentId, int? langKey = null)
    {

      var content = GetContent(parentId);
      Type type = content != null ? content.GetType().GetRealType() : BaseIContentModelType;
      var allowChild = type.GetObjectCustomAttribute<AllowChildrenAttribute>();
      IEnumerable<string> additionalList = allowChild != null && allowChild.TableList != null ? allowChild.TableList : new string[] { "Title", "DisplayOrder" };
      return GetContentTableHtmlView(content, type, allowChild, parentId, langKey);
    }
    private ContentTableHtmlView GetContentTableHtmlView(IContentModel content, Type type, AllowChildrenAttribute allowChild, long? parentId, int? langKey = null)
    {
      IEnumerable<string> additionalList = allowChild != null && allowChild.TableList != null ? allowChild.TableList : new string[] { "Title", "DisplayOrder" };
      var children = GetAllChildContent(parentId, langKey).OrderBy(b => b.DisplayOrder).ToList().ToList();
      var tableImageColumns = allowChild != null && allowChild.TableImageList != null ? allowChild.TableImageList : new string[] { };
      var rowItems = children.Select(b =>
      {
        var values = additionalList.Select(a => b.GetPropertyByKey(a, tableImageColumns.Contains(a))).ToList();
        return new ContentTableRowItem(b.Id, values, b.GetType().GetRealType(), b.DisplayOrder);
      }).ToList();
      var result = new ContentTableHtmlView();
      if (allowChild != null && allowChild.DisableDelete)
      {
        result.DisableDelete = true;
      }
      result.TableHeaders = additionalList.Select(b => type.GetPropertyLabelByKey(b)).ToList();
      result.Rows = rowItems;
      return result;
    }
    public IContentModel GetContent(long? id)
    {
      if (!id.HasValue || id <= 0)
      {
        return null;
      }
      return Find<IContentModel>(BaseIContentModelType, id.Value);
    }
    public IContentModel GetContent(string urls, int lang)
    {
      IContentModel result = null;
      if (String.IsNullOrWhiteSpace(urls))
      {
        goto HomePage;
      }

      var urlList = urls.Split('/').Select(b => b.Trim());
      foreach (var u in urlList)
      {
        result = Read<IContentModel>(BaseIContentModelType, b => b.Title.Equals(u, StringComparison.OrdinalIgnoreCase) && b.Lang == lang).FirstOrDefault();
        if (result == null)
        {
          goto HomePage;
        }
      }
      return result;

      HomePage:
      result = Read<IContentModel>(BaseIContentModelType, b => (!b.ParentId.HasValue || b.ParentId == 0) && b.Lang == lang).FirstOrDefault();
      if (result != null)
        return result;
      return Read<IContentModel>(BaseIContentModelType, b => !b.ParentId.HasValue || b.ParentId == 0).FirstOrDefault();
    }
    public ContentPostModel GetPreCreate(long? id, string fullTypeAndAssembly, int? langKey)
    {
      long? parentId = null;
      int lang = 0;
      if (id.HasValue)
      {
        var parent = Find<IContentModel>(BaseIContentModelType, id.Value);
        if (parent != null)
        {
          parentId = parent.Id;
          lang = parent.Lang;
        }
      }
      else
      {
        lang = langKey ?? 0;
      }
      var type = Type.GetType(fullTypeAndAssembly);
      if (type == null)
      {
        return null;
      }
      var model = Activator.CreateInstance(type) as IContentModel;
      model.ParentId = parentId;
      model.Lang = lang;
      return model.ConvertModelToPost();
    }
    public ContentPostViewModel GetContentPostViewModel(string url)
    {
      var homePageModel = Read<IContentModel>(BaseIContentModelType, b => b.ParentId == null).OrderBy(b => b.DisplayOrder).FirstOrDefault();
      if (String.IsNullOrEmpty(url))
        goto gotoHomePage;
      var urlList = url.Split('/').Select(b => b.Trim()).Where(b => !String.IsNullOrEmpty(b)).ToList();
      var reOrgnizeUrl = String.Join("/", urlList);
      var currentUrl = urlList.LastOrDefault();
      var models = Read<IContentModel>(BaseIContentModelType, b => String.Equals(b.Url, currentUrl)).ToList().Where(b => b.Parents.Count() == urlList.Count - 1).ToList();
      if (models.Count == 0)
        goto gotoHomePage;

      var model = models.Where(b => String.Equals(GetContentFullUrl(b), reOrgnizeUrl, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();
      if (model != null)
        return new ContentPostViewModel(model);
      gotoHomePage:
      if (homePageModel == null)
        return new ContentPostViewModel();
      return new ContentPostViewModel(homePageModel);
    }

    public string GetContentFullUrl(IContentModel model)
    {
      var parents = model.Parents.Select(b => b.Url).ToList();
      parents.Reverse();
      parents.Add(model.Url);
      return String.Join("/", parents);
    }
    public ContentListView GetContentListView(long? id, int parentLevel = 0, int? langKey = null)
    {
      if (id.HasValue && id.Value > 0)
      {
        var model = GetContent(id);
        if (model == null)
        {
          return null;
        }
        var result = new ContentListView()
        {
          Id = model.Id,
          ParentId = model.ParentId,
          Title = model.Title,
        };

        GetContentListView(model, result, 0);
        return result.Children.FirstOrDefault();
      }
      else
      {
        var roots = Read<IContentModel>(BaseIContentModelType, b => b.ParentId == null && b.Lang == langKey).ToList();
        var result = new ContentListView();
        roots.ForEach(b => GetContentListView(b, result, 0));
        return result;
      }
    }

    public void GetContentListView(IContentModel model, ContentListView parent, int parentLevel = 0, int sortChildLevel = 4)
    {
      if (parentLevel > sortChildLevel)
      {
        return;
      }
      parentLevel++;
      var result = new ContentListView();
      result.Id = model.Id;
      result.Title = model.Title;
      result.ParentId = model.ParentId;
      result.DisplayOrder = model.DisplayOrder;

      if (parent != null)
      {
        parent.Children.Add(result);
      }
      var children = model.Children;
      foreach (var item in children)
      {
        GetContentListView(item, result, parentLevel);

      }
      return;
    }

    public long? UpdateContentOrder(IEnumerable<ContentSortPostModel> inputs)
    {
      if (inputs == null)
        return null;
      var list = inputs.ToList();
      list.RemoveAt(0);
      var idList = list.Where(b => b.id.HasValue).Select(b => b.id).ToList();
      var contents = Read<IContentModel>(BaseIContentModelType, b => idList.Contains(b.Id), out var repo).ToList();
      contents.ForEach(c =>
      {
        var cInput = list.Where(b => b.id == c.Id).FirstOrDefault();
        if (cInput != null)
        {
          if (cInput.parentId.HasValue)
          {
            if (cInput.parentId.Value > 0)
            {
              c.ParentId = cInput.parentId.Value;
            }
            else
            {
              c.ParentId = null;
            }

          }
          if (cInput.displayOrder.HasValue)
          {
            c.DisplayOrder = cInput.displayOrder.Value;
          }
        }
      });
      repo.SaveChanges();
      return null;
    }

    public ContentIndexViewModel<T> GetContentIndexViewModelByIdOrLang<T>(long? id, int? langKey, IList<string> roles)
      where T : IContentModel
    {
      var result = new ContentIndexViewModel<T>();
      var content = GetContent(id.HasValue && id.Value > 0 ? id : null);
      result.Content = content != null ? (T)content : default(T);
      if (content == null)
      {
        result.ChildrenAttribute = BaseIContentModelType.GetObjectCustomAttribute<AllowChildrenAttribute>();
        result.ContentId = null;
        result.LanguageKey = langKey;
      }
      else
      {
        result.ChildrenAttribute = content.GetObjectCustomAttribute<AllowChildrenAttribute>();
        result.ContentId = content.Id;
        result.LanguageKey = content.Lang;
      }
      Func<IEnumerable<string>, bool> checkInRole = b =>
      {
        if (b == null || !b.Any())
          return true;
        if (configService.Systems.AdminFree)
          return true;
        return b.Intersect(roles).Any();
      };
      if (result.ChildrenAttribute != null)
      {
        result.TableSize = (int)result.ChildrenAttribute.TableSize;
        result.IsInCreateRoles = checkInRole(result.ChildrenAttribute.CreateRoles);
        result.IsInReadRoles = checkInRole(result.ChildrenAttribute.ReadRoles);
        result.IsInEditRoles = checkInRole(result.ChildrenAttribute.EditRoles);
        result.IsInDeleteRoles = checkInRole(result.ChildrenAttribute.DeleteRoles);
        result.IsInSortRoles = checkInRole(result.ChildrenAttribute.SortRoles);
      }
      result.Model = GetContentTableHtmlView(result.Content, typeof(T), result.ChildrenAttribute, result.ContentId, langKey);
      return result;
    }


    public Task<ContentPostViewModal> GetContentViewModel(long id, string outKey = "")
    {
      return Task<ContentPostViewModal>.Run(() =>
      {
        var content = GetContent(id);
        if (content == null)
          return null;
        return new ContentPostViewModal(content.ConvertModelToPost(), outKey);
      });
    }
    public Task Update(ContentPostModelSummary model)
    {
      return Task.Run(() =>
      {
        try
        {
          UpdateContent(model.ContentModel);
        }
        catch { }
        foreach (var m in model.Models)
        {
          try
          {
            Update(m);
          }
          catch { }
        }
      });
    }

    public async Task<IListGroupCardViewModel> GetContentsByParent(
      long? parentId)
    {
      var result = new BaseListGroupCardViewModel();
      result.ShowHeaderButton = true;
      IList<IContentModel> lists;
      if (!parentId.HasValue || parentId <= 0)
      {
        result.HeaderButton = new BaseListGroupCardItemViewModel()
        {
          DisplayName = "Root",
          Url = $"/Admin/Page",
        };
        var query = await ReadAsync<IContentModel>(BaseIContentModelType, b => b.ParentId == parentId);
        lists = query.ToList();
      }
      else
      {
        var parent = (await ReadAsync<IContentModel>(BaseIContentModelType, b => b.Id == parentId)).FirstOrDefault();
        lists = new List<IContentModel>();
        if (parent != null)
        {
          lists = parent.Children.ToList();
          result.HeaderButton = new BaseListGroupCardItemViewModel()
          {
            DisplayName = "Back to the previous",
            Url = $"/Admin/Page/{parent.Id}",
          };
        }
      }


      var resultList = new List<IListGroupCardItemViewModel>();
      result.Items = resultList;
      for (var i = 0; i < lists.Count; i++)
      {
        var content = lists[i];
        var attr = content.GetObjectCustomAttribute<AllowChildrenAttribute>();
        var contentChildren = content.Children.Count();
        var item = new BaseListGroupCardItemViewModel()
        {
          DisplayName = content.DisplayName(),
          Url = $"/Admin/Page/{content.Id}",
          Badges = new IListGroupCardItemBadgeViewModel[]
          {
            new BaseListGroupCardItemBadgeViewModel()
            {
              Value = contentChildren.ToString(),
              Url = $"/Admin/Page/{content.Id}/List",
            }
          }
        };
        resultList.Add(item);
      }
      return result;
    }
  }
}
