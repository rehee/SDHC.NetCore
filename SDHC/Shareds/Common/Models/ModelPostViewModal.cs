using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
  public class ModelPostViewModal : AbstractPostViewModal<ModelPostModel>
  {
    public ModelPostViewModal(ModelPostModel model, string outerKey = null) : base(model, outerKey)
    {
    }
  }
}
