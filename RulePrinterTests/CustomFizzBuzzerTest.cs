using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RulePrinter.Implementation.RulePrinters;

namespace RulePrinterTests
{
	[TestClass]
	public class CustomFizzBuzzerTest
	{
		[TestMethod]
		public void CustomFizzBuzzer_InheritsFromBasicFizzBuzzer()
		{
			Assert.IsTrue(typeof(CustomFizzBuzzer).IsSubclassOf(typeof(BasicFizzBuzzer)));
		}

		[TestMethod]
		public void CustomFizzBuzzer_MultipleOf4ReturnsQuarterly()
		{
			var results = new CustomFizzBuzzer(1, 4).Execute().ToList();
			Assert.AreEqual("quarterly", results[3]);
		}

		[TestMethod]
		public void CustomFizzBuzzer_21ReturnsBlackjack()
		{
			var results = new CustomFizzBuzzer(1, 21).Execute().ToList();
			Assert.AreEqual("fizzblackjack", results[20]);
		}

		[TestMethod]
		public void CustomFizzBuzzer_Only21ReturnsBlackjack()
		{
			var results = new CustomFizzBuzzer(1, 100).Execute().ToList();
			Assert.AreEqual(1, results.Count(r => r == "fizzblackjack"));
		}
	}
}
