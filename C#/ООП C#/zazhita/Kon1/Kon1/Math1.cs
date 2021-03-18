using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kon1
{
    class Math1
    {
        public static double Exp(double x)
        {
            double a, n;
            double eps = 0.00000001;
            double y;
            a = 1;
            y = a;
            n = 1;
            while (Math.Abs(a) > eps)
            {
                a = a * x / n;
                y = y + a;
                n++;
            }
            return y;
        }
        public static double Sin(double x)
        {
            double a, b, eps, c;
            double y, y1, M_PI=3.14159265358;
            int n;
            double g;
            eps = 0.00000001;
            g = x;
            while (g < 0)
            {
                g = g + 2 * M_PI;
            }
            while (g > 2 * M_PI)
            {
                g = g - 2 * M_PI;
            }
            a = g;
            y = a;
            n = 1;
            while (Math.Abs(a) > eps)
            {
                a = a * (-1) * g * g / (2 * n * (2 * n + 1));
                y = y + a;
                n++;
            }
            return y;
        }
        public static double Vvod()
        {
            double x=0;
            bool OK=false;
            while (!OK)
            {
                try
                {
                    Console.WriteLine("Введите X");
                    x = Convert.ToDouble(Console.ReadLine());
                    OK = true;
                }
                catch
                {
                    Console.WriteLine("Ошибка! Введите заново:");
                    OK = false;
                }
            }
            return x;
        }


    }
}
