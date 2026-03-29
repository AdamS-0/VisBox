/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 06.05.2021
 * Time: 16:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace VisBox {
	
	public partial class DisplaySegment : VisElement {
		
		// 50/16
		// dla horizontal
		protected float _segWidDiv2 = 9;
		protected float _segHeiDiv2 = 2;
		
		
		protected Point _center = new Point( 0, 0 );
		
		
		protected float _scale = 1.0f;
		[DefaultValue(typeof(float), "1.0f" )]
		public new float Scale {
			get { return _scale; }
			set { _scale = value; Invalidate(); }
		}
		

		protected PointF[] _segHorOrg = {
			new PointF( -6, 2 ), new PointF( 6, 2 ),
			new PointF( 8, 0 ), new PointF( 6, -2 ),
			new PointF( -6, -2 ), new PointF( -8, 0 )
		};
		protected PointF[] SegHorOrg {
			get { return _segHorOrg; }
			set { _segHorOrg = value; }
		}
		
		
		//private bool[] _segments = { false, false, false, false, false, false, false };
		protected string _segments = "00000000";
		[DefaultValue(typeof(string), "00000000")]
		public virtual string Segments {
			get { return _segments; }
			set { _segments = value; Invalidate(); }
		}
		
		
		
		
		protected bool _showDot = false;
		[DefaultValue(typeof(bool), "False")]
		public virtual bool ShowDot {
			get { return _showDot; }
			set { _showDot = value; Invalidate(); }
		}
		
		
		
		protected string[] _chars = {
			" :00000000", "-:00000001", "0:01111110", "1:00110000",
			"2:01101101", "3:01111001", "4:00110011", "5:01011011",
			"6:01011111", "7:01110000", "8:01111111", "9:01111011",
			"a:01110111", "b:00011111", "c:00001101", "d:00111101",
			"e:01001111", "f:01000111", "g:01011110", "h:01000111",
			"i:00010000", "j:00111000", "k:01010111", "l:00001110",
			"m:01010100", "n:00010101", "o:00011101", "p:01100111",
			"q:01110011", "r:00000101", "s:01011010", "t:00001111",
			"u:00011100", "v:00010100", "w:00111110", "x:00000000",
			"y:00111011", "z:01101101"
			
		};
		
		protected char _lastChar = ' ';
		protected bool lastDot = false;
		
		
		
		
		public DisplaySegment() {
			InitializeComponent();
			
			_colorOff = Color.FromArgb( 64, 64, 64 );
			
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
		}
		
		
		
		public virtual void ShowChar( char c, bool showDotNow = false ) {
			string code = _segments, codei;
			
			if( _lastChar != c ) {
				for( int i = 0; i < _chars.Length; i++ ) {
					codei = _chars[i];
					if( codei.StartsWith( c.ToString().ToLower() ) ) {
						code = codei.Substring( 2 );
						break;
					}
				}
				
			}
			
			if( lastDot != showDotNow ) {
				char [] codeA = code.ToCharArray();
				codeA[0] = showDotNow ? '1' : '0';
				
				code = new string( codeA );
			}
			
			if( _lastChar != c || lastDot != showDotNow ) {
				while( code.Length < 8 ) code += "0";
				
				Segments = code;
				_lastChar = c;
			}
				
		}
		
		
		
		
		
		protected bool GetOneSeg( char c ) {
			return c == '0' ? false : true;
		}
		
		void SegmentDisplayPaint(object sender, PaintEventArgs e) {
			Rectangle rect = GetInnerSpace();
			
			_center = new Point( rect.X + rect.Width/2, rect.Y + rect.Height/2 );
			
			if( _segments.Length == 8 ) //_segments.Length == 7
				DrawHorizontalSegment( e.Graphics, GetOneSeg( _segments[7] ), 0, 0 );
			
			DrawHorizontalSegment( e.Graphics, GetOneSeg( _segments[1] ), 0, -2*_scale*_segWidDiv2 );
			DrawHorizontalSegment( e.Graphics, GetOneSeg( _segments[4] ), 0, 2*_scale*_segWidDiv2 );
			
			// | L
			DrawVerticalSegment( e.Graphics, GetOneSeg( _segments[6] ), -_scale*_segWidDiv2, -_scale*_segWidDiv2 );
			DrawVerticalSegment( e.Graphics, GetOneSeg( _segments[5] ), -_scale*_segWidDiv2, _scale*_segWidDiv2 );
			
			// | R
			DrawVerticalSegment( e.Graphics, GetOneSeg( _segments[2] ), _scale*_segWidDiv2, -_scale*_segWidDiv2 );
			DrawVerticalSegment( e.Graphics, GetOneSeg( _segments[3] ), _scale*_segWidDiv2, _scale*_segWidDiv2 );
			
			// dot
			if( _showDot )
				DrawDot( e.Graphics, GetOneSeg( _segments[ 0 ] ),
					2*_scale*_segWidDiv2, 2*_scale*_segWidDiv2 );
		}
		
		
		
		
		protected void DrawDot( Graphics graph, bool segState, float x, float y ) {
			PointF relCent = new PointF( _center.X + x, _center.Y + y );
			
			RectangleF rect = new RectangleF(
				relCent.X - _scale*_segHeiDiv2, relCent.Y - _scale*_segHeiDiv2,
				-2*_scale*_segHeiDiv2, 2*_scale*_segHeiDiv2 );
			
			graph.FillEllipse( new SolidBrush( segState ? _colorOn : _colorOff ), rect );
		}
		
		
		
		protected void DrawHorizontalSegment( Graphics graph, bool segState, float x, float y ) {
			DrawHorizontalSegment( graph, segState, (int)x, (int)y );
		}
		protected void DrawHorizontalSegment( Graphics graph, bool segState, int x, int y ) {
			
			Point relCent = new Point( _center.X + x, _center.Y + y );
			
			PointF[] _segHorPoints = new PointF[6];
			
			for( int i = 0; i < 6; i++ ) {
				_segHorPoints[i].X = relCent.X + _scale*_segHorOrg[i].X;
				_segHorPoints[i].Y = relCent.Y + _scale*_segHorOrg[i].Y;
			}
			
			graph.FillPolygon( new SolidBrush( segState ? _colorOn : _colorOff ), _segHorPoints );
			
		}
		
		
		protected void DrawVerticalSegment( Graphics graph, bool segState, float x, float y ) {
			DrawVerticalSegment( graph, segState, (int)x, (int)y );
		}
		protected void DrawVerticalSegment( Graphics graph, bool segState, int x, int y ) {
			
			Point relCent = new Point( _center.X + x, _center.Y + y );
			
			PointF[] _segVerPoints = new PointF[6];
			
			for( int i = 0; i < 6; i++ ) {
				_segVerPoints[i].X = relCent.X + _scale*_segHorOrg[i].Y;
				_segVerPoints[i].Y = relCent.Y + _scale*_segHorOrg[i].X;
			}
			
			graph.FillPolygon( new SolidBrush( segState ? _colorOn : _colorOff ), _segVerPoints );
			
		}
		
		
	}
}
