namespace GlassLexer
{
	public class Token
	{
		public Token(TokenType type)
		{
			this.Type = type;
		}

		public TokenType Type { get; set; }

		public enum TokenType
		{
			VarKeyword,
			Identifier,     // ValueContent
			IntegerLiteral, // ValueContent
			StringLiteral,  // ValueContent
			SmallBracketBegin,
			SmallBracketEnd,
			MiddleBracketBegin,
			MiddleBracketEnd,
			LargeBracketBegin,
			LargeBracketEnd,
			ArithmeticOp,
			AssignOp,
			EqualOp,
			NotEqualOp,
			Semicolon,
			Comma,
			Dot
		}
	}

	public abstract class ValueToken : Token
	{
		public ValueToken(TokenType type, ValueContent content) : base(type) { this.Content = content; }

		public ValueContent Content { get; set; }
	}

	public class IdentifierToken : ValueToken
	{
		public IdentifierToken(ValueContent content) : base(TokenType.Identifier, content) { }
	}

	public class IntegerLiteral : ValueToken
	{
		public IntegerLiteral(ValueContent content) : base(TokenType.IntegerLiteral, content) { }
	}

	public class StringLiteral : ValueToken
	{
		public StringLiteral(ValueContent content) : base(TokenType.StringLiteral, content) { }
	}

	public abstract class ArithmeticOp : Token
	{
		public ArithmeticOp(ArithmeticOpType op) : base(TokenType.ArithmeticOp)
		{
			this.Op = op;
		}

		public ArithmeticOpType Op { get; set; }

		public enum ArithmeticOpType
		{
			Plus,
			Minus,
			Multi,
			Div
		}
	}
}
