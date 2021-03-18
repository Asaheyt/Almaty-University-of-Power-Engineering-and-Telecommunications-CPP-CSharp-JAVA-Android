using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace _1212
{
    public partial class MyForm : Form
    {

        SqlDataAdapter da;
        DataTable dt;

        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Istrebitel;Integrated Security=True";
        public MyForm()
        {
            InitializeComponent();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
 
        SqlConnection myConnection = new SqlConnection(connectionString);
 
        myConnection.Open();
 
        string query = "SELECT * FROM Istreb ORDER BY NumberOfIstreb";
 
        SqlCommand command = new SqlCommand(query, myConnection);
 
        SqlDataReader reader = command.ExecuteReader();
 
        List<string[]> data = new List<string[]>();
 
        while (reader.Read())
        {
            data.Add(new string[4]);
 
            data[data.Count - 1][0] = reader[0].ToString();
            data[data.Count - 1][1] = reader[1].ToString();
            data[data.Count - 1][2] = reader[2].ToString();
            data[data.Count - 1][3] = reader[3].ToString();
            }
 
        reader.Close();
 
        myConnection.Close();
 
        foreach (string[] s in data)
            dataGridView1.Rows.Add(s);
           /* string sqlExpression = "SELECT * FROM Istreb";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                {
                    // выводим названия столбцов
                    Console.WriteLine("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));

                    while (reader.Read()) // построчно считываем данные
                    {
                        object NumberOfIstreb = reader.GetValue(0);
                        object NameOfIstreb = reader.GetValue(1);
                        object AgeOfIstreb = reader.GetValue(2);
                        object Country = reader.GetValue(3);

                        foreach (var line in dataGridView1.ReadOnly("File.txt"))
                        {
                            var array = line.Split();
                            dataGridView1.Rows.Add(array);
                        }

                        Console.WriteLine("  {0}          \t{1}    \t{2}        \t{3}", NumberOfIstreb, NameOfIstreb, AgeOfIstreb,Country);
                    }
                }
                reader.Close();
            }

            Console.Read();

            */
        }

        private void button3_Click(object sender, EventArgs e)
        {
            

            string sqlExpression = String.Format("INSERT INTO Istreb (NumberOfIstreb,NameOfIstreb, AgeOfIstreb,Country) VALUES ('{0}', '{1}','{2}','{3}')", textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // добавление
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                int number = command.ExecuteNonQuery();
                Console.WriteLine("Добавлено объектов: {0}", number);
                connection.Close();
                // обновление ранее добавленного объекта
           /*     Console.WriteLine("Введите новое имя:");
                NameOfIstreb = Console.ReadLine();
                sqlExpression = String.Format("UPDATE Istreb SET NameOfIstreb='{0}' WHERE AgeOfIstreb={1}", NameOfIstreb, AgeOfIstreb);
                command.CommandText = sqlExpression;
                number = command.ExecuteNonQuery();
                Console.WriteLine("Обновлено объектов: {0}", number);*/
            }
            Console.Read();
        }

      

     

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sda.DeleteCommand = new SqlCommand("delete  from Istreb where NumberOfIstreb=@NumberOfIstreb", connection);
                    sda.DeleteCommand.Parameters.Add("@NumberOfIstreb", SqlDbType.Int).Value = Convert.ToInt32(textBox1.Text);
                    connection.Open();
                    sda.DeleteCommand.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
