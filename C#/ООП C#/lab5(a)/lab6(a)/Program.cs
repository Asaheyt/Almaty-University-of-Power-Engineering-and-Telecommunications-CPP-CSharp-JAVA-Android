using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_a_ {
    class Program {
        static void Main(string[] args) {
            Project a = new Project();
            Project b = new Project();
            Project c = new Project();
            a.Fill(5);
            a.show();Console.WriteLine();
            b.Fill(5);
            b.show(); Console.WriteLine();
            c=Project.Sum(a,b);
            c.show(); Console.WriteLine();
            c.DelKey(5);
            c.show();
            Console.ReadKey();
        }
    }
}
