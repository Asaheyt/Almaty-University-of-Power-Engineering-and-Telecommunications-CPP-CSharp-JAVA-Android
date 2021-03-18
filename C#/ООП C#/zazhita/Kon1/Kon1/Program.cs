using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kon1
{
    class Program
    {
        static void Main(string[] args)
        {
            double x;
            x=Math1.Vvod();
            Console.WriteLine("Vstroennaya function");
            Console.WriteLine(Math.Exp(Math.Sin(x)));
            Console.WriteLine("Moya function");
            Console.WriteLine(Math.Exp(Math1.Sin(x)));
            Console.ReadKey();
        }
    }
}
