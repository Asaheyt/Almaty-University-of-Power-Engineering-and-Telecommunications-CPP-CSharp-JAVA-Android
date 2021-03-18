using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7_a_ {
    class Program {
        [STAThread]
        static void Main(string[] args) {
            /*Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IndexForm());*/
            Client.Run();
            Console.ReadKey();
        }
    }
}
