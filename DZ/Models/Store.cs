using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ.Models
{
	public class Store
	{
		bool isNotFirst = false;

		public List<Lesson> lessons;

		public Store()
		{
			lessons = new List<Lesson>();
			lessons.Add(new Lesson() { id = 0, coast = 100, name = "Математика", time = "два дня" });
			lessons.Add(new Lesson() { id = 1, coast = 200, name = "Физика", time = "три дня" });
			lessons.Add(new Lesson() { id = 2, coast = 50, name = "Физра", time = "два дня" });
		}

		public void Hello()
		{
			Console.WriteLine("Приветствие....");
			Console.WriteLine("");
		}

		public void ShowLessons()
		{
			Console.WriteLine("Список предметов:");
			foreach (var lesson in this.lessons)
			{
				Console.WriteLine(lesson.id + "# " + lesson.name);
			}
		}

		public void GetDiscount(bool hasDiscount)
		{
			if (!hasDiscount)
			{
				Console.WriteLine("");
				Console.WriteLine("Хотите получить скидку для новых заказов? (Да / Нет)");

				string choose = Console.ReadLine();

				if (choose == "Да")
				{
					isNotFirst = true;
					Console.WriteLine("");
					Console.WriteLine("Вы получили скидку 5%");
				}
			}
		}

		public double Calculate(int kolvo, double coast, bool isDiscount)
		{
			double sum = kolvo * coast;

			if (isDiscount)
			{
				Console.WriteLine("");
				Console.WriteLine("Была использована скидка!");
				sum = sum - (sum / 100 * 6);
			}

			Console.WriteLine("");
			Console.WriteLine("Это будет стоить " + sum + "руб");

			return sum;
		}

		public void AprovePurchase(double sum, int kolvo, Lesson lesson)
		{
			Console.WriteLine("");
			Console.WriteLine("Введите номер телефона:");

			var phone = Console.ReadLine();

			DataService.Save(phone, sum, kolvo, lesson);
		}

		public void Buy()
		{
			Console.WriteLine("");
			Console.WriteLine("Введите # предмета:");

			try {

				int number = Convert.ToInt32(Console.ReadLine());

				var choosenLesson = lessons[number];

				Console.WriteLine(choosenLesson.name + " (" + choosenLesson.coast + "руб, " + choosenLesson.time + ")");

				Console.WriteLine("");
				Console.WriteLine("Введите количество работ:");

				int kolvo = Convert.ToInt32(Console.ReadLine());

				var sum = Calculate(kolvo, choosenLesson.coast, isNotFirst);

				Console.WriteLine("");
				Console.WriteLine("Вы подтверждаете свой заказ? (Да / Нет)");

				string choose = Console.ReadLine();

				if (choose == "Да")
				{
					GetDiscount(isNotFirst);

					AprovePurchase(sum, kolvo, choosenLesson);
				}
			}
			catch(Exception e)
			{
				Console.WriteLine("Ошибка! " + e.Message);
			}	
		}
	}
}
