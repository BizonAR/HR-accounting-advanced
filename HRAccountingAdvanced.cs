using System;
using System.Collections.Generic;

namespace HRAccountingAdvanced
{
	internal class HRAccountingAdvanced
	{
		static void Main(string[] args)
		{
			const string CommandAddDosier = "1";
			const string CommandDisplayAllDosier = "2";
			const string CommandRemoveDosier = "3";
			const string CommandExit = "4";

			List<string> fullNames = new List<string>(0);
			List<string> positions = new List<string>(0);

			bool isProgramActive = true;

			while (isProgramActive)
			{
				Console.WriteLine("Список команд:\n" +
						$"{CommandAddDosier} - добавить досье\n" +
						$"{CommandDisplayAllDosier} - вывести все досье\n" +
						$"{CommandRemoveDosier} - удалить досье\n" +
						$"{CommandExit} - выход из программы");
				Console.Write("Введите команду: ");
				string input = Console.ReadLine();

				switch (input)
				{
					case CommandAddDosier:
						AddDosier(fullNames, positions);
						break;

					case CommandDisplayAllDosier:
						DisplayAllDosier(fullNames, positions);
						break;

					case CommandRemoveDosier:
						RemoveDosier(fullNames, positions);
						break;

					case CommandExit:
						isProgramActive = false;
						break;

					default:
						Console.WriteLine("Неизвестная команда!");
						break;
				}
			}
		}

		private static void AddDosier(List<string> fullNames, List<string> positions)
		{
			Console.Write("Введите ФИО сотрудника: ");
			string name = Console.ReadLine();
			Console.Write("Введите должность сотрудника: ");
			string jobTitle = Console.ReadLine();

			fullNames.Add(name);
			positions.Add(jobTitle);
		}

		private static void DisplayAllDosier(List<string> fullNames, List<string> positions)
		{
			if (fullNames.Count > 0)
			{
				int index = 1;

				for (int i = 0; i < fullNames.Count; i++)
				{
					Console.WriteLine($"{index}. {fullNames[i]} - {positions[i]}");
					index++;
				}
			}
			else
			{
				Console.WriteLine("Список досье пусть");
			}
		}

		private static void RemoveDosier(List<string> fullNames, List<string> positions)
		{
			if (fullNames.Count > 0)
			{
				Console.Write("Введите индекс сотрудника, которого вы хотите удалить: ");
				int dossierNumber;
				int.TryParse(Console.ReadLine(), out dossierNumber);

				if (dossierNumber > 0 && dossierNumber <= fullNames.Count)
				{
					int index = dossierNumber - 1;
					fullNames.RemoveAt(index);
					positions.RemoveAt(index);
				}
				else
				{
					Console.WriteLine("Нет досье с таким порядковым номером!");
				}
			}
			else
			{
				Console.WriteLine("Список досье пусть");
			}
		}
	}
}
