using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_a_ {
    class ConsoleCmd:Project {
        public void Cmd() {
            Console.Write("Введите название автобусного парка: ");
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
                    case "add": { x.Read(); Add(x); }; break;
                    case "del": DelLast(); break;
                    case "show": Show(); break;
                    case "sort": Sort(); break;
                    case "reverse": Reverse(); break;
                    case "clear": Clear(); break;
                    case "stop": break;
                    case "help": Console.WriteLine("add del show sort reverse clear stop"); break;
                    default: Console.WriteLine("Неверная команда, введите команду help"); break;
                }
            }
            Console.WriteLine(GetProject_name() + ": программа завершена");
        }
    }
}
