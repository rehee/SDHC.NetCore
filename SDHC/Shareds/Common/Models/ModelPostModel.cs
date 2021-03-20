using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
  public class ModelPostModel : IPostModel
  {
    [BaseProperty]
    public long Id { get; set; }
    [BaseProperty]
    public string FullType { get; set; }
    [BaseProperty]
    public string ThisAssembly { get; set; }
    public string PostUrl { get; set; }
    public string PostReturnUrl { get; set; }
    public bool IsPostAjax { get; set; }
    public string PostBeforeMethod { get; set; }
    public string PostResponseMethod { get; set; }
    public string PostFormId { get; set; } = Guid.NewGuid().ToString().Replace('-', '_');
    public string PostFormTitle { get; set; }
    public List<ContentProperty> Properties { get; set; } = new List<ContentProperty>();
    public string CloseFunction { get; set; }
  }
}
