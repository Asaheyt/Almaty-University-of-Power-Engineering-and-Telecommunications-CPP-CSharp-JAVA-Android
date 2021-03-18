using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace zazh4 {
    class Project {
        string project_name;
        Student[] students_array = new Student[100];
        int size;
        List<Student> students_list = new List<Student>();
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
        public void Add_List(Student p) {
            students_list.Add((Student)p.Clone());
        }
        public void DelLast_List() {
            if (students_list.Count >= 1)
            {
                students_list.Remove(students_list[students_list.Count]);
            }
            else Console.WriteLine("DelLast error");
        }//
        public void Add_Array(Student p) {
            students_array[size] = (Student)p.Clone();
            size++;
        }
        public void DelLast_Array() {
            if (size >= 1)
            {
                Array.Resize(ref students_array, students_array.Length - 1);
                size--;
            }
            else Console.WriteLine("DelLast error");
        }
        //
        public void Show() {
            for (int i = 0; i < students_list.Count; i++)
            {
                students_list[i].Show();
            }

        }
        public void Clear() {
            students_list.Clear();
        }
        public void Sort() {
            students_list.Sort();
        }
        public void Reverse() {
            students_list.Sort();
            students_list.Reverse();
        }
        public void Read() {
            Student x = new Student();
            Console.WriteLine("Добавление программиста в проект через консоль");
            x.Read();
            students_list.Add(x);
        }
        public void FromArrayToList() {
            foreach(Student s in students_array)
            {
                this.Add_List(s);
            }
        }
        public void FromListToArray() {
            foreach(Student s in students_list)
            {
                this.Add_Array(s);
            }
        }

    }
}
