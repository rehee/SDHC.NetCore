using Common.Models;
using Common.Services.ModelServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.SelectServices
{
  public interface ISelectService : IModelService
  {
    void AddSelectType<T>() where T : IBasicSelect;
    IEnumerable<IBasicSelect> GetAllSelect(Type selectType);
    IEnumerable<IBasicSelect> GetAllSelect(string type);
    IEnumerable<Type> GetAllAvaliableSelect();
    IEnumerable<DropDownSummary> GetAllAvaliableSelectList();
  }
}
