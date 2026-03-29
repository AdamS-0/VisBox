/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 09.05.2021
 * Time: 20:28
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VisBox {
    /// <summary>
    /// Description of AnalogMeter.
    /// </summary>
    public partial class AnalogMeter : VisElement {
		
		
		
        private int _parts = 10;
        public int Parts {
            get { return _parts; }
            set { _parts = value; }
        }
		
		
        private Color _colorLine = Color.FromArgb( 255, 150, 150, 150 );
        public Color ColorLine {
            get { return _colorLine; }
            set { _colorLine = value; }
        }
		
		
        private Color _colorArrow = Color.FromArgb( 255, 20, 20, 255 );
        public Color ColorArrow {
            get { return _colorArrow; }
            set { _colorArrow = value; }
        }
		
		
        private Shape _shape = Shape.Rectangle;
        [DefaultValue( typeof(Shape), "Rectangle")]
        public Shape LayoutShape {
            get { return _shape; }
            set { _shape = value; }
        }
		
		
		
		
		
        public AnalogMeter() {
			
            InitializeComponent();
        }
		
		
		
        void AnalogMeterPaint ( object sender, PaintEventArgs e ) {
            Rectangle r1 = GetInnerSpace();
			
            r1.Height -= 4;
			
            float R = r1.Height - 3;
            float R2 = (float)r1.Height / 20;
            float x1, y1, x2, y2;
            float angleStart = -170, angleLen = 160, angle = 0;
            float a = (float)r1.Width / ( 2 * R );
            float dr = 0.8f, dra = 0.95f;
			
            PointF relCenter = new PointF(r1.X + (float)r1.Width / 2, r1.Y + (float)r1.Height);
			
//			e.Graphics.DrawArc( new Pen( _colorLine ), r1.X, r1.Y, r1.Width, 2*r1.Height,
//				angleStart, angleLen );
			
			
            for ( int i = 0; i < _parts; i++ ) {
                angle = ( (float)angleLen * i ) / ( _parts - 1 );
				
                x1 = a * R * (float)Math.Cos( ( Math.PI * ( angleStart + angle ) ) / 180 );
                x2 = dr * x1;
				
                y1 = R * (float)Math.Sin( ( Math.PI * ( angleStart + angle ) ) / 180 );
                y2 = dr * y1;
				
                x1 += relCenter.X;
                x2 += relCenter.X;
                y1 = relCenter.Y + y1;
                y2 = relCenter.Y + y2;
				
				
                e.Graphics.DrawLine( new Pen(_colorLine), x1, y1, x2, y2 );
            }
			
            //float val = (_value - _minimum)/( _maximum - _minimum );
            float val = _value;
			
            x1 = (float)Math.Cos( ( Math.PI * ( angleStart + val * angleLen ) ) / 180 );
            y1 = (float)Math.Sin( ( Math.PI * ( angleStart + val * angleLen ) ) / 180 );
			
            x2 = (float)Math.Cos( ( Math.PI * ( angleStart + val * angleLen + 90 ) ) / 180 );
            y2 = (float)Math.Sin( ( Math.PI * ( angleStart + val * angleLen + 90 ) ) / 180 );
			
			
            PointF[] arrow = new PointF[]
            {
                new PointF(a * dra * R * x1, dra * R * y1), new PointF(R2 * x2, R2 * y2), new PointF(-R2 * x2, -R2 * y2)
            };
			
            for ( int i = 0; i < arrow.Length; i++ ) {
                arrow [ i ].X += relCenter.X;
                arrow [ i ].Y += relCenter.Y;
            }
			
            e.Graphics.FillPolygon( new SolidBrush(_colorArrow), arrow );
			
        }
		
		
		
    }
}




