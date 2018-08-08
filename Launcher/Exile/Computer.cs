using System;
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
