using System;
using System.Collections.Generic;
using System.Text;

namespace System
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
  public class ConfigAttribute : Attribute
  {

  }
  public class FileReadAttribute : Attribute
  {
    public string ReadRoles { get; set; }
  }
}
