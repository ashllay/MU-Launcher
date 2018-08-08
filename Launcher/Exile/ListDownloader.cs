using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Launcher.Exile
{
	internal class ListDownloader
	{
		public static void DownloadList()
		{
			BackgroundWorker backgroundWorker = new BackgroundWorker();
			Common.ChangeStatus("LISTDOWNLOAD", new string[0]);
			backgroundWorker.DoWork += ListDownloader.backgroundWorker_DoWork;
			backgroundWorker.RunWorkerCompleted += ListDownloader.backgroundWorker_RunWorkerCompleted;
			bool isBusy = backgroundWorker.IsBusy;
			if (isBusy)
			{
				MessageBox.Show(Texts.GetText("UNKNOWNERROR", new object[]
				{
					"DownloadList isBusy"
				}), Globals.Caption);
				Application.Exit();
			}
			else
			{
				backgroundWorker.RunWorkerAsync();
			}
		}

		private static void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			WebClient webClient = new WebClient();
			Stream stream = webClient.OpenRead(Globals.ServerURL + Globals.PatchlistName);
			StreamReader streamReader = new StreamReader(stream);
			while (!streamReader.EndOfStream)
			{
				ListProcessor.AddFile(streamReader.ReadLine());
			}
		}

		private static void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			FileChecker.CheckFiles();
		}
	}
}
