// Decompiled with JetBrains decompiler
// Type: Launcher.Exile.Common
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: D4AA755B-F045-4A12-838C-6A7934E8D46E
// Assembly location: D:\NDev\NNTeam\nDev\launcher\Net 4.0\Launcher.exe

using Cyclic.Redundancy.Check;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Launcher.Exile
{
    internal class Common
    {
        public const int WM_NCLBUTTONDOWN = 161;
        public const int HT_CAPTION = 2;

        public static void ChangeStatus(string Key, params string[] Arguments)
        {
            Globals.pForm.Status.Text = Texts.GetText(Key, (object[])Arguments);
        }

        public static void ChangeProgresss(float fPercent)
        {
            float num = (float)(617.0 * ((double)fPercent / 100.0) + 1.5 * Math.Sin((double)DateTime.Now.Ticks / 100.0));
            if ((double)num < 0.0 || (double)fPercent < 0.00999999977648258)
                num = 0.0f;
            if ((double)num > 617.0 || (double)fPercent > 99.9899978637695)
                num = 0.0f;
            Globals.pForm.pictureBox6.Update();
            Globals.pForm.pictureBox6.Width = (int)num;
        }

        public static void UpdateCompleteProgress(long Value)
        {
            if (Value < 0L || Value > 100L);
        }

        public static void UpdateCurrentProgress(long Value, double Speed)
        {
            if (Value < 0L || Value > 100L)
                return;
            Common.ChangeProgresss((float)Value);
        }

        public static string GetHash(string Name)
        {
            if (Name == string.Empty)
                return string.Empty;
            CRC crc = new CRC();
            string empty = string.Empty;
            using (FileStream fileStream = System.IO.File.Open(Name, FileMode.Open))
            {
                foreach (byte num in crc.ComputeHash((Stream)fileStream))
                    empty += num.ToString("x2").ToUpper();
            }
            return empty;
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
            RectangleF rectangleF = new RectangleF(0.0f, 0.0f, (float)source.Width, (float)source.Height);
            RectangleF rect = new RectangleF(0.0f, 0.0f, (float)Width, (float)Height);
            Image image = (Image)new Bitmap(Width, Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.FillRectangle((Brush)new SolidBrush(Color.White), rect);
            if ((double)((float)source.Width / (float)source.Height) >= 1.0)
            {
                float num1 = (float)Width / rectangleF.Width;
                float height = rectangleF.Height * num1;
                float num2 = (float)Height - height;
                graphics.DrawImage(source, 0.0f, num2 / 2f, (float)Width, height);
            }
            else
            {
                float num1 = (float)Height / rectangleF.Height;
                float width = rectangleF.Width * num1;
                float num2 = (float)Width - width;
                graphics.DrawImage(source, num2 / 2f, 0.0f, width, (float)Height);
            }
            return image;
        }

        public static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] contents = System.IO.File.ReadAllLines(fileName);
            contents[line_to_edit - 1] = newText;
            System.IO.File.WriteAllLines(fileName, contents);
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
    }
}
