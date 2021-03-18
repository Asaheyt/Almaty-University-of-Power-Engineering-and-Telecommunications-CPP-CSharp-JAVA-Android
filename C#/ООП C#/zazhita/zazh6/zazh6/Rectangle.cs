using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zazh6 {
    class Rectangle : Figure, IFigure {
        private double a, b;
        public Rectangle() { }
        public Rectangle(double x,double y) {
            a = x;
            b = y;
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
        public override void Show() {
            Console.WriteLine("Прямоугольник. Площадь: " + this.Area());
        }
        public override double Area() {
            return a * b;
        }
        public void Show1() {
            Console.WriteLine("Прямоугольник. Площадь: " + this.Area1());
        }
        public double Area1() {
            return a * b;
        }
    }
}
