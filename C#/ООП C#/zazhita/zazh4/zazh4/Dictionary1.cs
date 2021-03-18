using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zazh4 {
    class Dictionary1 {
        int size;
        Dictionary<int,Student> students_dictionary = new Dictionary<int, Student>(100);
        public Dictionary<int, Student> GetStudents() {
            return students_dictionary;
        }
        public void Add_Dictionary(Student p) {
            students_dictionary.Add(size,(Student)p.Clone());
            size++;
        }
        public void DelLast_Dictionary() {
            if (students_dictionary.Count >= 1)
            {
                size--;
                students_dictionary.Remove(size);
            }
            else Console.WriteLine("DelLast error");
        }//
        public void Show() {
            for (int i = 0; i < size; i++)
            {
                students_dictionary[i].Show();
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
            students_dictionary.Add(size,x);
        }
        public void FromArrayToDictonary(Array1 st) {
            foreach (Student s in st.GetStudents())
            {
                this.Add_Dictionary(s);
            }
        }
        public Array1 FromDictionaryToArray() {
            Array1 st = new Array1();
            foreach (KeyValuePair<int,Student> s in students_dictionary)
            {
                st.Add_Array(s.Value);
            }
            return st;
        }
        public List1 FromDictionaryToList() {
            List1 st = new List1();
            foreach (KeyValuePair<int, Student> s in students_dictionary)
            {
                st.Add_List(s.Value);
            }
            return st;
        }
        public void FromListToDictonary(List1 st) {
            foreach (Student s in st.GetStudents())
            {
                this.Add_Dictionary(s);
            }
        }
    }
}
