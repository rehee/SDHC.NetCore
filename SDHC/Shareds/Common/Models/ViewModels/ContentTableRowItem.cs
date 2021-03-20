using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Models.ViewModels
{
  public class ContentTableRowItem
  {
    public ContentTableRowItem(long id, IEnumerable<string> values, Type type, long displayOrder = 0, string stringId = "")
    {
      this.Id = id;
      this.Values = values;
      this.ThisType = type.GetRealType();
      this.DisplayOrder = displayOrder;
      this.StringId = stringId;
    }
    public long Id { get; set; }
    public long DisplayOrder { get; set; }
    public IEnumerable<string> Values { get; set; } = Enumerable.Empty<string>();
    public Type ThisType { get; set; }
    public string StringId { get; set; }
  }
}
