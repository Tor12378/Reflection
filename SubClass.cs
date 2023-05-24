using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    public class SubClass : BaseClass, IDisposable
    {
        private static int staticField = 100;

        public static int StaticProperty { get; set; }

        public SubClass()
        {
            StaticProperty = 200;
        }

        public void Dispose()
        {
            Console.WriteLine("Вызван метод Dispose");
        }
    }
}
