
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace System
{
  public static class JsonElementExtends
  {
    public static IDictionary<string, dynamic> ToIDictionary(this object input, IDictionary<string, dynamic> result = null)
    {
      if(input.GetType()!= typeof(JsonElement))
      {
        return Enumerable.Empty<KeyValuePair<string, object>>().ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
      }
      return ToIDictionary((JsonElement)input);
    }
    public static IDictionary<string, dynamic> ToIDictionary(this JsonElement input, IDictionary<string, dynamic> result = null)
    {
      if (input.ValueKind != JsonValueKind.Object)
      {
        return Enumerable.Empty<KeyValuePair<string, object>>().ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
      }
      if (result == null)
      {
        result = new Dictionary<string, dynamic>();
      }

      var maps = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(input.GetRawText());
      maps.ToList().ForEach(b =>
      {
        if (b.Value.ValueKind == JsonValueKind.Object)
        {
          result.Add(b.Key.ToLower(), b.Value.ToIDictionary());
        }
        else
        {
          result.Add(b.Key.ToLower(), b.Value.GetString());
        }

      });
      return result;
    }

    public static object GetValue(this object input, string propertyName, Type type = null)
    {
      if (input == null)
      {
        return null;
      }
      if (type == null)
      {
        type = input.GetType();
      }
      return type.GetProperty(propertyName).GetValue(input);
    }
    public static object CallMethod(this object input, string methodName, object[] parameters = null, Type type = null)
    {
      if (input == null)
      {
        return null;
      }
      if (type == null)
      {
        type = input.GetType();
      }
      return type.GetMethod(methodName).Invoke(input, parameters);
    }

  }
}
