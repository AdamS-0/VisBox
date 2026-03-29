/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 02.05.2021
 * Time: 08:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace VisBox {

	/// <summary>
	/// Description of Bar.
	/// </summary>
	public partial class Bar : VisElement {
		
		
		private Color _colorFill = Color.DarkGreen;
		[DefaultValue(typeof(Color), "DarkGreen")]
		public Color ColorFill {
			get { return _colorFill; }
			set { _colorFill = value; }
		}
		
		
		private Color _colorBack = Color.Gray;
		[DefaultValue(typeof(Color), "Gray")]
		public Color ColorBackGround {
			get { return _colorBack; }
			set { _colorBack = value; }
		}
		
		
		
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
//		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
//		[Bindable(true)]
		public override Color ColorOn{ get; set; }
		
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
//		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
//		[Bindable(true)]
		public override Color ColorOff { get; set; }
		
		
		
		private int _borderRound = 4;
		[DefaultValue(typeof(float), "4")]
		public int BorderRound{
			get { return _borderRound; }
			set { _borderRound = value; this.Invalidate(); }
		}
		
		
		
		
		
		/*
		private float _value = 0;
		[DefaultValue(typeof(float), "0")]
		public float Value {
			get { return _value; }
			set { _value = value; this.Invalidate(); }
		}
		*/
		
		public Bar() {
			InitializeComponent();
		}
		
		
		void BarPaint(object sender, PaintEventArgs e) {
			Rectangle r1 = GetInnerSpace();
			
			r1.Width += -1 + (int)( _borderWidth );
			r1.Height += -1 + (int)( _borderWidth );
			
			r1.X -= (int)( _borderWidth / 2 );
			r1.Y -= (int)( _borderWidth / 2 );
			
			Rectangle r2 = r1;
			r2.Width = (int)( _value*(float)( r1.Width ) );
			
			int round2 = _borderRound;
			
			if( r2.Width <= _borderRound ){
				round2 = r2.Width/2;
				r2.Height -= 2*round2;
				r2.Y += round2;
			}
			
			e.Graphics.FillRoundedRectangle( new SolidBrush( _colorBack ), r1, _borderRound );
			
			e.Graphics.FillRoundedRectangle(
				new SolidBrush( _colorFill ), r2, round2 );
			
			
			e.Graphics.DrawRoundedRectangle( new Pen( _colorBorder, _borderWidth ), r1, _borderRound );
		
		}
		
		
		
		
		
		
		
		
		
		
		
	
	}
	
	
	public static class GraphicsExtensions{
		public static GraphicsPath RoundedRect(Rectangle bounds, int radius) {
			int diameter = radius * 2;
			Size size = new Size(diameter, diameter);
			Rectangle arc = new Rectangle(bounds.Location, size);
			GraphicsPath path = new GraphicsPath();
	
			if (radius == 0) {
				path.AddRectangle(bounds);
				return path;
			}
	
			// top left arc  
			path.AddArc(arc, 180, 90);
	
			// top right arc  
			arc.X = bounds.Right - diameter;
			path.AddArc(arc, 270, 90);
	
			// bottom right arc  
			arc.Y = bounds.Bottom - diameter;
			path.AddArc(arc, 0, 90);
	
			// bottom left arc 
			arc.X = bounds.Left;
			path.AddArc(arc, 90, 90);
	
			path.CloseFigure();
			return path;
		}
		
		
		
		public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, int x, int y, int width, int height, int cornerRadius) {
			DrawRoundedRectangle( graphics, pen, new Rectangle( x, y, width, height ), cornerRadius );
		}
		
		public static void DrawRoundedRectangle(this Graphics graphics, Pen pen, Rectangle bounds, int cornerRadius) {
			if( graphics == null )
				throw new ArgumentNullException( "graphics" );
			
			if( pen == null )
				throw new ArgumentNullException( "pen" );
	
			using( GraphicsPath path = RoundedRect( bounds, cornerRadius ) ) {
				graphics.DrawPath( pen, path );
			}
		}
		
		public static void FillRoundedRectangle(this Graphics graphics, Brush brush, int x, int y, int width, int height, int cornerRadius) {
			FillRoundedRectangle( graphics, brush, new Rectangle( x, y, width, height ), cornerRadius );
		}
		
		public static void FillRoundedRectangle(this Graphics graphics, Brush brush, Rectangle bounds, int cornerRadius) {
			if( graphics == null )
				throw new ArgumentNullException( "graphics" );
			
			if( brush == null )
				throw new ArgumentNullException( "brush" );
	
			using( GraphicsPath path = RoundedRect( bounds, cornerRadius ) ) {
				graphics.FillPath( brush, path );
			}
		}
	}
	
}
