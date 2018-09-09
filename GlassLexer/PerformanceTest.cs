using System;
using System.Diagnostics;

namespace GlassLexer
{
	public class PerformanceTest
	{
		public void EqualPartialTest(Scanner scanner)
		{
			Console.WriteLine("== PerformanceTest.EqualPartial ==");

			int i;
			scanner.Data = "hey";
			scanner.Location = 0;

			var testCount = 10000000; // 10M

			Console.WriteLine($"repeat test {testCount:#,0} times");

			var sw = new Stopwatch();

			sw.Start();

			// char
			i = 0;
			while (i < testCount)
			{
				if (scanner.Match('h', 'e', 'y'))
				{
					i++;
				}
				else throw new Exception();
			}

			sw.Stop();

			Console.WriteLine($"char:   {sw.ElapsedMilliseconds}ms");

			sw.Reset();
			sw.Start();

			// chars
			i = 0;
			var data = new char[] { 'h', 'e', 'y' };
			while (i < testCount)
			{
				if (scanner.Match(data))
				{
					i++;
				}
				else throw new Exception();
			}

			sw.Stop();

			Console.WriteLine($"chars:  {sw.ElapsedMilliseconds}ms");

			sw.Reset();
			sw.Start();

			// string
			i = 0;
			var strData = "hey";
			while (i < testCount)
			{
				if (scanner.Match(strData))
				{
					i++;
				}
				else throw new Exception();
			}

			sw.Stop();

			Console.WriteLine($"string: {sw.ElapsedMilliseconds}ms");

			Console.WriteLine("Done");
		}
	}
}
