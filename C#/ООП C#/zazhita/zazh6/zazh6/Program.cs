using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zazh6 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Абстрактный класс"+"\n");
            List<Figure> f = new List<Figure>();
            Figure.Fill(f, 5);
            Figure.Show(f);

            Console.WriteLine("\n\n Интерфейс"+"\n");
            List<IFigure> f1=new List<IFigure>();
            IFigure_Class.Fill(f1, 5);
            IFigure_Class.Show(f1);


            Console.ReadKey();
        }
    }
}
