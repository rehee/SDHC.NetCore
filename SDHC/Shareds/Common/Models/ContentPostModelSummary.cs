using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
  public class ContentPostModelSummary
  {
    public ContentPostModel ContentModel { get; set; }
    public IEnumerable<ModelPostModel> Models { get; set; }
  }

}
