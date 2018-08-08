using System;
using System.Reflection;

namespace IniParser.Exceptions
{
	public class ParsingException : Exception
	{
		public Version LibVersion { get; private set; }

		public int LineNumber { get; private set; }

		public string LineValue { get; private set; }

		public ParsingException(string msg) : this(msg, 0, string.Empty, null)
		{
		}

		public ParsingException(string msg, Exception innerException) : this(msg, 0, string.Empty, innerException)
		{
		}

		public ParsingException(string msg, int lineNumber, string lineValue) : this(msg, lineNumber, lineValue, null)
		{
		}

		public ParsingException(string msg, int lineNumber, string lineValue, Exception innerException) : base(string.Format("{0} while parsing line number {1} with value '{2}' - IniParser version: {3}", new object[]
		{
			msg,
			lineNumber,
			lineValue,
			Assembly.GetExecutingAssembly().GetName().Version
		}), innerException)
		{
			this.LibVersion = Assembly.GetExecutingAssembly().GetName().Version;
			this.LineNumber = lineNumber;
			this.LineValue = lineValue;
		}
	}
}
