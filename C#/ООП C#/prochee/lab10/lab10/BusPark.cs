using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace lab10
{
    [Serializable]
    public abstract class BusPark
    {
        string name;
        public BusPark() {  }
        public BusPark(string n) { name = n; }
        public void SetName(string r) { name = r; }
        public string GetName() { return name; }
        public bool DeSerialArray(FileStream fs, ref Bus[] arr, ref int np)
        {
            bool b = true;
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                arr = (Bus[])bf.Deserialize(fs);
                fs.Close();
                np = 0;
                while (arr[np] != null)
                {
                    np++;
                }
                Console.WriteLine("Deserialized Array: np = " + np);
            }
            catch (Exception) { b = false; }
            return b;
        }
        public bool SerialArray(FileStream fs, Bus[] arr)
        {
            bool b = true;
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, arr);
                fs.Close();
                Console.WriteLine("Serialized Array");
            }
            catch (Exception) { b = false; }
            return b;
        }
        public bool DeSerialXMLArray(FileStream fs, ref Bus[] arr, ref int np)
        {
            bool b = true;
            try
            {
                XmlSerializer xml = new XmlSerializer(arr.GetType());
                arr = (Bus[])xml.Deserialize(fs);
                fs.Close();
                while (arr[np] != null)
                {
                    np++;
                }
                Console.WriteLine("Deserialized XML Array: np = " + np);
            }
            catch (Exception) { b = false; }
            return b;
        }
        public bool SerialXMLArray(FileStream fs, Bus[] arr)
        {
            bool b = true;
            try
            {
                var xml = new XmlSerializer(arr.GetType());
                xml.Serialize(fs, arr);
                fs.Close();
                Console.WriteLine("Serialized XML Array");
            }
            catch (Exception) { b = false; }
            return b;
        }
        public bool DeSerialList(FileStream fs, ref List<Bus> list)
        {
            bool b = true;
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                list = (List<Bus>)bf.Deserialize(fs);
                fs.Close();
                Console.WriteLine("Deserialized List: np = " + list.Count);
            }
            catch (Exception) { b = false; }
            return b;
        }
        public bool SerialList(FileStream fs, List<Bus> list)
        {
            bool b = true;
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, list);
                fs.Close();
                Console.WriteLine("Serialized List: np = " + list.Count);
            }
            catch (Exception) { b = false; }
            return b;
        }
        public bool DeSerialXMLList(FileStream fs, ref List<Bus> list)
        {
            bool b = true;
            try
            {
                XmlSerializer xml = new XmlSerializer(list.GetType());
                list = (List<Bus>)xml.Deserialize(fs);
                fs.Close();
                Console.WriteLine("Deserialized XML List: np = " + list.Count);
            }
            catch (Exception) { b = false; }
            return b;
        }
        public bool SerialXMLList(FileStream fs, List<Bus> list)
        {
            bool b = true;
            try
            {
                XmlSerializer xml = new XmlSerializer(list.GetType());
                xml.Serialize(fs, list);
                fs.Close();
                Console.WriteLine("Serialized XML List: np = " + list.Count);
            }
            catch (Exception) { b = false; }
            return b;
        }
        public void CopyArrayToList(Bus[] arr, List<Bus> list)
        {
            int np = 0;
            while (arr[np] != null)
            {
                list.Add((Bus)arr[np].Clone());
                np++;
            }
        }
        public void CopyListToArray(List<Bus> list, Bus[] arr, ref int np)
        {
            for (int i = 0; i < list.Count; i++)
            {
                arr[i] = (Bus)list[i].Clone();
            }
            np = list.Count;
        }
        virtual public void ReadFromFile() { }
        virtual public void SaveToFile() { }
        virtual public void AppendFromFile() { }
        virtual public void ReadFromXMLFile() { }
        virtual public void SaveToXMLFile() { }
        virtual public void AppendFromXMLFile() { }
        virtual public void Add(Bus r) { }
        virtual public void Fill() { }
        virtual public void Delete() { }
        virtual public void Show() { }
        virtual public void Sort() { }
        virtual public void Reverse() { }
        virtual public void DelDoubles() { }
        virtual public void Clear() { }
        public bool SaveFromGridViewToFile(DataGridView dataGridView1)
        {
            bool b = true;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                Bus xbus = new Bus();
                xbus.Nbus = (int)row.Cells["nbus"].Value;
                xbus.BusName = (string)row.Cells["busname"].Value;
                xbus.ID = (int)row.Cells["id"].Value;
                xbus.DateProd.Day = 1;
                xbus.DateProd.Month = 1;
                xbus.DateProd.Year = 2011;
                Add(xbus);
            }
            SaveToFile();
            return b;
        }
        public bool SaveFromGridViewToXMLFile(DataGridView dataGridView1)
        {
            bool b = true;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;
                Bus xbus = new Bus();
                xbus.Nbus = (int)row.Cells["nbus"].Value;
                xbus.BusName = (string)row.Cells["busname"].Value;
                xbus.ID = (int)row.Cells["id"].Value;
                xbus.DateProd.Day = 1;
                xbus.DateProd.Month = 1;
                xbus.DateProd.Year = 2011;
                Add(xbus);
            }
            SaveToXMLFile();
            return b;
        }
        public DataTable CreateDataTable()
        {
            DataTable dtb = new DataTable();
            DataColumn dcolumn = new DataColumn();
            dcolumn.DataType = Type.GetType("System.Int32");
            dcolumn.ColumnName = "NBus";
            dtb.Columns.Add(dcolumn);
            DataColumn dcolumn_1 = new DataColumn();
            dcolumn_1.DataType = Type.GetType("System.String");
            dcolumn_1.ColumnName = "BusName";
            dtb.Columns.Add(dcolumn_1);
            DataColumn dcolumn_2 = new DataColumn();
            dcolumn_2.DataType = Type.GetType("System.Int32");
            dcolumn_2.ColumnName = "ID";
            dtb.Columns.Add(dcolumn_2);
            DataColumn dcolumn_3 = new DataColumn();
            dcolumn_3.DataType = Type.GetType("System.DateTime");
            dcolumn_3.ColumnName = "DateProd";
            dtb.Columns.Add(dcolumn_3);
            return dtb;
        }
        virtual public DataTable ConvertToDataTable() { return null; }
    }
}
