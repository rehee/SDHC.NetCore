using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
  public interface IInt64Key
  {
    Int64 Id { get; set; }
  }
  public interface IStringKey
  {
    String Id { get; set; }
  }
  public interface IDisplayName
  {
    string DisplayName();
  }
  
  public interface ILanguage
  {
    int Lang { get; set; }
  }
  public interface ISharedContent : IBasicModel, ILanguage
  {

  }
  public interface ISharedLink : ISharedContent
  {
    int DisplayOrder { get; set; }
    bool Displayed { get; set; }
    long? RelatedId { get; set; }
  }
  public interface IBasicContent : IBasicModel
  {

  }
  
}
