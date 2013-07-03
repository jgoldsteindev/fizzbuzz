using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RulePrinter.Implementation.Rules;

namespace RulePrinterTests
{
	[TestClass]
	public class RulePrinterTest
	{
		[TestMethod]
		public void RulePrinter_InstantiatesProperly()
		{
			const long start = 1;
			const long end = 100;
			var rules = new[] {new Rule(i => i%3 == 0, "fizz")};
			var ruleprinter = new RulePrinter.Implementation.RulePrinters.RulePrinter(start, end, rules);
			Assert.AreEqual(start, ruleprinter.Start);
			Assert.AreEqual(end, ruleprinter.End);
			Assert.AreEqual(rules.Count(), ruleprinter.Rules.Count());
			Assert.IsNotNull(ruleprinter.DefaultResult);
		}

		[TestMethod, ExpectedException(typeof(Exception))]
		public void RulePrinter_ThrowsErrorOnBadConfiguration()
		{
			var results = new RulePrinter.Implementation.RulePrinters.RulePrinter(-1, 0).Execute().ToList();
		}

		[TestMethod]
		public void RulePrinter_IteratesFrom1To100()
		{
			var expectedResults = new int[100].Select((a,b) => (b + 1).ToString()).ToList();
			var results = new RulePrinter.Implementation.RulePrinters.RulePrinter(1, 100).Execute().ToList();
			Assert.IsTrue(expectedResults.SequenceEqual(results));
		}

		[TestMethod]
		public void RulePrinter_IteratesFrom100To1()
		{
			var expectedResults = new int[100].Select((a, b) => (100-b).ToString()).ToList();
			var results = new RulePrinter.Implementation.RulePrinters.RulePrinter(100, 1).Execute().ToList();
			Assert.IsTrue(expectedResults.SequenceEqual(results));
		}

		[TestMethod]
		public void RulePrinter_UsesSimpleRuleProperly()
		{
			var expectedResults = new int[100].Select((a, b) =>
			                                          (b + 1) != 21
				                                          ? (b + 1).ToString()
				                                          : "blackjack").ToList();
			var results = new RulePrinter.Implementation.RulePrinters.RulePrinter(1, 100, new Rule(i => i == 21, "blackjack")).Execute().ToList();
			Assert.IsTrue(expectedResults.SequenceEqual(results));
		}
	}
}