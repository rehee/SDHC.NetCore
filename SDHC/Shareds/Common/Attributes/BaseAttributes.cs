using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Attributes
{
  public class BasePropertyAttribute : Attribute
  {
  }
  public class IgnoreEditAttribute : Attribute
  {

  }
  public class HideEditAttribute : Attribute
  {

  }
  public class CustomPropertyAttribute : Attribute
  {
  }
  public class ListItemAttribute : Attribute
  {
    public ListItemAttribute()
    {

    }
    public string[] KeyAndDisplayNames { get; set; }
  }
}
