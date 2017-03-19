using System;
using DZ.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ
{
	class Program
	{
		static void Main(string[] args)
		{
			var store = new Store();

			store.Hello();

			store.ShowLessons();

			while (true)
			{
				store.Buy();
				Console.ReadLine();
			}
		}
	}
}
