using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_a_ {
    class Master :Student
    {
        private string specialty;
        private int duration;
        public Master() {
            Console.WriteLine("Инициализация конструктора класса: Магистрант. Количество " + count);
        }
        public Master(string n, int a, string i, int y, string s, int d):base(n,a,i,y) {
            Console.WriteLine("Инициализация конструктора класса: Магистрант. Количество " + count);
            specialty = s;
            duration = d;
        }
        public void setSpecialty(string s) {
            specialty = s;
        }
        public void setDuration(int d) {
            duration = d;
        }
        public string getSpecialty() {
            return specialty;
        }
        public int getDuration() {
            return duration;
        }
        public void show() {
            base.show();
            Console.WriteLine(" Специальность: " + specialty + " Продолжительность обучения: " + duration);
        }
        public void read() {
            base.read();
            Console.WriteLine("Специальность: ");
            bool OK = false;
            while (!OK)
            {
                specialty = Console.ReadLine();
                for (int j = 0; j < specialty.Length; j++)
                {
                    if ((specialty[j] >= 'A' && specialty[j] <= 'Z') || (specialty[j] >= 'a' && specialty[j] <= 'z') || (specialty[j] >= 'А' && specialty[j] <= 'Я') || (specialty[j] >= 'а' && specialty[j] <= 'я') || (j != 0 && specialty[j] == ' '))
                    {
                        OK = true;
                    }
                    else { OK = false; break; }
                }
                if (OK == false) { Console.WriteLine("Ошибка! Введите Специальность: "); }
            }
            Console.WriteLine("Введите Продолжительность обучения: ");
        link3:
            try
            {
                duration = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка!Введите Продолжительность обучения!");
                goto link3;
            }
        }

    }
}
