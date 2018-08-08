using System;
using IniParser.Model.Configuration;

namespace IniParser.Model.Formatting
{
	public interface IIniDataFormatter
	{
		string IniDataToString(IniData iniData);

		IniParserConfiguration Configuration { get; set; }
	}
}
