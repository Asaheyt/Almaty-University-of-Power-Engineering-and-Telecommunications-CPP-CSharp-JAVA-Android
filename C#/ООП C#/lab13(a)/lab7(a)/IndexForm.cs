using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace lab7_a_ {
    class IndexForm:Form {
        public Project t { private set; get; }


        private Button save;
        private Button read;
        private Button uppend;
        private Button show;
        private Button add;
        private Button remove_all;
        private Button remove_last;
        private Button remove_doubles;
        private Button sort;
        private Button reverse_sort;
        private MyForm myForm;
        private Button save1;
        private Button read1;
        private MyForm1 myForm1;
        private Button delete1;
        private TextBox textBox1;



        public IndexForm() {
            //Win32.AllocConsole();

            t = new Project();

            this.Text = "Галвная форма.";
            this.Size = new Size(1000, 700); //260
            this.CenterToScreen();



            save = new Button();
            save.Parent = this;
            save.Text = "Сохранить";
            save.Size = new Size(100, 50);
            save.Location = new Point(160, 150);
            save.Click += new EventHandler(Click_Save);

            read = new Button();
            read.Parent = this;
            read.Text = "Читать файл";
            read.Size = new Size(100, 50);
            read.Location = new Point(55, 150);
            read.Click += new EventHandler(Click_Read);

            add = new Button();
            add.Parent = this;
            add.Text = "Доб. прог.";
            add.Size = new Size(75, 35);
            add.Location = new Point(10, 30);
            add.Click += new EventHandler(Click_Add);

            show = new Button();
            show.Parent = this;
            show.Text = "Показать";
            show.Size = new Size(75, 35);
            show.Location = new Point(10, 70);
            show.Click += new EventHandler(Click_Show);

            uppend = new Button();
            uppend.Parent = this;
            uppend.Text = "Добавить к списку";
            uppend.Size = new Size(75, 35);
            uppend.Location = new Point(90, 30);
            uppend.Click += new EventHandler(Click_Append);

            remove_all = new Button();
            remove_all.Parent = this;
            remove_all.Text = "Очистить";
            remove_all.Size = new Size(75, 35);
            remove_all.Location = new Point(90, 70);
            remove_all.Click += new EventHandler(Click_RemoveAll);

            remove_last = new Button();
            remove_last.Parent = this;
            remove_last.Text = "Удал. посл.";
            remove_last.Size = new Size(75, 35);
            remove_last.Location = new Point(170, 70);
            remove_last.Click += new EventHandler(Click_RemoveLast);

            remove_doubles = new Button();
            remove_doubles.Parent = this;
            remove_doubles.Text = "Удал. дубл.";
            remove_doubles.Size = new Size(75, 35);
            remove_doubles.Location = new Point(250, 70);
            remove_doubles.Click += new EventHandler(Click_RemoveDoubles);

            sort = new Button();
            sort.Parent = this;
            sort.Text = "Сорт.";
            sort.Size = new Size(75, 35);
            sort.Location = new Point(170, 30);
            sort.Click += new EventHandler(Click_Sort);

            reverse_sort = new Button();
            reverse_sort.Parent = this;
            reverse_sort.Text = "Обр.сорт.";
            reverse_sort.Size = new Size(75, 35);
            reverse_sort.Location = new Point(250, 30);
            reverse_sort.Click += new EventHandler(Click_ReverseSort);

            dtable.Columns.Add(new DataColumn("#", Type.GetType("System.Int32")));
            dtable.Columns.Add(new DataColumn("ВУЗ", Type.GetType("System.String")));
            dtable.Columns.Add(new DataColumn("Направление", Type.GetType("System.String")));
            dtable.Columns.Add(new DataColumn("Категория", Type.GetType("System.Int32")));
            DataGrd.DataSource = dtable;
            DataGrd.Parent = this;
            DataGrd.Size = new Size(450, 500);
            DataGrd.Location = new Point(400, 20);
            //DataGrd.ColumnCount = 4;
            //DataGrd.Columns[1].Width = 30;
            //DataGrd.Columns[].Width = ;
            //DataGrd.Columns[].Width = ;
            //DataGrd.Columns[].Width = ;

            InTable.Text = "В таблицу";
            InTable.Parent = this;
            InTable.Location = new Point(10, 330);
            InTable.Click += new EventHandler(InTable_Click);

            OutTable.Text = "Из таблицы";
            OutTable.Parent = this;
            OutTable.Location = new Point(100, 330);
            OutTable.Click += new EventHandler(OutTable_Click);

            SortTable.Parent = this;
            SortTable.Location = new Point(190, 330);
            SortTable.Text = "Сорт. табл.";
            SortTable.Click += new EventHandler(SortTable_Click);

            save1 = new Button();
            save1.Parent = this;
            save1.Text = "Доб. прог. в SQL";
            save1.Size = new Size(100, 50);
            save1.Location = new Point(160, 220);
            save1.Click += Save1_Click;

            read1 = new Button();
            read1.Parent = this;
            read1.Text = "Из SQL";
            read1.Size = new Size(100, 50);
            read1.Location = new Point(55, 220);
            read1.Click += Read1_Click;

            delete1 = new Button();
            delete1.Parent = this;
            delete1.Text = "Удал. прог. в SQL";
            delete1.Size = new Size(100, 50);
            delete1.Location = new Point(160, 280);
            delete1.Click += delete1_Click;

            textBox1 = new TextBox();
            textBox1.Parent = this;
            textBox1.Location = new Point(55, 280);

        }

        /*public Int32 CompareTo(Object obj)
        {
            DataRow rowToSort = (DataRow)obj;

            return this.name.CompareTo(s.name);
        }*/

        void SortTable_Click(object sender, EventArgs e) {
            dtable.DefaultView.Sort = "ВУЗ";
        }

        void OutTable_Click(object sender, EventArgs e) {
            t.Clear();
            for (Int32 d = 0; d < dtable.Rows.Count; d++)
            {
                Programer aaa = new Programer();
                DataRow rowToOut = dtable.Rows[d];
                aaa.SetInstitute_of_high_learning(  (String)rowToOut["ВУЗ"]);
                aaa.SetDirection( (string)rowToOut["Направление"]);
                aaa.SetCategory((Int32)rowToOut["Категория"]);
                t.Add(aaa);
            }

        }

        void InTable_Click(object sender, EventArgs e) {
            while (dtable.Rows.Count > 0)
            {
                dtable.Rows.RemoveAt(dtable.Rows.Count - 1);
            }
            for (Int32 g = 0; g < t.GetProgramers().Count; g++)
            {
                Programer aa = new Programer();
                aa = (Programer)t.GetProgramers()[g];

                DataRow rowToAdd = dtable.NewRow();
                rowToAdd["#"] = g + 1;
                rowToAdd["ВУЗ"] = aa.GetInstitute_of_high_learning();
                rowToAdd["Направление"] = aa.GetDirection();
                rowToAdd["Категория"] = aa.GetCategory();

                dtable.Rows.InsertAt(rowToAdd, g + 1);
                dtable.NewRow();

            }

        }

        DataGridView DataGrd = new DataGridView();
        DataTable dtable = new DataTable();
        Button InTable = new Button();
        Button OutTable = new Button();
        Button SortTable = new Button();


        private void Click_Save(object sender, EventArgs arg) {
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.InitialDirectory = Application.StartupPath;
            fileDialog.Filter = "txt files (*.txt)|*.txt";
            fileDialog.FilterIndex = 1;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    t.save(fileDialog.FileName);
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void Click_Read(object sender, EventArgs arg) {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Application.StartupPath;
            fileDialog.Filter = "txt files (*.txt)|*.txt";
            fileDialog.FilterIndex = 1;
            fileDialog.RestoreDirectory = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    t = Project.read(fileDialog.FileName);
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void Click_Append(object sender, EventArgs arg) {

            Project sp;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Application.StartupPath;
            fileDialog.Filter = "txt files (*.txt)|*.txt";
            fileDialog.FilterIndex = 1;
            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    sp = Project.read(fileDialog.FileName);
                    
                    foreach (Programer p in sp.GetProgramers())
                    {
                        t.Add(p);
                    }
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message);
                }
                catch (ArgumentNullException e)
                {
                    MessageBox.Show(e.Message);
                }
                catch (NotSupportedException e)
                {
                    MessageBox.Show(e.Message);
                }
            }

        }

        private void Click_Add(object sender, EventArgs arg) {
            myForm = new MyForm(this);
            myForm.Activate();
            myForm.Visible = true;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                this.Controls[i].Enabled = false;
            }
        }

        private void Click_Show(object sender, EventArgs arg) {
            t.Show();
        }
        private void Click_RemoveAll(object sender, EventArgs arg) {
            t.Clear();
        }

        private void Click_RemoveLast(object sender, EventArgs arg) {
            t.DelLast();
        }

        private void Click_RemoveDoubles(object sender, EventArgs arg) {
            t.DelDupl();
        }

        private void Click_Sort(object sender, EventArgs arg) {
            t.Sort();
        }

        private void Click_ReverseSort(object sender, EventArgs arg) {
            t.Reverse();
        }
        private void Read1_Click(object sender, EventArgs e) {
            /*OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = Application.StartupPath;
            fileDialog.Filter = "mdf files (*.mdf)|*.mdf";
            fileDialog.FilterIndex = 1;
            fileDialog.RestoreDirectory = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
            // t = Kafedra.read(fileDialog.FileName);
              Kafedra.read1(fileDialog.FileName);
               
            }*/
            Programer a = new Programer();
            string connectionString = "server=localhost;user=root;database=13;password=123456789;";
            string sqlExpression = "SELECT * FROM table13";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlExpression, connection);
                MySqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    dtable.Clear();
                    // выводим названия столбцов
                    // Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4));
                    while (reader.Read()) // построчно считываем данные
                    {
                        object IHL = reader.GetValue(0);
                        object Dir = reader.GetValue(1);
                        object cat = reader.GetValue(2);
                        

                        Int32 g = 0;
                        DataRow rowToAdd = dtable.NewRow();
                        rowToAdd["#"] = dtable.Rows.Count + 1;
                        rowToAdd["ВУЗ"] = IHL;
                        rowToAdd["Направление"] = Dir;
                        rowToAdd["Категория"] = cat;
                        

                        dtable.Rows.InsertAt(rowToAdd, g + 1);
                        dtable.NewRow();


                        // Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4}", name, age, zp, dis, date);
                    }
                    reader.Close();
                }
                
                connection.Close();
            }
        }

        private void Save1_Click(object sender, EventArgs e) {
            myForm1 = new MyForm1(this);
            myForm1.Activate();
            myForm1.Visible = true;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                this.Controls[i].Enabled = false;
            }
        }
        private void delete1_Click(object sender, EventArgs e) {
            string connectionString = "server=localhost;user=root;database=13;password=123456789;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlDataAdapter sda = new MySqlDataAdapter())
                {
                    sda.DeleteCommand = new MySqlCommand("delete  from table13 where IHL=@IHL", connection);
                    sda.DeleteCommand.Parameters.Add("@IHL", MySqlDbType.VarChar,50).Value = Convert.ToString(textBox1.Text);
                    connection.Open();
                    sda.DeleteCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
        //-----------------------------------------------------------------------------------------------------

    }
}
