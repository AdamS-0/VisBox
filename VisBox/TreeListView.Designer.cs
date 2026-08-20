/*
 * Created by SharpDevelop.
 * User: AS
 * Date: 19.08.2026
 * Time: 07:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace VisBox
{
    partial class TreeListView
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pMain;
        private System.Windows.Forms.VScrollBar vScrlBr;
        private System.Windows.Forms.HScrollBar hScrlBr;
        
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
            this.pMain = new System.Windows.Forms.Panel();
            this.vScrlBr = new System.Windows.Forms.VScrollBar();
            this.hScrlBr = new System.Windows.Forms.HScrollBar();
            this.SuspendLayout();
            // 
            // pMain
            // 
            this.pMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMain.Location = new System.Drawing.Point(0, 0);
            this.pMain.Name = "pMain";
            this.pMain.Size = new System.Drawing.Size(133, 133);
            this.pMain.TabIndex = 2;
            this.pMain.SizeChanged += new System.EventHandler(this.PMainSizeChanged);
            this.pMain.Paint += new System.Windows.Forms.PaintEventHandler(this.TreeListViewPaint);
            this.pMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PMainMouseDown);
            this.pMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PMainMouseMove);
            this.pMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TreeListViewMouseUp);
            // 
            // vScrlBr
            // 
            this.vScrlBr.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrlBr.Location = new System.Drawing.Point(133, 0);
            this.vScrlBr.Name = "vScrlBr";
            this.vScrlBr.Size = new System.Drawing.Size(17, 150);
            this.vScrlBr.TabIndex = 3;
            this.vScrlBr.ValueChanged += new System.EventHandler(this.VScrlBrValueChanged);
            // 
            // hScrlBr
            // 
            this.hScrlBr.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.hScrlBr.Location = new System.Drawing.Point(0, 133);
            this.hScrlBr.Name = "hScrlBr";
            this.hScrlBr.Size = new System.Drawing.Size(133, 17);
            this.hScrlBr.TabIndex = 0;
            // 
            // TreeListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pMain);
            this.Controls.Add(this.hScrlBr);
            this.Controls.Add(this.vScrlBr);
            this.Name = "TreeListView";
            this.ResumeLayout(false);

        }
    }
}
