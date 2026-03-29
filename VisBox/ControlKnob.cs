/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 18.05.2021
 * Time: 11:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VisBox {
	
	public partial class ControlKnob : VisElement {
		
		private bool mouseDown = false;
		Color cUpZew1;
		Color cDownZew1;
		Color cUpWew1;
		Color cDownWew1;
		
		
		
		private float _increment = 0.05f;
		[DefaultValue(typeof(float), "0.05")]
		public float Incrementer {
			get { return _increment; }
			set { _increment = value; }
		}
		
		
		/*
		private float _value = 0.0f;
		[DefaultValue(typeof(float), "0")]
		public float Value {
			get { return _value; }
			set {
				_value = value % (_maximum - _minimum);
				if( _value < _minimum ) _value += (_maximum - _minimum);
				else if( _value > _maximum ) _value -= (_maximum - _minimum);
				this.Invalidate();
			}
		}
		
		
		private float _minimum = 0;
		[DefaultValue(typeof(float), "0")]
		public float Minimum {
			get { return _minimum; }
			set {
				_minimum = value;
				this.Invalidate();
			}
		}
		
		private float _maximum = 100;
		[DefaultValue(typeof(float), "100")]
		public float Maximum {
			get { return _maximum; }
			set {
				_maximum = value;
				this.Invalidate();
			}
		}
		*/
		
		private Color _colorPointer = Color.Blue;
		[DefaultValue(typeof(Color), "Blue")]
		public Color ColorPointer{
			get { return _colorPointer; }
			set { _colorPointer = value; }
		}
		
		
		
		public ControlKnob() {
			InitializeComponent();
			
			this.MouseWheel += MouseWheelHandler;
			
			cUpZew1 = cUpZew;
			cDownZew1 = cDownZew;
			cUpWew1 = cUpWew;
			cDownWew1 = cDownWew;
		}
		
		
		
		
		
		
		
		void ControlKnobPaint(object sender, PaintEventArgs e) {
			Rectangle r1 = GetInnerSpace();
			
			r1.Width += -1 + (int)( _borderWidth );
			r1.Height += -1 + (int)( _borderWidth );
			
			r1.X -= (int)( _borderWidth / 2 );
			r1.Y -= (int)( _borderWidth / 2 );
			
			
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.DrawEllipse( new Pen( _colorBorder, _borderWidth ), r1 );
			
			// wspólny kod
			e.Graphics.FillEllipse( new SolidBrush( cUpZew1 ), r1 );
			
			r1.Width -= 1;
			r1.Height -= 1;
			
			e.Graphics.FillEllipse( new SolidBrush( cDownZew1 ), r1 );
			
			r1.X += 1;
			r1.Y += 1;
			r1.Width -= 1;
			r1.Height -= 1;
			
			e.Graphics.FillEllipse( new SolidBrush( cUpWew1 ), r1 );
			
			r1.Width -= 1;
			r1.Height -= 1;
			
			e.Graphics.FillEllipse( new SolidBrush( cDownWew1 ), r1 );
			
			r1.X += 1;
			r1.Y += 1;
			r1.Width -= 1;
			r1.Height -= 1;
			
			e.Graphics.FillEllipse( new SolidBrush( BackColor ), r1 );
			
			
			
			PointF relCenter = new PointF( r1.X + r1.Width/2, r1.Y + r1.Height/2 );
			PointF Radius = new PointF(0, 0);
			PointF radius = new PointF(0, 0);
			
			float R = r1.Height/2;
			float a = (float)r1.Width/( 2*R );
			float dr = 0.5f;
			
			float angle = _value*2*(float)Math.PI;
			
			
			Radius.X = a*R*(float)Math.Cos( angle );
			radius.X = dr*Radius.X;
			
			Radius.Y = R*(float)Math.Sin( angle );
			radius.Y = dr*Radius.Y;
			
			Radius.X += relCenter.X;				radius.X += relCenter.X;
			Radius.Y = relCenter.Y + Radius.Y;		radius.Y = relCenter.Y + radius.Y;
			
			e.Graphics.DrawLine( new Pen( _colorPointer ), radius, Radius );
		}
		
		private void MouseWheelHandler(object sender, System.Windows.Forms.MouseEventArgs e) {
			if (e.Delta > 0) Value += _increment;
			if (e.Delta < 0) Value -= _increment;
		}
		
		
		
		
		
		void ZipBarMouseDown(object sender, MouseEventArgs e) { mouseDown = true; }
		
		void ZipBarMouseUp(object sender, MouseEventArgs e) { mouseDown = false; }
		
		void ControlKnobMouseMove(object sender, MouseEventArgs e) {
			
			if( mouseDown ) {
				Rectangle r1 = GetInnerSpace();
				
				r1.Width -= 4;
				r1.Height -= 4;
				
				r1.X += 2;
				r1.Y += 2;
				
				PointF relCenter = new PointF( r1.X + r1.Width/2, r1.Y + r1.Height/2 );
				
				PointF relMouse = new PointF( e.X - relCenter.X, e.Y - relCenter.Y );
				
				float angle = (float)Math.Atan2( relMouse.Y, relMouse.X ) + (float)Math.PI;
				angle = angle/(2*(float)Math.PI) + 0.5f;
				
				Value = angle;
				
			}
			
		}
		
		
	}
}
