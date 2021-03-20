using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDHC.Controllers
{
  [ApiController]
  [Route("Test")]
  public class TestController : Controller
  {
    [HttpGet("{name}")]
    public IActionResult Index(string name)
    {
      var list = new List<object>();
      list.Add(new Models() { title = "1" });
      list.Add(new Models2() { title2 = "2" });
      list.Add(new Models3() { title3 = "3" });
      return StatusCode(500, new { list = list });
    }
  }

  public class Models
  {
    public string title { get; set; }
  }
  public class Models2 : Models
  {
    public string title2 { get; set; }
  }
  public class Models3 : Models
  {
    public string title3 { get; set; }
  }
}
