using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace lab7_a_ {
    [Serializable]
    class Project {
        string project_name;
        List<Programer> programers = new List<Programer>();
        public Project() { }
        public List<Programer> GetProgramers() {
            return programers; 
        }
        public Project(string pn) {
            project_name = pn;
        }
        public void SetProject_name(string pn) {
            project_name = pn;
        }
        public string GetProject_name() {
            return project_name;
        }
        public void Add(Programer p) {
            programers.Add((Programer)p.Clone());
        }
        public void DelLast() {
            if (programers.Count >= 1)
            {
                programers.Remove(programers[programers.Count-1]);
            }
            else Console.WriteLine("DelLast error");
        }
        public void DelDupl() {
            if (programers.Count >= 1)
            {
                for (int i = 0; i <programers.Count-1; i++)
                {
                    for (int j = i+1; j < programers.Count; j++)
                    {
                        if(programers[i].CompareTo(programers[j])==0)
                        {
                            programers.Remove(programers[j]);j--;
                        }
                    }
                }

            }
            else Console.WriteLine("DelDupl error");
        }
        public void Show() {
            for (int i = 0; i < programers.Count; i++)
            {
                programers[i].Show();
            }

        }
        public void Clear() {
            programers.Clear();
        }
        public void Sort() {
            programers.Sort();
        }
        public void Reverse() {
            programers.Sort();
            programers.Reverse();
        }
        public void Read() {
            Programer x = new Programer();
            Console.WriteLine("Добавление программиста в проект через консоль");
            x.Read();
            programers.Add(x);
        }
        public void Fill(int num) {
            Random rnd = new Random();
            Programer x = new Programer();
            Date y = new Date();
            String[] institute = { "AUPET", "KBTU", "IUIT", "KazGU", "KazNTU" };
            String[] direction = { "Technical", "Construction", "Economical", "Organiztion" };
            String[] language = { "C", "C++", "C#", "Java", "Python" };
            for (int i = 0; i < num; i++)
            {
                x.SetCategory(rnd.Next(1, 3)); x.SetInstitute_of_high_learning(institute[rnd.Next(0, 4)]);
                x.SetDirection(direction[rnd.Next(0, 3)]); x.SetMain_language(language[rnd.Next(0, 5)]);
                y.SetDay(rnd.Next(1, 31)); y.SetMonth(rnd.Next(1, 12)); y.SetYear(rnd.Next(1990, 2018));
                x.SetBeginning_of_work(y);
                this.Add((Programer)x.Clone());
            }
        }
        public void save(string filename) {
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (Stream wstream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None))
            {
                binFormatter.Serialize(wstream, this);
            }
        }
        public static Project read(string filename) {
            Project t;
            BinaryFormatter binFormatter = new BinaryFormatter();
            using (Stream rstream = File.OpenRead(filename))
            {
                t = (Project)binFormatter.Deserialize(rstream);
            }
            return t;
        }
        //
        public bool DeSerialXMLArray(FileStream fs, ref Programer[] arr, ref int np) {
            bool b = true;
            try
            {
                XmlSerializer xml = new XmlSerializer(arr.GetType());
                arr = (Programer[])xml.Deserialize(fs);
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
        public bool SerialXMLArray(FileStream fs, Programer[] arr) {
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
        //
        public bool DeSerialXMLList(FileStream fs, ref List<Programer> list) {
            bool b = true;
            try
            {
                XmlSerializer xml = new XmlSerializer(list.GetType());
                list = (List<Programer>)xml.Deserialize(fs);
                fs.Close();
                Console.WriteLine("Deserialized XML List: np = " + list.Count);
            }
            catch (Exception) { b = false; }
            return b;
        }
        public bool SerialXMLList(FileStream fs, List<Programer> list) {
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
        public void CopyArrayToList(Programer[] arr, List<Programer> list) {
            int np = 0;
            while (arr[np] != null)
            {
                list.Add((Programer)arr[np].Clone());
                np++;
            }
        }
        //
        public void ReadFromXMLFile() {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "*.fbxda;.fbxdl|*.fbxda;*.fbxdl";
            f.ShowDialog();
            bool b = new bool();
            try
            {
                FileStream fs = new FileStream(f.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                b = DeSerialXMLList(fs, ref programers);
            }
            catch (Exception) { MessageBox.Show("Файл не выбран"); return; }
            if (!b)
            {
                Console.WriteLine("ReadFromXMLFile: не удалось считывать файл Array\nИдет считывание файла List");
                Programer[] arr = new Programer[100];
                FileStream fs = new FileStream(f.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                int np = 0;
                b = DeSerialXMLArray(fs, ref arr, ref np);
                CopyArrayToList(arr, programers);
            }
            if (b) Console.WriteLine("ReadFromXMLFile: файл считан");
            else MessageBox.Show("ReadFromXMLFile: ошибка чтения");
        }
        public void SaveToXMLFile(string name) {
            
            int i = 1;
            while (File.Exists(name + ".fbxdl"))
            {
                name += Convert.ToString(i);
                i++;
            }
            FileStream fs = new FileStream(name + ".fbxdl", FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            //SerialXMLList(fs, programers);
            XmlSerializer xml = new XmlSerializer(programers.GetType());
            xml.Serialize(fs, programers);
            fs.Close();
            Console.WriteLine("Кол-во сохр записей: " + programers.Count);
        }

    }
}
