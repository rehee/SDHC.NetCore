using Common.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SDHC.JWT.Models;
using SDHC.JWT.Services;
using System.Text;

namespace SDHC.JWT
{
  public class StartUpFunction
  {
    public static void ConfigureServices<TSDHCUserManager>(IConfiguration configuration, IServiceCollection services, string tokenString = "tokenConfig")
      where TSDHCUserManager : ISDHCUserManager
    {
      services.Configure<TokenManagement>(configuration.GetSection(tokenString));
      var tokenConfig = configuration.GetSection(tokenString).Get<TokenManagement>();
      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(x =>
      {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          //获取或设置要使用的key用于签名验证,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(tokenConfig.Secret)),
          //验证发行者
          ValidIssuer = tokenConfig.Issuer,
          //验证接受者
          ValidAudience = tokenConfig.Audience,
          ValidateIssuer = false,
          ValidateAudience = false
        };
      });

      services.AddScoped<IAuthenticateService, TokenAuthenticationService>();
      services.AddScoped(typeof(ISDHCUserManager), typeof(TSDHCUserManager));
    }
  }
}
