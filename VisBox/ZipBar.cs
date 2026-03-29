/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 02.05.2021
 * Time: 11:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VisBox {
	
	[DefaultEvent("ValueChanged")]
	/// <summary>
	/// Description of ZipBar.
	/// </summary>
	public partial class ZipBar : VisElement {
		
		private bool mouseDown = false;
		
		/*
		private int _minimum = 0;
		public int Minimum {
			get { return _minimum; }
			set { _minimum = value; }
		}
		
		
		private int _maximum = 100;
		public int Maximum {
			get { return _maximum; }
			set { _maximum = value; }
		}
		
		
		
		private int _value = 0;
		public int Value {
			get { return _value; }
			set {
				if( value >= _minimum && value <= _maximum ) _value = value;
				this.Invalidate();
			}
		}
		*/
		
		
		private int _parts = 10;
		public int Parts {
			get { return _parts; }
			set { _parts = value; }
		}
		
		
		private bool _fix2nerby = false;
		public bool Fix2Nerby {
			get { return _fix2nerby; }
			set { _fix2nerby = value; }
		}
		
		
		private Color _colorLine = Color.FromArgb( 255, 220, 220, 220 );
		public Color ColorLine {
			get { return _colorLine; }
			set { _colorLine = value; }
		}
		
		
		
		private Color _colorHandle = Color.DarkGray;
		public Color ColorHandle {
			get { return _colorHandle; }
			set { _colorHandle = value; }
		}
		
		
		private int _handleWid = 5, _handleWidOrg = 5;
		private int _handleHei = 8, _handleHeiOrg = 8;
		
		
		public ZipBar() {
			InitializeComponent();
			_borderWidth = 2;
		}
		
		
		
		void ZipBarPaint(object sender, PaintEventArgs e) {
			Pen p1 = new Pen( _colorLine );
			
			Rectangle rect = GetInnerSpace();
			
			if( rect.Width <= (3*_handleWid)/2 ) _handleWid = (3*rect.Width)/2;
			else _handleWid = _handleWidOrg;
			if( rect.Height <= (3*_handleHei)/2 ) _handleHei = (3*rect.Height)/2;
			else _handleHei = _handleHeiOrg;
			
			//int deltaV = _maximum - _minimum;
			
			//if( deltaV <= 0 ) deltaV = 1;
			if( _parts <= 1 ) _parts = 2;
			
			float x = 0, y = Height/2;
			float wid = Width - Padding.Left - Padding.Right - Padding2.Left -
				Padding2.Right - 2 - 2*_handleWid;
			
			if( LayoutDirection == Direction.Horizontal ) {
				e.Graphics.DrawLine( p1, 1 + Padding.Left + Padding2.Left + _handleWid, y,
					1 + Padding.Left + Padding2.Left + _handleWid + wid, y );
				
				for( int i = 0; i < _parts; i++ ) {
					x = 1 + _handleWid + Padding2.Left + Padding.Left + ( i * wid )/( _parts - 1 );
					e.Graphics.DrawLine( p1, x, y - 4, x, y + 4 );
				}
				
				x = 1 + _handleWid + Padding.Left + Padding2.Left + _value*wid;
				//e.Graphics.FillRectangle( new SolidBrush( _colorHandle ),
				//	x - handleWid, y - handleHei, 2*handleWid, 2*handleHei );
				
				DrawHandle( e,
				           new Rectangle( (int)x - _handleWid, (int)y - _handleHei, 2*_handleWid, 2*_handleHei ) );
				
			} else {
				wid = Height - Padding2.Top - Padding2.Bottom - Padding.Top -
					Padding.Bottom - 1 - 2*_handleWid;
				y = Width/2;
				
				e.Graphics.DrawLine( p1, y, Height - 1 - Padding.Bottom - Padding2.Bottom - _handleWid,
					y, Height - 1 - Padding.Bottom - Padding2.Bottom - _handleWid - wid );
				
				for( int i = 0; i < _parts; i++ ) {
					x = Height - ( 1 + _handleWid + Padding.Bottom + Padding2.Bottom + ( i * wid )/( _parts - 1 ) );
					e.Graphics.DrawLine( p1, y - 4, x, y + 4, x );
				}
				
				x = Height - ( 1 + _handleWid + Padding.Bottom + Padding2.Bottom + _value*wid );
				
				//e.Graphics.FillRectangle( new SolidBrush( _colorHandle ),
				//	y - handleHei, x - handleWid, 2*handleHei, 2*handleWid );
				
				DrawHandle( e,
					new Rectangle( (int)y - _handleHei, (int)x - _handleWid, 2*_handleHei, 2*_handleWid ) );
				
			}
			
			
		}
		
		
		private void DrawHandle( PaintEventArgs e, Rectangle r1 ) {
			e.Graphics.SmoothingMode = SmoothingMode.None;
			
			e.Graphics.FillRectangle( new SolidBrush( cUpZew ), r1 );
			
			r1.Width -= 1;
			r1.Height -= 1;
			
			e.Graphics.FillRectangle( new SolidBrush( cDownZew ), r1 );
			
			r1.X += 1;
			r1.Y += 1;
			r1.Width -= 1;
			r1.Height -= 1;
			
			e.Graphics.FillRectangle( new SolidBrush( cUpWew ), r1 );
			
			r1.Width -= 1;
			r1.Height -= 1;
			
			e.Graphics.FillRectangle( new SolidBrush( cDownWew ), r1 );
			
			r1.X += 1;
			r1.Y += 1;
			r1.Width -= 1;
			r1.Height -= 1;
			
			e.Graphics.FillRectangle( new SolidBrush( _colorHandle ), r1 );
		}
		
		
		
		
		void ZipBarMouseDown(object sender, MouseEventArgs e) { mouseDown = true; }
		
		void ZipBarMouseUp(object sender, MouseEventArgs e) { mouseDown = false; }
		
		void ZipBarMouseMove(object sender, MouseEventArgs e) {
			
			if( mouseDown ) {
				float val = 0;
				int deltaV = 1;
				int dv = 1;
				int dmv = 0; // odległosć kursora od '_minimum' w pixelach
				int wid = 1;
				
				if( LayoutDirection == Direction.Horizontal ) {
					Point pos = PointToClient( Cursor.Position );
					wid = Width - Padding.Left - Padding.Right -
						Padding2.Left - Padding2.Right - 2 - 2*_handleWid;
					
					dmv = ( pos.X - Padding.Left - Padding2.Left - _handleWid );
				} else {
					Point pos = PointToClient( Cursor.Position );
					
					int x = Width/2;
					wid = Height - Padding.Top - Padding.Bottom -
						Padding2.Top - Padding2.Bottom - 2 - 2*_handleWid;
					
					dmv = ( Height - pos.Y - Padding.Bottom - Padding2.Bottom - _handleWid );
				}
				
				dv = wid/( _parts - 1 ); // szerokosć przedziału, w pixlach
				
				val = (float)( dmv * deltaV ) / wid;
				
				if( _fix2nerby ) {
					val = dmv/dv;
					dmv = (int)( ( dmv + dv/2 - val )/dv)*dv;
					val = dmv/dv;
					
					val = ( val * deltaV )/( _parts - 1 );
				}
				
				if ( val < 0) val = 0;
				else if (val > 1) val = 1;
				
				Value = val;
				
				OnValueChanged( EventArgs.Empty );
			}
		}
		
		
		
		
	}
}





/*
void ZipBarPaint(object sender, PaintEventArgs e) {
			Pen p1 = new Pen( _colorLine );
			
			Rectangle rect = GetInnerSpace();
			
			if( rect.Width <= (3*_handleWid)/2 ) _handleWid = (3*rect.Width)/2;
			else _handleWid = _handleWidOrg;
			if( rect.Height <= (3*_handleHei)/2 ) _handleHei = (3*rect.Height)/2;
			else _handleHei = _handleHeiOrg;
			
			//int deltaV = _maximum - _minimum;
			float deltaV = 1;
			
			if( deltaV <= 0 ) deltaV = 1;
			if( _parts <= 1 ) _parts = 2;
			
			int x = 0, y = Height/2;
			int wid = Width - Padding.Left - Padding.Right - Padding2.Left -
				Padding2.Right - 2 - 2*_handleWid;
			
			if( LayoutDirection == Direction.Horizontal ) {
				e.Graphics.DrawLine( p1, 1 + Padding.Left + Padding2.Left + _handleWid, y,
					1 + Padding.Left + Padding2.Left + _handleWid + wid, y );
				
				for( int i = 0; i < _parts; i++ ) {
					x = 1 + _handleWid + Padding2.Left + Padding.Left + ( i * wid )/( _parts - 1 );
					e.Graphics.DrawLine( p1, x, y - 4, x, y + 4 );
				}
				
				x = 1 + _handleWid + Padding.Left + Padding2.Left + ( ( _value - _minimum ) * wid )/( deltaV );
				//e.Graphics.FillRectangle( new SolidBrush( _colorHandle ),
				//	x - handleWid, y - handleHei, 2*handleWid, 2*handleHei );
				
				DrawHandle( e,
					new Rectangle( x - _handleWid, y - _handleHei, 2*_handleWid, 2*_handleHei ) );
				
			} else {
				wid = Height - Padding2.Top - Padding2.Bottom - Padding.Top -
					Padding.Bottom - 1 - 2*_handleWid;
				y = Width/2;
				
				e.Graphics.DrawLine( p1, y, Height - 1 - Padding.Bottom - Padding2.Bottom - _handleWid,
					y, Height - 1 - Padding.Bottom - Padding2.Bottom - _handleWid - wid );
				
				for( int i = 0; i < _parts; i++ ) {
					x = Height - ( 1 + _handleWid + Padding.Bottom + Padding2.Bottom + ( i * wid )/( _parts - 1 ) );
					e.Graphics.DrawLine( p1, y - 4, x, y + 4, x );
				}
				
				x = Height - ( 1 + _handleWid + Padding.Bottom + Padding2.Bottom + ( ( _value - _minimum ) * wid )/( deltaV ) );
				
				//e.Graphics.FillRectangle( new SolidBrush( _colorHandle ),
				//	y - handleHei, x - handleWid, 2*handleHei, 2*handleWid );
				
				DrawHandle( e,
					new Rectangle( y - _handleHei, x - _handleWid, 2*_handleHei, 2*_handleWid ) );
				
			}
			
			
		}
		*/



/*
void ZipBarMouseMove(object sender, MouseEventArgs e) {
			
			if( mouseDown ) {
				int val = 0;
				int deltaV = _maximum - _minimum;
				int dv = 1;
				int dmv = 0; // odległosć kursora od '_minimum' w pixelach
				int wid = 1;
				
				if( LayoutDirection == Direction.Horizontal ) {
					Point pos = PointToClient( Cursor.Position );
					wid = Width - Padding.Left - Padding.Right -
						Padding2.Left - Padding2.Right - 2 - 2*_handleWid;
					
					dmv = ( pos.X - Padding.Left - Padding2.Left - _handleWid );
				} else {
					Point pos = PointToClient( Cursor.Position );
					
					int x = Width/2;
					wid = Height - Padding.Top - Padding.Bottom -
						Padding2.Top - Padding2.Bottom - 2 - 2*_handleWid;
					
					dmv = ( Height - pos.Y - Padding.Bottom - Padding2.Bottom - _handleWid );
				}
				
				dv = wid/( _parts - 1 ); // szerokosć przedziału, w pixlach
				
				val = ( dmv * deltaV + _parts ) / wid + _minimum;
				
				if( _fix2nerby ) {
					val = dmv/dv;
					dmv = ( ( dmv + dv/2 - val )/dv)*dv;
					val = dmv/dv;
					
					val = ( val * deltaV )/( _parts - 1 ) + _minimum;
				}
				
				Value = val;
				
				OnValueChanged( EventArgs.Empty );
			}
		}
		*/