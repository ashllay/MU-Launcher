using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;

namespace Launcher.Exile
{
	internal class Networking
	{
		public static void CheckNetwork()
		{
			Common.ChangeStatus("CONNECTING", new string[0]);
			BackgroundWorker backgroundWorker = new BackgroundWorker();
			backgroundWorker.DoWork += Networking.backgroundWorker_DoWork;
			backgroundWorker.RunWorkerCompleted += Networking.backgroundWorker_RunWorkerCompleted;
			bool isBusy = backgroundWorker.IsBusy;
			if (isBusy)
			{
				MessageBox.Show(Texts.GetText("UNKNOWNERROR", new object[]
				{
					"CheckNetwork isBusy"
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
			try
			{
				WebClient webClient = new WebClient();
				webClient.OpenRead(Globals.ServerURL);
				e.Result = true;
			}
			catch
			{
				e.Result = false;
			}
		}

		private static void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			bool flag = !Convert.ToBoolean(e.Result);
			if (flag)
			{
				MessageBox.Show(Texts.GetText("NONETWORK", new object[0]), Globals.Caption);
				Application.Exit();
			}
			else
			{
				ListDownloader.DownloadList();
			}
		}
	}
}
