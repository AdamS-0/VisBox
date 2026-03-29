/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 18.05.2021
 * Time: 11:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace VisBox
{
	partial class ControlKnob
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.SuspendLayout();
			// 
			// ControlKnob
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Name = "ControlKnob";
			this.Size = new System.Drawing.Size(48, 48);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.ControlKnobPaint);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ZipBarMouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlKnobMouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ZipBarMouseUp);
			this.ResumeLayout(false);

		}
	}
}
