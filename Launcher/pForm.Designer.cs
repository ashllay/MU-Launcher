namespace Launcher
{
	public partial class pForm : global::System.Windows.Forms.Form
	{
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Launcher.pForm));
			this.Status = new global::System.Windows.Forms.Label();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox3 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox4 = new global::System.Windows.Forms.PictureBox();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.CopyRightLabel = new global::System.Windows.Forms.Label();
			this.webBrowser1 = new global::System.Windows.Forms.WebBrowser();
			this.timer1 = new global::System.Windows.Forms.Timer(this.components);
			this.pictureBox5 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox6 = new global::System.Windows.Forms.PictureBox();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox5).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox6).BeginInit();
			base.SuspendLayout();
			this.Status.AutoSize = true;
			this.Status.BackColor = global::System.Drawing.Color.Transparent;
			this.Status.Font = new global::System.Drawing.Font("Tahoma", 8.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.Status.ForeColor = global::System.Drawing.Color.White;
			this.Status.Location = new global::System.Drawing.Point(176, 503);
			this.Status.Name = "Status";
			this.Status.Size = new global::System.Drawing.Size(42, 14);
			this.Status.TabIndex = 6;
			this.Status.Text = "Status";
			this.pictureBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBox1.BackgroundImage = global::Launcher.Properties.Resources.start_4;
			this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Enabled = false;
			this.pictureBox1.Location = new global::System.Drawing.Point(840, 503);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(146, 53);
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			this.pictureBox1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.pictureBox1.MouseLeave += new global::System.EventHandler(this.pictureBox1_MouseLeave);
			this.pictureBox1.MouseHover += new global::System.EventHandler(this.pictureBox1_MouseHover);
			this.pictureBox1.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
			this.pictureBox2.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBox2.BackgroundImage = global::Launcher.Properties.Resources.exit_1;
			this.pictureBox2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox2.Location = new global::System.Drawing.Point(968, 3);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(18, 18);
			this.pictureBox2.TabIndex = 8;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new global::System.EventHandler(this.pictureBox2_Click);
			this.pictureBox2.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
			this.pictureBox2.MouseLeave += new global::System.EventHandler(this.pictureBox2_MouseLeave);
			this.pictureBox2.MouseHover += new global::System.EventHandler(this.pictureBox2_MouseHover);
			this.pictureBox2.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
			this.pictureBox3.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBox3.BackgroundImage = global::Launcher.Properties.Resources.setting_1;
			this.pictureBox3.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox3.Enabled = false;
			this.pictureBox3.Location = new global::System.Drawing.Point(947, 3);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new global::System.Drawing.Size(18, 18);
			this.pictureBox3.TabIndex = 9;
			this.pictureBox3.TabStop = false;
			this.pictureBox3.Click += new global::System.EventHandler(this.pictureBox3_Click);
			this.pictureBox3.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseDown);
			this.pictureBox3.MouseLeave += new global::System.EventHandler(this.pictureBox3_MouseLeave);
			this.pictureBox3.MouseHover += new global::System.EventHandler(this.pictureBox3_MouseHover);
			this.pictureBox3.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox3_MouseUp);
			this.pictureBox4.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBox4.BackgroundImage = global::Launcher.Properties.Resources.windowmode_uncheck;
			this.pictureBox4.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox4.Enabled = false;
			this.pictureBox4.Location = new global::System.Drawing.Point(818, 541);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new global::System.Drawing.Size(16, 15);
			this.pictureBox4.TabIndex = 10;
			this.pictureBox4.TabStop = false;
			this.pictureBox4.Click += new global::System.EventHandler(this.pictureBox4_Click);
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.ForeColor = global::System.Drawing.Color.LightSteelBlue;
			this.label1.Location = new global::System.Drawing.Point(760, 543);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(52, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "Winmode";
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.Color.Transparent;
			this.label2.Font = new global::System.Drawing.Font("Tahoma", 9f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.LightSteelBlue;
			this.label2.Location = new global::System.Drawing.Point(26, 3);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(86, 14);
			this.label2.TabIndex = 14;
			this.label2.Text = "MU Launcher";
			this.CopyRightLabel.AutoSize = true;
			this.CopyRightLabel.BackColor = global::System.Drawing.Color.Transparent;
			this.CopyRightLabel.Font = new global::System.Drawing.Font("Tahoma", 8.3f);
			this.CopyRightLabel.ForeColor = global::System.Drawing.SystemColors.AppWorkspace;
			this.CopyRightLabel.Location = new global::System.Drawing.Point(108, 543);
			this.CopyRightLabel.Name = "CopyRightLabel";
			this.CopyRightLabel.Size = new global::System.Drawing.Size(136, 14);
			this.CopyRightLabel.TabIndex = 41;
			this.CopyRightLabel.Text = "Coded by MyHeart (RZ)";
			this.CopyRightLabel.Click += new global::System.EventHandler(this.CopyRightLabel_Click);
			this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
			this.webBrowser1.Location = new global::System.Drawing.Point(5, 23);
			this.webBrowser1.MinimumSize = new global::System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.ScrollBarsEnabled = false;
			this.webBrowser1.Size = new global::System.Drawing.Size(979, 475);
			this.webBrowser1.TabIndex = 44;
			this.webBrowser1.Url = new global::System.Uri("http://js.exilemu.com/update/index_wz.php", global::System.UriKind.Absolute);
			this.webBrowser1.Visible = false;
			this.webBrowser1.DocumentCompleted += new global::System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
			this.timer1.Tick += new global::System.EventHandler(this.timer1_Tick);
			this.pictureBox5.BackgroundImage = global::Launcher.Properties.Resources.BITMAP154_1;
			this.pictureBox5.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox5.Location = new global::System.Drawing.Point(179, 524);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new global::System.Drawing.Size(619, 11);
			this.pictureBox5.TabIndex = 47;
			this.pictureBox5.TabStop = false;
			this.pictureBox6.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Center;
			this.pictureBox6.Image = global::Launcher.Properties.Resources.BITMAP155_1;
			this.pictureBox6.Location = new global::System.Drawing.Point(179, 524);
			this.pictureBox6.Name = "pictureBox6";
			this.pictureBox6.Size = new global::System.Drawing.Size(0, 11);
			this.pictureBox6.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox6.TabIndex = 50;
			this.pictureBox6.TabStop = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Launcher.Properties.Resources.BITMAP129_1;
			base.ClientSize = new global::System.Drawing.Size(990, 560);
			base.Controls.Add(this.pictureBox6);
			base.Controls.Add(this.pictureBox5);
			base.Controls.Add(this.webBrowser1);
			base.Controls.Add(this.CopyRightLabel);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.pictureBox4);
			base.Controls.Add(this.pictureBox3);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.Status);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
//			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			this.MaximumSize = new global::System.Drawing.Size(990, 560);
			this.MinimumSize = new global::System.Drawing.Size(990, 560);
			base.Name = "pForm";
			base.ShowIcon = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Autoupdate";
			base.TransparencyKey = global::System.Drawing.Color.Magenta;
			base.Load += new global::System.EventHandler(this.pForm_Load);
			base.Shown += new global::System.EventHandler(this.pForm_Shown);
			base.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pForm_MouseDown);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox3).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox5).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox6).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components = null;

		public global::System.Windows.Forms.Label Status;

		public global::System.Windows.Forms.PictureBox pictureBox1;

		public global::System.Windows.Forms.PictureBox pictureBox2;

		public global::System.Windows.Forms.PictureBox pictureBox3;

		public global::System.Windows.Forms.PictureBox pictureBox4;

		private global::System.Windows.Forms.Label label1;

		private global::System.Windows.Forms.Label label2;

		private global::System.Windows.Forms.Label CopyRightLabel;

		public global::System.Windows.Forms.WebBrowser webBrowser1;

		private global::System.Windows.Forms.Timer timer1;

		public global::System.Windows.Forms.PictureBox pictureBox5;

		public global::System.Windows.Forms.PictureBox pictureBox6;
	}
}
