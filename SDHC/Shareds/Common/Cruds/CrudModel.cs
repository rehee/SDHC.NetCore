using Common.Models;
using Common.Models.ViewModels;
using Common.Cruds;
using System.Linq;
using System.Threading.Tasks;

namespace System
{
  public class CrudModel : BaseCruds, ICrudModel
  {
    public CrudModel(ICrudInit container) : base(container)
    {
    }

    public void Create(ModelPostModel model)
    {
      var obj = model.ConvertToBaseModel();
      Create(obj);
    }
    public void Update(ModelPostModel model)
    {
      var type = Type.GetType($"{model.FullType},{model.ThisAssembly}");
      if (type == null)
        return;
      var target = Read<IInt64Key>(type, b => b.Id == model.Id, out ISave repo).FirstOrDefault();
      if (target == null)
        return;
      model.ConvertToBaseModel(target);
      try
      {
        repo.SaveChanges();
      }
      catch { }
    }
    public void Update(BaseViewModel model)
    {
      var type = model.ModelType();
      if (type == null)
        return;
      var baseModel = Read<IInt64Key>(type, b => b.Id == model.Id, out var repo).FirstOrDefault();
      if (baseModel == null)
        return;
      model.ConvertToModel(baseModel);
      try
      {
        repo.SaveChanges();
      }
      catch { }
    }

    public Task CreateOrUpdate(ModelPostModel model)
    {
      return Task.Run(() =>
      {
        try
        {
          if (model.Id <= 0)
          {
            Create(model);
          }
          else
          {
            Update(model);
          }
        }
        catch { }
      });
    }
  }
}
