using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace lab6_a_ {
    class Project {
        string project_name;
        int size;
        Dictionary<int, Programer> programers_dictionary = new Dictionary<int, Programer>(100);
        public Project() { }
        public Project(string pn) {
            project_name = pn;
        }
        public void SetProject_name(string pn) {
            project_name = pn;
        }
        public string GetProject_name() {
            return project_name;
        }
        
        public void AddDict(Programer r) {
            programers_dictionary.Add(size, (Programer)r.Clone());
            size++;

        }
        public Dictionary<int, Programer> getProgramer() { return programers_dictionary; }
        public void Fill(int num) {
            Random rnd = new Random();
            Programer x = new Programer();
            Date y = new Date();
            String[] institute = { "AUPET", "KBTU", "IUIT", "KazGU", "KazNTU" };
            String[] direction = { "Technical","Construction","Economical","Organiztion" };
            String[] language = { "C", "C++", "C#", "Java","Python" };
            for (int i = 0; i < num; i++)
            {
                x.SetCategory(rnd.Next(1, 3)); x.SetInstitute_of_high_learning(institute[rnd.Next(0, 4)]);
                x.SetDirection(direction[ rnd.Next(0, 3)]); x.SetMain_language(language[rnd.Next(0, 5)]);
                y.SetDay(rnd.Next(1, 31)); y.SetMonth(rnd.Next(1, 12)); y.SetYear(rnd.Next(1990, 2018));
                x.SetBeginning_of_work(y);
                this.AddDict((Programer)x.Clone());
            }
        }
        public void show() {
            Console.WriteLine();
            foreach(KeyValuePair<int,Programer> p in programers_dictionary)
            {
                p.Value.Show();
            }

        }
        public void DelKey(int k) {
            programers_dictionary.Remove(k);
        }
        public void DelLast() {
            size--;
            programers_dictionary.Remove(programers_dictionary.Count);
        }
        public void DelAll() {
            programers_dictionary.Clear();
        }
        public static Project Sum(Project o1, Project o2) {
            Project x = new Project();
            foreach(KeyValuePair<int,Programer> p in o1.getProgramer())
            {
                x.AddDict((Programer)p.Value.Clone());
            }
            foreach (KeyValuePair<int, Programer> p in o2.getProgramer())
            {
                x.AddDict((Programer)p.Value.Clone());
            }
            return x;
        }
    }
}
