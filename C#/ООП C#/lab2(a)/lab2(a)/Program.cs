using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_a_
{
    class Program
    {
        static void Main(string[] args)
        {
            Learner a = new Learner();
            a.setName("Джон");
            a.setAge(45);
            a.show();
            Console.WriteLine();

            Student b = new Student();
            b.read();
            b.show();
            Console.WriteLine();

            Master c = new Master("Майкл", 30, "MIT", 2018, "VTiPO", 2);
            c.show();
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
