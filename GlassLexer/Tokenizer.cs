using System;
using System.Collections.Generic;

namespace GlassLexer
{
	public class Tokenizer
	{
		private Scanner Scanner { get; set; } = new Scanner();

		private Token CurrentToken { get; set; }

		private bool IsNextToken { get; set; }

		/// <summary>
		/// 現在のループ終了後に、次のトークンへ移行します。
		/// </summary>
		private void NextToken()
		{
			this.IsNextToken = true;
		}

		/// <summary>
		/// source を複数のトークンに区切ります
		/// </summary>
		/// <param name="source"></param>
		public List<Token> Tokenize(string source)
		{
			var tokens = new List<Token>();

			this.Scanner.Data = source;
			this.Scanner.Location = 0;

			while (!this.Scanner.IsEnd) // token loop
			{
				// initialize token
				this.IsNextToken = false;
				this.CurrentToken = null;

				this.LoopInitialize();

				while (!this.Scanner.IsEnd && !this.IsNextToken) // loop
				{
					this.Loop();
				}

				// insert token
				if (this.CurrentToken != null)
					tokens.Add(this.CurrentToken);
			}

			return tokens;
		}

		// -- user logic --

		private bool IsComment = false;

		private void LoopInitialize()
		{
			this.IsComment = false;
		}

		private void Loop()
		{
			// state: comment
			if (this.IsComment)
			{
				// end (*/)
				if (this.Scanner.Match(TokenConstant.CommentEnd))
				{
					this.IsComment = false;

					this.Scanner.Increment(2);
				}

				// noop
				else
				{
					this.Scanner.Increment();
				}
			}

			// state: new token
			else if (this.CurrentToken == null)
			{
				// noop
				if (this.Scanner.CurrentChar == ' ' || this.Scanner.CurrentChar == '\t')
				{
					this.Scanner.Increment();
				}

				// noop (length 2)
				else if (this.Scanner.Match(TokenConstant.CRLF))
				{
					this.Scanner.Increment(2);
				}

				// begin string literal (")
				else if (this.Scanner.CurrentChar == TokenConstant.StringLiteralMarkChar)
				{
					this.CurrentToken = new StringLiteral(new ValueContent());
					this.Scanner.Increment();
				}

				// begin comment (/*)
				else if (this.Scanner.Match(TokenConstant.CommentBegin))
				{
					this.IsComment = true;
					this.Scanner.Increment(2);
				}

				// keyword: var
				else if (this.Scanner.Match(TokenConstant.KeywordVar))
				{
					var token = new KeywordToken(new ValueContent());
					token.Content.AddString(TokenConstant.KeywordVar);
					this.CurrentToken = token;

					this.Scanner.Increment(3);
					this.NextToken();
				}

				// equal op (==)
				else if (this.Scanner.Match(TokenConstant.EqualOp))
				{
					this.CurrentToken = new EqualOp();

					this.Scanner.Increment(2);
					this.NextToken();
				}

				// assign op (=)
				else if (this.Scanner.CurrentChar == TokenConstant.AssignOpChar)
				{
					this.CurrentToken = new AssignOp();

					this.Scanner.Increment();
					this.NextToken();
				}

				// (;)
				else if (this.Scanner.CurrentChar == TokenConstant.SemicolonChar)
				{
					this.CurrentToken = new Semicolon();

					this.Scanner.Increment();
					this.NextToken();
				}

				// identifier
				else if (this.Scanner.CurrentChar >= 'a' && this.Scanner.CurrentChar <= 'z' ||
					this.Scanner.CurrentChar >= 'A' && this.Scanner.CurrentChar <= 'Z' || this.Scanner.CurrentChar == '_')
				{
					this.CurrentToken = new IdentifierToken(new ValueContent());
				}

				// number
				else if (this.Scanner.CurrentChar >= '0' && this.Scanner.CurrentChar <= '9')
				{
					// TODO

					this.Scanner.Increment();
				}

				// unknown
				else
				{
					Console.WriteLine("unknown char: " + this.Scanner.Read());
				}
			}

			// state: content of string literal
			else if (this.CurrentToken is StringLiteral)
			{
				// add chars
				if (this.Scanner.CurrentChar != TokenConstant.StringLiteralMarkChar)
				{
					var strToken = (StringLiteral)this.CurrentToken;
					strToken.Content.AddChar(this.Scanner.Read());
				}

				// end
				else
				{
					this.Scanner.Increment();
					this.NextToken();
				}
			}

			// state: content of identifier
			else if (this.CurrentToken is IdentifierToken)
			{
				// add chars
				if (
					this.Scanner.CurrentChar >= 'a' && this.Scanner.CurrentChar <= 'z' ||
					this.Scanner.CurrentChar >= 'A' && this.Scanner.CurrentChar <= 'Z' ||
					this.Scanner.CurrentChar == '_' ||
					this.Scanner.CurrentChar >= '0' && this.Scanner.CurrentChar <= '9')
				{
					var identifierToken = (IdentifierToken)this.CurrentToken;
					identifierToken.Content.AddChar(this.Scanner.CurrentChar);

					this.Scanner.Increment();
				}

				// end
				else
				{
					this.Scanner.Increment();
					this.NextToken();
				}
			}
		}
	}
}
