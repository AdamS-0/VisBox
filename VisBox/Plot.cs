/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 22.12.2022
 * Time: 08:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VisBox {
    
    public class Marker {
        public Color Color { get; set; }
        public char Symbol { get; set; }
        
        public Marker() {
            
        }
        
        public Marker(Color? color = null, char symbol = ' ') {
            this.Color = color ?? Color.Blue;
            this.Symbol = symbol;
        }
    }
    
    
    
    
    
    public partial class Plot : VisElement {
        private Grid _gridX = new Grid();
        [Category("VisBox")]
        public Grid gridX {
            get { return _gridX; }
            set { _gridX = value; }
        }
        
        private Grid _gridY = new Grid();
        [Category("VisBox")]
        public Grid gridY {
            get { return _gridY; }
            set { _gridY = value; }
        }
        
        private Grid _gridXminor = new Grid();
        [Category("VisBox")]
        public Grid gridXminor {
            get { return _gridXminor; }
            set { _gridXminor = value; }
        }
        
        
        private Grid _gridYminor = new Grid();
        [Category("VisBox")]
        public Grid gridYminor {
            get { return _gridYminor; }
            set { _gridYminor = value; }
        }
        
        float _drawScaleX = 1;
        float _drawScaleY = 1;
        float _drawDeltaX = 1;
        float _drawDeltaY = 1;
        Rectangle canvas;
        Bitmap bmp;
        
        public List<Series> Series = new List<Series>();
//		public List<Series> Series {
//		    get { return _series; }
//		    set { _series = value; }
//		}
        
        private AxisLimits _axisLimitsX = new AxisLimits();
        [Category("VisBox")]
        public AxisLimits AxisLimitsX {
            get { return _axisLimitsX; }
            set { _axisLimitsX = value; }
        }
        
        private AxisLimits _axisLimitsY = new AxisLimits();
        [Category("VisBox")]
        public AxisLimits AxisLimitsY {
            get { return _axisLimitsY; }
            set { _axisLimitsY = value; }
        }
        
		private AxisMargin _axisMarginLast = new AxisMargin(0, 0, 0, 0);
        private AxisMargin _axisMargin = new AxisMargin();
        [Category("VisBox")]
        [Browsable(true)]
        [Description("Used during AxisLimits Autoscale option is set. Adds given value as % of |max - min| values to axis limits")]
        public AxisMargin AxisMargin {
            get { return _axisMargin; }
            set { _axisMargin = value; }
        }
        
        
        [Category("VisBox")]
        [Browsable(true)]
        [Description("Just a background color")]
        public Color BackgroundColor {
            get { return base.ColorInner; }
            set { base.ColorInner = value; }
        }
        
        private PropEditor _propEditor = new PropEditor();
        
        public Plot() {
            InitializeComponent();
            
            Init();
        }
        
        
        void PlotResize(object sender, EventArgs e) {
            Init();
        }
        
        
        private void UpdateCanvasSize() {
            canvas = GetInnerSpace2Draw();
			/* Update Canvas with axisMargins */
            canvas.X += _axisMargin.Left;
            canvas.Y += _axisMargin.Top;
            
            canvas.Width -= ( _axisMargin.Left + _axisMargin.Right );
            canvas.Height -= ( _axisMargin.Top + _axisMargin.Bottom );
			
            bmp = new Bitmap( canvas.Width, canvas.Height );
        }
        
        
        public void Init() {
            UpdateCanvasSize();
            gridYminor.Pen = new Pen( Color.Gray );
            gridYminor.Pen.DashPattern = new float[]{1, 1};
            gridY.GridOn = true;
            gridX.GridOn = true;
        }
        
        
        public void AddSeries(ref Series newSeries) {
            Series.Add(newSeries);
        }
        
        
        public void CalculateDrawScaler() {
            _drawDeltaX = AxisLimitsX.Max - AxisLimitsX.Min;
            _drawDeltaY = AxisLimitsY.Max - AxisLimitsY.Min;
            
            if( _drawDeltaX == 0 ) { _drawDeltaX = 1; }
            if( _drawDeltaY == 0 ) { _drawDeltaY = 1; }
            
            _drawScaleX = canvas.Width/_drawDeltaX;
            _drawScaleY = canvas.Height/_drawDeltaY;
        }
        
        public void GetSeriesLimits() {
            if( AxisLimitsX.Autoscale ) {
                if(Series.Count > 0) {
                    if( Series[0].dataX.Count > 0 ) {
                        AxisLimitsX.Min = Series[0].dataX[0];
                        AxisLimitsX.Max = AxisLimitsX.Min;
                    }
                }
                foreach( Series ser in Series ) {
                    for( int i = 0; i < ser.dataX.Count; i++ ) {
                        if( ser.dataX[i] < AxisLimitsX.Min ) { AxisLimitsX.Min = ser.dataX[i]; }
                        if( ser.dataX[i] > AxisLimitsX.Max ) { AxisLimitsX.Max = ser.dataX[i]; }
                    }
                }
                if( (int)AxisLimitsX.Min == (int)AxisLimitsX.Max ) {
                    AxisLimitsX.Min -= 0.1f;
                    AxisLimitsX.Max += 0.1f;
                }
                
                float deltaX = AxisLimitsX.Max - AxisLimitsX.Min;
                AxisLimitsX.Min -= deltaX*AxisMargin.Left;
                AxisLimitsX.Max += deltaX*AxisMargin.Right;
            }
            
            if( AxisLimitsY.Autoscale ) {
                if(Series.Count > 0) {
                    if( Series[0].dataY.Count > 0 ) {
                        AxisLimitsY.Min = Series[0].dataY[0];
                        AxisLimitsY.Max = AxisLimitsY.Min;
                    }
                }
                foreach( Series ser in Series ) {
                    for( int i = 0; i < ser.dataX.Count; i++ ) {
                        if( ser.dataY[i] < AxisLimitsY.Min ) { AxisLimitsY.Min = ser.dataY[i]; }
                        if( ser.dataY[i] > AxisLimitsY.Max ) { AxisLimitsY.Max = ser.dataY[i]; }
                    }
                }
                if( (int)AxisLimitsY.Min == (int)AxisLimitsY.Max ) {
                    AxisLimitsY.Min -= 0.1f;
                    AxisLimitsY.Max += 0.1f;
                }
                
                float deltaY = AxisLimitsY.Max - AxisLimitsY.Min;
                AxisLimitsY.Min -= deltaY*AxisMargin.Bottom;
                AxisLimitsY.Max += deltaY*AxisMargin.Top;
            }
            
        }
        
        public void Draw() {
            Graphics gr = Graphics.FromImage( bmp );
            
            GetSeriesLimits();
            CalculateDrawScaler();
            
            gr.Clear( _colorInner );
            gr.DrawRectangle(new Pen(Color.Gray), 0, 0, canvas.Width - 1, canvas.Height - 1);
            
            DrawGrid(ref gr);
            
            DrawSeries(ref gr);
            
            Refresh();
        }
        
        
        public void DrawSeries(ref Graphics gr) {
            
            foreach( Series ser in Series ) {
                if( ser.dataX.Count != ser.dataY.Count ) {
                    throw new Exception("Length of two vectors are not equal!");
                }
                
                ser.DrawSeries(ref gr, _drawScaleX, _drawScaleY, AxisLimitsX.Min, AxisLimitsX.Max, AxisLimitsY.Min, canvas.Height);
            }
            
            foreach( Series ser in Series ) {
                if( ser.dataX.Count != ser.dataY.Count ) {
                    throw new Exception("Length of two vectors are not equal!");
                }
                
                ser.DrawMarkers(ref gr, _drawScaleX, _drawScaleY, AxisLimitsX.Min, AxisLimitsY.Min, canvas.Height);
            }
        }
        
        public void DrawGrid(ref Graphics gr) {
            DrawGridY(ref gr);
            DrawGridX(ref gr);
            
        }
        
        
        public void DrawGridY(ref Graphics gr) {
            float drawY = 0;
            float drawX = 0;
            
            if( !gridY.GridOn ) { return; }
            if(gridY.Dots == null) { return; }
            
            if ( gridY.Autoscale || ( gridY.Dots.Count == 0 ) ) {
                gridY.Dots.Clear();
                gridY.ReCalculateGrid(AxisLimitsY.Min, AxisLimitsY.Max);
            }
            
            if( gridYminor.GridOn ) {
                if ( gridYminor.Autoscale || ( gridYminor.Dots.Count == 0 ) ) {
                    gridYminor.Dots.Clear();
                    gridYminor.ReCalculateGrid(AxisLimitsY.Min, AxisLimitsY.Max, gridYminor.ScaleFactor);
                }
            }
            
            drawX = 0;
            
            if( gridYminor.GridOn ) {
                // Plot Y minor grid
                foreach( GridDot gDot in gridYminor.Dots ) {
                    // Draw major grid lines
                    drawY = canvas.Height - (gDot.Value - AxisLimitsY.Min) * _drawScaleY;
                    gr.DrawLine( gridYminor.Pen, drawX, drawY, canvas.Width, drawY );
                    if( gridYminor.ShowLables ) {
                        gr.DrawString(gDot.Name, new Font("Arial",  10), gridYminor.LabelBrush,  0, drawY - 8);
                    }
                }
            }
            
            // Plot Y major grid
            foreach( GridDot gDot in gridY.Dots ) {
                // Draw major grid lines
                drawY = canvas.Height - (gDot.Value - AxisLimitsY.Min) * _drawScaleY;
                gr.DrawLine( gridY.Pen, drawX, drawY, canvas.Width, drawY );
                if( gridY.ShowLables ) {
                    gr.DrawString(gDot.Name, new Font("Arial",  10), gridY.LabelBrush,  0, drawY - 8);
                }
            }
        }
        
        public void DrawGridX(ref Graphics gr) {
            float drawY = 0;
            float drawX = 0;
            
            if( !gridX.GridOn ) { return; }
            if(gridX.Dots == null) { return; }
            
            if ( gridX.Autoscale || ( gridX.Dots.Count == 0 ) ) {
                gridX.Dots.Clear();
                gridX.ReCalculateGrid(AxisLimitsX.Min, AxisLimitsX.Max);
            }
            
            if( gridXminor.GridOn ) {
                if ( gridXminor.Autoscale || ( gridXminor.Dots.Count == 0 ) ) {
                    gridXminor.Dots.Clear();
                    gridXminor.ReCalculateGrid(AxisLimitsX.Min, AxisLimitsX.Max, gridXminor.ScaleFactor);
                }
            }
            
            drawY = 0;
            StringFormat strFrmtX = new StringFormat();
            strFrmtX.Alignment = StringAlignment.Center;
            if( gridXminor.GridOn ) {
                // Plot X minor grid
                foreach( GridDot gDot in gridXminor.Dots ) {
                    // Draw major grid lines
                    drawX = (gDot.Value - AxisLimitsX.Min) * _drawScaleX;
                    gr.DrawLine( gridYminor.Pen, drawX, drawY, drawX, canvas.Height );
                    if( gridXminor.ShowLables ) {
                        gr.DrawString(gDot.Name, new Font("Arial",  10), gridXminor.LabelBrush,  drawX, 8, strFrmtX);
                    }
                }
            }
            
            // Plot X major grid
            foreach( GridDot gDot in gridX.Dots ) {
                // Draw major grid lines
                drawX = (gDot.Value - AxisLimitsX.Min) * _drawScaleX;
                gr.DrawLine( gridX.Pen, drawX, drawY, drawX, canvas.Height );
                if( gridX.ShowLables ) {
                    gr.DrawString(gDot.Name, new Font("Arial",  10), gridX.LabelBrush,  drawX, 8, strFrmtX);
                }
            }
        }
        
        
        void PlotPaint(object sender, PaintEventArgs e) {
            Rectangle inner = GetInnerSpace();
			e.Graphics.DrawImage( bmp, inner.X + _axisMargin.Left, inner.Y + _axisMargin.Top );
        }
        
        
        
        void PlotMouseUp ( object sender, MouseEventArgs e ) {
            if ( e.Button == MouseButtons.Right ) {
                ctxMenuStrip.Show( this, this.PointToClient( MousePosition ), ToolStripDropDownDirection.Left );
            }
        }
        
        
        void ShowPropEditorToolStripMenuItemClick ( object sender, EventArgs e ) {
            _propEditor.ShowPropertyOf( this );
        }
        
        
        
        
        private PropEditor _seriesEditor = new PropEditor();
        void ShowSeriesPropsToolStripMenuItemClick ( object sender, EventArgs e ) {
            _seriesEditor.ShowPropertyOf( Series );
        }
        
        
        

        
    }
    
    
    
    
}
