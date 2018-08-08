using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Cyclic.Redundancy.Check;

namespace Launcher.Exile
{
	internal class Common
	{
		public static void ChangeStatus(string Key, params string[] Arguments)
		{
			Globals.pForm.Status.Text = Texts.GetText(Key, Arguments);
		}

		public static void ChangeProgresss(float fPercent)
		{
			float num = 617f * (fPercent / 100f) + 1.5f * (float)Math.Sin((double)DateTime.Now.Ticks / 100.0);
			bool flag = num < 0f || fPercent < 0.01f;
			if (flag)
			{
				num = 0f;
			}
			bool flag2 = num > 617f || fPercent > 99.99f;
			if (flag2)
			{
				num = 0f;
			}
			Globals.pForm.pictureBox6.Update();
			Globals.pForm.pictureBox6.Width = (int)num;
		}

		public static void UpdateCompleteProgress(long Value)
		{
			bool flag = Value < 0L || Value > 100L;
			if (flag)
			{
			}
		}

		public static void UpdateCurrentProgress(long Value, double Speed)
		{
			bool flag = Value < 0L || Value > 100L;
			if (!flag)
			{
				Common.ChangeProgresss((float)Value);
			}
		}

		public static string GetHash(string Name)
		{
			bool flag = Name == string.Empty;
			string result;
			if (flag)
			{
				result = string.Empty;
			}
			else
			{
				CRC crc = new CRC();
				string text = string.Empty;
				using (FileStream fileStream = File.Open(Name, FileMode.Open))
				{
					foreach (byte b in crc.ComputeHash(fileStream))
					{
						text += b.ToString("x2").ToUpper();
					}
				}
				result = text;
			}
			return result;
		}

		public static void EnableStart()
		{
			Globals.pForm.pictureBox1.Enabled = true;
			Globals.pForm.pictureBox3.Enabled = true;
			Globals.pForm.pictureBox4.Enabled = true;
			Globals.pForm.pictureBox1.Cursor = Cursors.Hand;
			Globals.EnableStartBTN = true;
		}

		public static Image ResizeImage(Image source, int Width, int Height, int dx, int dy)
		{
			RectangleF rectangleF = new RectangleF(0f, 0f, (float)source.Width, (float)source.Height);
			RectangleF rect = new RectangleF(0f, 0f, (float)Width, (float)Height);
			Image image = new Bitmap(Width, Height);
			Graphics graphics = Graphics.FromImage(image);
			graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
			graphics.FillRectangle(new SolidBrush(Color.White), rect);
			float num = (float)source.Width / (float)source.Height;
			bool flag = num >= 1f;
			if (flag)
			{
				float num2 = (float)Width / rectangleF.Width;
				float num3 = (float)Width;
				float num4 = rectangleF.Height * num2;
				float num5 = (float)Height - num4;
				graphics.DrawImage(source, 0f, num5 / 2f, (float)Width, num4);
			}
			else
			{
				float num2 = (float)Height / rectangleF.Height;
				float num3 = rectangleF.Width * num2;
				float num4 = (float)Height;
				float num6 = (float)Width - num3;
				graphics.DrawImage(source, num6 / 2f, 0f, num3, (float)Height);
			}
			return image;
		}

		public static void lineChanger(string newText, string fileName, int line_to_edit)
		{
			string[] array = File.ReadAllLines(fileName);
			array[line_to_edit - 1] = newText;
			File.WriteAllLines(fileName, array);
		}

		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		public const int WM_NCLBUTTONDOWN = 161;

		public const int HT_CAPTION = 2;
	}
}
