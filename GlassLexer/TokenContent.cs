using System.Text;

namespace GlassLexer
{
	public abstract class TokenContent { }

	public class ValueContent : TokenContent
	{
		public string Value => this.ValueBuilder.ToString();

		public StringBuilder ValueBuilder { get; set; } = new StringBuilder();

		public void AddChar(char c)
		{
			this.ValueBuilder.Append(c);
		}

		public void AddString(string str)
		{
			this.ValueBuilder.Append(str);
		}
	}

	public class BracketContent : TokenContent
	{
		public BracketContent(BracketType type)
		{
			this.Type = type;
		}

		public BracketType Type { get; set; }

		public enum BracketType
		{
			BracketBegin,
			BracketEnd
		}
	}

	public class ArithmeticOpContent : TokenContent
	{
		public ArithmeticOpContent(ArithmeticOpType type)
		{
			this.Type = type;
		}

		public ArithmeticOpType Type { get; set; }

		public enum ArithmeticOpType
		{
			Plus,
			Minus,
			Multi,
			Div
		}
	}
}
