using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProgressBarEx
{
	[ToolboxBitmap("PBEX.bmp")]
	public class ProgressBarEx : Control
	{
		public ProgressBarEx()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.OptimizedDoubleBuffer, true);
			base.TabStop = false;
			base.Size = new Size(200, 23);
			this.bBlend.Positions = new float[]
			{
				0f,
				0.2f,
				0.4f,
				0.6f,
				0.8f,
				1f
			};
			this.GradiantPosition = ProgressBarEx.GradiantArea.Top;
			base.BackColor = Color.Transparent;
			this._ForeColorBrush = new SolidBrush(base.ForeColor);
			this._BorderPen = new Pen(Color.Black);
		}

		[Category("Appearance")]
		[Description("The foreground color of the ProgressBars text.")]
		[Browsable(true)]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				bool flag = value == Color.Transparent;
				if (flag)
				{
					value = this._ForeColorBrush.Color;
				}
				base.ForeColor = value;
				this._ForeColorBrush.Color = value;
			}
		}

		[Category("Appearance")]
		[Description("The background color of the ProgressBar.")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "DarkGray")]
		public Color BackgroundColor
		{
			get
			{
				return this._BackColor;
			}
			set
			{
				bool flag = value == Color.Transparent;
				if (flag)
				{
					value = this._BackColor;
				}
				this._BackColor = value;
				this.Refresh();
			}
		}

		[Category("Appearance")]
		[Description("The progress color of the ProgressBar.")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "Lime")]
		public Color ProgressColor
		{
			get
			{
				return this._ProgressColor;
			}
			set
			{
				bool flag = value == Color.Transparent;
				if (flag)
				{
					value = this._ProgressColor;
				}
				this._ProgressColor = value;
				this.Refresh();
			}
		}

		[Category("Appearance")]
		[Description("The gradiant highlight color of the ProgressBar.")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "White")]
		public Color GradiantColor
		{
			get
			{
				return this._GradiantColor;
			}
			set
			{
				this._GradiantColor = value;
				this.Refresh();
			}
		}

		[Category("Behavior")]
		[Description("The minimum value of the ProgressBar.")]
		[Browsable(true)]
		[DefaultValue(0)]
		public int Minimum
		{
			get
			{
				return this._Minimum;
			}
			set
			{
				bool flag = value > this._Maximum;
				if (flag)
				{
					value = this._Maximum - 1;
				}
				this._Minimum = value;
				this.Refresh();
			}
		}

		[Category("Behavior")]
		[Description("The maximum value of the ProgressBar.")]
		[Browsable(true)]
		[DefaultValue(100)]
		public int Maximum
		{
			get
			{
				return this._Maximum;
			}
			set
			{
				bool flag = value <= this._Minimum;
				if (flag)
				{
					value = this._Minimum + 1;
				}
				this._Maximum = value;
				this.Refresh();
			}
		}

		[Category("Behavior")]
		[Description("The current value of the ProgressBar.")]
		[Browsable(true)]
		[DefaultValue(0)]
		public int Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				bool flag = value < this._Minimum;
				if (flag)
				{
					value = this._Minimum;
				}
				bool flag2 = value > this._Maximum;
				if (flag2)
				{
					value = this._Maximum;
				}
				this._Value = value;
				this.Refresh();
			}
		}

		[Category("Appearance")]
		[Description("Draw a border around the ProgressBar.")]
		[Browsable(true)]
		[DefaultValue(true)]
		public bool Border
		{
			get
			{
				return this._Border;
			}
			set
			{
				this._Border = value;
				this.Refresh();
			}
		}

		[Category("Appearance")]
		[Description("The color of the border around the ProgressBar.")]
		[Browsable(true)]
		[DefaultValue(typeof(Color), "Black")]
		public Color BorderColor
		{
			get
			{
				return this._BorderColor;
			}
			set
			{
				bool flag = value == Color.Transparent;
				if (flag)
				{
					value = this._BorderColor;
				}
				this._BorderColor = value;
				this._BorderPen.Color = value;
				this.Refresh();
			}
		}

		[Category("Appearance")]
		[Description("Shows the progress percentge as text in the ProgressBar.")]
		[Browsable(true)]
		[DefaultValue(false)]
		public bool ShowPercentage
		{
			get
			{
				return this._ShowPercentage;
			}
			set
			{
				this._ShowPercentage = value;
				this.Refresh();
			}
		}

		[Category("Appearance")]
		[Description("Shows the text of the Text property in the ProgressBar.")]
		[Browsable(true)]
		[DefaultValue(false)]
		public bool ShowText
		{
			get
			{
				return this._ShowText;
			}
			set
			{
				this._ShowText = value;
				this.Refresh();
			}
		}

		[Category("Appearance")]
		[Description("Determins the position of the gradiant shine in the ProgressBar.")]
		[Browsable(true)]
		[DefaultValue(typeof(ProgressBarEx.GradiantArea), "Top")]
		public ProgressBarEx.GradiantArea GradiantPosition
		{
			get
			{
				return this._GradiantPosition;
			}
			set
			{
				this._GradiantPosition = value;
				bool flag = value == ProgressBarEx.GradiantArea.None;
				if (flag)
				{
					this.bBlend.Factors = new float[6];
				}
				else
				{
					bool flag2 = value == ProgressBarEx.GradiantArea.Top;
					if (flag2)
					{
						this.bBlend.Factors = new float[]
						{
							0.8f,
							0.7f,
							0.6f,
							0.4f,
							0f,
							0f
						};
					}
					else
					{
						bool flag3 = value == ProgressBarEx.GradiantArea.Center;
						if (flag3)
						{
							this.bBlend.Factors = new float[]
							{
								0f,
								0.4f,
								0.6f,
								0.6f,
								0.4f,
								0f
							};
						}
						else
						{
							this.bBlend.Factors = new float[]
							{
								0f,
								0f,
								0.4f,
								0.6f,
								0.7f,
								0.8f
							};
						}
					}
				}
				this.Refresh();
			}
		}

		[Category("Appearance")]
		[Description("An image to display on the ProgressBarEx.")]
		[Browsable(true)]
		public Bitmap Image
		{
			get
			{
				return this._Image;
			}
			set
			{
				this._Image = value;
				this.Refresh();
			}
		}

		[Category("Appearance")]
		[Description("Determins how the image is displayed in the ProgressBarEx.")]
		[Browsable(true)]
		[DefaultValue(typeof(ProgressBarEx.ImageLayoutType), "None")]
		public ProgressBarEx.ImageLayoutType ImageLayout
		{
			get
			{
				return this._ImageLayout;
			}
			set
			{
				this._ImageLayout = value;
				bool flag = this._Image != null;
				if (flag)
				{
					this.Refresh();
				}
			}
		}

		[Category("Appearance")]
		[Description("True to draw corners rounded. False to draw square corners.")]
		[Browsable(true)]
		[DefaultValue(true)]
		public bool RoundedCorners
		{
			get
			{
				return this._RoundedCorners;
			}
			set
			{
				this._RoundedCorners = value;
				this.Refresh();
			}
		}

		[Category("Appearance")]
		[Description("Determins the direction of progress displayed in the ProgressBarEx.")]
		[Browsable(true)]
		[DefaultValue(typeof(ProgressBarEx.ProgressDir), "Horizontal")]
		public ProgressBarEx.ProgressDir ProgressDirection
		{
			get
			{
				return this._ProgressDirection;
			}
			set
			{
				this._ProgressDirection = value;
				this.Refresh();
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			Point point = new Point(0, 0);
			Point point2 = new Point(0, base.Height);
			bool flag = this._ProgressDirection == ProgressBarEx.ProgressDir.Vertical;
			if (flag)
			{
				point2 = new Point(base.Width, 0);
			}
			using (GraphicsPath graphicsPath = new GraphicsPath())
			{
				Rectangle rect = new Rectangle(0, 0, base.Width, base.Height);
				int num = Convert.ToInt32((double)rect.Height / 2.5);
				bool flag2 = rect.Width < rect.Height;
				if (flag2)
				{
					num = Convert.ToInt32((double)rect.Width / 2.5);
				}
				using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(point, point2, this._BackColor, this._GradiantColor))
				{
					linearGradientBrush.Blend = this.bBlend;
					bool roundedCorners = this._RoundedCorners;
					if (roundedCorners)
					{
						graphicsPath.AddArc(rect.X, rect.Y, num, num, 180f, 90f);
						graphicsPath.AddArc(rect.Right - num, rect.Y, num, num, 270f, 90f);
						graphicsPath.AddArc(rect.Right - num, rect.Bottom - num, num, num, 0f, 90f);
						graphicsPath.AddArc(rect.X, rect.Bottom - num, num, num, 90f, 90f);
						graphicsPath.CloseFigure();
						e.Graphics.FillPath(linearGradientBrush, graphicsPath);
					}
					else
					{
						e.Graphics.FillRectangle(linearGradientBrush, rect);
					}
				}
				bool flag3 = this._Value > this._Minimum;
				if (flag3)
				{
					int num2 = Convert.ToInt32((double)base.Width / (double)(this._Maximum - this._Minimum) * (double)this._Value);
					bool flag4 = this._ProgressDirection == ProgressBarEx.ProgressDir.Vertical;
					if (flag4)
					{
						num2 = Convert.ToInt32((double)base.Height / (double)(this._Maximum - this._Minimum) * (double)this._Value);
						rect.Y = rect.Height - num2;
						rect.Height = num2;
					}
					else
					{
						rect.Width = num2;
					}
					using (LinearGradientBrush linearGradientBrush2 = new LinearGradientBrush(point, point2, this._ProgressColor, this._GradiantColor))
					{
						linearGradientBrush2.Blend = this.bBlend;
						bool roundedCorners2 = this._RoundedCorners;
						if (roundedCorners2)
						{
							bool flag5 = this._ProgressDirection == ProgressBarEx.ProgressDir.Horizontal;
							if (flag5)
							{
								rect.Height--;
							}
							else
							{
								rect.Width--;
							}
							using (GraphicsPath graphicsPath2 = new GraphicsPath())
							{
								graphicsPath2.AddArc(rect.X, rect.Y, num, num, 180f, 90f);
								graphicsPath2.AddArc(rect.Right - num, rect.Y, num, num, 270f, 90f);
								graphicsPath2.AddArc(rect.Right - num, rect.Bottom - num, num, num, 0f, 90f);
								graphicsPath2.AddArc(rect.X, rect.Bottom - num, num, num, 90f, 90f);
								graphicsPath2.CloseFigure();
								using (GraphicsPath graphicsPath3 = new GraphicsPath())
								{
									using (Region region = new Region(graphicsPath))
									{
										region.Intersect(graphicsPath2);
										graphicsPath3.AddRectangles(region.GetRegionScans(new Matrix()));
									}
									e.Graphics.FillPath(linearGradientBrush2, graphicsPath3);
								}
							}
						}
						else
						{
							e.Graphics.FillRectangle(linearGradientBrush2, rect);
						}
					}
				}
				bool flag6 = this._Image != null;
				if (flag6)
				{
					bool flag7 = this._ImageLayout == ProgressBarEx.ImageLayoutType.Stretch;
					if (flag7)
					{
						e.Graphics.DrawImage(this._Image, 0, 0, base.Width, base.Height);
					}
					else
					{
						bool flag8 = this._ImageLayout == ProgressBarEx.ImageLayoutType.None;
						if (flag8)
						{
							e.Graphics.DrawImage(this._Image, 0, 0);
						}
						else
						{
							int x = Convert.ToInt32(base.Width / 2 - this._Image.Width / 2);
							int y = Convert.ToInt32(base.Height / 2 - this._Image.Height / 2);
							e.Graphics.DrawImage(this._Image, x, y);
						}
					}
				}
				bool flag9 = this._ShowPercentage | this._ShowText;
				if (flag9)
				{
					string text = "";
					bool showText = this._ShowText;
					if (showText)
					{
						text = this.Text;
					}
					bool showPercentage = this._ShowPercentage;
					if (showPercentage)
					{
						text = text + Convert.ToString(Convert.ToInt32(100.0 / (double)(this._Maximum - this._Minimum) * (double)this._Value)) + "%";
					}
					using (StringFormat stringFormat = new StringFormat
					{
						Alignment = StringAlignment.Center,
						LineAlignment = StringAlignment.Center
					})
					{
						e.Graphics.DrawString(text, this.Font, this._ForeColorBrush, new Rectangle(0, 0, base.Width, base.Height), stringFormat);
					}
				}
				bool border = this._Border;
				if (border)
				{
					rect = new Rectangle(0, 0, base.Width - 1, base.Height - 1);
					bool roundedCorners3 = this._RoundedCorners;
					if (roundedCorners3)
					{
						graphicsPath.Reset();
						graphicsPath.AddArc(rect.X, rect.Y, num, num, 180f, 90f);
						graphicsPath.AddArc(rect.Right - num, rect.Y, num, num, 270f, 90f);
						graphicsPath.AddArc(rect.Right - num, rect.Bottom - num, num, num, 0f, 90f);
						graphicsPath.AddArc(rect.X, rect.Bottom - num, num, num, 90f, 90f);
						graphicsPath.CloseFigure();
						e.Graphics.DrawPath(this._BorderPen, graphicsPath);
					}
					else
					{
						e.Graphics.DrawRectangle(this._BorderPen, rect);
					}
				}
			}
		}

		protected override void OnTextChanged(EventArgs e)
		{
			this.Refresh();
			base.OnTextChanged(e);
		}

		protected override void Dispose(bool disposing)
		{
			this._ForeColorBrush.Dispose();
			this._BorderPen.Dispose();
			base.Dispose(disposing);
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = Color.Transparent;
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("BackgroundImageLayout is not implemented.", true)]
		public new ImageLayout BackgroundImageLayout
		{
			get
			{
				return base.BackgroundImageLayout;
			}
			set
			{
				throw new NotImplementedException("BackgroundImageLayout is not implemented.");
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("BackgroundImage is not implemented.", true)]
		public new Image BackgroundImage
		{
			get
			{
				return null;
			}
			set
			{
				throw new NotImplementedException("BackgroundImage is not implemented.");
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("TabStop is not implemented.", true)]
		public new bool TabStop
		{
			get
			{
				return false;
			}
			set
			{
				throw new NotImplementedException("TabStop is not implemented.");
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Obsolete("TabIndex is not implemented.", true)]
		public new int TabIndex
		{
			get
			{
				return base.TabIndex;
			}
			set
			{
				throw new NotImplementedException("TabIndex is not implemented.");
			}
		}

		private Blend bBlend = new Blend();

		private int _Minimum = 0;

		private int _Maximum = 100;

		private int _Value = 0;

		private bool _Border = true;

		private Pen _BorderPen;

		private Color _BorderColor = Color.Black;

		private ProgressBarEx.GradiantArea _GradiantPosition;

		private Color _GradiantColor = Color.White;

		private Color _BackColor = Color.DarkGray;

		private Color _ProgressColor = Color.Lime;

		private SolidBrush _ForeColorBrush;

		private bool _ShowPercentage = false;

		private bool _ShowText = false;

		private ProgressBarEx.ImageLayoutType _ImageLayout = ProgressBarEx.ImageLayoutType.None;

		private Bitmap _Image = null;

		private bool _RoundedCorners = true;

		private ProgressBarEx.ProgressDir _ProgressDirection = ProgressBarEx.ProgressDir.Horizontal;

		public enum GradiantArea
		{
			None,
			Top,
			Center,
			Bottom
		}

		public enum ImageLayoutType
		{
			None,
			Center,
			Stretch
		}

		public enum ProgressDir
		{
			Horizontal,
			Vertical
		}
	}
}
