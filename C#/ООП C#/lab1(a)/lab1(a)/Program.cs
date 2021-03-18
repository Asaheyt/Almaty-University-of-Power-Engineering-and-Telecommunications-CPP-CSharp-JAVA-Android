using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_a_
{
    class Program
    {
        static void Main(string[] args)
        {
            double x;
            //Console.WriteLine("X>=0");
            x = Math1.Enter();
            Console.WriteLine("Моя функция:");
            //Console.WriteLine(Math1.Tan_Dou(Math1.Pow_Dou(x, 0.5)) * Math1.Arcctg_Dou(3 * Math1.Pow_Dou(x, 5)));
            Console.WriteLine(Math1.Th_Dou(Math1.Exp_Dou(x)+1));
            Console.WriteLine("Встроенная функция:");
            //Console.WriteLine(Math.Tan(Math.Sqrt(x)) * (Math.PI / 2 - Math.Atan(3 * Math.Pow(x, 5))));
            Console.WriteLine(Math.Tanh(Math.Exp(x)+1));
            Console.ReadKey();
        }
    }
}
