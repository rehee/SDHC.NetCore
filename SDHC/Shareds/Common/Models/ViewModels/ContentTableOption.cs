using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ViewModels
{
  public class ContentTableOption
  {
    public Func<object, object> RowTitle { get; set; }
    public string ButtonClass { get; set; } = "";
    public string RowAction { get; set; }
    public string RowController { get; set; }
    public string RowArea { get; set; } = "";
    public Func<object, object> RowObject { get; set; }
    public Func<object, string> UrlAttribute { get; set; } = (o) => "";

  }
}
