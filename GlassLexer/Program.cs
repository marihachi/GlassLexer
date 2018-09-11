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

			Console.WriteLine("# tokenize result");

			// display
			foreach (var token in tokens)
			{
				Console.Write(token.Type);

				if (token is ValueToken)
					Console.Write($" : \"{(token as ValueToken).Content.Value}\"");
				else if (token is ArithmeticOp)
					Console.Write($" : {(token as ArithmeticOp).Op}");

				Console.WriteLine();
			}

			// define
			var stringLiteral = new Syntax();
			stringLiteral.AddRange(new[] {
				Token.TokenType.VarKeyword,
				Token.TokenType.Identifier,
				Token.TokenType.AssignOp,
				Token.TokenType.StringLiteral,
				Token.TokenType.Semicolon
			});
			var result = stringLiteral.Match(tokens);
			Console.WriteLine($"# parse result = {result}");

			// test
			//var test = new PerformanceTest();
			//test.EqualPartialTest(new Scanner());

			Console.ReadLine();
        }
    }
}
