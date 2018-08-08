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
			FileIniDataParser fileIniDataParser = new FileIniDataParser();
			IniData iniData = fileIniDataParser.ReadFile("mu.ini");
			string a = iniData["LAUNCHER"]["S12"];
			string text = iniData["LAUNCHER"]["updateurl"];
			Globals.ServerURL = text;
			this.webBrowser1.Url = new Uri(text + "index.php");
			bool flag = a == "1";
			if (flag)
			{
				Globals.UseSeason12 = true;
			}
			Globals.pForm = this;
		}

		private void pForm_Shown(object sender, EventArgs e)
		{
			Common.ChangeStatus("CONNECTING", new string[0]);
			DateTime now = DateTime.Now;
			do
			{
				Application.DoEvents();
			}
			while (now.AddSeconds(1.0) > DateTime.Now);
			base.BeginInvoke(new pForm.DoWorkDelegate(this.DoWorkMethod));
			this.timer1.Interval = 600;
			this.timer1.Start();
		}

		public void DoWorkMethod()
		{
			Networking.CheckNetwork();
		}

		public string GetHDDSerial()
		{
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
			foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
			{
				ManagementObject managementObject = (ManagementObject)managementBaseObject;
				bool flag = managementObject["SerialNumber"] != null;
				if (flag)
				{
					return managementObject["SerialNumber"].ToString();
				}
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
			base.Close();
		}

		private void pictureBox4_Click(object sender, EventArgs e)
		{
			bool flag = !Globals.UseSeason12;
			if (flag)
			{
				try
				{
					RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Software\\Webzen\\Mu\\Config");
					int num = (int)registryKey.GetValue("WindowMode");
					registryKey.CreateSubKey("WindowMode");
					bool flag2 = num == 1;
					if (flag2)
					{
						registryKey.SetValue("WindowMode", 0, RegistryValueKind.DWord);
						this.pictureBox4.BackgroundImage = Resources.windowmode_uncheck;
					}
					else
					{
						registryKey.SetValue("WindowMode", 1, RegistryValueKind.DWord);
						this.pictureBox4.BackgroundImage = Resources.windowmode;
					}
					registryKey.Close();
				}
				catch
				{
				}
			}
			else
			{
				string text = ".\\\\LauncherOption.if";
				try
				{
					string[] array = File.ReadAllLines(text);
					bool flag3 = array[1] == "WindowMode:1";
					if (flag3)
					{
						Common.lineChanger("WindowMode:0", text, 2);
						this.pictureBox4.BackgroundImage = Resources.windowmode_uncheck;
					}
					else
					{
						Common.lineChanger("WindowMode:1", text, 2);
						this.pictureBox4.BackgroundImage = Resources.windowmode;
					}
				}
				catch
				{
					bool flag4 = !File.Exists(text);
					if (flag4)
					{
						string[] contents = new string[]
						{
							"DevModeIndex:1",
							"WindowMode:1",
							"ID:"
						};
						File.WriteAllLines(text, contents);
					}
					else
					{
						Common.lineChanger("WindowMode:1", text, 2);
					}
					this.pictureBox4.BackgroundImage = Resources.windowmode;
				}
			}
		}

		private void pictureBox3_Click(object sender, EventArgs e)
		{
			Opcoes opcoes = new Opcoes();
			opcoes.ShowDialog();
			opcoes.Dispose();
		}

		private void pictureBox5_Click(object sender, EventArgs e)
		{
		}

		private void pictureBox6_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void pForm_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				Common.ReleaseCapture();
				Common.SendMessage(base.Handle, 161, 2, 0);
			}
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
			bool flag = !pForm.IsSingleInstance();
			if (flag)
			{
				DialogResult dialogResult = MessageBox.Show("Another Autoupdate is running.\nDo you want to continue?", Globals.Caption, MessageBoxButtons.OKCancel);
				bool flag2 = dialogResult == DialogResult.Cancel;
				if (flag2)
				{
					base.Close();
				}
			}
			bool flag3 = !Globals.UseSeason12;
			if (flag3)
			{
				try
				{
					RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Webzen\\Mu\\Config");
					bool flag4 = registryKey != null;
					if (flag4)
					{
						bool flag5 = registryKey.GetValue("WindowMode") != null;
						if (flag5)
						{
							int num = (int)registryKey.GetValue("WindowMode");
							bool flag6 = num == 1;
							if (flag6)
							{
								this.pictureBox4.BackgroundImage = Resources.windowmode;
							}
						}
						else
						{
							registryKey = Registry.CurrentUser.CreateSubKey("Software\\Webzen\\Mu\\Config");
							registryKey.CreateSubKey("WindowMode");
							registryKey.SetValue("WindowMode", 0, RegistryValueKind.DWord);
						}
					}
					else
					{
						registryKey = Registry.CurrentUser.CreateSubKey("Software\\Webzen\\Mu\\Config");
						registryKey.CreateSubKey("WindowMode");
						registryKey.SetValue("WindowMode", 0, RegistryValueKind.DWord);
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
					string[] array = File.ReadAllLines("LauncherOption.if");
					bool flag7 = array[1] == "WindowMode:1";
					if (flag7)
					{
						this.pictureBox4.BackgroundImage = Resources.windowmode;
					}
				}
				catch
				{
				}
			}
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			this.pictureBox1.BackgroundImage = Resources.start_3;
		}

		private void pictureBox1_MouseHover(object sender, EventArgs e)
		{
			this.pictureBox1.BackgroundImage = Resources.start_2;
			this.Pic1_Hover = true;
		}

		private void pictureBox1_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBox1.BackgroundImage = Resources.start_1;
			this.Pic1_Hover = false;
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			this.pictureBox1.BackgroundImage = Resources.start_1;
		}

		private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
		{
			this.pictureBox3.BackgroundImage = Resources.setting_3;
		}

		private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
		{
			this.pictureBox3.BackgroundImage = Resources.setting_1;
		}

		private void pictureBox7_Click(object sender, EventArgs e)
		{
		}

		private void CopyRightLabel_Click(object sender, EventArgs e)
		{
		}

		private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
		{
			this.pictureBox2.BackgroundImage = Resources.exit_3;
		}

		private void pictureBox2_MouseHover(object sender, EventArgs e)
		{
			this.pictureBox2.BackgroundImage = Resources.exit_2;
		}

		private void pictureBox2_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBox2.BackgroundImage = Resources.exit_1;
		}

		private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
		{
			this.pictureBox2.BackgroundImage = Resources.exit_1;
		}

		private void pictureBox3_MouseHover(object sender, EventArgs e)
		{
			this.pictureBox3.BackgroundImage = Resources.setting_2;
		}

		private void pictureBox3_MouseLeave(object sender, EventArgs e)
		{
			this.pictureBox3.BackgroundImage = Resources.setting_1;
		}

		private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			this.webBrowser1.Visible = true;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			bool flag = !this.Pic1_Hover && Globals.EnableStartBTN;
			if (flag)
			{
				bool flag2 = this.blink;
				if (flag2)
				{
					this.pictureBox1.BackgroundImage = Resources.start_2;
				}
				else
				{
					this.pictureBox1.BackgroundImage = Resources.start_1;
				}
				this.blink = !this.blink;
			}
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
