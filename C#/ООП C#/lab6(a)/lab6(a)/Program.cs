using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_a_ {
    class Program {
        static void Main(string[] args) {
            Complex x = new Complex();
            x.Read();
            Complex b = new Complex();
            b = ((1.0 / Complex.Ln_Dou(2.0)) * Complex.Ln_Com(3.0 * x + 7.0)) / Complex.Tg_Com(3.0* x);
            b.Show();

            Console.ReadKey();
        }
    }
}
