// Decompiled with JetBrains decompiler
// Type: Launcher.Exile.ListProcessor
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D4AA755B-F045-4A12-838C-6A7934E8D46E
// Assembly location: D:\NDev\NNTeam\nDev\launcher\Net 4.0\Launcher.exe

namespace Launcher.Exile
{
    internal class ListProcessor
    {
        public static void AddFile(string File)
        {
            Globals.Files.Add(new Globals.File()
            {
                Name = File.Split(';')[0],
                Hash = File.Split(';')[1]
            });
        }
    }
}
