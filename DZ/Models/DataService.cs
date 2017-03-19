using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ.Models
{
	public static class DataService
	{
		public static void Save(string phone, double sum, int count, Lesson lesson)
		{
			Console.WriteLine("");
			Console.WriteLine("Сохранили " + phone + " " + lesson.name + " " + sum);

			string line = phone + " " + lesson.id + " " + sum + " " + count;

			StreamReader sr = new StreamReader("data.txt");

			var data = sr.ReadToEnd();

			sr.Close();

			data += "\n" + line;

			StreamWriter file = new StreamWriter("data.txt");

			file.WriteLine(data);

			file.Close();
		}
	}
}
