using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zazh6 {
    class Square : Figure,IFigure {
        private double a;
        public Square() { }
        public Square(double x) {
            a = x;
        }
        public void SetA(double x) {
            a = x;
        }
        public double GetA() {
            return a;
        }
        public override void Show() {
            Console.WriteLine("Квадрат. Площадь: " + this.Area());
        }
        public override double Area() {
            return a * a;
        }
        public  void Show1() {
            Console.WriteLine("Квадрат. Площадь: " + this.Area1());
        }
        public double Area1() {
            return a * a;
        }
    }
}
