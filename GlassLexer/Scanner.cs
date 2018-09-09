namespace GlassLexer
{
	public class Scanner
	{
		public string Data { get; set; }

		public int Location { get; set; } = 0;

		public bool IsEnd => (this.Location > this.Data.Length - 1);

		public char CurrentChar => this.Data[this.Location];

		public void Increment(int count = 1)
		{
			this.Location += count;
		}

		public char Read()
		{
			return this.Data[this.Location++];
		}

		private bool CheckIndexRange(int indexOffset)
		{
			return (this.Location + indexOffset) < this.Data.Length;
		}

		public bool Match(char c1, char c2)
		{
			// check c1
			if (this.CurrentChar != c1)
				return false;

			// check index range
			if (!this.CheckIndexRange(1))
				return false;

			// check c2
			if (this.Data[this.Location + 1] != c2)
				return false;

			return true;
		}

		public bool Match(char c1, char c2, char c3)
		{
			// check c1
			if (this.CurrentChar != c1)
				return false;

			// check index range
			if (!this.CheckIndexRange(2))
				return false;

			// check c2
			if (this.Data[this.Location + 1] != c2)
				return false;

			// check c3
			if (this.Data[this.Location + 2] != c3)
				return false;

			return true;
		}

		public bool Match(char[] chars)
		{
			// check index 0
			if (this.CurrentChar != chars[0])
				return false;

			// check index range
			if (!this.CheckIndexRange(chars.Length - 1))
				return false;

			for (int i = 1; i < chars.Length; i++)
			{
				// check index i
				if (this.Data[this.Location + i] != chars[i])
					return false;
			}

			return true;
		}

		public bool Match(string str)
		{
			// check index 0
			if (this.CurrentChar != str[0])
				return false;

			// check index range
			if (!this.CheckIndexRange(str.Length - 1))
				return false;

			for (int i = 1; i < str.Length; i++)
			{
				// check equal char of index i
				if (this.Data[this.Location + i] != str[i])
					return false;
			}

			return true;
		}
	}
}
