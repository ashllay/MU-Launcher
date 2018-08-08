using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Launcher.Exile
{
	internal class FileChecker
	{
		public static void CheckFiles()
		{
			FileChecker.backgroundWorker.WorkerReportsProgress = true;
			FileChecker.backgroundWorker.DoWork += FileChecker.backgroundWorker_DoWork;
			FileChecker.backgroundWorker.ProgressChanged += FileChecker.backgroundWorker_ProgressChanged;
			FileChecker.backgroundWorker.RunWorkerCompleted += FileChecker.backgroundWorker_RunWorkerCompleted;
			bool isBusy = FileChecker.backgroundWorker.IsBusy;
			if (isBusy)
			{
				MessageBox.Show(Texts.GetText("UNKNOWNERROR", new object[]
				{
					"CheckFiles isBusy"
				}), Globals.Caption);
				Application.Exit();
			}
			else
			{
				FileChecker.backgroundWorker.RunWorkerAsync();
			}
		}

		private static void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			foreach (Globals.File file in Globals.Files)
			{
				Globals.fullSize += 1L;
				FileChecker.backgroundWorker.ReportProgress(0, Path.GetFileName(file.Name));
				bool flag = file.Name.ToLower().Contains("launcher.exe") || file.Name.ToLower().Contains("mu.exe");
				if (flag)
				{
					Globals.completeSize += 1L;
					FileChecker.backgroundWorker.ReportProgress(1);
				}
				else
				{
					bool flag2 = !File.Exists(file.Name.Remove(file.Name.Length - 4, 4)) || Common.GetHash(file.Name.Remove(file.Name.Length - 4, 4)) != file.Hash;
					if (flag2)
					{
						Globals.OldFiles.Add(file.Name);
					}
					else
					{
						Globals.completeSize += 1L;
						FileChecker.backgroundWorker.ReportProgress(1);
					}
				}
			}
		}

		private static void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			bool flag = e.ProgressPercentage == 0;
			if (flag)
			{
				Common.ChangeStatus("CHECKFILE", new string[0]);
			}
			else
			{
				Common.UpdateCompleteProgress(Computer.Compute(Globals.completeSize));
			}
		}

		private static void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			FileDownloader.DownloadFile();
		}

		private static BackgroundWorker backgroundWorker = new BackgroundWorker();

		private enum State
		{
			REPORT_NAME,
			REPORT_PROGRESS
		}
	}
}
