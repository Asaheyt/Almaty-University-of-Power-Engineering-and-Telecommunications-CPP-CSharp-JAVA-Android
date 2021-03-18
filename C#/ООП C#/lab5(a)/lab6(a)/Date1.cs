using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_a_ {
    class Date1 {
        DateTime date;
        public Date1() { }
        public Date1(DateTime date) {
            this.date = date;
        }
        public Date1(int d, int m, int y) {
            date = new DateTime(y, m, d);
        }
        public DateTime GetDate() {
            return date;
        }
        public void SetDate(int d,int m, int y) {
            this.date = new DateTime(y, m, d);
        }
        public void Show() {
            Console.WriteLine(date.ToShortDateString());
        }
        public void Read() {
            int d,m,y;
        link1:
            Console.WriteLine("Введите день,месяц,год:");
            try
            {
                d = Convert.ToInt32(Console.ReadLine());
                m = Convert.ToInt32(Console.ReadLine());
                y = Convert.ToInt32(Console.ReadLine());
                this.date = new DateTime(y, m, d);
            }
            catch
            {
                Console.WriteLine("Ошибка! Введите заново!");
                goto link1;
            }

        }
    }
}
