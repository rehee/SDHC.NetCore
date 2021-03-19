using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SDHC.JWT;
using SDHC.Models;
using SDHC.UserAndRoles.Models;
using SDHC.UserAndRoles.Services;
using UserIdentity.Services;

namespace SDHC
{
  public class Startup
  {
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      Action<DbContextOptionsBuilder> dbAction = options =>
      {
        options.UseSqlServer(
              Configuration.GetConnectionString("DefaultConnection"));
      };

      services.AddDbContext<MyDBContext>(dbAction);
      services.AddIdentity<SDHCUser, IdentityRole>(
        options =>
        {
          options.SignIn.RequireConfirmedAccount = false;
        })
        .AddEntityFrameworkStores<MyDBContext>()
        .AddDefaultTokenProviders();
      services.AddScoped<RoleManager<IdentityRole>>();

      services.AddScoped(typeof(ISDHCMemberService<IdentityResult, Claim, ClaimsPrincipal, UserLoginInfo>), typeof(SDHCMemberService<SDHCUser>));
      services.AddScoped(typeof(ISDHCSignInService<IdentityResult, Claim, SignInResult, ClaimsPrincipal, AuthenticationProperties, AuthenticationScheme, ExternalLoginInfo>), typeof(SDHCSignInService<SDHCUser>));
      services.AddScoped<ISDHCUserManager, SDHCUserManager<SDHCUser>>();
      StartUpFunction.ConfigureServices(Configuration, services);
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseAuthentication();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");
      });
    }
  }
}
