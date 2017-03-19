using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DZ.Models;

namespace Tests
{
	[TestClass]
	public class StoreTests
	{
		[TestMethod]
		public void calculateWithoutDiscountReturnSum()
		{
			var store = new Store();

			var kolvo = 2;
			var coast = 50;
			var isDiscount = false;

			var sum = store.Calculate(kolvo, coast, isDiscount);

			Assert.AreEqual(kolvo * coast, sum);
		}

		[TestMethod]
		public void calculateWithDiscountReturnSum()
		{
			var store = new Store();

			var kolvo = 2;
			var coast = 50;
			var isDiscount = true;

			var sum = store.Calculate(kolvo, coast, isDiscount);

			Assert.AreEqual((kolvo * coast) - ((kolvo * coast) / 100 * 5), sum);
		}
	}
}
