using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models.ViewModels
{
  public class ContentIndexViewModel<T> where T : IBasicModel
  {
    public int? LanguageKey { get; set; }
    public long? ContentId { get; set; }
    public int TableSize { get; set; } = 10;
    public bool IsInCreateRoles { get; set; } = true;
    public bool IsInReadRoles { get; set; } = true;
    public bool IsInEditRoles { get; set; } = true;
    public bool IsInDeleteRoles { get; set; } = true;
    public bool IsInSortRoles { get; set; } = true;
    public AllowChildrenAttribute ChildrenAttribute { get; set; }
    public ContentTableHtmlView Model { get; set; }
    public T Content { get; set; }
  }
}
