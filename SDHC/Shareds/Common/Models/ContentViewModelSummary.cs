using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
  public class ContentPostViewModelSummary
  {
    public ContentPostViewModal ContentModel { get; set; }
    public IEnumerable<ModelPostViewModal> Models { get; set; }
  }
}
