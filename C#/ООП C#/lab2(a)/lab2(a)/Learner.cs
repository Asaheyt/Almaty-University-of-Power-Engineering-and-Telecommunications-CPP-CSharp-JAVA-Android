using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_a_
{
    class Learner
    {
        protected static int count = 0;
        private string name;
        private int age;
        public Learner() {
            count++;
            Console.WriteLine("Инициализация конструктора класса: Учащийся. Количество "+ count);
        }
        public Learner(string n, int a) {
            count++;
            Console.WriteLine("Инициализация конструктора класса: Учащийся. Количество " + count);
            name = n;
            age = a;
        }
        public void setName(string n) {
            name = n;
        }
        public void setAge(int a) {
            age = a;
        }
        public string getName() {
            return name;
        }
        public int getAge() {
            return age;
        }
        public void show() {
            Console.Write("Имя: " + name + " Возраст: " + age);
        }
        public void read() {
            Console.WriteLine("Введите данные: ");
            Console.WriteLine("Имя: ");
            bool OK = false;
            while (!OK)
            {
                name = Console.ReadLine();
                for (int j = 0; j < name.Length; j++)
                {
                    if ((name[j] >= 'A' && name[j] <= 'Z') || (name[j] >= 'a' && name[j] <= 'z') || (name[j] >= 'А' && name[j] <= 'Я') || (name[j] >= 'а' && name[j] <= 'я') || (j != 0 && name[j] == ' '))
			        {
                         OK = true;
                    }
			        else { OK = false; break; }
                 }
                 if (OK == false) {Console.WriteLine("Ошибка! Введите имя: "); }
            }
            Console.WriteLine("Введите Возраст: ");
        link1:
            try
            {
                age=Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Ошибка!Введите возраст!");
                goto link1;
            }
        }
        
    }
}
