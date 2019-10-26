using System;
using System.Collections.Generic;

namespace ReflectIt
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeList = CreateCollection(typeof(List<>), typeof(Employee));
            Console.WriteLine(employeeList.GetType().Name);
            Console.WriteLine(employeeList.GetType().FullName);
            var genericArguments = employeeList.GetType().GenericTypeArguments;

            foreach (var arg in genericArguments)
            {
                Console.WriteLine("[{0}]", arg.Name);
            }
            Console.WriteLine();
        }

        private static object CreateCollection(Type collectionType, Type itemType)
        {
            var closedType = collectionType.MakeGenericType(itemType);
            return Activator.CreateInstance(closedType);
        }
    }

    public class Employee
    {
        public string Name { get; set; }
    }
}
