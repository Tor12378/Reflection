using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp18
{
    public class BaseClass
    {
        private string privateField;

        public BaseClass()
        {
            privateField = "Значение приватного поля";
        }

        public string PublicProperty { get; set; }

        private string PrivateMethod()
        {
            return "Вызван приватный метод";
        }

        public string PublicMethod(string input)
        {
            return $"Вызван публичный метод с параметром: {input}";
        }
    }

}
