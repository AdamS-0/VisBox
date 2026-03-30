/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 02.05.2021
 * Time: 08:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace tester
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private VisBox.Lamp lamp1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer1;
		private VisBox.Bar bar1;
		private VisBox.ZipBar zipBar1;
		private VisBox.PushButton pushButton1;
		private VisBox.PushButton pushButton2;
		private VisBox.PushButton pushButton3;
		private VisBox.PushButton pushButton6;
		private VisBox.PushButton pushButton7;
		private VisBox.PushButton pushButton8;
		private VisBox.PushButton pushButton9;
		private VisBox.Lamp lamp2;
		private VisBox.ZipBar zipBar2;
		private VisBox.Lamp lamp3;
		private VisBox.Lamp lamp4;
		private VisBox.ZipBar zipBar3;
		private VisBox.ZipBar zipBar4;
		private VisBox.ZipBar zipBar5;
		private VisBox.ZipBar zipBar6;
		private VisBox.ZipBar zipBar10;
		private System.Windows.Forms.Label label2;
		private VisBox.DisplaySegmentManager displaySegmentManager1;
		private VisBox.DisplaySegmentManager displaySegmentManager2;
		private VisBox.DisplaySegmentManager displaySegmentManager3;
		private VisBox.DisplaySegment displaySegment1;
		private VisBox.DisplaySegment displaySegment2;
		private VisBox.DisplaySegment displaySegment3;
		private VisBox.DisplaySegment displaySegment4;
		private VisBox.DisplaySegment displaySegment5;
		private VisBox.DisplaySegment displaySegment6;
		private VisBox.Display14Segment display14Segment1;
		private VisBox.Display14Segment display14Segment2;
		private VisBox.Display14Segment display14Segment3;
		private VisBox.Display14Segment display14Segment4;
		private VisBox.Display14Segment display14Segment5;
		private VisBox.Display14Segment display14Segment6;
		private VisBox.Display14Segment display14Segment7;
		private VisBox.Display14Segment display14Segment8;
		private VisBox.Display14Segment display14Segment9;
		private VisBox.Display14Segment display14Segment10;
		private VisBox.Display14Segment display14SegmentLoading;
		private VisBox.PushButtonManager pushButtonManager1;
		private VisBox.PushButtonManager pushButtonManager2;
		private VisBox.AnalogMeter analogMeter1;
		private VisBox.AnalogMeter analogMeter2;
		private VisBox.Switch switch1;
		private VisBox.ControlKnob controlKnob1;
		private VisBox.LCDDisplay lcdDisplay1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private VisBox.Plot plot1;
		private System.Windows.Forms.TextBox txtBxPlotMarker;
		private VisBox.ZipBar zipBar7;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
		    this.components = new System.ComponentModel.Container();
		    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
		    this.lamp1 = new VisBox.Lamp();
		    this.label1 = new System.Windows.Forms.Label();
		    this.timer1 = new System.Windows.Forms.Timer(this.components);
		    this.bar1 = new VisBox.Bar();
		    this.zipBar1 = new VisBox.ZipBar();
		    this.pushButton1 = new VisBox.PushButton();
		    this.pushButtonManager1 = new VisBox.PushButtonManager();
		    this.pushButton2 = new VisBox.PushButton();
		    this.pushButton3 = new VisBox.PushButton();
		    this.pushButtonManager2 = new VisBox.PushButtonManager();
		    this.pushButton6 = new VisBox.PushButton();
		    this.pushButton7 = new VisBox.PushButton();
		    this.pushButton8 = new VisBox.PushButton();
		    this.pushButton9 = new VisBox.PushButton();
		    this.lamp2 = new VisBox.Lamp();
		    this.zipBar2 = new VisBox.ZipBar();
		    this.lamp3 = new VisBox.Lamp();
		    this.lamp4 = new VisBox.Lamp();
		    this.zipBar3 = new VisBox.ZipBar();
		    this.zipBar4 = new VisBox.ZipBar();
		    this.zipBar5 = new VisBox.ZipBar();
		    this.zipBar6 = new VisBox.ZipBar();
		    this.zipBar10 = new VisBox.ZipBar();
		    this.label2 = new System.Windows.Forms.Label();
		    this.displaySegmentManager1 = new VisBox.DisplaySegmentManager();
		    this.displaySegmentManager2 = new VisBox.DisplaySegmentManager();
		    this.displaySegmentManager3 = new VisBox.DisplaySegmentManager();
		    this.displaySegment1 = new VisBox.DisplaySegment();
		    this.displaySegment2 = new VisBox.DisplaySegment();
		    this.displaySegment3 = new VisBox.DisplaySegment();
		    this.displaySegment4 = new VisBox.DisplaySegment();
		    this.displaySegment5 = new VisBox.DisplaySegment();
		    this.displaySegment6 = new VisBox.DisplaySegment();
		    this.display14Segment1 = new VisBox.Display14Segment();
		    this.display14Segment2 = new VisBox.Display14Segment();
		    this.display14Segment3 = new VisBox.Display14Segment();
		    this.display14Segment4 = new VisBox.Display14Segment();
		    this.display14Segment5 = new VisBox.Display14Segment();
		    this.display14Segment6 = new VisBox.Display14Segment();
		    this.display14Segment7 = new VisBox.Display14Segment();
		    this.display14Segment8 = new VisBox.Display14Segment();
		    this.display14Segment9 = new VisBox.Display14Segment();
		    this.display14Segment10 = new VisBox.Display14Segment();
		    this.display14SegmentLoading = new VisBox.Display14Segment();
		    this.analogMeter1 = new VisBox.AnalogMeter();
		    this.analogMeter2 = new VisBox.AnalogMeter();
		    this.switch1 = new VisBox.Switch();
		    this.controlKnob1 = new VisBox.ControlKnob();
		    this.lcdDisplay1 = new VisBox.LCDDisplay();
		    this.button1 = new System.Windows.Forms.Button();
		    this.textBox1 = new System.Windows.Forms.TextBox();
		    this.plot1 = new VisBox.Plot();
		    this.txtBxPlotMarker = new System.Windows.Forms.TextBox();
		    this.zipBar7 = new VisBox.ZipBar();
		    this.SuspendLayout();
		    // 
		    // lamp1
		    // 
		    this.lamp1.BackColor = System.Drawing.SystemColors.Control;
		    this.lamp1.BorderWidth = 2F;
		    this.lamp1.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.lamp1.Location = new System.Drawing.Point(12, 3);
		    this.lamp1.Name = "lamp1";
		    this.lamp1.Size = new System.Drawing.Size(32, 32);
		    this.lamp1.TabIndex = 0;
		    this.lamp1.Text = null;
		    this.lamp1.DoubleClick += new System.EventHandler(this.Lamp1DoubleClick);
		    // 
		    // label1
		    // 
		    this.label1.Location = new System.Drawing.Point(0, 38);
		    this.label1.Name = "label1";
		    this.label1.Size = new System.Drawing.Size(67, 23);
		    this.label1.TabIndex = 1;
		    this.label1.Text = "Lampka 1";
		    this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
		    // 
		    // timer1
		    // 
		    this.timer1.Tick += new System.EventHandler(this.Timer1Tick);
		    // 
		    // bar1
		    // 
		    this.bar1.BackColor = System.Drawing.SystemColors.Control;
		    this.bar1.BorderRound = 8;
		    this.bar1.BorderWidth = 2F;
		    this.bar1.ColorBackGround = System.Drawing.Color.Gainsboro;
		    this.bar1.ColorFill = System.Drawing.Color.Silver;
		    this.bar1.ColorOff = System.Drawing.Color.Empty;
		    this.bar1.ColorOn = System.Drawing.Color.Empty;
		    this.bar1.Dock = System.Windows.Forms.DockStyle.Bottom;
		    this.bar1.FlatStyle = VisBox.VisElement.VisFlatStyle.Collapsed;
		    this.bar1.Location = new System.Drawing.Point(0, 287);
		    this.bar1.Name = "bar1";
		    this.bar1.Padding = new System.Windows.Forms.Padding(3);
		    this.bar1.Size = new System.Drawing.Size(1026, 40);
		    this.bar1.TabIndex = 4;
		    this.bar1.Text = null;
		    this.bar1.Value = 0.15F;
		    // 
		    // zipBar1
		    // 
		    this.zipBar1.BorderWidth = 2F;
		    this.zipBar1.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.zipBar1.Location = new System.Drawing.Point(3, 170);
		    this.zipBar1.Name = "zipBar1";
		    this.zipBar1.Parts = 5;
		    this.zipBar1.Size = new System.Drawing.Size(178, 23);
		    this.zipBar1.TabIndex = 5;
		    this.zipBar1.Text = null;
		    this.zipBar1.ValueChanged += new System.EventHandler(this.ZipBar1ValueChanged);
		    // 
		    // pushButton1
		    // 
		    this.pushButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
		    this.pushButton1.ColorBorder = System.Drawing.SystemColors.Control;
		    this.pushButton1.ColorButton = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
		    this.pushButton1.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.pushButton1.LayoutShape = VisBox.VisElement.Shape.Ellipse;
		    this.pushButton1.Location = new System.Drawing.Point(12, 55);
		    this.pushButton1.Name = "pushButton1";
		    this.pushButton1.PushButtonManager = this.pushButtonManager1;
		    this.pushButton1.Size = new System.Drawing.Size(32, 32);
		    this.pushButton1.TabIndex = 6;
		    this.pushButton1.Text = null;
		    this.pushButton1.WithLight = true;
		    this.pushButton1.StateChanged += new System.EventHandler(this.PushButton1StateChanged);
		    // 
		    // pushButton2
		    // 
		    this.pushButton2.ColorButton = System.Drawing.SystemColors.Control;
		    this.pushButton2.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.pushButton2.Location = new System.Drawing.Point(47, 55);
		    this.pushButton2.Name = "pushButton2";
		    this.pushButton2.PushButtonManager = this.pushButtonManager1;
		    this.pushButton2.Size = new System.Drawing.Size(32, 32);
		    this.pushButton2.TabIndex = 7;
		    this.pushButton2.Text = null;
		    this.pushButton2.StateChanged += new System.EventHandler(this.PushButton2StateChanged);
		    // 
		    // pushButton3
		    // 
		    this.pushButton3.BorderWidth = 4F;
		    this.pushButton3.ColorBorder = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
		    this.pushButton3.ColorButton = System.Drawing.SystemColors.Control;
		    this.pushButton3.Location = new System.Drawing.Point(85, 55);
		    this.pushButton3.Name = "pushButton3";
		    this.pushButton3.PushButtonManager = this.pushButtonManager2;
		    this.pushButton3.Size = new System.Drawing.Size(67, 32);
		    this.pushButton3.TabIndex = 8;
		    this.pushButton3.Text = "test";
		    this.pushButton3.StateChanged += new System.EventHandler(this.PushButton3StateChanged);
		    // 
		    // pushButton6
		    // 
		    this.pushButton6.ColorButton = System.Drawing.SystemColors.Control;
		    this.pushButton6.FlatStyle = VisBox.VisElement.VisFlatStyle.Collapsed;
		    this.pushButton6.Location = new System.Drawing.Point(85, 93);
		    this.pushButton6.Name = "pushButton6";
		    this.pushButton6.PushButtonManager = this.pushButtonManager2;
		    this.pushButton6.Size = new System.Drawing.Size(67, 32);
		    this.pushButton6.TabIndex = 11;
		    this.pushButton6.Text = "siema";
		    // 
		    // pushButton7
		    // 
		    this.pushButton7.ColorButton = System.Drawing.SystemColors.Control;
		    this.pushButton7.ColorOff = System.Drawing.Color.Green;
		    this.pushButton7.ColorOn = System.Drawing.Color.Lime;
		    this.pushButton7.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.pushButton7.Location = new System.Drawing.Point(12, 93);
		    this.pushButton7.Name = "pushButton7";
		    this.pushButton7.Size = new System.Drawing.Size(67, 32);
		    this.pushButton7.TabIndex = 10;
		    this.pushButton7.Text = null;
		    this.pushButton7.WithLight = true;
		    // 
		    // pushButton8
		    // 
		    this.pushButton8.BackColor = System.Drawing.SystemColors.Control;
		    this.pushButton8.ColorBorder = System.Drawing.SystemColors.Control;
		    this.pushButton8.ColorButton = System.Drawing.SystemColors.Control;
		    this.pushButton8.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.pushButton8.LayoutShape = VisBox.VisElement.Shape.Ellipse;
		    this.pushButton8.Location = new System.Drawing.Point(12, 131);
		    this.pushButton8.Name = "pushButton8";
		    this.pushButton8.Size = new System.Drawing.Size(67, 32);
		    this.pushButton8.TabIndex = 13;
		    this.pushButton8.Text = "Test 123";
		    // 
		    // pushButton9
		    // 
		    this.pushButton9.BackColor = System.Drawing.SystemColors.Control;
		    this.pushButton9.ColorBorder = System.Drawing.SystemColors.Control;
		    this.pushButton9.ColorButton = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
		    this.pushButton9.LayoutShape = VisBox.VisElement.Shape.Ellipse;
		    this.pushButton9.Location = new System.Drawing.Point(85, 131);
		    this.pushButton9.Name = "pushButton9";
		    this.pushButton9.Size = new System.Drawing.Size(67, 32);
		    this.pushButton9.TabIndex = 14;
		    this.pushButton9.Text = "Test 123";
		    // 
		    // lamp2
		    // 
		    this.lamp2.BackColor = System.Drawing.SystemColors.Control;
		    this.lamp2.BorderWidth = 2F;
		    this.lamp2.Location = new System.Drawing.Point(123, 3);
		    this.lamp2.Name = "lamp2";
		    this.lamp2.Size = new System.Drawing.Size(32, 32);
		    this.lamp2.TabIndex = 15;
		    this.lamp2.Text = null;
		    // 
		    // zipBar2
		    // 
		    this.zipBar2.BorderWidth = 2F;
		    this.zipBar2.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.zipBar2.LayoutDirection = VisBox.VisElement.Direction.Vertical;
		    this.zipBar2.Location = new System.Drawing.Point(158, 3);
		    this.zipBar2.Name = "zipBar2";
		    this.zipBar2.Parts = 11;
		    this.zipBar2.Size = new System.Drawing.Size(23, 161);
		    this.zipBar2.TabIndex = 16;
		    this.zipBar2.Text = null;
		    this.zipBar2.ValueChanged += new System.EventHandler(this.ZipBar2ValueChanged);
		    // 
		    // lamp3
		    // 
		    this.lamp3.BackColor = System.Drawing.SystemColors.Control;
		    this.lamp3.BorderWidth = 2F;
		    this.lamp3.ColorOff = System.Drawing.Color.Chocolate;
		    this.lamp3.ColorOn = System.Drawing.Color.Orange;
		    this.lamp3.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.lamp3.Location = new System.Drawing.Point(47, 3);
		    this.lamp3.Name = "lamp3";
		    this.lamp3.Size = new System.Drawing.Size(32, 32);
		    this.lamp3.TabIndex = 17;
		    this.lamp3.Text = null;
		    // 
		    // lamp4
		    // 
		    this.lamp4.BackColor = System.Drawing.SystemColors.Control;
		    this.lamp4.BorderWidth = 2F;
		    this.lamp4.ColorOff = System.Drawing.Color.DarkGreen;
		    this.lamp4.ColorOn = System.Drawing.Color.Lime;
		    this.lamp4.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.lamp4.Location = new System.Drawing.Point(85, 3);
		    this.lamp4.Name = "lamp4";
		    this.lamp4.Size = new System.Drawing.Size(32, 32);
		    this.lamp4.TabIndex = 18;
		    this.lamp4.Text = null;
		    // 
		    // zipBar3
		    // 
		    this.zipBar3.BorderWidth = 2F;
		    this.zipBar3.Fix2Nearby = true;
		    this.zipBar3.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.zipBar3.Location = new System.Drawing.Point(216, 141);
		    this.zipBar3.Name = "zipBar3";
		    this.zipBar3.Parts = 2;
		    this.zipBar3.Size = new System.Drawing.Size(131, 23);
		    this.zipBar3.TabIndex = 19;
		    this.zipBar3.Text = null;
		    this.zipBar3.ValueChanged += new System.EventHandler(this.ZipBar10ValueChanged);
		    // 
		    // zipBar4
		    // 
		    this.zipBar4.BorderWidth = 2F;
		    this.zipBar4.Fix2Nearby = true;
		    this.zipBar4.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.zipBar4.Location = new System.Drawing.Point(216, 112);
		    this.zipBar4.Name = "zipBar4";
		    this.zipBar4.Parts = 3;
		    this.zipBar4.Size = new System.Drawing.Size(131, 23);
		    this.zipBar4.TabIndex = 20;
		    this.zipBar4.Text = null;
		    this.zipBar4.ValueChanged += new System.EventHandler(this.ZipBar10ValueChanged);
		    // 
		    // zipBar5
		    // 
		    this.zipBar5.BorderWidth = 2F;
		    this.zipBar5.Fix2Nearby = true;
		    this.zipBar5.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.zipBar5.Location = new System.Drawing.Point(216, 83);
		    this.zipBar5.Name = "zipBar5";
		    this.zipBar5.Parts = 4;
		    this.zipBar5.Size = new System.Drawing.Size(131, 23);
		    this.zipBar5.TabIndex = 21;
		    this.zipBar5.Text = null;
		    this.zipBar5.ValueChanged += new System.EventHandler(this.ZipBar10ValueChanged);
		    // 
		    // zipBar6
		    // 
		    this.zipBar6.BorderWidth = 2F;
		    this.zipBar6.Fix2Nearby = true;
		    this.zipBar6.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.zipBar6.Location = new System.Drawing.Point(216, 54);
		    this.zipBar6.Name = "zipBar6";
		    this.zipBar6.Parts = 5;
		    this.zipBar6.Size = new System.Drawing.Size(131, 23);
		    this.zipBar6.TabIndex = 22;
		    this.zipBar6.Text = null;
		    this.zipBar6.ValueChanged += new System.EventHandler(this.ZipBar10ValueChanged);
		    // 
		    // zipBar10
		    // 
		    this.zipBar10.BorderWidth = 2F;
		    this.zipBar10.Fix2Nearby = true;
		    this.zipBar10.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.zipBar10.Location = new System.Drawing.Point(187, 170);
		    this.zipBar10.Name = "zipBar10";
		    this.zipBar10.Parts = 20;
		    this.zipBar10.Size = new System.Drawing.Size(160, 23);
		    this.zipBar10.TabIndex = 26;
		    this.zipBar10.Text = null;
		    this.zipBar10.ValueChanged += new System.EventHandler(this.ZipBar10ValueChanged);
		    // 
		    // label2
		    // 
		    this.label2.Location = new System.Drawing.Point(272, 12);
		    this.label2.Name = "label2";
		    this.label2.Size = new System.Drawing.Size(60, 23);
		    this.label2.TabIndex = 27;
		    this.label2.Text = "label2";
		    // 
		    // displaySegment1
		    // 
		    this.displaySegment1.BackColor = System.Drawing.Color.Black;
		    this.displaySegment1.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.displaySegment1.Location = new System.Drawing.Point(350, 3);
		    this.displaySegment1.Margin = new System.Windows.Forms.Padding(0);
		    this.displaySegment1.Name = "displaySegment1";
		    this.displaySegment1.Scale = 1F;
		    this.displaySegment1.Segments = "10000000";
		    this.displaySegment1.ShowDot = true;
		    this.displaySegment1.Size = new System.Drawing.Size(32, 48);
		    this.displaySegment1.TabIndex = 28;
		    this.displaySegment1.Text = "displaySegment1";
		    // 
		    // displaySegment2
		    // 
		    this.displaySegment2.BackColor = System.Drawing.Color.Black;
		    this.displaySegment2.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.displaySegment2.Location = new System.Drawing.Point(382, 3);
		    this.displaySegment2.Margin = new System.Windows.Forms.Padding(0);
		    this.displaySegment2.Name = "displaySegment2";
		    this.displaySegment2.Scale = 1F;
		    this.displaySegment2.ShowDot = true;
		    this.displaySegment2.Size = new System.Drawing.Size(32, 48);
		    this.displaySegment2.TabIndex = 29;
		    this.displaySegment2.Text = "displaySegment2";
		    // 
		    // displaySegment3
		    // 
		    this.displaySegment3.BackColor = System.Drawing.Color.Black;
		    this.displaySegment3.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.displaySegment3.Location = new System.Drawing.Point(414, 3);
		    this.displaySegment3.Margin = new System.Windows.Forms.Padding(0);
		    this.displaySegment3.Name = "displaySegment3";
		    this.displaySegment3.Scale = 1F;
		    this.displaySegment3.ShowDot = true;
		    this.displaySegment3.Size = new System.Drawing.Size(32, 48);
		    this.displaySegment3.TabIndex = 30;
		    this.displaySegment3.Text = "displaySegment3";
		    // 
		    // displaySegment4
		    // 
		    this.displaySegment4.BackColor = System.Drawing.Color.Black;
		    this.displaySegment4.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.displaySegment4.Location = new System.Drawing.Point(446, 3);
		    this.displaySegment4.Margin = new System.Windows.Forms.Padding(0);
		    this.displaySegment4.Name = "displaySegment4";
		    this.displaySegment4.Scale = 1F;
		    this.displaySegment4.ShowDot = true;
		    this.displaySegment4.Size = new System.Drawing.Size(32, 48);
		    this.displaySegment4.TabIndex = 31;
		    this.displaySegment4.Text = "displaySegment4";
		    // 
		    // displaySegment5
		    // 
		    this.displaySegment5.BackColor = System.Drawing.Color.Black;
		    this.displaySegment5.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.displaySegment5.Location = new System.Drawing.Point(478, 3);
		    this.displaySegment5.Margin = new System.Windows.Forms.Padding(0);
		    this.displaySegment5.Name = "displaySegment5";
		    this.displaySegment5.Scale = 1F;
		    this.displaySegment5.ShowDot = true;
		    this.displaySegment5.Size = new System.Drawing.Size(32, 48);
		    this.displaySegment5.TabIndex = 32;
		    this.displaySegment5.Text = "displaySegment5";
		    // 
		    // displaySegment6
		    // 
		    this.displaySegment6.BackColor = System.Drawing.Color.Black;
		    this.displaySegment6.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.displaySegment6.Location = new System.Drawing.Point(510, 3);
		    this.displaySegment6.Margin = new System.Windows.Forms.Padding(0);
		    this.displaySegment6.Name = "displaySegment6";
		    this.displaySegment6.Scale = 1F;
		    this.displaySegment6.ShowDot = true;
		    this.displaySegment6.Size = new System.Drawing.Size(32, 48);
		    this.displaySegment6.TabIndex = 33;
		    this.displaySegment6.Text = "displaySegment6";
		    // 
		    // display14Segment1
		    // 
		    this.display14Segment1.BackColor = System.Drawing.Color.Black;
		    this.display14Segment1.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.display14Segment1.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(254)))), ((int)(((byte)(2)))));
		    this.display14Segment1.Location = new System.Drawing.Point(350, 116);
		    this.display14Segment1.Margin = new System.Windows.Forms.Padding(0);
		    this.display14Segment1.Name = "display14Segment1";
		    this.display14Segment1.Scale = 1F;
		    this.display14Segment1.Segments = "000000000000000";
		    this.display14Segment1.ShowDot = true;
		    this.display14Segment1.Size = new System.Drawing.Size(32, 48);
		    this.display14Segment1.TabIndex = 34;
		    this.display14Segment1.Text = "display14Segment1";
		    // 
		    // display14Segment2
		    // 
		    this.display14Segment2.BackColor = System.Drawing.Color.Black;
		    this.display14Segment2.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.display14Segment2.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(254)))), ((int)(((byte)(2)))));
		    this.display14Segment2.Location = new System.Drawing.Point(382, 116);
		    this.display14Segment2.Margin = new System.Windows.Forms.Padding(0);
		    this.display14Segment2.Name = "display14Segment2";
		    this.display14Segment2.Scale = 1F;
		    this.display14Segment2.Segments = "000000000000000";
		    this.display14Segment2.ShowDot = true;
		    this.display14Segment2.Size = new System.Drawing.Size(32, 48);
		    this.display14Segment2.TabIndex = 35;
		    this.display14Segment2.Text = "display14Segment2";
		    // 
		    // display14Segment3
		    // 
		    this.display14Segment3.BackColor = System.Drawing.Color.Black;
		    this.display14Segment3.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.display14Segment3.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(254)))), ((int)(((byte)(2)))));
		    this.display14Segment3.Location = new System.Drawing.Point(414, 116);
		    this.display14Segment3.Margin = new System.Windows.Forms.Padding(0);
		    this.display14Segment3.Name = "display14Segment3";
		    this.display14Segment3.Scale = 1F;
		    this.display14Segment3.Segments = "000000000000000";
		    this.display14Segment3.ShowDot = true;
		    this.display14Segment3.Size = new System.Drawing.Size(32, 48);
		    this.display14Segment3.TabIndex = 36;
		    this.display14Segment3.Text = "display14Segment3";
		    // 
		    // display14Segment4
		    // 
		    this.display14Segment4.BackColor = System.Drawing.Color.Black;
		    this.display14Segment4.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.display14Segment4.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(254)))), ((int)(((byte)(2)))));
		    this.display14Segment4.Location = new System.Drawing.Point(446, 116);
		    this.display14Segment4.Margin = new System.Windows.Forms.Padding(0);
		    this.display14Segment4.Name = "display14Segment4";
		    this.display14Segment4.Scale = 1F;
		    this.display14Segment4.Segments = "000000000000000";
		    this.display14Segment4.ShowDot = true;
		    this.display14Segment4.Size = new System.Drawing.Size(32, 48);
		    this.display14Segment4.TabIndex = 37;
		    this.display14Segment4.Text = "display14Segment4";
		    // 
		    // display14Segment5
		    // 
		    this.display14Segment5.BackColor = System.Drawing.Color.Black;
		    this.display14Segment5.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.display14Segment5.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(254)))), ((int)(((byte)(2)))));
		    this.display14Segment5.Location = new System.Drawing.Point(478, 116);
		    this.display14Segment5.Margin = new System.Windows.Forms.Padding(0);
		    this.display14Segment5.Name = "display14Segment5";
		    this.display14Segment5.Scale = 1F;
		    this.display14Segment5.Segments = "000000000000000";
		    this.display14Segment5.ShowDot = true;
		    this.display14Segment5.Size = new System.Drawing.Size(32, 48);
		    this.display14Segment5.TabIndex = 38;
		    this.display14Segment5.Text = "display14Segment5";
		    // 
		    // display14Segment6
		    // 
		    this.display14Segment6.BackColor = System.Drawing.Color.Black;
		    this.display14Segment6.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.display14Segment6.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(254)))), ((int)(((byte)(2)))));
		    this.display14Segment6.Location = new System.Drawing.Point(350, 164);
		    this.display14Segment6.Margin = new System.Windows.Forms.Padding(0);
		    this.display14Segment6.Name = "display14Segment6";
		    this.display14Segment6.Scale = 1F;
		    this.display14Segment6.Segments = "000000000000000";
		    this.display14Segment6.ShowDot = true;
		    this.display14Segment6.Size = new System.Drawing.Size(32, 48);
		    this.display14Segment6.TabIndex = 39;
		    this.display14Segment6.Text = "display14Segment6";
		    // 
		    // display14Segment7
		    // 
		    this.display14Segment7.BackColor = System.Drawing.Color.Black;
		    this.display14Segment7.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.display14Segment7.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(254)))), ((int)(((byte)(2)))));
		    this.display14Segment7.Location = new System.Drawing.Point(382, 164);
		    this.display14Segment7.Margin = new System.Windows.Forms.Padding(0);
		    this.display14Segment7.Name = "display14Segment7";
		    this.display14Segment7.Scale = 1F;
		    this.display14Segment7.Segments = "000000000000000";
		    this.display14Segment7.ShowDot = true;
		    this.display14Segment7.Size = new System.Drawing.Size(32, 48);
		    this.display14Segment7.TabIndex = 40;
		    this.display14Segment7.Text = "display14Segment7";
		    // 
		    // display14Segment8
		    // 
		    this.display14Segment8.BackColor = System.Drawing.Color.Black;
		    this.display14Segment8.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.display14Segment8.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(254)))), ((int)(((byte)(2)))));
		    this.display14Segment8.Location = new System.Drawing.Point(414, 164);
		    this.display14Segment8.Margin = new System.Windows.Forms.Padding(0);
		    this.display14Segment8.Name = "display14Segment8";
		    this.display14Segment8.Scale = 1F;
		    this.display14Segment8.Segments = "000000000000000";
		    this.display14Segment8.ShowDot = true;
		    this.display14Segment8.Size = new System.Drawing.Size(32, 48);
		    this.display14Segment8.TabIndex = 41;
		    this.display14Segment8.Text = "display14Segment8";
		    // 
		    // display14Segment9
		    // 
		    this.display14Segment9.BackColor = System.Drawing.Color.Black;
		    this.display14Segment9.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.display14Segment9.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(254)))), ((int)(((byte)(2)))));
		    this.display14Segment9.Location = new System.Drawing.Point(446, 164);
		    this.display14Segment9.Margin = new System.Windows.Forms.Padding(0);
		    this.display14Segment9.Name = "display14Segment9";
		    this.display14Segment9.Scale = 1F;
		    this.display14Segment9.Segments = "000000000000000";
		    this.display14Segment9.ShowDot = true;
		    this.display14Segment9.Size = new System.Drawing.Size(32, 48);
		    this.display14Segment9.TabIndex = 42;
		    this.display14Segment9.Text = "display14Segment9";
		    // 
		    // display14Segment10
		    // 
		    this.display14Segment10.BackColor = System.Drawing.Color.Black;
		    this.display14Segment10.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.display14Segment10.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(254)))), ((int)(((byte)(2)))));
		    this.display14Segment10.Location = new System.Drawing.Point(478, 164);
		    this.display14Segment10.Margin = new System.Windows.Forms.Padding(0);
		    this.display14Segment10.Name = "display14Segment10";
		    this.display14Segment10.Scale = 1F;
		    this.display14Segment10.Segments = "000000000000000";
		    this.display14Segment10.ShowDot = true;
		    this.display14Segment10.Size = new System.Drawing.Size(32, 48);
		    this.display14Segment10.TabIndex = 43;
		    this.display14Segment10.Text = "display14Segment10";
		    // 
		    // display14SegmentLoading
		    // 
		    this.display14SegmentLoading.BackColor = System.Drawing.Color.Black;
		    this.display14SegmentLoading.ColorInner = System.Drawing.Color.Black;
		    this.display14SegmentLoading.ColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
		    this.display14SegmentLoading.ColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(254)))), ((int)(((byte)(2)))));
		    this.display14SegmentLoading.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.display14SegmentLoading.Location = new System.Drawing.Point(513, 116);
		    this.display14SegmentLoading.Margin = new System.Windows.Forms.Padding(0);
		    this.display14SegmentLoading.Name = "display14SegmentLoading";
		    this.display14SegmentLoading.Scale = 1F;
		    this.display14SegmentLoading.Segments = "100000000000000";
		    this.display14SegmentLoading.Size = new System.Drawing.Size(32, 48);
		    this.display14SegmentLoading.TabIndex = 44;
		    this.display14SegmentLoading.Text = "display14Segment11";
		    // 
		    // analogMeter1
		    // 
		    this.analogMeter1.BackColor = System.Drawing.SystemColors.Control;
		    this.analogMeter1.ColorArrow = System.Drawing.Color.Teal;
		    this.analogMeter1.ColorLine = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
		    this.analogMeter1.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.analogMeter1.Location = new System.Drawing.Point(350, 54);
		    this.analogMeter1.Name = "analogMeter1";
		    this.analogMeter1.Parts = 11;
		    this.analogMeter1.Size = new System.Drawing.Size(95, 58);
		    this.analogMeter1.TabIndex = 45;
		    this.analogMeter1.Text = "analogMeter1";
		    this.analogMeter1.Value = 0.5F;
		    // 
		    // analogMeter2
		    // 
		    this.analogMeter2.ColorArrow = System.Drawing.Color.Teal;
		    this.analogMeter2.ColorLine = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
		    this.analogMeter2.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.analogMeter2.Location = new System.Drawing.Point(447, 54);
		    this.analogMeter2.Name = "analogMeter2";
		    this.analogMeter2.Parts = 11;
		    this.analogMeter2.Size = new System.Drawing.Size(95, 58);
		    this.analogMeter2.TabIndex = 46;
		    this.analogMeter2.Text = "analogMeter2";
		    this.analogMeter2.Value = 0.4F;
		    // 
		    // switch1
		    // 
		    this.switch1.Location = new System.Drawing.Point(513, 164);
		    this.switch1.Name = "switch1";
		    this.switch1.Size = new System.Drawing.Size(32, 48);
		    this.switch1.TabIndex = 47;
		    this.switch1.Text = "switch1";
		    // 
		    // controlKnob1
		    // 
		    this.controlKnob1.Location = new System.Drawing.Point(216, 3);
		    this.controlKnob1.Name = "controlKnob1";
		    this.controlKnob1.Size = new System.Drawing.Size(46, 46);
		    this.controlKnob1.TabIndex = 48;
		    this.controlKnob1.Text = "controlKnob1";
		    // 
		    // lcdDisplay1
		    // 
		    this.lcdDisplay1.Background = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(173)))), ((int)(((byte)(52)))));
		    this.lcdDisplay1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lcdDisplay1.BackgroundImage")));
		    this.lcdDisplay1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
		    this.lcdDisplay1.BlockColorOff = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(159)))), ((int)(((byte)(47)))));
		    this.lcdDisplay1.BlockColorOn = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(63)))), ((int)(((byte)(48)))));
		    this.lcdDisplay1.Cols = 14;
		    this.lcdDisplay1.Location = new System.Drawing.Point(3, 199);
		    this.lcdDisplay1.Name = "lcdDisplay1";
		    this.lcdDisplay1.Rows = 2;
		    this.lcdDisplay1.Size = new System.Drawing.Size(344, 88);
		    this.lcdDisplay1.TabIndex = 49;
		    this.lcdDisplay1.Text = "Test";
		    // 
		    // button1
		    // 
		    this.button1.Location = new System.Drawing.Point(350, 244);
		    this.button1.Name = "button1";
		    this.button1.Size = new System.Drawing.Size(100, 23);
		    this.button1.TabIndex = 50;
		    this.button1.Text = "Print on screen";
		    this.button1.UseVisualStyleBackColor = true;
		    this.button1.Click += new System.EventHandler(this.Button1Click);
		    // 
		    // textBox1
		    // 
		    this.textBox1.Location = new System.Drawing.Point(350, 218);
		    this.textBox1.Name = "textBox1";
		    this.textBox1.Size = new System.Drawing.Size(100, 20);
		    this.textBox1.TabIndex = 51;
		    // 
		    // plot1
		    // 
		    this.plot1.BackColor = System.Drawing.Color.Gainsboro;
		    this.plot1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("plot1.BackgroundImage")));
		    this.plot1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		    this.plot1.BorderWidth = 1F;
		    this.plot1.FlatStyle = VisBox.VisElement.VisFlatStyle.Collapsed;
		    this.plot1.Location = new System.Drawing.Point(548, 3);
		    this.plot1.Name = "plot1";
		    this.plot1.Size = new System.Drawing.Size(472, 284);
		    this.plot1.TabIndex = 52;
		    this.plot1.Text = "plot1";
		    // 
		    // txtBxPlotMarker
		    // 
		    this.txtBxPlotMarker.Location = new System.Drawing.Point(495, 218);
		    this.txtBxPlotMarker.Name = "txtBxPlotMarker";
		    this.txtBxPlotMarker.Size = new System.Drawing.Size(50, 20);
		    this.txtBxPlotMarker.TabIndex = 53;
		    this.txtBxPlotMarker.TextChanged += new System.EventHandler(this.TxtBxPlotMarkerTextChanged);
		    // 
		    // zipBar7
		    // 
		    this.zipBar7.BorderWidth = 2F;
		    this.zipBar7.Fix2Nearby = true;
		    this.zipBar7.FlatStyle = VisBox.VisElement.VisFlatStyle.Popup;
		    this.zipBar7.LayoutDirection = VisBox.VisElement.Direction.Vertical;
		    this.zipBar7.Location = new System.Drawing.Point(187, 3);
		    this.zipBar7.Name = "zipBar7";
		    this.zipBar7.Parts = 20;
		    this.zipBar7.Size = new System.Drawing.Size(23, 161);
		    this.zipBar7.TabIndex = 54;
		    this.zipBar7.Text = null;
		    // 
		    // MainForm
		    // 
		    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		    this.BackColor = System.Drawing.SystemColors.Control;
		    this.ClientSize = new System.Drawing.Size(1026, 327);
		    this.Controls.Add(this.zipBar7);
		    this.Controls.Add(this.txtBxPlotMarker);
		    this.Controls.Add(this.plot1);
		    this.Controls.Add(this.textBox1);
		    this.Controls.Add(this.button1);
		    this.Controls.Add(this.lcdDisplay1);
		    this.Controls.Add(this.controlKnob1);
		    this.Controls.Add(this.switch1);
		    this.Controls.Add(this.analogMeter2);
		    this.Controls.Add(this.analogMeter1);
		    this.Controls.Add(this.display14SegmentLoading);
		    this.Controls.Add(this.display14Segment10);
		    this.Controls.Add(this.display14Segment9);
		    this.Controls.Add(this.display14Segment8);
		    this.Controls.Add(this.display14Segment7);
		    this.Controls.Add(this.display14Segment6);
		    this.Controls.Add(this.display14Segment5);
		    this.Controls.Add(this.display14Segment4);
		    this.Controls.Add(this.display14Segment3);
		    this.Controls.Add(this.display14Segment2);
		    this.Controls.Add(this.display14Segment1);
		    this.Controls.Add(this.displaySegment6);
		    this.Controls.Add(this.displaySegment5);
		    this.Controls.Add(this.displaySegment4);
		    this.Controls.Add(this.displaySegment3);
		    this.Controls.Add(this.displaySegment2);
		    this.Controls.Add(this.displaySegment1);
		    this.Controls.Add(this.label2);
		    this.Controls.Add(this.zipBar10);
		    this.Controls.Add(this.zipBar6);
		    this.Controls.Add(this.zipBar5);
		    this.Controls.Add(this.zipBar4);
		    this.Controls.Add(this.zipBar3);
		    this.Controls.Add(this.lamp4);
		    this.Controls.Add(this.lamp3);
		    this.Controls.Add(this.zipBar2);
		    this.Controls.Add(this.lamp2);
		    this.Controls.Add(this.pushButton9);
		    this.Controls.Add(this.pushButton8);
		    this.Controls.Add(this.pushButton6);
		    this.Controls.Add(this.pushButton7);
		    this.Controls.Add(this.pushButton3);
		    this.Controls.Add(this.pushButton2);
		    this.Controls.Add(this.pushButton1);
		    this.Controls.Add(this.zipBar1);
		    this.Controls.Add(this.bar1);
		    this.Controls.Add(this.label1);
		    this.Controls.Add(this.lamp1);
		    this.Location = new System.Drawing.Point(200, 100);
		    this.Name = "MainForm";
		    this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		    this.Text = "tester";
		    this.Load += new System.EventHandler(this.MainFormLoad);
		    this.ResumeLayout(false);
		    this.PerformLayout();

		}
	}
}
