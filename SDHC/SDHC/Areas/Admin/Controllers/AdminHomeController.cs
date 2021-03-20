﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDHC.Areas.Admin.Controllers
{
  [Area("Admin")]
  public class AdminHomeController : Controller
  {
    public IActionResult Index()
    {
      return Content("Admin");
    }
  }
}
