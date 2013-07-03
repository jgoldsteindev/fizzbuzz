using System;
using System.Diagnostics;
using System.Linq;
using RulePrinter.Implementation.RulePrinters;
using RulePrinter.Interfaces;

namespace Fizzbuzz
{
	class Program
	{
		static void Main(string[] args)
		{
			new Program().Process();
		}

		void Process()
		{
			Console.WriteLine("BASIC FIZZBUZZER - 1-100");
			var fizzbuzzer = new BasicFizzBuzzer(1, 100);
			WriteFizzBuzzes(fizzbuzzer);
			Pause();

			Console.WriteLine("BASIC FIZZBUZZER - 100-1");
			fizzbuzzer = new BasicFizzBuzzer(100, 1);
			WriteFizzBuzzes(fizzbuzzer);
			Pause();

			Console.WriteLine("CUSTOM FIZZBUZZER - 1-100");
			var customfizzbuzzer = new CustomFizzBuzzer(1, 100);
			WriteFizzBuzzes(customfizzbuzzer);
			Pause();

			Console.WriteLine("CUSTOM FIZZBUZZER - 1-1,000,000 PERFORMANCE TEST");
			customfizzbuzzer = new CustomFizzBuzzer(1, 1000000);
			Console.Write("Working...");
			var sw = Stopwatch.StartNew();
			var results = customfizzbuzzer.Execute().ToList();
			sw.Stop();
			Console.WriteLine("Done. Time elapsed: {0} ms", sw.ElapsedMilliseconds);
			Pause();
		}

		private void WriteFizzBuzzes(IRulePrinter rulePrinter)
		{
			foreach (var result in rulePrinter.Execute())
				Console.WriteLine(result);
		}

		private static void Pause()
		{
			Console.WriteLine("Press Enter to Continue...");
			Console.ReadLine();
		}
	}
}
