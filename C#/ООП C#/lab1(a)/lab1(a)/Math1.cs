using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_a_
{
    class Math1
    {
        public static double Enter(){
            double x = 0;
            bool OK = false;
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
        public static double Pow_Dou(double a, double b){
            return Exp_Dou(b * Ln_Dou(a));
        }
        public static double Ln_Dou(double x){
            double a, b, eps, c=2;
            double y, y1;
            int n;
            eps = 0.0000001;
            a = (x - 1) / (x + 1);
            y = a;
            n = 1;
            b = a;
            while (Math.Abs(a) > eps)
            {
                if (n == 1)
                {
                    a = a * b * (x - 1) / ((x + 1) * (2 * n + 1));
                }
                else
                {
                    a = a * b * (x - 1) * c / ((x + 1) * (2 * n + 1));
                }
                y = y + a;
                c = (2 * n + 1);
                n++;
            }
            y = y * 2;
            return y;
        }
        public static double Exp_Dou(double x){
            double a, n;
            double eps = 0.000000001;
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
        public static double Cos_Dou(double x){
            double a, eps;
            double y;
            int n;
            double g;
            eps = 0.00000001;
            a = 1;
            y = a;
            n = 1;
            g = x;
            while (g < 0)
            {
                g = g + 2 * Math.PI;
            }
            while (g > 2 * Math.PI)
            {
                g = g - 2 * Math.PI;
            }
            while (Math.Abs(a) > eps)
            {
                a = a * (-1) * g * g / ((2 * n) * (2 * n - 1));
                y = y + a;
                n++;
            }
            return y;
        }
        public static double Sin_Dou(double x){
            double a, b, eps, c;
            double y, y1;
            int n;
            double g;
            eps = 0.00000001;
            g = x;
            while (g < 0)
            {
                g = g + 2 * Math.PI;
            }
            while (g > 2 * Math.PI)
            {
                g = g - 2 * Math.PI;
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
        public static double Tan_Dou(double x){
            double a;
            a = Sin_Dou(x) / Cos_Dou(x);
            return a;
        }
        public static double Arctg_Dou(double x){
            double y=x;
            if (Math.Abs(x) < 1)
            {
                double a, eps;
                int n;
                eps = 0.000001;
                a = x;
                y = a;
                n = 1;
                while (Math.Abs(a) > eps)
                {
                    a = a * (-1) * x * x  / (2 * n + 1);
                    y = y + a;
                    n++;
                }
            }
            else
                if (Math.Abs(x) >= 1)
            {
                double a, b, eps ;
                int n;
                eps = 0.000001;
                a = -(1 / x);
                y = a;
                n = 1;
                while (Math.Abs(a) > eps)
                {
                    if (n == 1)
                    {
                        a = a * (-1) / ((2 * n + 1) * x * x);
                    }
                    else if (n > 1)
                    {
                        a = a * (-1)  / ((2 * n + 1) * x * x);
                    }
                    y = y + a;
                    n++;
                }
                a = -(1 / x);
                if (a < 0)
                {
                    y = Math.PI/2 + y;
                }
                else if (a > 0)
                {
                    y = y - Math.PI/2;
                }
            }
            return y;
        }
        public static double Arcctg_Dou(double x){
            double a;
            a = Math.PI / 2 - Arctg_Dou(x);
            return a;
        }
        public static double Th_Dou(double x){
            double a;
            a = (Exp_Dou(x) - Exp_Dou(-1 * x)) / (Exp_Dou(x) + Exp_Dou(-1 * x));
            return a;
        }
    }
}
