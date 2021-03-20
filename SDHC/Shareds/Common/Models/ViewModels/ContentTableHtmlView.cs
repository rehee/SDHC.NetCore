using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ViewModels
{
  public class ContentTableHtmlView
  {
    public string FirstRowAction { get; set; }
    public string FirstRowController { get; set; }
    public string FirstRowArea { get; set; }
    public Func<object, object> FirstRowObject { get; set; }
    public string TableClass { get; set; }

    public IEnumerable<string> TableHeaders { get; set; }
    public IEnumerable<string> TableImageColumns { get; set; }
    public IEnumerable<ContentTableRowItem> Rows { get; set; }


    public string FirstRowTitle { get; set; }
    public ContentTableOption FirstRow { get; set; }
    public List<ContentTableOption> Options { get; set; }

    public bool FirstRowIsNotAction { get; set; }
    public bool DisableDelete { get; set; }
    public string DeleteFunctionName { get; set; }
    public Type ThisTypeFrom { get; set; } = null;
  }
}
