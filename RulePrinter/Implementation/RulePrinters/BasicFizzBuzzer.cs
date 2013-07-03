using System.Linq;
using RulePrinter.Implementation.Rules;

namespace RulePrinter.Implementation.RulePrinters
{
	public class BasicFizzBuzzer : RulePrinter
	{
		public BasicFizzBuzzer(long start, long end)
			: base(start, end,
			       new Rule(i => i%3 == 0, "fizz"),
			       new Rule(i => i%5 == 0, "buzz"))
		{}

		public BasicFizzBuzzer(long start, long end, params Rule[] additionalRules)
			: this(start, end)
		{
			if (additionalRules != null && additionalRules.Any())
				Rules.AddRange(additionalRules);
		}
	}
}