namespace Launcher
{
	public partial class Opcoes : global::System.Windows.Forms.Form
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
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Launcher.Opcoes));
			this.pictureBox2 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.comboBox1 = new global::System.Windows.Forms.ComboBox();
			this.comboBox2 = new global::System.Windows.Forms.ComboBox();
			this.textBox1 = new global::System.Windows.Forms.TextBox();
			this.checkBox1 = new global::System.Windows.Forms.CheckBox();
			this.checkBox2 = new global::System.Windows.Forms.CheckBox();
			this.radioButton1 = new global::System.Windows.Forms.RadioButton();
			this.radioButton2 = new global::System.Windows.Forms.RadioButton();
			this.CopyRightLabel = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.label2 = new global::System.Windows.Forms.Label();
			this.label3 = new global::System.Windows.Forms.Label();
			this.comboBox3 = new global::System.Windows.Forms.ComboBox();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.pictureBox2.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBox2.BackgroundImage = global::Launcher.Properties.Resources.accept_1;
			this.pictureBox2.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox2.Location = new global::System.Drawing.Point(170, 412);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new global::System.Drawing.Size(108, 43);
			this.pictureBox2.TabIndex = 11;
			this.pictureBox2.TabStop = false;
			this.pictureBox2.Click += new global::System.EventHandler(this.pictureBox2_Click);
			this.pictureBox2.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
			this.pictureBox2.MouseLeave += new global::System.EventHandler(this.pictureBox2_MouseLeave);
			this.pictureBox2.MouseHover += new global::System.EventHandler(this.pictureBox2_MouseHover);
			this.pictureBox2.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseUp);
			this.pictureBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBox1.BackgroundImage = global::Launcher.Properties.Resources.exit_1;
			this.pictureBox1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.Location = new global::System.Drawing.Point(426, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(18, 18);
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			this.pictureBox1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.pictureBox1.MouseLeave += new global::System.EventHandler(this.pictureBox1_MouseLeave);
			this.pictureBox1.MouseHover += new global::System.EventHandler(this.pictureBox1_MouseHover);
			this.pictureBox1.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
			this.comboBox1.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[]
			{
				"1: 800x600 (4:3)",
				"2: 1024x768 (4:3)",
				"3: 1280x1024 (4:3)",
				"4: 1366x768 (4:3)",
				"5: 1440x900 (16:10)",
				"6: 1600x1050 (16:10)",
				"7: 1920x1080 (16:9)"
			});
			this.comboBox1.Location = new global::System.Drawing.Point(61, 229);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new global::System.Drawing.Size(122, 21);
			this.comboBox1.TabIndex = 20;
			this.comboBox2.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[]
			{
				"English"
			});
			this.comboBox2.Location = new global::System.Drawing.Point(240, 229);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new global::System.Drawing.Size(122, 21);
			this.comboBox2.TabIndex = 21;
			this.textBox1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.textBox1.Location = new global::System.Drawing.Point(170, 70);
			this.textBox1.MaxLength = 20;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new global::System.Drawing.Size(190, 23);
			this.textBox1.TabIndex = 22;
			this.checkBox1.AutoSize = true;
			this.checkBox1.BackColor = global::System.Drawing.Color.Transparent;
			this.checkBox1.ForeColor = global::System.Drawing.Color.CornflowerBlue;
			this.checkBox1.Location = new global::System.Drawing.Point(92, 169);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new global::System.Drawing.Size(57, 17);
			this.checkBox1.TabIndex = 23;
			this.checkBox1.Text = "Sound";
			this.checkBox1.UseVisualStyleBackColor = false;
			this.checkBox2.AutoSize = true;
			this.checkBox2.BackColor = global::System.Drawing.Color.Transparent;
			this.checkBox2.ForeColor = global::System.Drawing.Color.CornflowerBlue;
			this.checkBox2.Location = new global::System.Drawing.Point(235, 169);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new global::System.Drawing.Size(54, 17);
			this.checkBox2.TabIndex = 24;
			this.checkBox2.Text = "Music";
			this.checkBox2.UseVisualStyleBackColor = false;
			this.radioButton1.AutoSize = true;
			this.radioButton1.BackColor = global::System.Drawing.Color.Transparent;
			this.radioButton1.ForeColor = global::System.Drawing.Color.CornflowerBlue;
			this.radioButton1.Location = new global::System.Drawing.Point(92, 124);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new global::System.Drawing.Size(104, 17);
			this.radioButton1.TabIndex = 25;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Min Color (16 bit)";
			this.radioButton1.UseVisualStyleBackColor = false;
			this.radioButton2.AutoSize = true;
			this.radioButton2.BackColor = global::System.Drawing.Color.Transparent;
			this.radioButton2.ForeColor = global::System.Drawing.Color.CornflowerBlue;
			this.radioButton2.Location = new global::System.Drawing.Point(235, 124);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new global::System.Drawing.Size(107, 17);
			this.radioButton2.TabIndex = 26;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Max Color (32 bit)";
			this.radioButton2.UseVisualStyleBackColor = false;
			this.radioButton2.CheckedChanged += new global::System.EventHandler(this.radioButton2_CheckedChanged);
			this.CopyRightLabel.AutoSize = true;
			this.CopyRightLabel.BackColor = global::System.Drawing.Color.Transparent;
			this.CopyRightLabel.Font = new global::System.Drawing.Font("Tahoma", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.CopyRightLabel.ForeColor = global::System.Drawing.SystemColors.AppWorkspace;
			this.CopyRightLabel.Location = new global::System.Drawing.Point(12, 9);
			this.CopyRightLabel.Name = "CopyRightLabel";
			this.CopyRightLabel.Size = new global::System.Drawing.Size(121, 13);
			this.CopyRightLabel.TabIndex = 42;
			this.CopyRightLabel.Text = "Coded by MyHeart (RZ)";
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Font = new global::System.Drawing.Font("Tahoma", 11.25f);
			this.label1.ForeColor = global::System.Drawing.Color.DarkOrange;
			this.label1.Location = new global::System.Drawing.Point(104, 72);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(60, 18);
			this.label1.TabIndex = 43;
			this.label1.Text = "Account";
			this.label2.AutoSize = true;
			this.label2.BackColor = global::System.Drawing.Color.Transparent;
			this.label2.Font = new global::System.Drawing.Font("Tahoma", 11.25f);
			this.label2.ForeColor = global::System.Drawing.Color.DarkOrange;
			this.label2.Location = new global::System.Drawing.Point(58, 208);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(73, 18);
			this.label2.TabIndex = 44;
			this.label2.Text = "Resolution";
			this.label3.AutoSize = true;
			this.label3.BackColor = global::System.Drawing.Color.Transparent;
			this.label3.Font = new global::System.Drawing.Font("Tahoma", 11.25f);
			this.label3.ForeColor = global::System.Drawing.Color.DarkOrange;
			this.label3.Location = new global::System.Drawing.Point(237, 208);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(71, 18);
			this.label3.TabIndex = 45;
			this.label3.Text = "Language";
			this.comboBox3.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox3.FormattingEnabled = true;
			this.comboBox3.Items.AddRange(new object[]
			{
				"1: 800x600 (4:3)",
				"2: 1024x768 (4:3)",
				"3: 1152x864 (4:3)",
				"4: 1280x720 (16:9)",
				"5: 1280x800 (16:10)",
				"6: 1280x960 (4:3)",
				"7: 1600x900 (16:9)",
				"8: 1680x1050 (16:10)",
				"9: 1920x1080 (16:9)",
				"10: 1440x900 (16:10)"
			});
			this.comboBox3.Location = new global::System.Drawing.Point(61, 229);
			this.comboBox3.Name = "comboBox3";
			this.comboBox3.Size = new global::System.Drawing.Size(122, 21);
			this.comboBox3.TabIndex = 46;
			this.comboBox3.Visible = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Launcher.Properties.Resources.setting_back;
			this.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
			base.ClientSize = new global::System.Drawing.Size(446, 461);
			base.Controls.Add(this.comboBox3);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.CopyRightLabel);
			base.Controls.Add(this.radioButton2);
			base.Controls.Add(this.radioButton1);
			base.Controls.Add(this.checkBox2);
			base.Controls.Add(this.checkBox1);
			base.Controls.Add(this.textBox1);
			base.Controls.Add(this.comboBox2);
			base.Controls.Add(this.comboBox1);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.pictureBox1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
//			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "Opcoes";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Opcoes";
			base.TransparencyKey = global::System.Drawing.Color.Magenta;
			base.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.Opcoes_MouseDown);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		private global::System.ComponentModel.IContainer components = null;

		private global::System.Windows.Forms.PictureBox pictureBox2;

		private global::System.Windows.Forms.PictureBox pictureBox1;

		private global::System.Windows.Forms.ComboBox comboBox1;

		private global::System.Windows.Forms.ComboBox comboBox2;

		private global::System.Windows.Forms.TextBox textBox1;

		private global::System.Windows.Forms.CheckBox checkBox1;

		private global::System.Windows.Forms.CheckBox checkBox2;

		private global::System.Windows.Forms.RadioButton radioButton1;

		private global::System.Windows.Forms.RadioButton radioButton2;

		private global::System.Windows.Forms.Label CopyRightLabel;

		private global::System.Windows.Forms.Label label1;

		private global::System.Windows.Forms.Label label2;

		private global::System.Windows.Forms.Label label3;

		public global::System.Windows.Forms.ComboBox comboBox3;
	}
}
