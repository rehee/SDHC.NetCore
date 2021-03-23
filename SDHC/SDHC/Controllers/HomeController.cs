using Common.Cruds;
using Microsoft.AspNetCore.Mvc;
using SDHC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDHC.Controllers
{
  public class HomeController : Controller
  {
    private readonly ICrud crud;

    public HomeController(ICrud crud)
    {
      this.crud = crud;
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
