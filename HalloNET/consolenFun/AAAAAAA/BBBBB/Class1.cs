using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consolenFun.AAAAAAA.BBBBB
{
    internal class Class1
    {
        int _zahl;

        public string? Name { get; set; }

        public Class1? MyProperty { get; set; }

        public int Zahl { get => _zahl; set => _zahl = value; }



        public IQueryable<Class1> Dings(int zahl)
        {
            _zahl += zahl;
            Console.WriteLine(Name);
            return new List<Class1>().AsQueryable<Class1>();
        }

    }
}
