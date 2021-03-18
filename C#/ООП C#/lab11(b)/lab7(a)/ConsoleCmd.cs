using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace lab7_a_ {
    [Serializable]
    class ConsoleCmd:Project {
        public void Cmd() {
            Console.Write("Введите название проекта: ");
            SetProject_name(Console.ReadLine());
            string s = GetProject_name();
            string f = "f",e;
            Programer x = new Programer();
            while (f != "stop")
            {
                Console.WriteLine(GetProject_name() + " -> введите команду help");
                f = Console.ReadLine();
                switch (f)
                {
                    case "add": { x.Read(); Add(x); }; break;
                    case "del": DelLast(); break;
                    case "show": Show(); break;
                    case "sort": Sort(); break;
                    case "reverse": Reverse(); break;
                    case "clear": Clear(); break;
                    case "deldupl":DelDupl();break;
                    case "save": { e = Console.ReadLine();save(e); };break;
                    case "read": {
                            Project a;//= new Project();
                            e = Convert.ToString(Console.ReadLine()); a=read(e);a.Show(); };break;
                    case "stop": break;
                    case "help": Console.WriteLine("add del show sort reverse clear deldupl save read stop"); break;
                    default: Console.WriteLine("Неверная команда, введите команду help"); break;
                }
            }
            Console.WriteLine(GetProject_name() + ": программа завершена");
        }
    }
}
