using RulePrinter.Implementation.Rules;

namespace RulePrinter.Implementation.RulePrinters
{
	public class CustomFizzBuzzer : BasicFizzBuzzer
	{
		public CustomFizzBuzzer(long start, long end)
			: base(start, end,
			       new Rule(i => i%4 == 0, "quarterly"),
			       new Rule(i => i/7d == 3, "blackjack"))
		{}
	}
}