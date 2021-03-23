using System;
using System.Security.Claims;
using Common.Configs;
using Common.Cruds;
using Common.Models;
using Common.NetCore.Models;
using Common.NetCore.Services;
using Common.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SDHC.JWT;
using SDHC.Models;
using SDHC.UserAndRoles.Services;

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
      services.AddSession();
      services.AddHttpContextAccessor();


      services.Configure<SystemConfig>(Configuration.GetSection("SystemConfig"));
      services.Configure<AdminAreaConfig>(Configuration.GetSection("AdminAreaConfig"));
      services.Configure<LanguageSetting>(Configuration.GetSection("LanguageSetting"));
      //services.Configure<IEnumerable<LanguageConfig>>(Configuration.GetSection("LanguageSetting:LanguageConfigs"));
      //var tokenConfig1 = Configuration.GetSection("LanguageSetting").Get<LanguageSetting>();
      //var language = Configuration.GetSection("LanguageSetting").Get<LanguageSetting>();
      //language.LanguageConfigs = Configuration.GetSection("LanguageSetting:LanguageConfigs").Get<IEnumerable<LanguageConfig>>();


      services.AddScoped<ISessionService, SessionService>();
      services.AddScoped<IConfigService, ConfigService>();

      services.AddScoped<ISDHCLanguageService, SDHCLanguageService>();


      services.AddControllers();
      services.AddRazorPages();
      services.AddServerSideBlazor();

      var builder = new DbContextOptionsBuilder<MyDBContext>();

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
      services.AddScoped(typeof(ISDHCMemberService<SDHCUser, IdentityResult, Claim, ClaimsPrincipal, UserLoginInfo, IUserValidator<SDHCUser>, IUserTwoFactorTokenProvider<SDHCUser>>), typeof(SDHCMemberService<SDHCUser>));
      services.AddScoped(typeof(ISDHCSignInService<SDHCUser, IdentityResult, Claim, SignInResult, ClaimsPrincipal, AuthenticationProperties, AuthenticationScheme, ExternalLoginInfo>), typeof(SDHCSignInService<SDHCUser>));
      services.AddScoped<ISDHCUserManager<SDHCUser>, SDHCUserManager<SDHCUser>>();
      services.AddScoped<ISDHCUserManager, SDHCUserManager<SDHCUser>>();
      StartUpFunction.ConfigureServices<SDHCUserManager<SDHCUser>>(Configuration, services);

      services.AddScoped<IUserService, UserService>();


      dbAction(builder);
      Func<CrudInit<BaseContentModel>> getCrud = () => new CrudInit<BaseContentModel>(() => Activator.CreateInstance(typeof(MyDBContext), builder.Options) as ISave);
      services.AddScoped<ICrudInit, CrudInit<BaseContentModel>>(
        (s) => getCrud());


      services.AddScoped<ICrud, BaseCruds>();
      services.AddScoped<ICrudContent, CrudContent>();
      services.AddScoped<ICrudModel, CrudModel>();
      AbstractBaseContent.Init<BaseContentModel>(() => new CrudContent(getCrud()));
      services.AddScoped<IContentService, ContentService>();
      services.AddScoped<IContentListService, ContentService>();


      services.AddScoped<ILayoutService, LayoutService>();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      app.UseSession();
      app.UseAuthentication();
      app.UseStaticFiles();
      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapAreaControllerRoute(
                  name: "AdminArea",
                  areaName: "Admin",
                  pattern: "Admin/{controller=AdminHome}/{action=Index}/{id?}");

        endpoints.MapBlazorHub();
        endpoints.MapFallbackToAreaPage("~/{area:exists}/{*clientroutes:nonfile}", "/_Host", "Admin");

        endpoints.MapControllerRoute(
          name: "default",
          pattern: "{controller=Home}/{action=Index}/{id?}");

      });
    }
  }
}
