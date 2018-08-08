using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using Launcher.Properties;

namespace Launcher.Exile
{
	internal class FileDownloader
	{
		public static void DownloadFile()
		{
			bool flag = Globals.OldFiles.Count <= 0;
			if (flag)
			{
				Common.ChangeStatus("CHECKCOMPLETE", new string[0]);
				Globals.pForm.pictureBox1.BackgroundImage = Resources.start_1;
				Common.EnableStart();
			}
			else
			{
				bool flag2 = FileDownloader.curFile >= Globals.OldFiles.Count;
				if (flag2)
				{
					Common.ChangeStatus("DOWNLOADCOMPLETE", new string[0]);
					Globals.pForm.pictureBox1.BackgroundImage = Resources.start_1;
					Common.EnableStart();
				}
				else
				{
					bool flag3 = Globals.OldFiles[FileDownloader.curFile].Contains("\\");
					if (flag3)
					{
						Directory.CreateDirectory(Path.GetDirectoryName(Globals.OldFiles[FileDownloader.curFile]));
					}
					WebClient webClient = new WebClient();
					webClient.DownloadProgressChanged += FileDownloader.webClient_DownloadProgressChanged;
					webClient.DownloadFileCompleted += FileDownloader.webClient_DownloadFileCompleted;
					FileDownloader.stopWatch.Start();
					webClient.DownloadFileAsync(new Uri(Globals.ServerURL + Globals.OldFiles[FileDownloader.curFile]), Globals.OldFiles[FileDownloader.curFile].Remove(Globals.OldFiles[FileDownloader.curFile].Length - 4, 4));
				}
			}
		}

		private static void webClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			FileDownloader.currentBytes = FileDownloader.lastBytes + e.BytesReceived;
			Common.ChangeStatus("DOWNLOADFILE", new string[]
			{
				Globals.OldFiles[FileDownloader.curFile].Remove(Globals.OldFiles[FileDownloader.curFile].Length - 4, 4)
			});
			Common.UpdateCompleteProgress(Computer.Compute(Globals.completeSize + FileDownloader.currentBytes));
			Common.UpdateCurrentProgress((long)e.ProgressPercentage, Computer.ComputeDownloadSpeed((double)e.BytesReceived, FileDownloader.stopWatch));
		}

		private static void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
		{
			FileDownloader.lastBytes = FileDownloader.currentBytes;
			Common.UpdateCurrentProgress(100L, 0.0);
			FileDownloader.curFile++;
			FileDownloader.stopWatch.Reset();
			FileDownloader.DownloadFile();
		}

		private static int curFile;

		private static long lastBytes;

		private static long currentBytes;

		private static Stopwatch stopWatch = new Stopwatch();
	}
}
