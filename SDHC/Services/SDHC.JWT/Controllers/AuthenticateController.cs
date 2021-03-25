using System;
using System.Threading.Tasks;
using Common.Models.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SDHC.JWT.Services;

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
      catch
      {
        return StatusCode(500, new { isSuccess = false, token = "" });
      }
    }


    [HttpGet("Create")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Create()
    {
      return await Task<IActionResult>.Run(() =>
     {
       return StatusCode(200);
     });
      //try
      //{
      //  var c = obj.ToIDictionary();
      //  dynamic MyDynamic = new System.Dynamic.ExpandoObject();
      //  var a = TypeMixer<object>.ExtendWith<IRegisterWithNameViewModel>(c);
      //  var isSuccess = await authenticateService.CreateUser(a);
      //  return StatusCode(200, new { isSuccess = isSuccess.isSuccess, user = isSuccess.user });
      //}
      //catch
      //{
      //  return StatusCode(500, new { isSuccess = false, user = "" });
      //}
    }
  }
}