using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zazh6 {
    class Triangle : Figure, IFigure {
        private double a, b, c;
        private int v;

        public Triangle() { }
        public Triangle(double x, double y,double z) {
            a = x;
            b = y;
            c = z;
        }
        public void SetA(double x) {
            a = x;
        }
        public double GetA() {
            return a;
        }
        public void SetB(double y) {
            b = y;
        }
        public double GetB() {
            return b;
        }
        public void SetC(double z) {
            c = z;
        }
        public double GetC() {
            return c;
        }
        public override void Show() {
            Console.WriteLine("Треугольник. Площадь: " + this.Area());
        }
        public override double Area() {
            double p;
            p = (a + b + c) / 2;
            return Math.Sqrt(p*(p-a) *(p- b) * (p-c));
        }
        public void Show1() {
            Console.WriteLine("Треугольник. Площадь: " + this.Area1());
        }
        public double Area1() {
            double p;
            p = (a + b + c) / 2;
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
