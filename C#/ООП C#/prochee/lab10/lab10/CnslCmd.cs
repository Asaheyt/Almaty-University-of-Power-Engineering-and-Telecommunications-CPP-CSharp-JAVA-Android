using System;

namespace lab10
{
    class CnslCmd
    {
        static public void Cmd(BusPark x)
        {
            string f = "f";
            Bus y = new Bus();
            while (f != "stop")
            {
                Console.WriteLine("Введите команду");
                f = Console.ReadLine();
                switch (f)
                {
                    case "read": x.ReadFromFile(); break;
                    case "save": x.SaveToFile(); break;
                    case "append": x.AppendFromFile(); break;
                    case "readx": x.ReadFromXMLFile(); break;
                    case "savex": x.SaveToXMLFile(); break;
                    case "appendx": x.AppendFromXMLFile(); break;
                    case "add":
                        {
                            y.Read();
                            x.Add(y);
                        };
                        break;
                    case "fill": x.Fill(); break;
                    case "del": x.Delete(); break;
                    case "show": x.Show(); break;
                    case "sort": x.Sort(); break;
                    case "reverse": x.Reverse(); break;
                    case "deldub": x.DelDoubles(); break;
                    case "clear": x.Clear(); break;
                    case "stop": break;
                    case "help": Console.WriteLine("read save append readx savex appendx\nadd fill del show sort reverse deldub clear stop"); break;
                    default: Console.WriteLine("Неверная команда"); break;
                }
            }
            Console.WriteLine("Программа завершена");
        }
    }
}
