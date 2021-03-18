using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zazh6 {
    class IFigure_Class {
        public static void Fill(List<IFigure> f, int n) {
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                f.Add(new Square(rnd.Next(1, 50)));
                f.Add(new Rectangle(rnd.Next(1, 50), rnd.Next(1, 50)));
                f.Add(new Triangle(rnd.Next(20, 50), rnd.Next(20, 50), rnd.Next(20, 50)));
            }
        }
        public static void Show(List<IFigure> f) {
            foreach (IFigure ff in f)
            {
                ff.Show1();
            }
        }
    }
}
