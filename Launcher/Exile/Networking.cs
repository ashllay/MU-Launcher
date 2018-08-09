// Decompiled with JetBrains decompiler
// Type: Launcher.Exile.Networking
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D4AA755B-F045-4A12-838C-6A7934E8D46E
// Assembly location: D:\NDev\NNTeam\nDev\launcher\Net 4.0\Launcher.exe

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
            Common.ChangeStatus("CONNECTING");
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(Networking.backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Networking.backgroundWorker_RunWorkerCompleted);
            if (backgroundWorker.IsBusy)
            {
                int num = (int)MessageBox.Show(Texts.GetText("UNKNOWNERROR", (object)"CheckNetwork isBusy"), Globals.Caption);
                Application.Exit();
            }
            else
                backgroundWorker.RunWorkerAsync();
        }

        private static void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                new WebClient().OpenRead(Globals.ServerURL);
                e.Result = (object)true;
            }
            catch
            {
                e.Result = (object)false;
            }
        }

        private static void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!Convert.ToBoolean(e.Result))
            {
                int num = (int)MessageBox.Show(Texts.GetText("NONETWORK"), Globals.Caption);
                Application.Exit();
            }
            else
                ListDownloader.DownloadList();
        }
    }
}
