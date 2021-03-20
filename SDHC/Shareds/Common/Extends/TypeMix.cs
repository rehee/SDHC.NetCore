using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
namespace System
{
  public static class TypeMixer<T>
  {
    public static readonly BindingFlags visibilityFlags = BindingFlags.Public | BindingFlags.Instance;
    public static K ExtendWith<K>(IDictionary<string, dynamic> source = null)
    {
      var assemblyName = new Guid().ToString();
      var assembly = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(assemblyName), AssemblyBuilderAccess.Run);
      var module = assembly.DefineDynamicModule("Module");
      var type = module.DefineType(typeof(T).Name + "_" + typeof(K).Name, TypeAttributes.Public, typeof(T));
      var fieldsList = new List<string>();
      type.AddInterfaceImplementation(typeof(K));
      var kType = typeof(K);
      var allvs = kType.GetProperties().ToList();
      kType.GetInterfaces().ToList().SelectMany(i => i.GetProperties()).ToList().ForEach(b => allvs.Add(b));

      foreach (var v in allvs)
      {
        fieldsList.Add(v.Name);
        var field = type.DefineField("_" + v.Name.ToLower(), v.PropertyType, FieldAttributes.Private);
        var property = type.DefineProperty(v.Name, PropertyAttributes.None, v.PropertyType, new Type[0]);
        var getter = type.DefineMethod("get_" + v.Name, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.Virtual, v.PropertyType, new Type[0]);
        var setter = type.DefineMethod("set_" + v.Name, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.Virtual, null, new Type[] { v.PropertyType });
        var getGenerator = getter.GetILGenerator();
        var setGenerator = setter.GetILGenerator();
        getGenerator.Emit(OpCodes.Ldarg_0);
        getGenerator.Emit(OpCodes.Ldfld, field);
        getGenerator.Emit(OpCodes.Ret);
        setGenerator.Emit(OpCodes.Ldarg_0);
        setGenerator.Emit(OpCodes.Ldarg_1);
        setGenerator.Emit(OpCodes.Stfld, field);
        setGenerator.Emit(OpCodes.Ret);
        property.SetGetMethod(getter);
        property.SetSetMethod(setter);
        type.DefineMethodOverride(getter, v.GetGetMethod());
        type.DefineMethodOverride(setter, v.GetSetMethod());
      }
      //if (source != null)
      //{
      //  foreach (var v in source.GetType().GetProperties())
      //  {
      //    if (fieldsList.Contains(v.Name))
      //    {
      //      continue;
      //    }
      //    fieldsList.Add(v.Name);
      //    var field = type.DefineField("_" + v.Name.ToLower(), v.PropertyType, FieldAttributes.Private);
      //    var property = type.DefineProperty(v.Name, PropertyAttributes.None, v.PropertyType, new Type[0]);
      //    var getter = type.DefineMethod("get_" + v.Name, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.Virtual, v.PropertyType, new Type[0]);
      //    var setter = type.DefineMethod("set_" + v.Name, MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.Virtual, null, new Type[] { v.PropertyType });
      //    var getGenerator = getter.GetILGenerator();
      //    var setGenerator = setter.GetILGenerator();
      //    getGenerator.Emit(OpCodes.Ldarg_0);
      //    getGenerator.Emit(OpCodes.Ldfld, field);
      //    getGenerator.Emit(OpCodes.Ret);
      //    setGenerator.Emit(OpCodes.Ldarg_0);
      //    setGenerator.Emit(OpCodes.Ldarg_1);
      //    setGenerator.Emit(OpCodes.Stfld, field);
      //    setGenerator.Emit(OpCodes.Ret);
      //    property.SetGetMethod(getter);
      //    property.SetSetMethod(setter);
      //  }
      //}
      var newObject = (K)Activator.CreateInstance(type.CreateTypeInfo());
      return source == null ? newObject : CopyValues(source, newObject);
    }
    private static K CopyValues<K>(IDictionary<string, object> source, K destination)
    {
      var sourceType = source.GetType();
      var sourceList = sourceType.GetProperties();
      foreach (PropertyInfo property in destination.GetType().GetProperties(visibilityFlags))
      {
        if (property.CanWrite && source.Keys.Contains(property.Name.ToLower()))
        {
          property.SetValue(destination, source[property.Name.ToLower()], null);
        }

      }
      return destination;
    }
  }
}