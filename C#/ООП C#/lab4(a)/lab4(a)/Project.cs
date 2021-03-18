using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace lab4_a_ {
    class Project {
        string project_name;
        List<Programer> programers = new List<Programer>();
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
        public void Add(Programer p) {
            programers.Add((Programer)p.Clone());
        }
        public void DelLast() {
            if (programers.Count >= 1)
            {
                programers.Remove(programers[programers.Count]);
            }
            else Console.WriteLine("DelLast error");
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
    }
}
