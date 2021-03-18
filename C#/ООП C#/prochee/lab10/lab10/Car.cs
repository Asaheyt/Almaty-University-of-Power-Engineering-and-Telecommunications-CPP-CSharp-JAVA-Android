using System;

namespace lab10
{
    [Serializable]
    public class Car
    {
        int nbus;
        public Car() { }
        public Car(int n) { nbus = n; }
        public int Nbus
        {
            get { return nbus; }
            set { nbus = value; }
        }
        public void Show()
        {
            Console.Write(nbus + "\t| ");
        }
        public void Read()
        {
            try
            {
                Console.Write("Введите Nbus: "); nbus = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка во входных данных");
            }
        }
    }
}
