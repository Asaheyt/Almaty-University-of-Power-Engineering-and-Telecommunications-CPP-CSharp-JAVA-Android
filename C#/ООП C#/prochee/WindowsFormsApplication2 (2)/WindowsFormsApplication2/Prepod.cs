using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    [Serializable]
    class Prepod: Person, ICloneable
    {
        Random rnd = new Random();
        private string spec;
        public string Spec
        {
            set
            {
                char[] ch = { '%', '\n', '#' };
                if (value.IndexOfAny(ch) != -1)
                {
                    throw new SpecException("Введена некорректная Дисциплина!");
                }
                else
                {
                    spec = value;
                }
            }
            get
            {
                return spec;
            }
        }
        public Int32 Zp
        {
             get;
             set;
           
        }
        public override Int32 Year
        {
            set 
            {
                if (value < 1900 || value > 2015)
                {
                    throw new AgeException("Введен некорректный Год рождения!");
                }
                else
                {
                    base.Year = value;
                }
                Zp = (2015 - base.Year)+rnd.Next(60000, 150000);
            }
            get
            {
                return base.Year;
            }
        }
        public Prepod() { }
        public Prepod(string name, Int32 year, Int32 zp, string spec1):base(name, year)
        {
            //Random rnd = new Random();
            // this.Zp = rnd.Next(60000, 300000);
            // this.zp =Zp;
            this.Zp = (2015 - base.Year) + rnd.Next(60000, 150000);
            this.spec = spec1;
        }
        new public void read()
        {
            base.read();
            Zp = (2015 - base.Year) + rnd.Next(60000, 150000);
            Console.WriteLine("Введите Дисциплину:");
            Spec = Console.ReadLine();
        }
        public override string ToString()
        {
            return base.ToString() + "\tЗарплата: " + Zp + "\tДисциплина: "+ Spec + '\n';
        }
        public object Clone()
        {
            Prepod a = new Prepod();
            a.Name = this.Name;
            a.Year = this.Year;
            a.Zp = this.Zp;
            a.Spec = this.Spec;
            return a;
        }
        public void SetSpec(string sp) { spec = sp; }
        public string GetSpec() { return spec; }
        public void SetNpar(int np) { Zp = Zp; }
        public int GetNpar() { return Zp; }

    }
}
