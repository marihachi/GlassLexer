using System;
using System.IO;
using System.Threading.Tasks;

namespace GlassLexer
{
    class Program
    {
        static async Task Main(string[] args)
        {
			// load source
			string code;
			using (var sr = new StreamReader("source.txt"))
			{
				code = await sr.ReadToEndAsync();
			}

			// tokenize
			var tokenizer = new Tokenizer();
			var tokens = tokenizer.Tokenize(code);

			// display
			foreach(var token in tokens)
			{
				Console.Write(token.Type);

				if (token is IValueToken)
					Console.Write($" : \"{(token as ValueToken).Content.Value}\"");

				Console.WriteLine();
			}

			// test
			//var test = new PerformanceTest();
			//test.EqualPartialTest(new Scanner());

			Console.ReadLine();
        }
    }
}
