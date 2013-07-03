using System;

namespace RulePrinter.Implementation.Rules
{
	public class Rule
	{
		public Rule(Func<long, bool> condition, string result)
		{
			Condition = condition;
			Result = result;
		}

		public Func<long, bool> Condition { get; set; }
		public string Result { get; set; }
	}
}