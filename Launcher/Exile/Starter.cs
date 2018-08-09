// Decompiled with JetBrains decompiler
// Type: Launcher.Exile.Starter
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D4AA755B-F045-4A12-838C-6A7934E8D46E
// Assembly location: D:\NDev\NNTeam\nDev\launcher\Net 4.0\Launcher.exe

using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Launcher.Exile
{
    internal class Starter
    {
        public static void Start()
        {
            if (!System.IO.File.Exists(Globals.BinaryName))
            {
                int num1 = (int)MessageBox.Show(Texts.GetText("MISSINGBINARY", (object)Globals.BinaryName), Globals.Caption);
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
                    int num2 = (int)MessageBox.Show(Texts.GetText("UNKNOWNERROR", (object)ex.Message), Globals.Caption);
                    Application.Exit();
                }
            }
        }
    }
}
