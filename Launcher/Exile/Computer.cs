// Decompiled with JetBrains decompiler
// Type: Launcher.Exile.Computer
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D4AA755B-F045-4A12-838C-6A7934E8D46E
// Assembly location: D:\NDev\NNTeam\nDev\launcher\Net 4.0\Launcher.exe

using System.Diagnostics;

namespace Launcher.Exile
{
    internal class Computer
    {
        public static long Compute(long Size)
        {
            return Size * 100L / Globals.fullSize;
        }

        public static double ComputeDownloadSize(double Size)
        {
            return Size / 1024.0 / 1024.0;
        }

        public static double ComputeDownloadSpeed(double Size, Stopwatch stopWatch)
        {
            return Size / 1024.0 / stopWatch.Elapsed.TotalSeconds;
        }
    }
}
