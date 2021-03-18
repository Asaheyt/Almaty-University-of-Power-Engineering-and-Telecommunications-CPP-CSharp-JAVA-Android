#pragma once
/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
#include <iostream>
#include <string>
using namespace std;
using namespace System;


	class Engineer {
	private:
		string institute_of_high_learning, direction;
	public:
		Engineer() { }
		Engineer(string i, string d) {
			institute_of_high_learning = i; direction = d;
		}
		void SetInstitute_of_high_learning(string i) {
			institute_of_high_learning = i;
		}
		string GetInstitute_of_high_learning() {
			return institute_of_high_learning;
		}
		void SetDirection(string d) {
			direction = d;
		}
		string GetDirection() {
			return direction;
		}
		void Show() {
			Console.Write("ВУЗ:" + institute_of_high_learning + "\t|Направление:" + direction + "\t|");
		}
		void Read() {
			Console.WriteLine("Введите данные: ");
			Console.WriteLine("ВУЗ: ");
			bool OK = false;
			while (!OK)
			{
				institute_of_high_learning = Console.ReadLine();
				for (int j = 0; j < institute_of_high_learning.size; j++)
				{
					if ((institute_of_high_learning[j] >= 'A' && institute_of_high_learning[j] <= 'Z') || (institute_of_high_learning[j] >= 'a' && institute_of_high_learning[j] <= 'z') || (institute_of_high_learning[j] >= 'А' && institute_of_high_learning[j] <= 'Я') || (institute_of_high_learning[j] >= 'а' && institute_of_high_learning[j] <= 'я') || (j != 0 && institute_of_high_learning[j] == ' '))
					{
						OK = true;
					}
					else { OK = false; break; }
				}
				if (OK == false) { Console.WriteLine("Ошибка! Введите ВУЗ: "); }
			}
			OK = false;
			Console.WriteLine("Направление: ");
			while (!OK)
			{
				direction = Console.ReadLine();
				for (int j = 0; j < direction.size; j++)
				{
					if ((direction[j] >= 'A' && direction[j] <= 'Z') || (direction[j] >= 'a' && direction[j] <= 'z') || (direction[j] >= 'А' && direction[j] <= 'Я') || (direction[j] >= 'а' && direction[j] <= 'я') || (j != 0 && direction[j] == ' '))
					{
						OK = true;
					}
					else { OK = false; break; }
				}
				if (OK == false) { Console.WriteLine("Ошибка! Введите Направление: "); }
			}
		}

	};
