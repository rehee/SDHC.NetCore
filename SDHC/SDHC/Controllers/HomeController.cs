using Common.Configs;
using Common.Cruds;
using Common.Services;
using Microsoft.AspNetCore.Mvc;
using SDHC.Models;

namespace SDHC.Controllers
{
  public class HomeController : Controller
  {
    private readonly ICrud crud;
    private readonly IConfigService config;

    public ISDHCLanguageService Lang { get; }

    public HomeController(ICrud crud,ISDHCLanguageService lang,IConfigService config)
    {
      this.crud = crud;
      Lang = lang;
      
      this.config = config;
      var a = config.GetTypeSetting<LanguageSetting>("LanguageSetting");
      
    }
    public IActionResult Index()
    {
      return Content("Home");
    }
    public IActionResult Add()
    {
      var BaseContent = new BaseContentModel()
      {
        Title="b1",
      };
      var BaseContent2 = new BaseContentModel()
      {
        Title = "b2",
      };
      var BaseContent3 = new BaseContentModel()
      {
        Title = "b3",
      };
      crud.Create(BaseContent);
      crud.Create(BaseContent2);
      crud.Create(BaseContent3);
      var BaseContent31 = new BaseContentModel()
      {
        Title = "b31",
        ParentId = BaseContent3.Id
      };
      crud.Create(BaseContent31);
      return Content("Add");
    }
  }
}
