using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication2
{
    [Serializable]
    abstract class Person: IComparable
    {
        private string name;
        public string Name 
        {
            set
            {
                char[] ch = { '%','\n', '#' };
                if (value.IndexOfAny(ch) != -1)
                {
                    throw new NameException("Введено некорректное Имя!");
                }
                else 
                {
                    name = value;
                }
            }
            get
            {
                return name;
            }
        }
        public virtual Int32 Year
        {
            set;
            get;
        }
        public Person() { }
        public Person( string name, Int32 year ) 
        {
            this.name = name;
            this.Year = year;
        }
        public void read()
        {
            Console.WriteLine("Введите Имя:");
            Name = Console.ReadLine();
            Console.WriteLine("Введите Год рождения: ");
            Year = Convert.ToInt32(Console.ReadLine());
        }
        public override string ToString()
        {
            return "Имя: " + Name + "\tГод рождения: " + Year;
        }
        public Int32 CompareTo(Object obj)
        {
            Person s = (Person)obj;
            return this.name.CompareTo(s.name);
        }
        public override bool Equals(object obj)
        {
            Person s = (Person)obj;
            return this.Name == s.Name;
        }
        public void SetName(string n) { name = n; }
        public string GetName() { return name; }
        public void SetAge(int a) { Year = a; }
        public int GetAge() { return Year; }
    }
}
