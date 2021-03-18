using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7_a_ {
    class Program {
        static void Main(string[] args) {
            Project a = new Project();
            a.Fill(10);
            a.Show();
            Console.WriteLine(" \n");
            a.save("tbd.txt");
            Project b = new Project();
            b=Project.read("tbd.txt");
            b.Show();
            Console.ReadKey();
        }
    }
}
