/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 15.05.2021
 * Time: 15:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VisBox {

	public partial class Switch : VisElement {
		
		private Color[] _ColorStateOne = { Color.FromArgb(0, 100, 0), Color.FromArgb(0, 255, 0) };
		private Color[] _ColorStateZero = { Color.FromArgb(255, 0, 0), Color.FromArgb(127, 0, 0) };
		
		
		private PointF[] _partFull = {
			new PointF( -.45f, 0 ), new PointF( .45f, 0 ),
			new PointF( .45f, .45f ), new PointF( -.45f, .45f )
		};
		
		
		private PointF[] _partUp = {
			new PointF( -.45f, 0 ), new PointF( .45f, 0 ),
			new PointF( .35f, .4f ), new PointF( -.35f, .4f )
		};
		
		
		
		private PointF[] _partDark = {
			new PointF( -.5f, .5f ), new PointF( -.35f, .4f ),
			new PointF( .35f, -.4f ), new PointF( .5f, -.5f ),
			new PointF( .5f, .5f )
		};
		
		private PointF[] _whiteLine = { new PointF( -.5f, -.5f ), new PointF( -.35f, -.4f ) };
		
		
		
		
		
		
		
		public Switch() {
			InitializeComponent();
			
		}
		
		
		
		void SwitchMouseDown(object sender, MouseEventArgs e) {
			bool downClick = false;
			Rectangle rect = GetInnerSpace();
			if( 2*(e.Location.Y) > 2*rect.Y + rect.Height ) downClick = true;
			
			if( _state == downClick ) Toggle();
			
		}
		
		
		
		
		
		
		void SwitchPaint(object sender, PaintEventArgs e) {
			
			Rectangle rect = GetInnerSpace();
			
			PointF relCenter = new PointF( rect.X + rect.Width/2, rect.Y + rect.Height/2 );
			
			PointF[] _pointsUpBase = new PointF[4];
			PointF[] _pointsDownBase = new PointF[4];
			
			PointF[] _pointsUp = new PointF[4];
			PointF[] _pointsDown = new PointF[4];
			
			PointF[] darkPart = new PointF[5];
			PointF[] whiteLine = new PointF[2];
			
			
			if( _state ) {
				
				for( int i = 0; i < _partFull.Length; i++ ) {
					_pointsUpBase[i] = _partFull[i];
					_pointsDownBase[i] = _partUp[i];
					
					_pointsUpBase[i].Y *= -1;
				}
				
			} else {
				
				for( int i = 0; i < _partFull.Length; i++ ) {
					_pointsUpBase[i] = _partUp[i];
					_pointsDownBase[i] = _partFull[i];
					
					_pointsUpBase[i].Y *= -1;
				}
				
			}
			
			
			for( int i = 0; i < _pointsUpBase.Length; i++ ) {
				_pointsUp[i].X = relCenter.X + _pointsUpBase[i].X*rect.Width;
				_pointsUp[i].Y = relCenter.Y + _pointsUpBase[i].Y*rect.Height;
				
				_pointsDown[i].X = relCenter.X + _pointsDownBase[i].X*rect.Width;
				_pointsDown[i].Y = relCenter.Y + _pointsDownBase[i].Y*rect.Height;
			}
			
			
			
			for( int i = 0; i < darkPart.Length; i++ ){
				darkPart[i] = new PointF( _partDark[i].X, _partDark[i].Y );
				
				darkPart[i].X = relCenter.X + darkPart[i].X*rect.Width;
				darkPart[i].Y = relCenter.Y + darkPart[i].Y*rect.Height;
				
			}
			
			for( int i = 0; i < _whiteLine.Length; i++ ) {
				whiteLine[i] = new PointF( _whiteLine[i].X, _whiteLine[i].Y );
				whiteLine[i].X = relCenter.X + whiteLine[i].X*rect.Width;
				whiteLine[i].Y = relCenter.Y + whiteLine[i].Y*rect.Height;
			}
			
			e.Graphics.FillRectangle( new SolidBrush( Color.FromArgb( 192, 192, 192 ) ), rect );
			e.Graphics.FillPolygon( new SolidBrush( Color.FromArgb( 128, 128, 128 ) ), darkPart);
			e.Graphics.DrawLine( new Pen( Color.White ), whiteLine[0], whiteLine[1] );
			
			e.Graphics.FillPolygon( new SolidBrush( _ColorStateOne[ _state ? 1 : 0 ] ), _pointsUp );
			e.Graphics.FillPolygon( new SolidBrush( _ColorStateZero[ _state ? 1 : 0 ] ), _pointsDown );
		}
		
		
		
		
	}
}
