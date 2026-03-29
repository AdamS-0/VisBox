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
	
    public struct AxisLimits {
        public float Min;
        public float Max;
        public float Margin;
        public bool Use;
    }
    
    
	public partial class Plot : VisElement {
		public Grid gridX = new Grid();
		public Grid gridY = new Grid();
        public Grid gridXminor = new Grid();
        public Grid gridYminor = new Grid();
        
        float _drawScaleX = 1;
		float _drawScaleY = 1;
        float _drawDeltaX = 1;
        float _drawDeltaY = 1;
        Rectangle canvas;
		Bitmap bmp;
		
		public List<Series> Series = new List<Series>();
		
        public AxisLimits AxisLimitsX;
        public AxisLimits AxisLimitsY;
        
        
		public Plot() {
			InitializeComponent();
			
			Init();
		}
		
		
		void PlotResize(object sender, EventArgs e) {
			Init();
		}
		
		
		private void UpdateCanvasSize() {
		    canvas = GetInnerSpace2Draw();
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
            if( !AxisLimitsX.Use ) {
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
                if( AxisLimitsX.Min == AxisLimitsX.Max ) {
                    AxisLimitsX.Min -= 0.1f;
                    AxisLimitsX.Max += 0.1f;
                }
                
                if( AxisLimitsX.Margin != 0 ) {
                    float delta = AxisLimitsX.Max - AxisLimitsX.Min;
                    AxisLimitsX.Max += delta*AxisLimitsX.Margin/2;
                    AxisLimitsX.Min -= delta*AxisLimitsX.Margin/2;;
                }
            }
            
            if( !AxisLimitsY.Use ) {
                if(Series.Count > 0) {
                    if( Series[0].dataY.Count > 0 ) {
                        AxisLimitsY.Min = Series[0].dataY[0];
                        AxisLimitsY.Max = AxisLimitsY.Min;
                    }
                    gridX.Dots.Clear();
                    gridY.Dots.Clear();
                    
                    gridXminor.Dots.Clear();
                    gridYminor.Dots.Clear();
                }
                foreach( Series ser in Series ) {
                    for( int i = 0; i < ser.dataX.Count; i++ ) {
                        if( ser.dataY[i] < AxisLimitsY.Min ) { AxisLimitsY.Min = ser.dataY[i]; }
                        if( ser.dataY[i] > AxisLimitsY.Max ) { AxisLimitsY.Max = ser.dataY[i]; }
                    }
                }
                if( AxisLimitsY.Min == AxisLimitsY.Max ) {
                    AxisLimitsY.Min -= 0.1f;
                    AxisLimitsY.Max += 0.1f;
                }
                
                if( AxisLimitsY.Margin != 0 ) {
                    float delta = AxisLimitsY.Max - AxisLimitsY.Min;
                    AxisLimitsY.Max += delta*AxisLimitsY.Margin/2;
                    AxisLimitsY.Min -= delta*AxisLimitsY.Margin/2;;
                }
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
                
                ser.DrawSeries(ref gr, _drawScaleX, _drawScaleY, AxisLimitsX.Min, AxisLimitsY.Min, canvas.Height);
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
        }
        
        
        public void DrawGridY(ref Graphics gr) {
            float drawY = 0;
            float drawX = 0;
            
            if( !gridY.GridOn ) { return; }
            if(gridY.Dots == null) { return; }
            
            if( gridY.Dots.Count == 0 ) { gridY.ReCalculateGrid(AxisLimitsY.Min, AxisLimitsY.Max); }
            
            if( gridYminor.GridOn ) {
                if( gridYminor.Dots.Count == 0 ) {
                    gridYminor.ReCalculateGrid(AxisLimitsY.Min, AxisLimitsY.Max, gridYminor.ScaleFactor);
                }
            }
            
            drawX = AxisLimitsX.Min * _drawScaleX;
            
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
		
		
		void PlotPaint(object sender, PaintEventArgs e) {
		    Rectangle inner = GetInnerSpace();
			e.Graphics.DrawImage( bmp, inner.X, inner.Y );
		}
		
		

		
	}
    
    public class GridDot {
        public float Value { get; set; }
        public string Name { get; set; }
        
        public GridDot(float value, string name = "") {
            this.Name = name;
            this.Value = value;
        }
    }
    
    public class Grid {
        public bool GridOn = false;
        public bool ShowLables = true;
        public float ScaleFactor = 1.0f;
        
        public Brush LabelBrush = new SolidBrush(Color.Red);
        
        protected string _format = "";
        public string Format {
            get { return _format; }
            set { _format = value; }
        }
        
        protected Pen _pen = new Pen(Color.Black);
        public Pen Pen {
            get { return _pen; }
            set { _pen = value; }
        }
        
        protected List<GridDot> _dots = new List<GridDot>();
        public List<GridDot> Dots { 
            get { return _dots; }
            set { _dots = value; }
        }
        
        public Grid(bool gridOn = false) {
            this.GridOn = gridOn;
        }
        
        public Grid(List<GridDot> dots, bool gridOn = false) {
            this.GridOn = gridOn;
            this.Dots = dots;
        }
        
        /// <summary>
        /// Create Grid object for given limits
        /// </summary>
        /// <param name="gridMin"></param>
        /// <param name="gridMax"></param>
        /// <param name="usersFormat"></param>
        /// <param name="gridOn"></param>
        public Grid(float gridMin, float gridMax, string usersFormat = "", bool gridOn = false) {
            this.GridOn = gridOn;
            this.Format = usersFormat;
            ReCalculateGrid(gridMin, gridMax);
        }
        
        
        /// <summary>
        /// Recalculate grid dots for given conditions
        /// </summary>
        /// <param name="gridMin"></param>
        /// <param name="gridMax"></param>
        public void ReCalculateGrid(float gridMin, float gridMax, float userScale = 1.0f) {
            if( Dots != null ) { Dots.Clear(); }
            
            if( gridMin > gridMax ) {
                float swapMem = gridMin;
                gridMin = gridMax;
                gridMax = swapMem;
            }
            
            Dots = GetGridFromLimits(gridMin, gridMax, this.Format, userScale);
        }
        
        
        /// <summary>
        /// Calculate grid for given limits without creating new instance of an Grid objct
        /// </summary>
        /// <param name="axisMin"></param>
        /// <param name="axisMax"></param>
        /// <param name="usersFormat"></param>
        /// <returns></returns>
        public static List<GridDot> GetGridFromLimits(float axisMin, float axisMax, string usersFormat = "", float userScale = 1.0f) {
            List<GridDot> gridDots = new List<GridDot>();
            string gridDotNameFormat = "";
            float gridWidth = 1;
            float gridScale = 1;
            int gridNum = 0;
            
            if( axisMin == axisMax ) {
                axisMin -= 0.1f;
                axisMax += 0.1f;
            }
            
            float deltaAxis = axisMax - axisMin;
            
            if( usersFormat.Length == 0 ) {
                gridDotNameFormat = deltaAxis > 99999.0f || deltaAxis < 0.001 ? "0.###E-0" : "";
            } else {
                gridDotNameFormat = usersFormat;
            }
            
            gridWidth = deltaAxis;
            gridScale = 1;
            
            // Calculate grid scale
            while( gridWidth < 1 )  { gridWidth *= 10.0f; gridScale *= 0.1f; }
            while( gridWidth > 1 )  { gridWidth *=  0.1f; gridScale *= 10.0f; }
            gridScale *= 0.1f;
            
            gridNum = (int)(deltaAxis / gridScale);
            
            if      ( gridNum > 11 ) { gridScale *= 5; }
            else if ( gridNum > 6 ) { gridScale *= 2; }
            else if ( gridNum < 2 ) { gridScale *= 0.2f; }
            else if ( gridNum < 4 ) { gridScale *= 0.5f; }
            
            gridScale *= userScale;
            
            // Calculatee next grid points
            float fGridDot = (int)(axisMin / gridScale)*gridScale;
            while( fGridDot <= axisMax ) {
                gridDots.Add( new GridDot(fGridDot, fGridDot.ToString(gridDotNameFormat)) );
                fGridDot += gridScale;
            }
            
            return gridDots;
        }
    }
    
    
    
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
    
    
    public class Series {
        public List<float> dataX = new List<float>();
        public List<float> dataY = new List<float>();
        public Marker Marker { get; set; }
        public Pen Pen { get; set; }
        public string Name { get; set; }
        
        public Series() {
            
        }
        
        public Series(ref List<float> dataX, ref List<float> dataY) {
            if (dataX == null) throw new ArgumentNullException("dataX");
            if (dataY == null) throw new ArgumentNullException("dataY");
            this.dataX = dataX;
            this.dataY = dataY;
            
        }
        
        public Series(ref List<float> dataX, ref List<float> dataY, Marker marker, Pen pen, string name = "") {
            if (dataX == null) throw new ArgumentNullException("dataX");
            if (dataY == null) throw new ArgumentNullException("dataY");
            if (marker == null) throw new ArgumentNullException("marker");
            if (pen == null) throw new ArgumentNullException("pen");
            this.dataX = dataX;
            this.dataY = dataY;
            this.Marker = marker;
            this.Pen = pen;
            this.Name = name;
            
        }
        
        public void DrawSeries(ref Graphics gr, float scaleX, float scaleY, float axMin, float ayMin, float canvHeightPx) {
            float drawX = 0, drawY = 0;
            
            if( dataX.Count != dataY.Count ) {
                throw new Exception("Length of two vectors are not equal!");
            }
            
            drawX = ((float)dataX[0] - axMin) * scaleX;
            drawY = canvHeightPx - (dataY[0] - ayMin) * scaleY;
            PointF pL = new PointF( drawX, drawY );
            
            // Draw series
            for( int idx = 0; idx < dataX.Count; idx++ ) {
                drawX = (dataX[idx] - axMin) * scaleX;
                drawY = canvHeightPx - (dataY[idx] - ayMin) * scaleY;
                
                gr.DrawLine( Pen, pL.X, pL.Y, drawX, drawY );
                
                pL.X = (float)drawX;
                pL.Y = (float)drawY;
            }
        }
        
        public void DrawMarkers(ref Graphics gr, float scaleX, float scaleY, float axMin, float ayMin, float canvHeightPx) {
            if( Marker.Symbol == ' ' ) { return; }
            
            if( dataX.Count != dataY.Count ) {
                throw new Exception("Length of two vectors are not equal!");
            }
            
            Brush markerBrush = new SolidBrush(Marker.Color);
            Font markerFont = new Font("Arial", 10);
            float drawX = 0, drawY = 0;
            
            StringFormat markerFormat = new StringFormat();
            markerFormat.LineAlignment = StringAlignment.Center;
            markerFormat.Alignment = StringAlignment.Center;
            
            // Draw markers
            for( int i = 0; i < dataX.Count; i++ ) {
                drawX = (dataX[i] - axMin) * scaleX;
                drawY = canvHeightPx - (dataY[i] - ayMin) * scaleY;
                gr.DrawString(Marker.Symbol.ToString(), markerFont, markerBrush, drawX, drawY, markerFormat);
            } 
        }
    }
    
}
