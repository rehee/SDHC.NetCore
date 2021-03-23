using Common.NetCore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SDHC.UserAndRoles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDHC.Models
{
  public class MyDBContext : IdentityDbContext, ISave
  {
    public MyDBContext(DbContextOptions<MyDBContext> options)
        : base(options)
    {
    }
    public DbSet<SDHCUser> SDHCUsers { get; set; }
    public DbSet<BaseContent> Contents { get; set; }
    public DbSet<BaseContentModel> BaseContentModels { get; set; }

    public Task<int> SaveChangesAsync()
    {
      return this.SaveChangesAsync(default(System.Threading.CancellationToken));
    }
  }
}
