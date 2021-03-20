using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
  public class ContentPostViewModal : AbstractPostViewModal<ContentPostModel>
  {
    public ContentPostViewModal(ContentPostModel model, string outerKey = null) : base(model, outerKey, model.Lang)
    {
    }
    public string ViewPath => Model.ViewPath;
  }
}
