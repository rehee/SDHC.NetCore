using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
  public class DropDownViewModel
  {
    public string Name { get; set; } = "";
    public string Value { get; set; }
    public bool Select { get; set; } = false;
  }
}
