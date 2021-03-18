using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zazh4 {
    class List1 {
        List<Student> students_list = new List<Student>();
        public List<Student> GetStudents() {
            return students_list;
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
        public void Show() {
            for (int i = 0; i < students_list.Count; i++)
            {
                students_list[i].Show();
            }
            /*foreach(Student s in students_list)
            {
                s.Show();
            }*/

        }
        public void Read() {
            Student x = new Student();
            Console.WriteLine("Добавление программиста в проект через консоль");
            x.Read();
            students_list.Add(x);
        }
        public void FromArrayToList(Array1 st) {
            foreach(Student s in st.GetStudents())
            {
                this.Add_List(s);
            }
        }
        public Array1 FromListToArray() {
            Array1 st = new Array1();
            foreach (Student s in students_list)
            {
                st.Add_Array(s);
            }
            return st;
        }
    }
}
