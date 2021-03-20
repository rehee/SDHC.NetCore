using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
  public class ContentPropertyIndex
  {
    public ContentProperty Property { get; set; }
    public int Index { get; set; }
    public string RandomIndex { get; }
    public string InputName { get; }
    public string FileName { get; }
    public bool IsFile => Property != null ? Property.EditorType == EnumInputType.FileUpload : false;
    public string OuterName => $"{OutMakr}{(IsFile ? FileName : InputName)}";
    public string OuterNameNoMark
    {
      get
      {
        var s = OuterName.Split('[', ']', '.');
        return String.Join("_", s);
      }
    }
    public string ModalName => $"modal_{OuterNameNoMark}";
    public string ModalRefresh => $"{ModalName}_refresh";
    public string ModalReview => $"{ModalName} review";


    public string OutIndex { get; }
    public string OutMakr => String.IsNullOrEmpty(OutIndex) ? $"" : $"{OutIndex}.";
    public int? Lang { get; }
    public long? ModelId { get; }
    public string FullType { get; }
    public string AssemblyName { get; }
    public ContentPropertyIndex(ContentProperty property, int index, string outIndex = null, int? lang = null, long? modelId = null,
      string fullType = null, string assemblyName = null

      )
    {
      Property = property;
      Index = index;
      OutIndex = outIndex;
      RandomIndex = Guid.NewGuid().ToString().Replace('-', '_');
      var valueName = "Value";
      if (Property.MultiSelect)
      {
        valueName = "MultiValue";
      }
      InputName = "Properties[" + Index.ToString() + "]." + valueName;
      FileName = "Properties[" + Index.ToString() + "].FileCore";
      Lang = lang;
      ModelId = modelId;
      FullType = fullType;
      AssemblyName = assemblyName;
    }
  }
}
