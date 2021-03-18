using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    [Serializable]
    class Kafedra
    {
        public ArrayList prepods
        {
            set;
            get;
        }
        public void add(Prepod a)
        {
            prepods.Add(a.Clone());
        }
        public void removeLast()
        {
            prepods.RemoveAt(prepods.Count-1);
        }
        public void removeAll()
        {
            prepods.Clear();
        }
        public override string ToString()
        {
            string str = "";
            if (prepods.Count > 0)
            {
                Int32 i = 1;
                foreach (Prepod a in prepods)
                {
                    str += i + ". " + a.ToString() + '\n';
                    i++;
                }
            }
            else 
            {
                str += "В списке нет ни одного Преподавателя"; 
            }
            return str; 
        }
        public void sort()
        {
            prepods.Sort();
        }
        class Revers : IComparer
        {
            Int32 IComparer.Compare(Object a, Object b)
            {
                return (new CaseInsensitiveComparer()).Compare(b, a);
            }
        }
        public void resort()
        {
            IComparer reverse = new Revers();
            prepods.Sort(reverse);
        }
        public Kafedra() 
        {
            prepods = new ArrayList();
        }
        public ArrayList removeDouble()
        {
            ArrayList newArray = new ArrayList();
            foreach ( Prepod a in prepods)
            {
                if(!newArray.Contains(a))
                {
                    newArray.Add(a);
                }
            }
            return newArray;
        }
        public void save(string filename)
        {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (Stream wstream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                binFormatter.Serialize(wstream, this);
            }
        }
        static public Kafedra read(string filename)
        {
            Kafedra t;
            BinaryFormatter binFormatter = new BinaryFormatter();
            using(Stream rstream = File.OpenRead(filename))
            {
                t = (Kafedra)binFormatter.Deserialize(rstream);
            }
            return t;
        }

        //
        /* public void save1(string filename)
         {
             BinaryFormatter binFormatter = new BinaryFormatter();
             using (Stream wstream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
             {
                 binFormatter.Serialize(wstream, this);
             }
         }
         public Kafedra read1(string filename)
         {
             Kafedra t;
             BinaryFormatter binFormatter = new BinaryFormatter();
             using (Stream rstream = File.OpenRead(filename))
             {
                 t = (Kafedra)binFormatter.Deserialize(rstream);
             }
             return t;
         }*/

        static public Kafedra  read1(string filename)
        {
            Kafedra t = new Kafedra();
            Prepod a = new Prepod();
            BinaryFormatter binFormatter = new BinaryFormatter();
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Test;Integrated Security=False";
            string sqlExpression = "SELECT * FROM Table_2";
            using (SqlConnection connection = new SqlConnection(connectionString) )
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows) // если есть данные
                { 
                    // выводим названия столбцов
                   // Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3), reader.GetName(4));
                    while (reader.Read()) // построчно считываем данные
                    {
                       a.Name = Convert.ToString(reader.GetValue(0));
                       // a.Year = Convert.ToInt32(reader.GetValue(1));
                        a.Zp = Convert.ToInt32(reader.GetValue(2));
                        a.Spec = Convert.ToString(reader.GetValue(3));
                        a.Year = Convert.ToInt32(reader.GetValue(1));

                       // Console.WriteLine("{0} \t{1} \t{2} \t{3} \t{4}", name, age, zp, dis, date);
                    }
                }

                reader.Close();
            }
            return t;
        }


        public void Fill(int num)
        {
            Random rnd = new Random();
            Prepod x = new Prepod();

            String[] names = { "Petr", "Vlad", "Vasiliy", "Maks", "Ali", "Madi", "Dos", "Nick" };
            String[] specs = { "VT", "PS", "VT,PS", "IS", "IS,VT", "IS,PS", "SIB", "SIB,VT,IS", "SIB,PS" };
            for (int i = 0; i < num; i++)
            {
                x.SetAge(rnd.Next(22, 65)); x.SetName(names[rnd.Next(0, 7)]);
                x.SetNpar(rnd.Next(60000, 500000)); x.SetSpec(specs[rnd.Next(0, 8)]);
                prepods.Add((Prepod)x.Clone());
            }
        }
    }
}
