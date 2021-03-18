using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace lab10
{
    // --------------------ARRAY--------------------
    class PArray : BusPark
    {
        int np;
        Bus[] arr = new Bus[50];
        public PArray() { np = 0; }
        public PArray(string n) : base(n) { }
        override public void ReadFromFile()
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "*.fbda;.fbdl|*.fbda;*.fbdl";
            f.ShowDialog();
            bool b = new bool();
            try
            {
                FileStream fs = new FileStream(f.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                b = DeSerialArray(fs, ref arr, ref np);
            }
            catch (Exception) { MessageBox.Show("Файл не выбран"); return; }
            if (!b)
            {
                Console.WriteLine("ReadFromFile: не удалось считывать файл Array\nИдет считывание файла List");
                List<Bus> list = new List<Bus>();
                FileStream fs = new FileStream(f.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                b = DeSerialList(fs, ref list);
                CopyListToArray(list, arr, ref np);
            }
            if (b) Console.WriteLine("ReadFromFile: файл считан");
            else MessageBox.Show("ReadFromFile: ошибка чтения");
        }
        override public void SaveToFile()
        {
            string name = "BusParkS";
            int i = 1;
            while (File.Exists(name + ".fbda"))
            {
                name += Convert.ToString(i);
                i++;
            }
            FileStream fs = new FileStream(name + ".fbda", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            SerialArray(fs, arr);
            Console.WriteLine("Кол-во сохр записей: " + np);
        }
        public void Append(PArray r)
        {
            int rnp = r.np;
            for (int i = 0; i < rnp; i++)
            {
                Add(r.arr[i]);
            }
        }
        override public void AppendFromFile()
        {
            PArray temp = new PArray("blah");
            temp.ReadFromFile();
            Append(temp);
            File.Delete("blah");
        }
        override public void ReadFromXMLFile()
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "*.fbxda;.fbxdl|*.fbxda;*.fbxdl";
            f.ShowDialog();
            bool b = new bool();
            try
            {
                FileStream fs = new FileStream(f.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                b = DeSerialXMLArray(fs, ref arr, ref np);
            }
            catch (Exception) { MessageBox.Show("Файл не выбран"); return; }
            if (!b)
            {
                Console.WriteLine("ReadFromXMLFile: не удалось считывать файл Array\nИдет считывание файла List");
                List<Bus> list = new List<Bus>();
                FileStream fs = new FileStream(f.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                b = DeSerialXMLList(fs, ref list);
                CopyListToArray(list, arr, ref np);
            }
            if (b) Console.WriteLine("ReadFromXMLFile: файл считан");
            else MessageBox.Show("ReadFromXMLFile: ошибка чтения");
        }
        override public void SaveToXMLFile()
        {
            string name = "BusParkX";
            int i = 1;
            while (File.Exists(name + ".fbxda"))
            {
                name += Convert.ToString(i);
                i++;
            }
            FileStream fs = new FileStream(name + ".fbxda", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            SerialXMLArray(fs, arr);
            Console.WriteLine("Кол-во сохр записей: " + np);
        }
        override public void AppendFromXMLFile()
        {
            PArray temp = new PArray("blah");
            temp.ReadFromXMLFile();
            Append(temp);
            File.Delete("blah");
        }
        override public void Add(Bus r) { arr[np] = (Bus)r.Clone(); np++; }
        override public void Fill()
        {
            Add(new Bus(101, "AAA", 901, new Date(3, 4, 2018)));
            Add(new Bus(145, "ABB", 923, new Date(2, 4, 2018)));
            Add(new Bus(333, "ABC", 933, new Date(3, 4, 2018)));
            Add(new Bus(297, "BBB", 927, new Date(1, 4, 2018)));
            Add(new Bus(661, "KKK", 761, new Date(5, 4, 2018)));
        }
        override public void Delete() {
            if (np >= 1) { Array.Resize(ref arr, arr.Length - 1); np--; }
            else Console.WriteLine("DelLast error");
        }
        override public void Show() {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Nbus\t| BusName\t| ID\t| DateProd");
            Console.WriteLine("-----------------------------------------------------------------");
            for (uint i = 0; i < np; i++) { arr[i].Show(); }
            Console.WriteLine("-----------------------------------------------------------------");
        }
        override public void Sort()
        {
            Array.Sort(arr, 0, np);
        }
        override public void Reverse()
        {
            Sort();
            Array.Reverse(arr, 0, np);
        }
        override public void DelDoubles()
        {
            for (int i = 0; i < np; i++)
                for (int j = i + 1; j < np;)
                    if ((arr[i]).CompareTo(arr[j]) == 0)
                    {
                        Array.Copy(arr, i, arr, j, np - i - 2);
                        arr[np - 1] = null;
                        np--;
                    }
                    else j++;
        }
        override public void Clear() { Array.Clear(arr, 0, np); np = 0; }
        override public DataTable ConvertToDataTable()
        {
            DataTable dtb = CreateDataTable();
            DataRow row;
            foreach (var i in arr)
            {
                row = dtb.NewRow();
                row["NBus"] = i.Nbus;
                row["BusName"] = i.BusName;
                row["ID"] = i.ID;
                row["DateProd"] = i.DateProd.Year;
                dtb.Rows.Add(row);
            }
            return dtb;
        }
    }
    // --------------------LIST--------------------
    class PList : BusPark
    {
        List<Bus> list = new List<Bus>();
        public PList() { }
        public PList(string n) : base(n) { }
        override public void ReadFromFile()
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "*.fbda;.fbdl|*.fbda;*.fbdl";
            f.ShowDialog();
            bool b = new bool();
            try
            {
                FileStream fs = new FileStream(f.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                b = DeSerialList(fs, ref list);
            }
            catch (Exception) { MessageBox.Show("Файл не выбран"); return; }
            if (!b)
            {
                Console.WriteLine("ReadFromFile: не удалось считывать файл List\nИдет считывание файла Array");
                Bus[] arr = new Bus[100];
                FileStream fs = new FileStream(f.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                int np = 0;
                b = DeSerialArray(fs, ref arr, ref np);
                CopyArrayToList(arr, list);
            }
            if (b) Console.WriteLine("ReadFromFile: файл считан");
            else MessageBox.Show("ReadFromFile: ошибка чтения");
        }
        override public void SaveToFile()
        {
            string name = "BusParkS";
            int i = 1;
            while (File.Exists(name + ".fbdl"))
            {
                name += Convert.ToString(i);
                i++;
            }
            FileStream fs = new FileStream(name + ".fbdl", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            SerialList(fs, list);
            Console.WriteLine("Кол-во сохр записей: " + list.Count);
        }
        override public void AppendFromFile()
        {
            PList temp = new PList("blah");
            temp.ReadFromFile();
            list.AddRange(temp.list);
            File.Delete("blah");
        }
        override public void ReadFromXMLFile()
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "*.fbxda;.fbxdl|*.fbxda;*.fbxdl";
            f.ShowDialog();
            bool b = new bool();
            try
            {
                FileStream fs = new FileStream(f.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                b = DeSerialXMLList(fs, ref list);
            }
            catch (Exception) { MessageBox.Show("Файл не выбран"); return; }
            if (!b)
            {
                Console.WriteLine("ReadFromXMLFile: не удалось считывать файл Array\nИдет считывание файла List");
                Bus[] arr = new Bus[100];
                FileStream fs = new FileStream(f.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                int np = 0;
                b = DeSerialXMLArray(fs, ref arr, ref np);
                CopyArrayToList(arr, list);
            }
            if (b) Console.WriteLine("ReadFromXMLFile: файл считан");
            else MessageBox.Show("ReadFromXMLFile: ошибка чтения");
        }
        override public void SaveToXMLFile()
        {
            string name = "BusParkX";
            int i = 1;
            while (File.Exists(name + ".fbxdl"))
            {
                name += Convert.ToString(i);
                i++;
            }
            FileStream fs = new FileStream(name + ".fbxdl", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            SerialXMLList(fs, list);
            Console.WriteLine("Кол-во сохр записей: " + list.Count);
        }
        override public void AppendFromXMLFile()
        {
            PList temp = new PList("blah");
            temp.ReadFromXMLFile();
            list.AddRange(temp.list);
            File.Delete("blah");
        }
        override public void Add(Bus r) { list.Add((Bus)r.Clone()); }
        override public void Fill()
        {
            Add(new Bus(101, "AAA", 901, new Date(3, 4, 2018)));
            Add(new Bus(145, "ABB", 923, new Date(2, 4, 2018)));
            Add(new Bus(333, "ABC", 933, new Date(3, 4, 2018)));
            Add(new Bus(297, "BBB", 927, new Date(1, 4, 2018)));
            Add(new Bus(661, "KKK", 761, new Date(5, 4, 2018)));
        }
        override public void Delete() { list.RemoveAt(list.Count - 1); }
        override public void Show()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("Nbus\t| BusName\t| ID\t| DateProd");
            Console.WriteLine("-----------------------------------------------------------------");
            for (int i = 0; i < list.Count; i++) { list[i].Show(); }
            Console.WriteLine("-----------------------------------------------------------------");
        }
        override public void Sort()
        {
            list.Sort();
        }
        override public void Reverse()
        {
            Sort();
            list.Reverse();
        }
        override public void DelDoubles()
        {
            for (int i = 0; i < list.Count; i++)
                for (int j = i + 1; j < list.Count;)
                    if ((list[i]).CompareTo(list[j]) == 0)
                        list.Remove(list[j]);
                    else j++;
        }
        override public void Clear() { list.Clear(); }
        override public DataTable ConvertToDataTable()
        {
            DataTable dtb = CreateDataTable();
            DataRow row;
            foreach (var i in list)
            {
                row = dtb.NewRow();
                row["NBus"] = i.Nbus;
                row["BusName"] = i.BusName;
                row["ID"] = i.ID;
                row["DateProd"] = i.DateProd.Day + "." + i.DateProd.Month + "." + i.DateProd.Year;
                dtb.Rows.Add(row);
            }
            return dtb;
        }
    }
}
