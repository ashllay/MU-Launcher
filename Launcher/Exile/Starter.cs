using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Launcher.Exile
{
	internal class Starter
	{
		public static void Start()
		{
			bool flag = !File.Exists(Globals.BinaryName);
			if (flag)
			{
				MessageBox.Show(Texts.GetText("MISSINGBINARY", new object[]
				{
					Globals.BinaryName
				}), Globals.Caption);
			}
			else
			{
				try
				{
					Process.Start(Globals.BinaryName);
					Globals.pForm.WindowState = FormWindowState.Minimized;
					Thread.Sleep(5000);
					Application.Exit();
				}
				catch (Exception ex)
				{
					MessageBox.Show(Texts.GetText("UNKNOWNERROR", new object[]
					{
						ex.Message
					}), Globals.Caption);
					Application.Exit();
				}
			}
		}
	}
}
