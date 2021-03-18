using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zazh4 {
    class Program {
        static void Main(string[] args) {
            List1 a = new List1();
            Date d1 = new Date(26, 10, 2015);
            Date d2 = new Date(15, 4, 2014);
            Date d3 = new Date(19, 12, 2007);
            Student x1 = new Student("АУЭС", "Технологичекое", 2, d1, "Java");
            Student x2 = new Student("КБТУ", "Технологичекое", 3, d2, "Python");
            Student x3 = new Student("МУИТ", "Технологичекое", 1, d3, "C");
            a.Add_List(x2);
            a.Add_List(x1);
            a.Add_List(x3);
            a.Show();
            Console.WriteLine();
            Dictionary1 b= new Dictionary1();
            b.FromListToDictonary(a);
            b.Show();
            Console.ReadKey();
        }
    }
}
