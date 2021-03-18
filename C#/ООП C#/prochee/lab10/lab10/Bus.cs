using System;

namespace lab10
{
    [Serializable]
    public class Bus : Car, ICloneable, IComparable
    {
        string busname;
        int id;
        Date dateprod = new Date();
        public Bus() { }
        public Bus(int n, string dn, int i, Date dp) : base(n) { busname = dn; id = i; dateprod = dp; }
        public string BusName
        {
            get { return busname; }
            set { busname = value; }
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public Date DateProd
        {
            get { return dateprod; }
            set { dateprod = value; }
        }
        public void Show()
        {
            base.Show();
            Console.Write(busname + "\t| " + id + "\t| ");
            dateprod.Show();
            Console.WriteLine();
        }
        public void Read()
        {
            base.Read();
            try
            {
                Console.Write("Введите BusName: "); busname = Console.ReadLine();
                Console.Write("Введите ID: "); id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите Day: "); dateprod.Day = Convert.ToInt16(Console.ReadLine());
                Console.Write("Введите Month: "); dateprod.Month = Convert.ToInt16(Console.ReadLine());
                Console.Write("Введите Year: "); dateprod.Year = Convert.ToInt16(Console.ReadLine());
            }
            catch (Exception) { Console.WriteLine("Ошибка во входных данных"); }
        }
        public object Clone()
        {
            Bus x = new Bus();
            x.Nbus = this.Nbus;
            x.busname = this.busname;
            x.id = this.id;
            x.dateprod.Day = this.dateprod.Day;
            x.dateprod.Month = this.dateprod.Month;
            x.dateprod.Year = this.dateprod.Year;
            return x;
        }
        public int CompareTo(object x)
        {
            int i = 0;
            Bus xx = x as Bus;
            i = String.Compare(this.BusName, xx.BusName);
            return i;
        }
    }
}
