using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_a_ {
    class Complex {
        protected double x;
        protected double y;
        public Complex(){}
        public Complex(double v, double a)
        {
            x = v;
            y = a;
        }
        public static Complex operator +(Complex a, Complex b) {
            Complex c=new Complex();
            c.x = a.x + b.x;
            c.y = a.y + b.y;
            return c;
        }
        public static Complex operator -(Complex a, Complex b) {
            Complex c = new Complex();
            c.x = a.x - b.x;
            c.y = a.y - b.y;
            return c;
        }
        public static Complex operator *(Complex a, Complex b) {
            Complex c = new Complex();
            c.x = a.x * b.x - a.y * b.y;
            c.y = b.x * a.y + a.x * b.y;
            return c;
        }
        public static Complex operator /(Complex a, Complex b) {
            Complex c = new Complex();
            c.x = (a.x * b.x + a.y * b.y) / (b.x*b.x + b.y*b.y);
            c.y = (a.y * b.x - a.x * b.y) / (b.x * b.x + b.y * b.y);
            return c;
        }
        public static Complex operator *(Complex b, double a) {
            Complex c = new Complex();
            c.x = a * b.x;
            c.y = a * b.y;
            return c;
        }
        public static Complex operator /(Complex b, double a) {
            Complex c = new Complex();
            c.x = b.x / a;
            c.y = b.y / a;
            return c;
        }
        public static Complex operator +(Complex b, double a) {
            Complex c = new Complex();
            c.x = a + b.x;
            c.y = b.y;
            return c;
        }
        public static Complex operator -(Complex b, double a) {
            Complex c = new Complex();
            c.x = b.x - a;
            c.y = b.y;
            return c;
        }
        public static Complex operator *(double a,Complex b ) {
            Complex c = new Complex();
            c.x = a * b.x;
            c.y = a * b.y;
            return c;
        }
        public static Complex operator /(double a, Complex b) {
            Complex c = new Complex();
            c.x = b.x / a;
            c.y = b.y / a;
            return c;
        }
        public static Complex operator +(double a, Complex b) {
            Complex c = new Complex();
            c.x = a + b.x;
            c.y = b.y;
            return c;
        }
        public static Complex operator -(double a, Complex b) {
            Complex c = new Complex();
            c.x = b.x - a;
            c.y = b.y;
            return c;
        }     
        public void Show() {
            Console.WriteLine( "(" + this.x + ";" + this.y + "i)" );
        }
        public void Read() {
            Console.WriteLine("Введите действительную часть:");
            //this.x=Convert.ToDouble(Console.ReadLine());
            this.x = Enter();
            Console.WriteLine("Введите мнимую часть:");
            //this.y = Convert.ToDouble(Console.ReadLine());
            this.y = Enter();
            Console.WriteLine();
        }
        //------------------------------------------------------------------------
        public static Complex Exp_Com(Complex a) {
            Complex b=new Complex();
            b.x = Exp_Dou(a.x) * Cos_Dou(a.y);
            b.y = Exp_Dou(a.x) * Sin_Dou(a.y);
            return b;
        }
        public static Complex Th_Com(Complex a) {
            Complex b, c;
            double d = -1;
            c = a * d;
            b = (Complex.Exp1_Com(a) - Complex.Exp1_Com(c)) / (Complex.Exp1_Com(a) + Complex.Exp1_Com(c));
            return b;
        }
        public static Complex Sin_Com(Complex t) {
            Complex x = new Complex();
            double a = t.x;
            double b = t.y;
            x.x = Sin_Dou(a)*Ch_Dou(b);
            x.y = Sh_Dou(b)*Cos_Dou(a);
            return x;
            /*Complex a=new Complex(), b = new Complex(), c = new Complex();
            Complex y = new Complex(), y1 = new Complex();
            double eps;
            int n;
            Complex g = new Complex();
            eps = 0.001;
            g = t;
            while (Complex.MyABC_Com(g) < 0)
            {
                g = g + 2 * Math.PI;
            }
            while (Complex.MyABC_Com(g) > 2 * Math.PI)
            {
                g = g - 2 * Math.PI;
            }
            a = g;
            y = a;
            n = 1;
            while (Complex.MyABC_Com(a) > eps)
            {
                a = a * (-1) * g * g / (2 * n * (2 * n + 1));
                y = y + a;
                n++;
            }
            return y;*/
        }
        public static Complex Cos_Com(Complex x) {
            Complex t = new Complex();
            double a = x.x;
            double b = x.y;
            t.x = Cos_Dou(a) * Ch_Dou(b);
            t.y = -Sin_Dou(a) * Sh_Dou(b);
            return t;
        }
        public static Complex Ln_Com(Complex a) {
            Complex b=new Complex();
            b.x = Ln_Dou(Pow_Dou(a.x * a.x + a.y * a.y, 0.5));
            b.y = Arctg_Dou(a.y / a.x);
            return b;
        }
        public static Complex Sqrt_Com(Complex a) {
            Complex b=new Complex();
            double r, f;
            r = Pow_Dou(a.x * a.x + a.y * a.y, 0.5);
            f = Arctg_Dou(a.y / a.x);
            b.x = Pow_Dou(r, 0.5) * Cos_Dou(f / 2);
            b.y = Pow_Dou(r, 0.5) * Sin_Dou(f / 2);
            return b;
        }
        public static Complex Pow_Com(Complex a, Complex b) {
            Complex c, d, f;
            d = Ln_Com(a);
            f = d * b;
            c = Exp_Com(f);
            return c;
        }
        public static Complex Log_Com(Complex x) {
            Complex a=new Complex(), b = new Complex();
            Complex y = new Complex(), y1 = new Complex();
            int n, c=2;
            double eps = 0.001;
            a = (x - 1) / (x + 1);
            y = a;
            n = 1;
            b = a;
            while (Complex.MyABC_Com(a) > eps)
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
        public static Complex Exp1_Com(Complex x) {
            Complex a=new Complex(1, 0);
            double eps = 0.001, n;
            Complex y;
            y = a;
            n = 1;
            while (Complex.MyABC_Com(a) > eps)
            {
                a = a * x / n;
                y = y + a;
                n++;
            }
            return y;
        }
        public static double MyABC_Com(Complex a) {
            double r;
            r = Pow_Dou((a.x * a.x + a.y * a.y), 0.5);
            return r;
        }
        public static Complex Sh_Com(Complex x) {
            Complex a, b, c;
            Complex y, y1;
            double eps;
            int n;
            eps = 0.001;
            a = x;
            y = a;
            n = 1;
            while (Complex.MyABC_Com(a) > eps)
            {
                a = a * x * x / (2 * n * (2 * n + 1));
                y = y + a;
                n++;
            }
            return y;
        }
        public static Complex Tg_Com(Complex a) {
            Complex r;
            r = Sin_Com(a) / Cos_Com(a);
            return r;
        }
        //------------------------------------------------------------------------------
        public static double Exp_Dou(double x) {
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
        public static double Cos_Dou(double x) {
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
        public static double Sin_Dou(double x) {
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
        public static double Ln_Dou(double x) {
            double a, b, eps, c = 2;
            double y, y1;
            int n;
            eps = 0.00001;
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
        public static double Arctg_Dou(double x) {
            double y=0;
            if (Math.Abs(x) < 1)
            {
                double a, c, eps;
                int n;
                eps = 0.000001;
                a = x;
                y = a;
                n = 1;
                c = 1;
                while (Math.Abs(a) > eps)
                {
                    a = a * (-1) * x * x * c / (2 * n + 1);
                    y = y + a;
                    c = 2 * n + 1;
                    n++;
                }
            }
            else
                if (Math.Abs(x) >= 1)
            {
                double a, b, eps, c;
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
                    c = (2 * n + 1);
                    n++;
                }
                a = -(1 / x);
                if (a < 0)
                {
                    y = Math.PI/2 + y;
                }
                else if (a > 0)
                {
                    y = y - Math.PI / 2;
                }
            }
            return y;
        }
        public static double Ch_Dou(double x) {
            double a, b, eps, c;
            double y, y1;
            int n;
            double g;
            eps = 0.000001;
            a = 1;
            y = a;
            n = 0;
            g = x;
            while (Math.Abs(a) > eps)
            {
                if (n == 0)
                {
                    a = a * g * g / 2;
                }
                else if (n >= 1)
                {
                    a = a * g * g / ((2 * n + 2) * (2 * n + 1));
                }
                y = y + a;
                n++;
            }

            return y;
        }
        public static double Sh_Dou(double x) {
            double a, b, eps, c;
            double y, y1;
            int n;
            eps = 0.00000001;
            a = x;
            y = a;
            n = 1;
            while (Math.Abs(a) > eps)
            {
                a = a * x * x / (2 * n * (2 * n + 1));
                y = y + a;
                n++;
            }
            return y;
        }
        public static double Pow_Dou(double a, double b) {
            return Complex.Exp_Dou(b * Complex.Ln_Dou(a));
        }
        public static double Enter() {
            double x = 0;
            bool OK = false;
            while (!OK)
            {
                try
                {
                    //Console.WriteLine("Введите значение");
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
