using Common.Models;
using Common.Services.ModelServices;
using Common.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System
{
  public static class TypeExtends
  {
    private static Type baseIContentModelType { get; set; }
    private static SystemConfig config { get; } = getConfig();
    private static Func<SystemConfig> getConfig { get; set; } = () => null;
    private static IModelService modelService { get; } = getModelService();
    private static Func<IModelService> getModelService { get; set; } = () => null;

    public static void Init<BaseIContentType>(Func<SystemConfig> config, Func<IModelService> modelService) where BaseIContentType : class, IContentModel
    {
      baseIContentModelType = typeof(BaseIContentType);
      getConfig = config;
      getModelService = modelService;
    }

    public static IEnumerable<Type> GetAllowChildrens(object input)
    {
      Type type;
      if (input == null)
      {
        type = baseIContentModelType;
      }
      else
      {
        type = input.GetType().GetRealType();
      }
      var allows = type.GetObjectCustomAttribute<AllowChildrenAttribute>();
      if (allows == null || allows.ChildrenType == null)
      {
        return Enumerable.Empty<Type>();
      }
      return allows.ChildrenType;
    }
    public static int GetTableSize(object input)
    {
      Type type;
      if (input == null)
      {
        type = baseIContentModelType;
      }
      else
      {
        type = input.GetType().GetRealType();
      }
      return GetTableSize(type);
    }
    public static int GetTableSize(Type type)
    {
      var allows = type.GetObjectCustomAttribute<AllowChildrenAttribute>();
      if (allows == null || allows.TableSize == EnumTablePageSize.L0)
      {
        return config.DefaultTablePageSize;
      }
      return (int)allows.TableSize;
    }
    public static string GetClassDisplayName(Type input)
    {
      var display = input.GetObjectCustomAttribute<AllowChildrenAttribute>();
      if (display != null)
      {
        if (!String.IsNullOrEmpty(display.Name))
        {
          return display.Name;
        }
      }
      return input.Name.SpacesFromCamel();
    }

    public static IEnumerable<string> GetAdminAuthorizeRoles(EnumAdminAuthorize crud, Type input)
    {
      var adminList = config.AdminRole.Split(',')
        .Select(b => b.Trim()).Where(b => !String.IsNullOrEmpty(b)).ToList();
      var children = input.GetAllowChildren();
      if (children == null)
        return adminList;
      switch (crud)
      {
        case EnumAdminAuthorize.Create:
          if (children.CreateRoles != null)
            return children.CreateRoles;
          break;
        case EnumAdminAuthorize.Read:
          if (children.ReadRoles != null)
            return children.ReadRoles;
          break;
        case EnumAdminAuthorize.Update:
          if (children.EditRoles != null)
            return children.EditRoles;
          break;
        case EnumAdminAuthorize.Delete:
          if (children.DeleteRoles != null)
            return children.DeleteRoles;
          break;
      }
      return adminList;
    }

    public static AllowChildrenAttribute GetAllowChildren(this Type type)
    {
      return type.GetObjectCustomAttribute<AllowChildrenAttribute>();
    }
    public static AllowChildrenAttribute GetAllowChildren(this object input)
    {
      return input.GetType().GetRealType().GetObjectCustomAttribute<AllowChildrenAttribute>();
    }
    public static bool IsSingleRecordTable(this Type type)
    {
      var a = type.GetAllowChildren();
      if (a == null)
        return false;
      return a.SingleRecord;
    }
    public static bool IsSingleRecordTable(this object input)
    {
      return input.GetType().GetRealType().IsSingleRecordTable();
    }
    public static IEnumerable<string> GetTableList(AllowChildrenAttribute model, IEnumerable<string> defaultList)
    {
      if (model == null || model.TableList == null)
      {
        return defaultList;
      }
      return model.TableList;
    }
    public static IEnumerable<string> GetTableList(Type type, IEnumerable<string> defaultList)
    {
      return GetTableList(type.GetAllowChildren(), defaultList);
    }

    public static string GetModelTitle(this string key)
    {
      if (modelService.ModelMapper.ContainsKey(key))
      {
        var type = modelService.ModelMapper[key];

        var allow = type.GetAllowChildren();
        if (allow == null || String.IsNullOrEmpty(allow.Name))
        {
          return key.SpacesFromCamel();
        }
        return allow.Name.SpacesFromCamel();
      }

      return key;
    }
    public static string GetModelTitleFullType(string fullName, string assemName)
    {
      var type = Type.GetType($"{fullName},{assemName}");
      if (type != null)
      {
        var allow = type.GetAllowChildren();
        if (allow == null || String.IsNullOrEmpty(allow.Name))
        {
          return type.Name.SpacesFromCamel();
        }
        return allow.Name.SpacesFromCamel();
      }

      return "";
    }
    public static string ImagePath(this string path)
    {
      if (string.IsNullOrEmpty(path))
      {
        return path;
      }
      var paths = path.Split('/', '\\').ToList();
      if (paths[0] != config.FileUploadPath)
      {
        paths.Insert(0, config.FileUploadPath);
      }
      return String.Join("/", paths);
    }
  }
}