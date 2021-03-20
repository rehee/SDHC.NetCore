using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
  public interface IContentModel : IBasicContent, ILanguage
  {
    string Url { get; set; }
    long DisplayOrder { get; set; }
    DateTime? CreateTime { get; set; }
    long? ParentId { get; set; }
    IContentModel Parent { get; }
    IEnumerable<IContentModel> Parents { get; }
    IEnumerable<IContentModel> Children { get; }
  }
}
