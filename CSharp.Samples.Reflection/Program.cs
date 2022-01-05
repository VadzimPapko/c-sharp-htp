using System;
using System.Linq;
using System.Reflection;

namespace ReflectionSample
{
    class Program
    {
        static void Main()
        {
            #region Work with Assemblies

            Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                Show(0, "Assembly: {0}", assembly);

                if (!assembly.FullName.Contains("CSharp.Samples.Reflection", StringComparison.Ordinal)) continue;

                foreach (Type type in assembly.GetTypes())
                {
                    Show(1, "Type: {0}", type);

                    //Getting info about type's members
                    
                    foreach (MemberInfo memberInfo in type.GetTypeInfo().DeclaredMembers)
                    {
                        string typeName = string.Empty;

                        if (memberInfo is Type) typeName = "(Nested) Type";
                        if (memberInfo is FieldInfo) typeName = "FieldInfo";
                        if (memberInfo is MethodInfo) typeName = "MethodInfo";
                        if (memberInfo is ConstructorInfo) typeName = "ConstructorInfo";
                        if (memberInfo is PropertyInfo) typeName = "PropertyInfo";
                        if (memberInfo is EventInfo) typeName = "EventInfo";

                        Show(2, "{0}: {1}", typeName, memberInfo);
                    }
                }
            }
            #endregion

            #region Work with types

            //Create Instance
            Type motoType = typeof(Motorcycle);
            Type ctorParameter = typeof(string); //or Type.GetType("System.String");

            ConstructorInfo ctor = motoType.GetTypeInfo().DeclaredConstructors
                .First(ct => ct.GetParameters().Any() && ct.GetParameters()[0].ParameterType == ctorParameter);

            object[] args = new object[] { "Honda" };
            object obj = ctor.Invoke(args);
            Console.WriteLine($"Current Type - {obj.GetType()}");
            Console.WriteLine(obj.ToString());

            //Read/Write field
            FieldInfo fieldInfo = obj.GetType().GetTypeInfo().GetDeclaredField("_vinNumber");
            Console.WriteLine($"Field - {fieldInfo.Name}");
            Console.WriteLine($"Is Private - {fieldInfo.IsPrivate}");
            fieldInfo.SetValue(obj, 999);
            Console.WriteLine(obj.ToString());

            //Read/Write Property
            PropertyInfo propertyInfo = obj.GetType().GetTypeInfo().GetDeclaredProperty("Model");
            propertyInfo.SetValue(obj, "CB600F");
            Console.WriteLine(propertyInfo.GetValue(obj));

            //Method Call
            MethodInfo methodInfo = obj.GetType().GetTypeInfo().GetDeclaredMethod("GetVinNumber");
            var methodResult = methodInfo.Invoke(obj, null);
            Console.WriteLine($"Current VinNUmber - {methodResult}");

            #endregion

            Console.Read();
        }

        static void Show(int indent, string format, params object[] args)
        {
            Console.WriteLine(new String(' ', 3 * indent) + format, args);
        }
    }
}
