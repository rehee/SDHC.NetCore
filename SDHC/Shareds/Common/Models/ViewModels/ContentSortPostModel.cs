using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ViewModels
{
  public class ContentSortPostModel
  {
    public long? id { get; set; }
    public long? parentId { get; set; }
    public long? displayOrder { get; set; }
  }
}
