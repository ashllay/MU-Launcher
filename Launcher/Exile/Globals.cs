using System;
using System.Collections.Generic;

namespace Launcher.Exile
{
	internal class Globals
	{
		public static string ServerURL = "http://js.exilemu.com/launcher/";

		public static string PatchlistName = "update.txt";

		public static string BinaryName = "Main.exe";

		public static string Caption = "Launcher";

		public static bool EnableStartBTN = false;

		public static pForm pForm;

		public static bool UseSeason12 = false;

		public static List<Globals.File> Files = new List<Globals.File>();

		public static List<string> OldFiles = new List<string>();

		public static long fullSize;

		public static long completeSize;

		public struct File
		{
			public string Name;

			public string Hash;
		}
	}
}
