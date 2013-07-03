using System.Collections.Generic;
using RulePrinter.Implementation.Rules;

namespace RulePrinter.Interfaces
{
	public interface IRulePrinter
	{
		List<Rule> Rules { get; set; }
		IEnumerable<string> Execute();
	}
}