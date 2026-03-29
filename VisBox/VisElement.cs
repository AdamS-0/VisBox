/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 02.05.2021
 * Time: 11:38
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
	/// Description of VisElement.
	/// </summary>
	public partial class VisElement : UserControl {
		
		
		
		public enum Shape {
			Rectangle, Ellipse
		}
		
		
		
		public event EventHandler ValueChanged;
		protected virtual void OnValueChanged( EventArgs e ){
			EventHandler handler = ValueChanged;
			if( handler != null ) handler( this, e );
		}
		
		
		public event EventHandler StateChanged;
		protected virtual void OnStateChanged( EventArgs e ){
			EventHandler handler = StateChanged;
			if( handler != null ) handler( this, e );
		}
		
		
		
		protected Padding Padding2 = new Padding( 0, 0, 0, 0 );
		
		
		
		protected Color cDownZew = Color.FromArgb( 255, 255, 255, 255 );
		protected Color cDownWew = Color.FromArgb( 255, 227, 227, 227 );
		
		protected Color cUpZew = Color.FromArgb( 255, 160, 160, 160 );
		protected Color cUpWew = Color.FromArgb( 255, 105, 105, 105 );
		
		
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Bindable(true)]
		[DefaultValue(typeof(string), "")]
		public override string Text { get; set;}
		
		/*
		[Bindable(true)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
		[Browsable(true)]
		[Category("Appearance")]
		[DefaultValue(typeof(string), "")]
		public override string Text {
			get { return base.Text; }
			set {
				if (base.Text != value) {
					base.Text = value; this.Invalidate();
					if(TextChanged != null) TextChanged(this, EventArgs.Empty);
				}
			}
			
		}
		
		[Browsable(true)]
		public event EventHandler TextChanged;
		*/
		
		public enum VisFlatStyle{
			Flat,
			Collapsed,
			Popup
		}
		
		private VisFlatStyle _flatStyle = VisFlatStyle.Flat;
		[DefaultValue(typeof(VisFlatStyle), "Flat")]
		public VisFlatStyle FlatStyle{
			get { return _flatStyle; }
			set { _flatStyle = value; }
		}
		
		
		
		
		public enum Direction{
			Horizontal,
			Vertical
		}
		
		private Direction _direction = Direction.Horizontal;
		[DefaultValue(typeof(Direction), "Horizontal")]
		public Direction LayoutDirection{
			get { return _direction; }
			set { _direction = value; }
		}
		
		
		
		
		
		protected float _value = 0;
		[DefaultValue(typeof(float), "0")]
		public float Value {
			get { return _value; }
			set {
				if( value >= 0 && value <= 1.0f ) _value = value;
				else if( value < 0 ) _value = 1 - ( value % 1 );
				else _value = value % 1;
				this.Invalidate();
				OnValueChanged( new EventArgs() );
			}
		}
		
		
		
		protected bool _state = false;
		[DefaultValue(typeof(bool), "False")]
		public bool State {
			get { return _state; }
			set { _state = value; stateChanged(); Invalidate(); OnStateChanged( new EventArgs() );}
		}
		
		protected virtual void stateChanged() { }
		
		
		
		protected Color _colorOn = Color.Red;
		[DefaultValue(typeof(Color), "Red")]
		public virtual Color ColorOn {
			get { return _colorOn; }
			set { _colorOn = value; colorChanged(); }
		}
		
		
		protected Color _colorOff = Color.Maroon;
		[DefaultValue(typeof(Color), "Maroon")]
		public virtual Color ColorOff {
			get { return _colorOff; }
			set { _colorOff = value; colorChanged(); }
		}
		
		protected virtual void colorChanged() {
			Invalidate();
		}
		
		
		
		protected Color _colorInner = SystemColors.Control;
		[DefaultValue(typeof(Color), "Control")]
		public Color ColorInner {
			get { return _colorInner; }
			set { _colorInner = value; }
		}
		
		
		protected Color _colorBorder = Color.DarkGray;
		[DefaultValue(typeof(Color), "DarkGray")]
		public Color ColorBorder {
			get { return _colorBorder; }
			set { _colorBorder = value; }
		}
		
		
		
		
		protected float _borderWidth = 0;
		[DefaultValue(typeof(float), "0")]
		public float BorderWidth{
			get { return _borderWidth; }
			set { _borderWidth = value; this.Invalidate(); }
		}
		
		
		
		
		
		
		/// <summary>
		/// Gets current state of VisElement.
		/// </summary>
		/// <returns></returns>
		public bool GetState() { return _state; }
		
		
		/// <summary>
		/// Turn on  the VisElement.
		/// </summary>
		public void On() { State = true; }
		
		
		/// <summary>
		/// Turn off the VisElement.
		/// </summary>
		public void Off() { State = false; }
		
		
		/// <summary>
		/// Toggle state of VisElement.
		/// </summary>
		public void Toggle() { State = !GetState(); }
		
		
		
		public Rectangle GetInnerSpace() {
			Rectangle r1 = new Rectangle(
				Padding.Left + Padding2.Left + (int)_borderWidth,
				Padding.Top + Padding2.Top + (int)_borderWidth,
				Width - Padding.Left - Padding.Right - Padding2.Left - Padding2.Right - (int)( 2*_borderWidth ),
				Height - Padding.Bottom - Padding.Top - Padding2.Bottom - Padding2.Top - (int)( 2*_borderWidth ));
			
			return r1;
		}
		
		public Rectangle GetInnerSpace2Draw() {
		    Rectangle r1 = GetInnerSpace();
//            r1.Width += -1 + (int)( _borderWidth );
//            r1.Height += -1 + (int)( _borderWidth );
//            
//            r1.X -= (int)( _borderWidth / 2 );
//            r1.Y -= (int)( _borderWidth / 2 );
            r1.X += 2;
            r1.Y += 2;
            r1.Width -= 6;
            r1.Height -= 6;
            
            return r1;
        }
		
		public int GetScaledValue( int max ) { return (int)GetScaledValue( (float)0, (float)max ); }
		public int GetScaledValue( int min, int max ) {
			return (int)GetScaledValue( (float)min, (float)max );
		}
		
		public float GetScaledValue( float max ) { return GetScaledValue( 0.0f, max ); }
		public float GetScaledValue( float min, float max ) {
			return _value*( max - min ) + min;
		}
		
		
		
		
		public VisElement() {
			InitializeComponent();
			this.DoubleBuffered = true;
		}
		
		
		
		
		
		
		
		
		void VisElementPaint(object sender, PaintEventArgs e) {
//			if( BackgroundImage != null ) return;
			
			if( FlatStyle == VisFlatStyle.Flat ) {
				Padding2 = new Padding( 0, 0, 0, 0 );
			} else {
				
				Rectangle r1 = new Rectangle( Padding.Left, Padding.Top,
					Width - Padding.Left - Padding.Right + 1, Height - Padding.Bottom - Padding.Top + 1 );
				
				Padding2 = new Padding( 3, 3, 3, 3 );
				
				r1.Width -= 1;
				r1.Height -= 1;
				
				Color cUpZew1 = cUpZew;
				Color cDownZew1 = cDownZew;
				Color cUpWew1 = cUpWew;
				Color cDownWew1 = cDownWew;
				
				if( FlatStyle == VisFlatStyle.Collapsed ) {
					Color c1 = cDownZew1;
					cDownZew1 = cUpZew1;
					cUpZew1 = c1;
					
					c1 = cDownWew1;
					cDownWew1 = cUpWew1;
					cUpWew1 = c1;		
				}
				
				//e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
				
				e.Graphics.FillRectangle( new SolidBrush( cUpZew1 ), r1 );
				
				r1.Width -= 1;
				r1.Height -= 1;
				
				e.Graphics.FillRectangle( new SolidBrush( cDownZew1 ), r1 );
				
				r1.X += 1;
				r1.Y += 1;
				r1.Width -= 1;
				r1.Height -= 1;
				
				e.Graphics.FillRectangle( new SolidBrush( cUpWew1 ), r1 );
				
				r1.Width -= 1;
				r1.Height -= 1;
				
				e.Graphics.FillRectangle( new SolidBrush( cDownWew1 ), r1 );
				
				r1.X += 1;
				r1.Y += 1;
				r1.Width -= 1;
				r1.Height -= 1;
				
				e.Graphics.FillRectangle( new SolidBrush( _colorInner ), r1 );
				
			}
		}
		
	}
}
