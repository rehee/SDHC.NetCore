using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.NetCore.Models.ViewModels
{
  public class SharedLinkPost
  {
    public SharedLinkView View { get; set; }
    public IEnumerable<string> Headers { get; set; }
    public IEnumerable<string> Images { get; set; }
    public IEnumerable<ISharedLink> Models { get; set; }
    public String TypeName { get; set; }
    public String AssemblyName { get; set; }
    public bool IsRelated { get; set; }
    public long RelatedId { get; set; }
    public int? Lang { get; set; }
  }
}
