using System.Reflection;

namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Type subClassType = typeof(SubClass);
            SubClass instance = (SubClass)Activator.CreateInstance(subClassType);

            
            Console.WriteLine("Поля и свойства:");
            foreach (var field in subClassType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                Console.WriteLine($"{field.Name}: {field.GetValue(instance)}");
            }

            foreach (var property in subClassType.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(instance)}");
            }

            Console.WriteLine();

            
            Type baseClassType = typeof(BaseClass);
            FieldInfo privateField = baseClassType.GetField("privateField", BindingFlags.Instance | BindingFlags.NonPublic);
            privateField.SetValue(instance, "Новое значение приватного поля");

            PropertyInfo publicProperty = subClassType.GetProperty("PublicProperty");
            publicProperty.SetValue(instance, "Новое значение публичного свойства");

            Console.WriteLine("Обновленные поля и свойства:");
            foreach (var field in subClassType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                Console.WriteLine($"{field.Name}: {field.GetValue(instance)}");
            }

            foreach (var property in subClassType.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(instance)}");
            }

            Console.WriteLine();

            
            MethodInfo privateMethod = baseClassType.GetMethod("PrivateMethod", BindingFlags.Instance | BindingFlags.NonPublic);
            string privateMethodResult = (string)privateMethod.Invoke(instance, null);
            Console.WriteLine(privateMethodResult);

            MethodInfo publicMethod = subClassType.GetMethod("PublicMethod", BindingFlags.Instance | BindingFlags.Public);
            string publicMethodResult = (string)publicMethod.Invoke(instance, new object[] { "Тестовый ввод" });
            Console.WriteLine(publicMethodResult);

            Console.WriteLine();

            
            Console.WriteLine($"Значение статического поля: {SubClass.StaticProperty}");

            
            instance.Dispose();
            Console.WriteLine($"Значение статического поля после вызова статического метода: {SubClass.StaticProperty}");
        }
    }
}