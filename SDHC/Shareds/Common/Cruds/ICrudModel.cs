using Common.Models;
using Common.Models.ViewModels;
using System.Threading.Tasks;

namespace SDHC.Common.Cruds
{
  public interface ICrudModel : ICrud
  {
    void Create(ModelPostModel model);
    void Update(ModelPostModel model);
    void Update(BaseViewModel model);

    Task CreateOrUpdate(ModelPostModel model);
  }
}

