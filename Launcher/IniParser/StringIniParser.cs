using System;
using IniParser.Model;
using IniParser.Parser;

namespace IniParser
{
	[Obsolete("Use class IniDataParser instead. See remarks comments in this class.")]
	public class StringIniParser
	{
		public IniDataParser Parser { get; protected set; }

		public StringIniParser() : this(new IniDataParser())
		{
		}

		public StringIniParser(IniDataParser parser)
		{
			this.Parser = parser;
		}

		public IniData ParseString(string dataStr)
		{
			return this.Parser.Parse(dataStr);
		}

		public string WriteString(IniData iniData)
		{
			return iniData.ToString();
		}
	}
}
