using System;

namespace IniParser.Helpers
{
	internal static class Assert
	{
		internal static bool StringHasNoBlankSpaces(string s)
		{
			return !s.Contains(" ");
		}
	}
}
