using System;
using System.IO;
using IniParser.Model;
using IniParser.Model.Formatting;
using IniParser.Parser;

namespace IniParser
{
	public class StreamIniDataParser
	{
		public IniDataParser Parser { get; protected set; }

		public StreamIniDataParser() : this(new IniDataParser())
		{
		}

		public StreamIniDataParser(IniDataParser parser)
		{
			this.Parser = parser;
		}

		public IniData ReadData(StreamReader reader)
		{
			bool flag = reader == null;
			if (flag)
			{
				throw new ArgumentNullException("reader");
			}
			return this.Parser.Parse(reader.ReadToEnd());
		}

		public void WriteData(StreamWriter writer, IniData iniData)
		{
			bool flag = iniData == null;
			if (flag)
			{
				throw new ArgumentNullException("iniData");
			}
			bool flag2 = writer == null;
			if (flag2)
			{
				throw new ArgumentNullException("writer");
			}
			writer.Write(iniData.ToString());
		}

		public void WriteData(StreamWriter writer, IniData iniData, IIniDataFormatter formatter)
		{
			bool flag = formatter == null;
			if (flag)
			{
				throw new ArgumentNullException("formatter");
			}
			bool flag2 = iniData == null;
			if (flag2)
			{
				throw new ArgumentNullException("iniData");
			}
			bool flag3 = writer == null;
			if (flag3)
			{
				throw new ArgumentNullException("writer");
			}
			writer.Write(iniData.ToString(formatter));
		}
	}
}
