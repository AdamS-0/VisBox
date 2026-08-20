/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 22.12.2022
 * Time: 08:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace VisBox
{
	partial class Plot
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ContextMenuStrip ctxMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem showPropEditorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showSeriesPropsToolStripMenuItem;
		
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
		    this.components = new System.ComponentModel.Container();
		    this.ctxMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
		    this.showPropEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.showSeriesPropsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		    this.ctxMenuStrip.SuspendLayout();
		    this.SuspendLayout();
		    // 
		    // ctxMenuStrip
		    // 
		    this.ctxMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showPropEditorToolStripMenuItem,
            this.showSeriesPropsToolStripMenuItem});
		    this.ctxMenuStrip.Name = "ctxMenuStrip";
		    this.ctxMenuStrip.Size = new System.Drawing.Size(182, 70);
		    // 
		    // showPropEditorToolStripMenuItem
		    // 
		    this.showPropEditorToolStripMenuItem.Name = "showPropEditorToolStripMenuItem";
		    this.showPropEditorToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
		    this.showPropEditorToolStripMenuItem.Text = "Show PropEditor";
		    this.showPropEditorToolStripMenuItem.Click += new System.EventHandler(this.ShowPropEditorToolStripMenuItemClick);
		    // 
		    // showSeriesPropsToolStripMenuItem
		    // 
		    this.showSeriesPropsToolStripMenuItem.Name = "showSeriesPropsToolStripMenuItem";
		    this.showSeriesPropsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
		    this.showSeriesPropsToolStripMenuItem.Text = "Show Series\' props";
		    this.showSeriesPropsToolStripMenuItem.Click += new System.EventHandler(this.ShowSeriesPropsToolStripMenuItemClick);
		    // 
		    // Plot
		    // 
		    this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
		    this.Name = "Plot";
		    this.Paint += new System.Windows.Forms.PaintEventHandler(this.PlotPaint);
		    this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PlotMouseUp);
		    this.Resize += new System.EventHandler(this.PlotResize);
		    this.ctxMenuStrip.ResumeLayout(false);
		    this.ResumeLayout(false);

		}
	}
}
