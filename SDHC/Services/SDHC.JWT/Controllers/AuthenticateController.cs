using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;
using Common.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SDHC.JWT.Models;
using SDHC.JWT.Services;
using UserIdentity.Models.IdentityModels;
using UserIdentity.Services;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace SDHC.JWT.Controllers
{
  [ApiController]
  [Route("Authenticate")]
  public class AuthenticateController : Controller
  {
    private readonly IAuthenticateService authenticateService;


    public AuthenticateController(IAuthenticateService authenticateService)
    {
      this.authenticateService = authenticateService;

    }


    [HttpGet]
    public IActionResult Index()
    {
      return Content("123");
    }
    [HttpPost("Login")]
    public async Task<IActionResult> Login(object obj)
    {
      try
      {
        var c = obj.ToIDictionary();
        var a = TypeMixer<object>.ExtendWith<ILoginRequest>(c);
        var isSuccess = await authenticateService.IsAuthenticated(a);
        return StatusCode(200, new { isSuccess = isSuccess.isSuccess, token = isSuccess.token });
      }
      catch (Exception ex)
      {
        return StatusCode(500, new { isSuccess = false, token = "" });
      }
    }




    [HttpPost("Create")]
    public async Task<IActionResult> Create(object obj)
    {
      try
      {

        var c = obj.ToIDictionary();
        dynamic MyDynamic = new System.Dynamic.ExpandoObject();
        var a = TypeMixer<object>.ExtendWith<IRegisterWithNameViewModel>(c);
        var isSuccess = await authenticateService.CreateUser(a);
        return StatusCode(200, new { isSuccess = isSuccess.isSuccess, user = isSuccess.user });
      }
      catch (Exception ex)
      {
        return StatusCode(500, new { isSuccess = false, user = "" });
      }
    }
  }
}