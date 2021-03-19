using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    private readonly ISDHCUserManager u;

    public AuthenticateController(IAuthenticateService authenticateService, ISDHCUserManager u)
    {
      this.authenticateService = authenticateService;
      this.u = u;
    }


    [HttpGet]
    public IActionResult Index()
    {
      return Content("123");
    }
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginItem request)
    {
      try
      {
        var a = await u.CheckLoginRequest(request);
        var isSuccess = authenticateService.IsAuthenticated(request, out var token);
        return StatusCode(200, new { isSuccess = isSuccess, token = token });
      }
      catch (Exception ex)
      {
        var isSuccess = authenticateService.IsAuthenticated(request, out var token);
        return StatusCode(500, new { isSuccess = false, token = "" });
      }

    }
  }
}