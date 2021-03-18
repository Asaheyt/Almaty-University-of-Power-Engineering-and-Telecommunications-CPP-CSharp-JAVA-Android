using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4_a_ {
    class Program {
        static void Main(string[] args) {
            Project a = new Project();
            Date d1 = new Date(26, 10, 2015);
            Date d2 = new Date(15, 4, 2014);
            Date d3 = new Date(19, 12, 2007);
            Programer x1 = new Programer("АУЭС", "Технологичекое", 2, d1, "Java");
            Programer x2 = new Programer("КБТУ", "Технологичекое", 3, d2, "Python");
            Programer x3 = new Programer("МУИТ", "Технологичекое", 1, d3, "C");
            a.Add(x2);
            a.Add(x1);
            a.Add(x3);
            a.Show();
            Console.WriteLine("После сортировки");
            a.Sort();
            a.Show();
            Console.ReadKey();
        }
    }
}
