using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RulePrinter.Implementation.Rules;
using RulePrinter.Interfaces;

namespace RulePrinter.Implementation.RulePrinters
{
	public class RulePrinter : IRulePrinter
	{
		public long Start { get; set; }
		public long End { get; set; }
		public Func<long, string> DefaultResult { get; set; }
		public List<Rule> Rules { get; set; }
		
		public RulePrinter(long start, long end, params Rule[] rules)
		{
			Start = start;
			End = end;
			Rules = rules != null ? rules.ToList() : null;
			DefaultResult = i => i.ToString();
		}

		public RulePrinter(long start, long end, Func<long, string> defaultResult, params Rule[] rules)
			:this(start, end, rules)
		{
			DefaultResult = defaultResult;
		}

		public IEnumerable<string> Execute()
		{
			CheckConfiguration();

			foreach (var i in GetIterator())
			{
				var sb = new StringBuilder();
				if (Rules != null)
					Rules.ForEach(r => sb.Append(r.Condition(i) ? r.Result : String.Empty));
				if (sb.Length == 0)
					sb.Append(DefaultResult(i));
				yield return sb.ToString();
			}
		}

		private IEnumerable<long> GetIterator()
		{
			if (Start <= End)
				for (var i = Start; i <= End; i++)
					yield return i;
			else
				for (var i = Start; i >= End; i--)
					yield return i;
		}

		private void CheckConfiguration()
		{
			if (Start < 0)
				throw new Exception("Class property 'Start' must be 0 or above.");
			
			if (End < 0)
				throw new Exception("Class property 'End' must be 0 or above.");
		}
	}
}
