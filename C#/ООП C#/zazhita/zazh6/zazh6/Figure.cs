using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zazh6 {
    abstract class Figure {
        public abstract double Area();
        public abstract void Show();
        public static void Fill(List<Figure>f,int n) {
            Random rnd=new Random();
            for (int i=0;i<n; i++)
            {
                f.Add(new Square(rnd.Next(1, 50)));
                f.Add(new Rectangle(rnd.Next(1, 50), rnd.Next(1, 50)));
                f.Add(new Triangle(rnd.Next(20, 50), rnd.Next(20, 50), rnd.Next(20, 50)));

            }
        }
        public static void Show(List<Figure> f) {
            foreach (Figure ff in f)
            {
                ff.Show();

            }
        }
    }
}
