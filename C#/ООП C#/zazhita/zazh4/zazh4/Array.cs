using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zazh4 {
    class Array1 {
       
        Student[] students_array = new Student[100];
        int size;
        public int GetSize() {
            return size;
        }
        public Student[] GetStudents() {
            return students_array;
        }
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
            for (int i = 0; i < size; i++)
            {
                students_array[i].Show();
            }

        }
        public void Read() {
            Student x = new Student();
            Console.WriteLine("Добавление программиста в проект через консоль");
            x.Read();
            this.Add_Array(x);
        }
        public List1 FromArrayToList() {
            List1 st = new List1();
            Student s1 = new Student();
           foreach (Student s in students_array)
            {
                
                st.Add_List(s);
            }
            return st;
        }
        public void FromListToArray(List1 st) {
            foreach (Student s in st.GetStudents())
            {
                this.Add_Array(s);
            }
        }
    }
}
