using System;

namespace Launcher.Exile
{
	internal class ListProcessor
	{
		public static void AddFile(string File)
		{
			Globals.File item = default(Globals.File);
			item.Name = File.Split(new char[]
			{
				';'
			})[0];
			item.Hash = File.Split(new char[]
			{
				';'
			})[1];
			Globals.Files.Add(item);
		}
	}
}
