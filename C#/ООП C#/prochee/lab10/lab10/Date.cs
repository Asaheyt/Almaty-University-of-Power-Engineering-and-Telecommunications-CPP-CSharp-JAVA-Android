using System;

namespace lab10
{
    [Serializable]
    public class Date
    {
        int day;
        int month;
        int year;
        public Date() { }
        public Date(int d, int m, int y)
        {
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
        public int Day
        {
            get { return day; }
            set
            {
                if (value <= 31)
                {
                    day = value;
                }
                else
                {
                    while (value > 31)
                    {
                        value -= 31;
                        month++;
                    }
                    day = value;
                }
            }
        }
        public int Month
        {
            get { return month; }
            set
            {
                if (value <= 12)
                {
                    month = value;
                }
                else
                {
                    while (value > 12)
                    {
                        value -= 12;
                        year++;
                    }
                    month += value;
                }
            }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public void Show() { Console.Write("{0:00}.{1:00}.{2:0000}", day, month, year); }
    }
}
