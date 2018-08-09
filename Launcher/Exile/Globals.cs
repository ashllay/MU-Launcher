// Decompiled with JetBrains decompiler
// Type: Launcher.Exile.Globals
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D4AA755B-F045-4A12-838C-6A7934E8D46E
// Assembly location: D:\NDev\NNTeam\nDev\launcher\Net 4.0\Launcher.exe

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
        public static bool UseSeason12 = false;
        public static List<Globals.File> Files = new List<Globals.File>();
        public static List<string> OldFiles = new List<string>();
        public static pForm pForm;
        public static long fullSize;
        public static long completeSize;

        public struct File
        {
            public string Name;
            public string Hash;
        }
    }
}
