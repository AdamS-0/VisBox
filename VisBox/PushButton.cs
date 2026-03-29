/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 02.05.2021
 * Time: 13:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VisBox {
	
	[DefaultEvent("StateChanged")]
	
	/// <summary>
	/// Description of PushButton.
	/// </summary>
	public partial class PushButton : VisElement {
		
		
		Color cUpZew1;
		Color cDownZew1;
		Color cUpWew1;
		Color cDownWew1;
		
		private Shape _shape = Shape.Rectangle;
		[DefaultValue(typeof(Shape), "Rectangle")]
		public Shape LayoutShape {
			get { return _shape; }
			set { _shape = value; }
		}
		
		private bool _withLight = false;
        [DefaultValue(typeof(bool), "false")]
        public bool WithLight {
            get { return _withLight; }
            set { _withLight = value; }
        }
		
		private Color _colorBtn = Color.Maroon;
		[DefaultValue(typeof(Color), "Maroon")]
		public Color ColorButton {
			get { return _colorBtn; }
			set { _colorBtn = value; }
		}
		
		
		protected override void stateChanged(){
			cUpZew1 = cUpZew;
			cDownZew1 = cDownZew;
			cUpWew1 = cUpWew;
			cDownWew1 = cDownWew;
			
			if( _state ) {
				cUpZew1 = cDownZew;
				cDownZew1 = cUpZew;
				cUpWew1 = cDownWew;
				cDownWew1 = cUpWew;	
			}
			
			OnStateChanged( EventArgs.Empty );
		}
		
		
		private PushButtonManager _pBtnManager = null;
		[DefaultValue(typeof(PushButtonManager), "null")]
		public PushButtonManager PushButtonManager {
			get { return _pBtnManager; }
			set { _pBtnManager = value; _pBtnManager.AddButton( this ); }
		}
		
		
		
		
		public PushButton() {
			InitializeComponent();
			cUpZew1 = cUpZew;
			cDownZew1 = cDownZew;
			cUpWew1 = cUpWew;
			cDownWew1 = cDownWew;
			
			if( _state ) {
				cUpZew1 = cDownZew;
				cDownZew1 = cUpZew;
				cUpWew1 = cDownWew;
				cDownWew1 = cUpWew;	
			}
		}
		
		
		private delegate void drawFunc( Brush b, Rectangle r );
		private event drawFunc DrawFunc;
		
		void PushButtonPaint(object sender, PaintEventArgs e) {
			
			Rectangle r1 = GetInnerSpace();
			Rectangle rect = r1;
			
			if( _shape == Shape.Rectangle ) {
				e.Graphics.SmoothingMode = SmoothingMode.None;
				e.Graphics.DrawRectangle( new Pen( _colorBorder, _borderWidth ), r1 );
				
				DrawFunc = e.Graphics.FillRectangle;
			} else {
				r1.Width += -1 + (int)( _borderWidth );
				r1.Height += -1 + (int)( _borderWidth );
				
				r1.X -= (int)( _borderWidth / 2 );
				r1.Y -= (int)( _borderWidth / 2 );
				
				
				e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				e.Graphics.DrawEllipse( new Pen( _colorBorder, _borderWidth ), r1 );
				
				DrawFunc = e.Graphics.FillEllipse;
			}
			
			/* Common code for any shape */
			DrawFunc( new SolidBrush( cUpZew1 ), r1 );
			
			r1.Width -= 1;
			r1.Height -= 1;
			
			DrawFunc( new SolidBrush( cDownZew1 ), r1 );
			
			r1.X += 1;
			r1.Y += 1;
			r1.Width -= 1;
			r1.Height -= 1;
			
			DrawFunc( new SolidBrush( cUpWew1 ), r1 );
			
			r1.Width -= 1;
			r1.Height -= 1;
			
			DrawFunc( new SolidBrush( cDownWew1 ), r1 );
			
			r1.X += 1;
			r1.Y += 1;
			r1.Width -= 1;
			r1.Height -= 1;
			
			if ( _withLight ) {
			    DrawFunc( new SolidBrush( _state ? _colorOn : _colorOff ), r1 );
			} else {
                DrawFunc( new SolidBrush( _colorBtn ), r1 );
			}
			
			if ( _state ) {
			    int deltaX = 2;
			    int deltaY = 2;
			    switch (_shape) {
		            case Shape.Rectangle: deltaX = 2; deltaY = 2; break;
                    case Shape.Ellipse  : deltaX = 1; deltaY = 2; break;
                    default             : deltaX = 0; deltaY = 0; break;
			    }
			    
			    r1.X += deltaX;
			    r1.Y += deltaY;
			    r1.Width -= deltaX;
			    r1.Height -= deltaY;
			}
			
			StringFormat format1 = new StringFormat();
			format1.Alignment = StringAlignment.Center;
			format1.LineAlignment = StringAlignment.Center;
			e.Graphics.DrawString( this.Text, this.Font, new SolidBrush( ForeColor ), r1, format1 );
		}
		
		void PushButtonMouseDown(object sender, MouseEventArgs e) {
			try {
				if( _pBtnManager != null ) _pBtnManager.OneElementChanged( this );
				else Toggle();
			} catch {}
		}
		
		
		
		
	}
}

