using Common.Models;
using Common.Models.ViewModels;

namespace System
{
  public static class ViewModelExtends
  {
    public static T ConvertModelToViewModel<T>(this IInt64Key input) where T : BaseViewModel, new()
    {
      var result = new T();
      result.SetViewModel(input);
      return result;
    }
  }
}
