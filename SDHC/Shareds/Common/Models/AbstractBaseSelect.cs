using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
  public abstract class AbstractBaseSelect : IBasicSelect
  {
    public virtual long Id { get; set; }
    [InputType(EditorType = EnumInputType.Text, SortOrder = 9999)]
    public virtual string Title { get; set; }
    public virtual string DisplayName()
    {
      return String.IsNullOrEmpty(this.Title) ? this.Id.ToString() : this.Title;
    }
    public override string ToString()
    {
      return this.DisplayName();
    }
  }
}
