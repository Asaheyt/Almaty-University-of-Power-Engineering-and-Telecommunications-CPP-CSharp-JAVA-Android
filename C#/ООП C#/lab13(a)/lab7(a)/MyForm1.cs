using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7_a_ {
    class MyForm1 : Form {
        private Programer a = null;

        public Programer Programer { private set; get; }

        private IndexForm index1;

        private Label iohl;
        private Label dir;
        private Label cat;
        private TextBox tIOHL;
        private TextBox tDir;
        private TextBox tCat;

        private Button ok;
        private Button cancel;

        DataGridView DataGrd = new DataGridView();
        DataTable dtable = new DataTable();


        public MyForm1(IndexForm index1) {
            this.index1 = index1;

            this.Text = "Новый прог.";
            this.Size = new Size(250, 400);
            this.CenterToParent();

            iohl = new Label();
            iohl.Parent = this;
            iohl.Text = "ВУЗ:";
            iohl.BorderStyle = BorderStyle.None;
            iohl.Location = new Point(10, 10);

            dir = new Label();
            dir.Parent = this;
            dir.Text = "Направление:";
            dir.BorderStyle = BorderStyle.None;
            dir.Location = new Point(10, 60);

            cat = new Label();
            cat.Parent = this;
            cat.Text = "Категория:";
            cat.BorderStyle = BorderStyle.None;
            cat.Location = new Point(10, 110);

            tIOHL = new TextBox();
            tIOHL.Parent = this;
            tIOHL.Location = new Point(10, 35);
            tIOHL.KeyPress += TIOHL_KeyPress;

            tDir = new TextBox();
            tDir.Parent = this;
            tDir.Location = new Point(10, 85);
            tDir.KeyPress += TDir_KeyPress;

            tCat = new TextBox();
            tCat.Parent = this;
            tCat.Location = new Point(10, 135);
            tCat.KeyPress += TCat_KeyPress;

            ok = new Button();
            ok.Parent = this;
            ok.Text = "OK";
            ok.Location = new Point(10, 300);
            ok.Click += new EventHandler(OK_Click);

            cancel = new Button();
            cancel.Parent = this;
            cancel.Text = "Cancel";
            cancel.Location = new Point(130, 100);
            cancel.Click += new EventHandler(Cancel_Click);


            this.FormClosing += new FormClosingEventHandler(E_Close);
        }



        private void TIOHL_KeyPress(object sender, KeyPressEventArgs e) {

            char ch = e.KeyChar;
            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }

        }
        private void TDir_KeyPress(object sender, KeyPressEventArgs e) {

            char ch = e.KeyChar;
            if (!Char.IsLetter(ch) && ch != 8)
            {
                e.Handled = true;
            }

        }
        private void TCat_KeyPress(object sender, KeyPressEventArgs e) {

            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }

        }



        private void E_Close(object sender, EventArgs arg) {
            for (int i = 0; i < index1.Controls.Count; i++)
            {
                index1.Controls[i].Enabled = true;
            }
        }

        private void OK_Click(object sender, EventArgs arg) {
            try
            {
                /////////////////

                string connectionString = "server=localhost;user=root;database=13;password=123456789;";
                
                string sqlExpression = "INSERT INTO table13 (IHL, Dir, Cat, ML, BW) VALUES ('"+Convert.ToString(tIOHL.Text)+ "',' " + Convert.ToString(tDir.Text) + "',' " + Convert.ToInt32(tCat.Text) + "', 'C#', '2015-09-19')";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    // добавление
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);
                    int number = command.ExecuteNonQuery();
                    //Console.WriteLine("Добавлено объектов: {0}", number);
                    connection.Close();
                    // обновление ранее добавленного объекта
                    /*     Console.WriteLine("Введите новое имя:");
                         NameOfIstreb = Console.ReadLine();
                         sqlExpression = String.Format("UPDATE Istreb SET NameOfIstreb='{0}' WHERE AgeOfIstreb={1}", NameOfIstreb, AgeOfIstreb);
                         command.CommandText = sqlExpression;
                         number = command.ExecuteNonQuery();
                         Console.WriteLine("Обновлено объектов: {0}", number);*/
                }


                ////////////////////
                this.Close();
                for (int i = 0; i < index1.Controls.Count; i++)
                {
                    index1.Controls[i].Enabled = true;
                }
            }
            catch (StringException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (IntException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (FormatException e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void Cancel_Click(object sender, EventArgs arg) {
            this.Close();
            for (int i = 0; i < index1.Controls.Count; i++)
            {
                index1.Controls[i].Enabled = true;
            }
        }
        public void setDtable() {
            dtable.Columns.Add(new DataColumn("#", Type.GetType("Int32")));

        }
        public void setDataGrd() {
            DataGrd.DataSource = dtable;
        }
    }
}
