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
}
