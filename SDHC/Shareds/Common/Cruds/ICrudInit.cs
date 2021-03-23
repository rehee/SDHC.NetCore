using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Cruds
{
  public interface ICrudInit
  {
    Func<ISave> GetRepo { get; }
    Type BaseIContentModelType { get; }
  }

  public class CrudInit<T> : ICrudInit where T : IContentModel, new()
  {
    public Func<ISave> GetRepo { get; }
    public Type BaseIContentModelType { get; }
    public CrudInit(Func<ISave> getRepo)
    {
      GetRepo = getRepo;
      BaseIContentModelType = typeof(T);
    }
  }
}
