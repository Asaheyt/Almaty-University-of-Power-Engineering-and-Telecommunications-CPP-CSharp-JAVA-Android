using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zazh4 {
    class Student {
        private int category;
        private Date beginning_of_work = new Date();
        private string main_language;
        public Student() { }
        public Student(string i, string d, int c, Date bw, string ml) {
            category = c;
            beginning_of_work = bw;
            main_language = ml;
        }
        public void SetCategory(int c) {
            category = c;
        }
        public int GetCategory() {
            return category;
        }
        public void SetBeginning_of_work(Date bw) {
            beginning_of_work = bw;
        }
        public Date GetBeginning_of_work() {
            return beginning_of_work;
        }
        public void SetMain_language(string ml) {
            main_language = ml;
        }
        public new string GetMain_language() {
            return main_language;
        }
        public void Show() {
            Console.Write("Главный язык:"+main_language + " \t|Категория:" + category + "\t|Дата начала работы:");
            beginning_of_work.Show();
            Console.WriteLine();
        }
        public void Read() {
            Console.WriteLine("Введите главный язык: "); main_language = Console.ReadLine();
            Console.WriteLine("Категория:");
            link1:
            try
            { 
                category = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка! Введите категорию");
                goto link1;
            }
            Console.WriteLine("Дата начала учебы:");
            beginning_of_work.Read();
        }
        public Student Clone() {
            Student x = new Student();

            x.SetMain_language(this.GetMain_language());
            x.SetCategory(this.GetCategory());
            x.beginning_of_work.SetDay(this.beginning_of_work.GetDay());
            x.beginning_of_work.SetMonth(this.beginning_of_work.GetMonth());
            x.beginning_of_work.SetYear(this.beginning_of_work.GetYear());
            x.SetMain_language(this.GetMain_language());

            return x;
        }
        public int CompareTo(object x) {
            int i = 0;
            Student xx = x as Student;
            i = string.Compare(this.GetMain_language(), xx.GetMain_language());
            return i;
        }
    }
}
