using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6_a_ {
    class ConsoleCmd:Project {
        public void Cmd() {
            Console.Write("Введите название проекта: ");
            SetProject_name(Console.ReadLine());
            string s = GetProject_name();
            string f = "f";
            Programer x = new Programer();
            while (f != "stop")
            {
                Console.WriteLine(GetProject_name() + " -> введите команду help");
                f = Console.ReadLine();
                switch (f)
                {
                    case "add": { x.Read(); AddDict(x); }; break;
                    case "del": DelLast(); break;
                    case "show": show(); break;
                    
                    case "clear": DelAll(); break;
                    case "stop": break;
                    case "help": Console.WriteLine("add del show clear stop"); break;
                    default: Console.WriteLine("Неверная команда, введите команду help"); break;
                }
            }
            Console.WriteLine(GetProject_name() + ": программа завершена");
        }
    }
}
