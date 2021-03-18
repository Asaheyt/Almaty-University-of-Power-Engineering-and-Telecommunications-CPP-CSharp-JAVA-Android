using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zazh4 {
    class Date {
        int day=0;
        int month=0;
        int year=0;
        public Date() { }
        public Date(int d, int m, int y) {
            if (d <= 31)
            {
                day = d;
            }
            else
            {
                while (d > 31)
                {
                    d -= 31;
                    m++;
                }
                day = d;
            }
            if (m <= 12)
            {
                month = m;
            }
            else
            {
                while (m > 12)
                {
                    m -= 12;
                    y++;
                }
                month = m;
            }
            year = y;

        }
        public void SetDay(int d) {
            if (d <= 31)
            {
                day = d;
            }
            else
            {
                while (d > 31)
                {
                    d -= 31;
                    month++;
                }
                day = d;
            }
        }
        public int GetDay() {
            return day;
        }
        public void SetMonth(int m) {
            if (m <= 12)
            {
                month = m;
            }
            else
            {
                while (m > 12)
                {
                    m -= 12;
                    year++;
                }
                month = month + m;
            }
        }
        public int GetMonth() {
            return month;
        }
        public void SetYear(int y) {
            year = y;
        }
        public int GetYear() {
            return year;
        }
        public void Show() {
            Console.Write("{0:00}.{1:00}.{2:0000}", day, month, year);
        }
        public void Read() {
            Console.WriteLine("День: ");
            bool OK = false;
            while (!OK)
            {
                day = Convert.ToInt32(Console.ReadLine());
                if (day < 0 && day > 31) { OK = false; Console.WriteLine("Ошибка! Введите день: "); }
                else { OK = true; }
            }
            Console.WriteLine("Месяц: ");
            OK = false;
            while (!OK)
            {
                month = Convert.ToInt32(Console.ReadLine());
                if (month < 0 && month > 12) { OK = false; Console.WriteLine("Ошибка! Введите месяц: "); }
                else { OK = true; }
            }
            Console.WriteLine("Год: ");
            OK = false;
            while (!OK)
            {
                year = Convert.ToInt32(Console.ReadLine());
                if (year < 1900 && year > 2018) { OK = false; Console.WriteLine("Ошибка! Введите год: "); }
                else { OK = true; }
            }
        }

    }
}
