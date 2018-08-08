using System;
using System.Collections.Generic;

namespace Launcher.Exile
{
	internal class Texts
	{
		public static string GetText(string Key, params object[] Arguments)
		{
			foreach (KeyValuePair<string, string> keyValuePair in Texts.Text)
			{
				bool flag = keyValuePair.Key == Key;
				if (flag)
				{
					return string.Format(keyValuePair.Value, Arguments);
				}
			}
			return null;
		}

		private static Dictionary<string, string> Text = new Dictionary<string, string>
		{
			{
				"UNKNOWNERROR",
				"Cannot connect to server: \n{0}"
			},
			{
				"MISSINGBINARY",
				"This file is corrupt or missing {0}."
			},
			{
				"CANNOTSTART",
				"Unable to start Main.exe, please run Lancher as Administrator."
			},
			{
				"NONETWORK",
				"The update server is not responding or is not running right now."
			},
			{
				"CONNECTING",
				"Connecting to server."
			},
			{
				"LISTDOWNLOAD",
				"Analyzing patch info.."
			},
			{
				"CHECKFILE",
				"Initializing.."
			},
			{
				"DOWNLOADFILE",
				"Downloading: {0}"
			},
			{
				"COMPLETEPROGRESS",
				"Updated: {0}%"
			},
			{
				"CURRENTPROGRESS",
				"Downloading: {0}%  |  {1} kb/s"
			},
			{
				"CHECKCOMPLETE",
				"Ready to start."
			},
			{
				"DOWNLOADCOMPLETE",
				"Ready to start."
			},
			{
				"DOWNLOADSPEED",
				"{0} kb/s"
			}
		};
	}
}
