using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_a_ {
    class Programer:Engineer, ICloneable, IComparable {
        private int category;
        private Date beginning_of_work = new Date();
        private string main_language;
        public Programer() { }
        public Programer(string i, string d, int c, Date bw, string ml) : base(i, d) {
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
            base.Show();
            Console.Write("Главный язык:"+main_language + " \t|Категория:" + category + "\t|Дата начала работы:");
            beginning_of_work.Show();
            Console.WriteLine();
        }
        public void Read() {
            base.Read();
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
            Console.WriteLine("Дата начала работы:");
            beginning_of_work.Read();
        }
        public object Clone() {
            Programer x = new Programer();
            x.SetInstitute_of_high_learning(this.GetInstitute_of_high_learning());
            x.SetDirection(this.GetDirection());
            x.SetMain_language(this.GetMain_language());
            x.category = this.category;
            x.beginning_of_work.SetDay(this.beginning_of_work.GetDay());
            x.beginning_of_work.SetMonth(this.beginning_of_work.GetMonth());
            x.beginning_of_work.SetYear(this.beginning_of_work.GetYear());
            x.main_language = this.main_language;
            return x;
        }
        public int CompareTo(object x) {
            int i = 0;
            Programer xx = x as Programer;
            i = string.Compare(this.GetInstitute_of_high_learning(), xx.GetInstitute_of_high_learning());
            return i;
        }
    }
}
