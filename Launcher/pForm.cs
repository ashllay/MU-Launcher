using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using IniParser;
using IniParser.Model;
using Launcher.Exile;
using Launcher.Properties;
using Microsoft.Win32;

namespace Launcher
{
	public partial class pForm : Form
	{
        public pForm()
        {
            this.InitializeComponent();
            IniData iniData = new FileIniDataParser().ReadFile("mu.ini");
            string str1 = iniData["LAUNCHER"]["S12"];
            string str2 = iniData["LAUNCHER"]["updateurl"];
            Globals.ServerURL = str2;
            this.webBrowser1.Url = new Uri(str2 + "index.php");
            if (str1 == "1")
                Globals.UseSeason12 = true;
            Globals.pForm = this;
        }

        private void pForm_Shown(object sender, EventArgs e)
        {
            Common.ChangeStatus("CONNECTING");
            DateTime now = DateTime.Now;
            do
            {
                Application.DoEvents();
            }
            while (now.AddSeconds(1.0) > DateTime.Now);
            this.BeginInvoke((Delegate)new pForm.DoWorkDelegate(this.DoWorkMethod));
            this.timer1.Interval = 600;
            this.timer1.Start();
        }

        public void DoWorkMethod()
        {
            Networking.CheckNetwork();
        }

        public string GetHDDSerial()
        {
            foreach (ManagementObject managementObject in new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia").Get())
            {
                if (managementObject["SerialNumber"] != null)
                    return managementObject["SerialNumber"].ToString();
            }
            return string.Empty;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pForm._m = new Mutex(true, "#32770");
            Starter.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (!Globals.UseSeason12)
            {
                try
                {
                    RegistryKey subKey = Registry.CurrentUser.CreateSubKey("Software\\Webzen\\Mu\\Config");
                    int num = (int)subKey.GetValue("WindowMode");
                    subKey.CreateSubKey("WindowMode");
                    if (num == 1)
                    {
                        subKey.SetValue("WindowMode", (object)0, RegistryValueKind.DWord);
                        this.pictureBox4.BackgroundImage = (Image)Resources.windowmode_uncheck;
                    }
                    else
                    {
                        subKey.SetValue("WindowMode", (object)1, RegistryValueKind.DWord);
                        this.pictureBox4.BackgroundImage = (Image)Resources.windowmode;
                    }
                    subKey.Close();
                }
                catch
                {
                }
            }
            else
            {
                string str = ".\\\\LauncherOption.if";
                try
                {
                    if (System.IO.File.ReadAllLines(str)[1] == "WindowMode:1")
                    {
                        Common.lineChanger("WindowMode:0", str, 2);
                        this.pictureBox4.BackgroundImage = (Image)Resources.windowmode_uncheck;
                    }
                    else
                    {
                        Common.lineChanger("WindowMode:1", str, 2);
                        this.pictureBox4.BackgroundImage = (Image)Resources.windowmode;
                    }
                }
                catch
                {
                    if (!System.IO.File.Exists(str))
                    {
                        string[] contents = new string[3]
                        {
              "DevModeIndex:1",
              "WindowMode:1",
              "ID:"
                        };
                        System.IO.File.WriteAllLines(str, contents);
                    }
                    else
                        Common.lineChanger("WindowMode:1", str, 2);
                    this.pictureBox4.BackgroundImage = (Image)Resources.windowmode;
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Opcoes opcoes = new Opcoes();
            int num = (int)opcoes.ShowDialog();
            opcoes.Dispose();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Common.ReleaseCapture();
            Common.SendMessage(this.Handle, 161, 2, 0);
        }

        private static bool IsSingleInstance()
        {
            try
            {
                Mutex.OpenExisting(pForm.InstanceName);
            }
            catch
            {
                pForm._m = new Mutex(true, pForm.InstanceName);
                return true;
            }
            return false;
        }

        private void pForm_Load(object sender, EventArgs e)
        {
            if (!pForm.IsSingleInstance() && MessageBox.Show("Another Autoupdate is running.\nDo you want to continue?", Globals.Caption, MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                this.Close();
            if (!Globals.UseSeason12)
            {
                try
                {
                    RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Webzen\\Mu\\Config");
                    if (registryKey != null)
                    {
                        if (registryKey.GetValue("WindowMode") != null)
                        {
                            if ((int)registryKey.GetValue("WindowMode") == 1)
                                this.pictureBox4.BackgroundImage = (Image)Resources.windowmode;
                        }
                        else
                        {
                            registryKey = Registry.CurrentUser.CreateSubKey("Software\\Webzen\\Mu\\Config");
                            registryKey.CreateSubKey("WindowMode");
                            registryKey.SetValue("WindowMode", (object)0, RegistryValueKind.DWord);
                        }
                    }
                    else
                    {
                        registryKey = Registry.CurrentUser.CreateSubKey("Software\\Webzen\\Mu\\Config");
                        registryKey.CreateSubKey("WindowMode");
                        registryKey.SetValue("WindowMode", (object)0, RegistryValueKind.DWord);
                    }
                    registryKey.Close();
                }
                catch
                {
                }
            }
            else
            {
                try
                {
                    if (System.IO.File.ReadAllLines("LauncherOption.if")[1] == "WindowMode:1")
                        this.pictureBox4.BackgroundImage = (Image)Resources.windowmode;
                }
                catch
                {
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.pictureBox1.BackgroundImage = (Image)Resources.start_3;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox1.BackgroundImage = (Image)Resources.start_2;
            this.Pic1_Hover = true;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox1.BackgroundImage = (Image)Resources.start_1;
            this.Pic1_Hover = false;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this.pictureBox1.BackgroundImage = (Image)Resources.start_1;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            this.pictureBox3.BackgroundImage = (Image)Resources.setting_3;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            this.pictureBox3.BackgroundImage = (Image)Resources.setting_1;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
        }

        private void CopyRightLabel_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            this.pictureBox2.BackgroundImage = (Image)Resources.exit_3;
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox2.BackgroundImage = (Image)Resources.exit_2;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox2.BackgroundImage = (Image)Resources.exit_1;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            this.pictureBox2.BackgroundImage = (Image)Resources.exit_1;
        }

        private void pictureBox3_MouseHover(object sender, EventArgs e)
        {
            this.pictureBox3.BackgroundImage = (Image)Resources.setting_2;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBox3.BackgroundImage = (Image)Resources.setting_1;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            this.webBrowser1.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Pic1_Hover || !Globals.EnableStartBTN)
                return;
            if (this.blink)
                this.pictureBox1.BackgroundImage = (Image)Resources.start_2;
            else
                this.pictureBox1.BackgroundImage = (Image)Resources.start_1;
            this.blink = !this.blink;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
        }

        private static Mutex _m;

		private static string InstanceName = "#launcheritself";

		private bool Pic1_Hover = false;

		private bool blink = true;

		public delegate void DoWorkDelegate();
	}
}
