using Common.NetCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.NetCore.Repos
{
  public interface IContentContext : ISave
  {
    DbSet<BaseContent> Contents { get; set; }
    DbSet<BaseSelect> Selects { get; set; }
  }
}
