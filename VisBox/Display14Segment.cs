/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 07.05.2021
 * Time: 15:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VisBox {
	
	public partial class Display14Segment : DisplaySegment {
		
		
		public override string Segments {
			get { return _segments; }
			set {
				_segments = value;
				if( _segments.Length == 8 ) _segments += "0" + _segments[6];
				while( _segments.Length < 15 ) _segments += "0";
				Invalidate();
			}
		}
		
		// ----A----
		// |\  |  /|
		// F L H M B
		// |  \|/  |
		//  -G- -I-
		// |  /|\  |
		// E K J N C
		// |/  |  \|
		// ----D----
		
		// , " :000000000000000"
		// dot, A, B, C, D, E, F, G, H, I, J, K, L, M, N 
		protected string[] _chars14 = {
			" :000000000000000", "0:011111100001010", "1:001100000000010",
			"2:011010000101000", "3:011110000100000", "4:001100110100000", // 2:11011010100000
			"5:010110000100100", "6:010111110100000", "7:010000000010010", // 5:10110110100000 7:011100000000000
			"8:011111110100000", "9:011110110100000", "a:011101110100000",
			"b:011110001110000", "c:010011100000000", "d:011110001010000",
			"e:010011110000000", "f:010001110000000", "g:010111100100000",
			"h:001101110100000", "i:010010001010000", "j:001111000000000",
			"k:000001110000011", "l:000011100000000", "m:001101100000110",
			"n:001101100000101", "o:011111100000000", "p:011001110100000",
			"q:011111100000001", "r:011001110100001", "s:010110110100000",
			"t:010000001010000", "u:001111100000000", "v:000001100001010",
			"w:001101100001001", "x:000000000001111", "y:000000000010110",
			"z:010010000001010", "/:000000000001010", "\\:000000000000101",
			"|:000000001010000", "-:000000010100000", "+:000000011110000"
			
		};
		
		protected PointF[] _segHorDiv2Org;
		
		
		protected PointF[] _segDiagonalOrg = {
			new PointF( -4f, -11f ), new PointF( -4f, -7f ),
			new PointF( 4f, 11f ), new PointF( 4f, 7f )
		};
		
		
		public Display14Segment() {
			InitializeComponent();
			
			_colorOn = Color.FromArgb( 128, 254, 2 );
			
			// A, B, C, D, E, F, G, H, I, J, K, L, M, N
			_segments = "000000000000000";
			
			_segWidDiv2 = 9; // 7;
			_segHeiDiv2 = 2; //1.5f;
			
			float _segWidDiv2_2 = 0.7f*_segWidDiv2;
			float _segHeiDiv2_2 = 0.85f*_segHeiDiv2;
			
			_segHorOrg = new PointF[]{
				new PointF( -_segWidDiv2_2, _segHeiDiv2_2 ),
				new PointF( _segWidDiv2_2, _segHeiDiv2_2 ),
				new PointF( _segWidDiv2_2 + _segHeiDiv2_2, 0 ),
				new PointF( _segWidDiv2_2, -_segHeiDiv2_2 ),
				new PointF( -_segWidDiv2_2, -_segHeiDiv2_2 ),
				new PointF( -_segWidDiv2_2 - _segHeiDiv2_2, 0 )
			};
			
			
			_segHorDiv2Org = new PointF[]{
				new PointF( -_segWidDiv2_2/2, _segHeiDiv2_2 ),
				new PointF( _segWidDiv2_2/2, _segHeiDiv2_2 ),
				new PointF( _segWidDiv2_2/2 + _segHeiDiv2_2/2, 0 ),
				new PointF( _segWidDiv2_2/2, -_segHeiDiv2_2 ),
				new PointF( -_segWidDiv2_2/2, -_segHeiDiv2_2 ),
				new PointF( -_segWidDiv2_2/2 - _segHeiDiv2_2/2, 0 )
			};
			
			_segDiagonalOrg = new PointF[]{
				new PointF( -0.6f*_segWidDiv2_2/2, -1f*_segWidDiv2_2 ),
				new PointF( -0.8f*_segWidDiv2_2/2, -1f*_segWidDiv2_2 ),
				new PointF( -0.8f*_segWidDiv2_2/2, -0.5f*_segWidDiv2_2 ),
				new PointF( 0.6f*_segWidDiv2_2/2, 1f*_segWidDiv2_2 ),
				new PointF( 0.8f*_segWidDiv2_2/2, 1f*_segWidDiv2_2 ),
				new PointF( 0.8f*_segWidDiv2_2/2, 0.5f*_segWidDiv2_2 )
			};
			
			
			_chars = _chars14;
		}
		
		
		
		
		
		
		public override void ShowChar( char c, bool showDotNow = false ) {
			string code = _segments, codei;
			
			
			if( _lastChar != c ) {
				for( int i = 0; i < _chars.Length; i++ ) {
					codei = _chars[i];
					if( codei.StartsWith( c.ToString().ToLower() ) ) {
						code = codei.Substring( 2 );
						break;
					}
				}
				
				if( code.Length == 8 ) code += "0" + code[7];
				
			}
			
			if( lastDot != showDotNow ) {
				char [] codeA = code.ToCharArray();
				codeA[0] = showDotNow ? '1' : '0';
				
				code = new string( codeA );
			}
			
			if( _lastChar != c || lastDot != showDotNow ) {
				while( code.Length < 15 ) code += "0";
				
				Segments = code;
				_lastChar = c;
			}
		}
		
		
		
		
		
		
		
//		bool GetOneSeg( char c ) {
//			return c == '0' ? false : true;
//		}
		
		protected override void OnPaint( PaintEventArgs e ) {
			base.OnPaint( e );
			try {
				SegmentDisplayPaint( this, e );
			} catch {}
		}
		
		
		
		
		
		// ----A----
		// |\  |  /|
		// F L H M B
		// |  \|/  |
		//  -G- -I-
		// |  /|\  |
		// E K J N C
		// |/  |  \|
		// ----D----
		void SegmentDisplayPaint(object sender, PaintEventArgs e) {
			Rectangle rect = GetInnerSpace();
			
			_center = new Point( rect.X + rect.Width/2, rect.Y + rect.Height/2 );
			
			// G
			DrawHorizontalDiv2Segment( e.Graphics, GetOneSeg( _segments[7] ), -_scale*_segWidDiv2/2, 0 );
			
			// H
			DrawVerticalSegment( e.Graphics, GetOneSeg( _segments[8] ), 0, -_scale*_segWidDiv2 );
			
			// I
			DrawHorizontalDiv2Segment( e.Graphics, GetOneSeg( _segments[9] ), _scale*_segWidDiv2/2, 0 );
			
			// J
			DrawVerticalSegment( e.Graphics, GetOneSeg( _segments[10] ), 0, _scale*_segWidDiv2 - 1 );
			
			// K
			DrawDiagonalSegment( e.Graphics, GetOneSeg( _segments[11] ), -_scale*_segWidDiv2/2, _scale*_segWidDiv2, -1 );
			
			// M
			DrawDiagonalSegment( e.Graphics, GetOneSeg( _segments[13] ), _scale*_segWidDiv2/2, -_scale*_segWidDiv2, -1 );
			
			
			// L
			DrawDiagonalSegment( e.Graphics, GetOneSeg( _segments[12] ), -_scale*_segWidDiv2/2, -_scale*_segWidDiv2 );
			
			// N
			DrawDiagonalSegment( e.Graphics, GetOneSeg( _segments[14] ), _scale*_segWidDiv2/2, _scale*_segWidDiv2 );
			
			
			
			
//			// | L
//			DrawVerticalSegment( e.Graphics, GetOneSeg( _segments[5] ), -_scale*_segWidDiv2, -_scale*_segWidDiv2 );
//			DrawVerticalSegment( e.Graphics, GetOneSeg( _segments[4] ), -_scale*_segWidDiv2, _scale*_segWidDiv2 );
//			
//			// | R
//			DrawVerticalSegment( e.Graphics, GetOneSeg( _segments[1] ), _scale*_segWidDiv2, -_scale*_segWidDiv2 );
//			DrawVerticalSegment( e.Graphics, GetOneSeg( _segments[2] ), _scale*_segWidDiv2, _scale*_segWidDiv2 );
//			//e.Graphics.FillRectangle( new SolidBrush( Color.Red ), 10, 10, 100, 100 );
		}
		
		
		private void DrawHorizontalDiv2Segment( Graphics graph, bool segState, float x, float y ) {
			DrawHorizontalDiv2Segment( graph, segState, (int)x, (int)y );
		}
		private void DrawHorizontalDiv2Segment( Graphics graph, bool segState, int x, int y ) {
			
			Point relCent = new Point( _center.X + x, _center.Y + y );
			
			PointF[] _segHorPoints = new PointF[6];
			
			for( int i = 0; i < 6; i++ ) {
				_segHorPoints[i].X = relCent.X + _scale*_segHorDiv2Org[i].X;
				_segHorPoints[i].Y = relCent.Y + _scale*_segHorDiv2Org[i].Y;
			}
			
			graph.FillPolygon( new SolidBrush( segState ? _colorOn : _colorOff ), _segHorPoints );
			
		}
		
		
		private void DrawDiagonalSegment( Graphics graph, bool segState, float x, float y, int YCoef = 1 ) {
			DrawDiagonalSegment( graph, segState, (int)x, (int)y, YCoef );
		}
		private void DrawDiagonalSegment( Graphics graph, bool segState, int x, int y, int YCoef = 1 ) {
			
			Point relCent = new Point( _center.X + x, _center.Y + y );
			
			PointF[] _segVerPoints = new PointF[ _segDiagonalOrg.Length ];
			
			for( int i = 0; i < _segDiagonalOrg.Length; i++ ) {
				_segVerPoints[i].X = relCent.X + _scale*_segDiagonalOrg[i].X;
				_segVerPoints[i].Y = relCent.Y + YCoef*_scale*_segDiagonalOrg[i].Y;
			}
			
			graph.FillPolygon( new SolidBrush( segState ? _colorOn : _colorOff ), _segVerPoints );
			
		}
		
		
		
	}
}
