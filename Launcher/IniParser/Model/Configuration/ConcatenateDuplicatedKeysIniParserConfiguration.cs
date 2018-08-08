using System;

namespace IniParser.Model.Configuration
{
	public class ConcatenateDuplicatedKeysIniParserConfiguration : IniParserConfiguration
	{
		public new bool AllowDuplicateKeys
		{
			get
			{
				return true;
			}
		}

		public ConcatenateDuplicatedKeysIniParserConfiguration()
		{
			this.ConcatenateSeparator = ";";
		}

		public ConcatenateDuplicatedKeysIniParserConfiguration(ConcatenateDuplicatedKeysIniParserConfiguration ori) : base(ori)
		{
			this.ConcatenateSeparator = ori.ConcatenateSeparator;
		}

		public string ConcatenateSeparator { get; set; }
	}
}
