using System;
using System.Reflection;

namespace ConsoleApp17
{
    class Program
    {
        class Base
        {
            [IgnoreDuringEquals]
            public int Bar { get; set; }
        }

        [Equals(DoNotAddEqualityOperators = true)]
        class MyEquals : Base
        {
            public int Foo { get; set; }
        }

        static void Main(string[] args)
        {
            var type = typeof(MyEquals);

            var properties = type.GetProperties();

            foreach (var property in properties)
            {
                try
                {
                    var attributes = property.GetCustomAttributes();

                    Console.WriteLine($"Succes: {property.Name}");
                }
                catch
                {
                    Console.WriteLine($"Failed: {property.Name}");
                }
            }
        }
    }
}
