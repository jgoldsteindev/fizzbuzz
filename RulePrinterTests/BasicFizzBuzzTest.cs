using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RulePrinter.Implementation.RulePrinters;

namespace RulePrinterTests
{
	[TestClass]
	public class BasicFizzBuzzTest
	{
		[TestMethod]
		public void BasicFizzBuzz_MultipleOf3ReturnsFizz()
		{
			var results = new BasicFizzBuzzer(1, 3).Execute().ToList();
			Assert.AreEqual("fizz", results[2]);
		}

		[TestMethod]
		public void BasicFizzBuzz_MultipleOf5ReturnsBuzz()
		{
			var results = new BasicFizzBuzzer(1, 5).Execute().ToList();
			Assert.AreEqual("buzz", results[4]);
		}

		[TestMethod]
		public void BasicFizzBuzz_MultiplesOf3And5ReturnsFizzBuzz()
		{
			var results = new BasicFizzBuzzer(1, 15).Execute().ToList();
			Assert.AreEqual("fizzbuzz", results[14]);
		}

		[TestMethod]
		public void BasicFizzBuzz_NonMultiplesOf3Or5ReturnsNumber()
		{
			var results = new BasicFizzBuzzer(1, 3).Execute().ToList();
			Assert.AreEqual("1", results[0]);
		}
	}
}
