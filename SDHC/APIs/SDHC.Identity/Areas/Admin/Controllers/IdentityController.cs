﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Common.Models.ViewModels;
using Common.Services;
using Common.NetCore.Models;
using SDHC.UserAndRoles.Services;

namespace SDHC.JWT.Controllers
{
  [Area("Admin")]
  public class IdentityController : Controller
  {
    private readonly ISDHCUserManager<SDHCUser> um;

    public IdentityController(ISDHCUserManager<SDHCUser> um)
    {
      this.um = um;
    }
    public IActionResult Login(string id = "")
    {
      ViewBag.RedirectUrl = id;
      return View(null);
    }
    [HttpPost]
    public IActionResult Login(LoginViewModel model, string redirectUrl)
    {
      ViewBag.RedirectUrl = redirectUrl;

      var result = um.Login(model).GetAsyncValue();
      if (result)
      {
        return Redirect("/Admin/Identity/Login");
      }
      return View(model);
    }

  }
}