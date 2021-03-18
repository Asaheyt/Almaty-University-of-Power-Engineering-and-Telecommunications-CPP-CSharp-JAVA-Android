using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_a_ {
    class Student :Learner
    {
        private string institute_of_higher_learning;
        private int year;
        public Student() {
            Console.WriteLine("Инициализация конструктора класса: Студент. Количество " + count);
        }
        public Student(string n, int a, string i, int y):base(n,a) {
            Console.WriteLine("Инициализация конструктора класса: Студент. Количество " + count);
            institute_of_higher_learning = i;
            year = y;
        }
        public void setIohl(string i) {
            institute_of_higher_learning = i;
        }
        public void setYear(int y) {
            year = y;
        }
        public string getIohl() {
            return institute_of_higher_learning;
        }
        public int getYear() {
            return year;
        }
        public void show() {
            base.show();
            Console.Write(" ВУЗ: " + institute_of_higher_learning + " Год обучения: " + year);
        }
        public void read() {
            base.read();
            Console.WriteLine("ВУЗ: ");
            bool OK = false;
            while (!OK)
            {
                institute_of_higher_learning = Console.ReadLine();
                for (int j = 0; j < institute_of_higher_learning.Length; j++)
                {
                    if ((institute_of_higher_learning[j] >= 'A' && institute_of_higher_learning[j] <= 'Z') || (institute_of_higher_learning[j] >= 'a' && institute_of_higher_learning[j] <= 'z') || (institute_of_higher_learning[j] >= 'А' && institute_of_higher_learning[j] <= 'Я') || (institute_of_higher_learning[j] >= 'а' && institute_of_higher_learning[j] <= 'я') || (j != 0 && institute_of_higher_learning[j] == ' '))
                    {
                        OK = true;
                    }
                    else { OK = false; break; }
                }
                if (OK == false) { Console.WriteLine("Ошибка! Введите ВУЗ: "); }
            }
            Console.WriteLine("Введите Год обучения: ");
        link2:
            try
            {
                year = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка!Введите Год обучения!");
                goto link2;
            }
        }

    }
}
