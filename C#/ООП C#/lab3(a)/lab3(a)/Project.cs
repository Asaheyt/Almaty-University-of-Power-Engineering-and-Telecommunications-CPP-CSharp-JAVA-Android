using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_a_ {
    class Project:ICloneable {
        string project_name;
        int size;
        Programer[] programers = new Programer[50];
        public int GetSize() {
            return size;
        }
        public Programer[] Getprogramerss() {
            return programers;
        }
        public Project() {
            size = 0;
        }
        public Project(string pn) {
            size = 0;
            project_name = pn;
        }
        public void SetProject_name(string pn) {
            project_name = pn;
        }
        public string GetProject_name() {
            return project_name;
        }
        public void Add(Programer p) {
            programers[size] = (Programer)p.Clone();
            size++;
        }
        public void DelLast() {
            if (size >= 1)
            {
                Array.Resize(ref programers, programers.Length - 1);
                size--;
            }
            else Console.WriteLine("DelLast error");
        }
        public void Show() {
            for (int i = 0; i < size; i++)
            {
                programers[i].Show();
            }

        }
        public void Clear() {
            Array.Clear(programers, 0, size);
            size = 0;
        }
        public void Sort() {
            Array.Sort(programers, 0, size);
        }
        public void Reverse() {
            Sort();
            Array.Reverse(programers, 0, size);
        }
        public object Clone() {
            Project x = new Project();
            x.programers.Clone();
            return x;
        }
    }
}
