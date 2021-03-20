using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
  public class ContentPostModel : IPostModel
  {
    [BaseProperty]
    public long Id { get; set; }
    [BaseProperty]
    public long? ParentId { get; set; }
    [BaseProperty]
    public string FullType { get; set; }
    [BaseProperty]
    public string ThisAssembly { get; set; }
    [BaseProperty]
    public string Title { get; set; }
    [BaseProperty]
    public DateTime? CreateTime { get; set; }
    [BaseProperty]
    public long DisplayOrder { get; set; }
    [BaseProperty]
    public int? Lang { get; set; }
    [BaseProperty]
    public string ViewPath { get; set; }
    public List<ContentProperty> Properties { get; set; } = PassModeConvert.NewContentPropertyList();
  }
}
