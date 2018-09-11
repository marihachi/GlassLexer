using System;
using System.Collections.Generic;
using System.Linq;

namespace GlassLexer
{
	public class Syntax
	{
		public Token TokenValue { get; private set; }

		public List<Syntax> Sequence { get; private set; } = new List<Syntax>();

		public bool HasToken => this.TokenValue != null;

		public void Add(Syntax syntax)
		{
			if (this.HasToken) throw new InvalidOperationException("this syntax has a token");

			this.Sequence.Add(syntax);
		}

		public void Add(Token token)
		{
			Add(FromToken(token));
		}

		public void Add(Token.TokenType tokenType)
		{
			Add(FromTokenType(tokenType));
		}

		public void AddRange(IEnumerable<Syntax> syntaxSequence)
		{
			if (this.HasToken) throw new InvalidOperationException("this syntax has a token");

			this.Sequence.AddRange(syntaxSequence);
		}

		public void AddRange(IEnumerable<Token> tokens)
		{
			AddRange(tokens.Select(i => FromToken(i)));
		}

		public void AddRange(IEnumerable<Token.TokenType> tokenTypes)
		{
			AddRange(tokenTypes.Select(i => FromTokenType(i)));
		}

		public static Syntax FromToken(Token token)
		{
			return new Syntax { TokenValue = token, Sequence = null };
		}

		public static Syntax FromTokenType(Token.TokenType tokenType)
		{
			return new Syntax { TokenValue = new Token(tokenType), Sequence = null };
		}

		/// <summary>
		/// 渡されたトークン列のタイプが syntax に合致するかどうかを返します
		/// </summary>
		public bool Match(List<Token> tokens)
		{
			// TODO
			return false;
		}

		/// <summary>
		/// 渡されたトークン列のタイプが syntax に合致するかどうかを返します
		/// </summary>
		public bool Match(List<Syntax> syntaxSequence)
		{
			// TODO
			return false;
		}
	}
}
