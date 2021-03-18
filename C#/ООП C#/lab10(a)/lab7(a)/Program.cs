using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            string connectString = @"Data Source=.\SQLEXPRESS; Initial Catalog=12.mdf; Integrated Security=True";
            SqlConnection baza = new SqlConnection(connectString);
            baza.Open();
            Console.WriteLine(baza.Database);
            baza.Close();
            Console.ReadKey();
        }
    }
}
