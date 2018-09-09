namespace GlassLexer
{
	public abstract class Token
	{
		public Token(TokenType type)
		{
			this.Type = type;
		}

		public TokenType Type { get; set; }

		public enum TokenType
		{
			Keyword,        // ValueContent
			Identifier,     // ValueContent
			IntegerLiteral, // ValueContent
			StringLiteral,  // ValueContent
			SmallBracket,   // BracketContent
			MiddleBracket,  // BracketContent
			LargeBracket,   // BracketContent
			ArithmeticOp,   // ArithmeticOpContent
			AssignOp,
			EqualOp,
			NotEqualOp,
			Semicolon,
			Comma,
			Dot
		}
	}

	public interface IValueToken
	{
		ValueContent Content { get; set; }
	}

	public abstract class ValueToken : Token, IValueToken
	{
		public ValueToken(TokenType type, ValueContent content) : base(type) { this.Content = content; }

		public ValueContent Content { get; set; }
	}

	public class KeywordToken : ValueToken
	{
		public KeywordToken(ValueContent content) : base(TokenType.Keyword, content) { }
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

	public abstract class BracketToken : Token
	{
		public BracketToken(TokenType type, BracketContent content) : base(type) { this.Content = content; }

		public BracketContent Content { get; set; }
	}

	public class SmallBracket : BracketToken
	{
		public SmallBracket(BracketContent content) : base(TokenType.SmallBracket, content) { }
	}

	public class MiddleBracket : BracketToken
	{
		public MiddleBracket(BracketContent content) : base(TokenType.MiddleBracket, content) { }
	}

	public class LargeBracket : BracketToken
	{
		public LargeBracket(BracketContent content) : base(TokenType.LargeBracket, content) { }
	}

	public abstract class ArithmeticOp : Token
	{
		public ArithmeticOp(ArithmeticOpContent content) : base(TokenType.ArithmeticOp) { this.Content = content; }

		public ArithmeticOpContent Content { get; set; }
	}

	public class AssignOp : Token
	{
		public AssignOp() : base(TokenType.AssignOp) { }
	}

	public class EqualOp : Token
	{
		public EqualOp() : base(TokenType.EqualOp) { }
	}

	public class NotEqualOp : Token
	{
		public NotEqualOp() : base(TokenType.NotEqualOp) { }
	}

	public class Semicolon : Token
	{
		public Semicolon() : base(TokenType.Semicolon) { }
	}

	public class Comma : Token
	{
		public Comma() : base(TokenType.Comma) { }
	}

	public class Dot : Token
	{
		public Dot() : base(TokenType.Dot) { }
	}
}
