using Common.Models;
using Common.Models.ViewModels;
using Common.Services;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SDHC.JWT.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SDHC.JWT.Services
{
  public interface IAuthenticateService
  {
    Task<(bool isSuccess, string token)> IsAuthenticated(ILoginRequest request);
    Task<(bool isSuccess, IUserBase user)> CreateUser(IRegisterWithNameViewModel login);
  }

  public class TokenAuthenticationService : IAuthenticateService
  {
    private readonly ISDHCUserManager u;
    private readonly TokenManagement _tokenManagement;
    public TokenAuthenticationService(ISDHCUserManager u, IOptions<TokenManagement> tokenManagement)
    {
      this.u = u;
      _tokenManagement = tokenManagement.Value;
    }
    public async Task<(bool isSuccess, string token)> IsAuthenticated(ILoginRequest request)
    {
      var token = string.Empty;
      var user = await u.CheckLoginRequest(request);
      if (user == null)
        return (false, token);
      var claims = new[]
      {
        new Claim(ClaimTypes.Name,user.GetUserName()),
        new Claim(ClaimTypes.Email,user.GetEmail()),
        new Claim(ClaimTypes.Role,"Admin"),
        new Claim(ClaimTypes.Role,"Staff")
      };
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenManagement.Secret));
      var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var jwtToken = new JwtSecurityToken(_tokenManagement.Issuer, _tokenManagement.Audience, claims,
          expires: DateTime.Now.AddMinutes(_tokenManagement.AccessExpiration),
          signingCredentials: credentials);
      token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
      return (true, token);
    }
    public async Task<(bool isSuccess, IUserBase user)> CreateUser(IRegisterWithNameViewModel login)
    {
      var user = await u.CreateUser(login);
      return (user != null, user);
    }
  }
}
