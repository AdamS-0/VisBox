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
        
        private int _valueInt = 0;
        
        private int _parts = 10;
        public int Parts {
            get { return _parts; }
            set { _parts = value; }
        }
        
        private float _increment = 0.05f;
        [DefaultValue(typeof(float), "0.05")]
        [Description("Smallest value that will be added when MouseWheel detected on this Control. Used when property Fix2Nearby is disabled")]
        public float Incrementer {
            get { return _increment; }
            set { _increment = value; }
        }
        
        private bool _fix2Nearby = false;
        [DefaultValue(typeof(bool), "False")]
        public bool Fix2Nearby {
            get { return _fix2Nearby; }
            set { _fix2Nearby = value; }
        }
        
        
        private Color _colorLine = Color.Black;
        [DefaultValue(typeof(Color), "Black")]
        public Color ColorLine {
            get { return _colorLine; }
            set { _colorLine = value; }
        }
        
        
        
        private Color _colorHandle = Color.Gainsboro;
        [DefaultValue(typeof(Color), "Gainsboro")]
        public Color ColorHandle {
            get { return _colorHandle; }
            set { _colorHandle = value; }
        }
        
        
        private int _handleWid = 5, _handleWidOrg = 5;
        private int _handleHei = 8, _handleHeiOrg = 8;
        
        
        public ZipBar() {
            InitializeComponent();
            this.MouseWheel += ZipBarMouseWheelHandler;
            _borderWidth = 2;
        }
        
        
        pixelsLimits getPixelsLimitsX() {
            /* From left to right */
            int xBase =          _handleWid + Padding.Left  + Padding2.Left ;
            int xEnd = Width - ( _handleWid + Padding.Right + Padding2.Right + 1 );
            return new pixelsLimits(xBase, xEnd);
        }
        
        pixelsLimits getPixelsLimitsY() {
            int yBase   = Height - ( _handleWid + Padding.Bottom + Padding2.Bottom + 1 );
            int yEnd    =            _handleWid + Padding.Top    + Padding2.Top;
            return new pixelsLimits(yBase, yEnd);
        }
        
        void ZipBarPaint(object sender, PaintEventArgs e) {
            Pen p1 = new Pen( _colorLine );
            
            Rectangle rect = GetInnerSpace();
            
            if ( rect.Width <= (3*_handleWid)/2 ) _handleWid = (3*rect.Width)/2;
            else _handleWid = _handleWidOrg;
            
            if ( rect.Height <= (3*_handleHei)/2 ) _handleHei = (3*rect.Height)/2;
            else _handleHei = _handleHeiOrg;
            
            if ( _parts <= 1 ) _parts = 2;
            
            float x = 0, y = Height/2;
            
            if ( LayoutDirection == Direction.Horizontal ) {
                pixelsLimits xLim = getPixelsLimitsX();
                int pixelsTotal = Math.Abs(xLim.End - xLim.Base);
                y = Height/2;
                
                e.Graphics.DrawLine( p1, xLim.Base, y, xLim.End, y );
                
                for ( int i = 0; i < _parts; i++ ) {
                    x = xLim.Base + ( i * pixelsTotal )/( _parts - 1 );
                    e.Graphics.DrawLine( p1, x, y - 4, x, y + 4 );
                }
                
                /* Calculate X coordinate of a handle (handle's center) */
                if ( _fix2Nearby )  { x = ( _valueInt * pixelsTotal ) / ( _parts - 1 ); }
                else                { x = (int)((float)_value * pixelsTotal); }
                x = xLim.Base + x;
                
                DrawHandle( e, new Rectangle( (int)x - _handleWid, (int)y - _handleHei, 2*_handleWid + 1, 2*_handleHei + 1 ) );
            } else {
                pixelsLimits yLim = getPixelsLimitsY();
                int pixelsTotal = Math.Abs(yLim.End - yLim.Base);
                x = Width/2;
                
                /* Draw vertical line */
                e.Graphics.DrawLine( p1, x, yLim.Base, x, yLim.End );
                
                for ( int i = 0; i < _parts; i++ ) {
                    y = yLim.Base - ( i * pixelsTotal )/( _parts - 1 );
                    e.Graphics.DrawLine( p1, x - 4, y, x + 4, y );
                }
                
                /* Calculate Y coordinate of a handle (handle's center) */
                if ( _fix2Nearby )  { y = ( _valueInt * pixelsTotal ) / ( _parts - 1 ); }
                else                { y = (int)((float)_value * pixelsTotal); }
                
                y = yLim.Base - y;

                /* Due to the rotation of direction, handle.height must be swapped with handle.width */
                DrawHandle( e, new Rectangle( (int)x - _handleHei, (int)y - _handleWid, 2*_handleHei + 1, 2*_handleWid + 1 ) );
                
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
        
        
        
        private void ZipBarMouseWheelHandler(object sender, System.Windows.Forms.MouseEventArgs e) {
            int dValue = 0;
            if (e.Delta > 0) dValue = +1;
            if (e.Delta < 0) dValue = -1;
            
            float val = Value;
            int pixelsTotal = 0;
            
            if ( LayoutDirection == Direction.Horizontal ) {
                /* From left to right */
                pixelsLimits xLim = getPixelsLimitsX();
                pixelsTotal = Math.Abs(xLim.End - xLim.Base);
            } else {
                /* From bottom to top */
                pixelsLimits yLim = getPixelsLimitsY();
                pixelsTotal = Math.Abs(yLim.End - yLim.Base);
            }
            
            if ( _fix2Nearby ) {
                _valueInt += dValue;
                if ( _valueInt < 0 ) { _valueInt = 0; }
                if ( _valueInt >= _parts ) { _valueInt = _parts - 1; }
                
                val = (float)_valueInt /( _parts - 1 );
            } else {
                val += dValue*_increment;
            }
            
            if      ( val < 0 ) { val = 0; }
            else if ( val > 1 ) { val = 1; }
            Value = val;
        }
        
        void ZipBarMouseDown(object sender, MouseEventArgs e) { mouseDown = true; }
        
        void ZipBarMouseUp(object sender, MouseEventArgs e) { mouseDown = false; }
        
        void ZipBarMouseMove(object sender, MouseEventArgs e) {
            if ( !mouseDown ) { return; }
            
            float val = 0;
            int valPixels = 0, pixelsTotal = 0;
            Point pos = PointToClient( Cursor.Position );
            
            if ( LayoutDirection == Direction.Horizontal ) {
                /* From left to right */
                pixelsLimits xLim = getPixelsLimitsX();
                pixelsTotal = Math.Abs(xLim.End - xLim.Base);
                valPixels = pos.X - xLim.Base;
            } else {
                /* From bottom to top */
                pixelsLimits yLim = getPixelsLimitsY();
                pixelsTotal = Math.Abs(yLim.End - yLim.Base);
                valPixels = yLim.Base - pos.Y;
            }
            
            if ( _fix2Nearby ) {
                int partSizePx = pixelsTotal / ( _parts - 1 );
                
                _valueInt = ( ( _parts - 1 ) * ( valPixels + partSizePx/2 ) ) / pixelsTotal;
                
                if ( _valueInt < 0 ) { _valueInt = 0; }
                if ( _valueInt >= _parts ) { _valueInt = _parts - 1; }
                
                val = (float)_valueInt /( _parts - 1 );
            } else {
                val = (float)( valPixels ) / pixelsTotal;
            }
            
            if      ( val < 0 ) { val = 0; }
            else if ( val > 1 ) { val = 1; }
            Value = val;
        }
        
        
    }
    
    public class pixelsLimits {
        public int Base;
        public int End;
        public pixelsLimits(int Base, int End) {
            this.Base = Base;
            this.End = End;
        }
    }
}





/*
void ZipBarPaint(object sender, PaintEventArgs e) {
            Pen p1 = new Pen( _colorLine );
            
            Rectangle rect = GetInnerSpace();
            
            if ( rect.Width <= (3*_handleWid)/2 ) _handleWid = (3*rect.Width)/2;
            else _handleWid = _handleWidOrg;
            if ( rect.Height <= (3*_handleHei)/2 ) _handleHei = (3*rect.Height)/2;
            else _handleHei = _handleHeiOrg;
            
            //int deltaV = _maximum - _minimum;
            float deltaV = 1;
            
            if ( deltaV <= 0 ) deltaV = 1;
            if ( _parts <= 1 ) _parts = 2;
            
            int x = 0, y = Height/2;
            int wid = Width - Padding.Left - Padding.Right - Padding2.Left -
                Padding2.Right - 2 - 2*_handleWid;
            
            if ( LayoutDirection == Direction.Horizontal ) {
                e.Graphics.DrawLine( p1, 1 + Padding.Left + Padding2.Left + _handleWid, y,
                    1 + Padding.Left + Padding2.Left + _handleWid + wid, y );
                
                for ( int i = 0; i < _parts; i++ ) {
                    x = 1 + _handleWid + Padding2.Left + Padding.Left + ( i * wid )/( _parts - 1 );
                    e.Graphics.DrawLine( p1, x, y - 4, x, y + 4 );
                }
                
                x = 1 + _handleWid + Padding.Left + Padding2.Left + ( ( _value - _minimum ) * wid )/( deltaV );
                //e.Graphics.FillRectangle( new SolidBrush( _colorHandle ),
                //    x - handleWid, y - handleHei, 2*handleWid, 2*handleHei );
                
                DrawHandle( e,
                    new Rectangle( x - _handleWid, y - _handleHei, 2*_handleWid, 2*_handleHei ) );
                
            } else {
                wid = Height - Padding2.Top - Padding2.Bottom - Padding.Top -
                    Padding.Bottom - 1 - 2*_handleWid;
                y = Width/2;
                
                e.Graphics.DrawLine( p1, y, Height - 1 - Padding.Bottom - Padding2.Bottom - _handleWid,
                    y, Height - 1 - Padding.Bottom - Padding2.Bottom - _handleWid - wid );
                
                for ( int i = 0; i < _parts; i++ ) {
                    x = Height - ( 1 + _handleWid + Padding.Bottom + Padding2.Bottom + ( i * wid )/( _parts - 1 ) );
                    e.Graphics.DrawLine( p1, y - 4, x, y + 4, x );
                }
                
                x = Height - ( 1 + _handleWid + Padding.Bottom + Padding2.Bottom + ( ( _value - _minimum ) * wid )/( deltaV ) );
                
                //e.Graphics.FillRectangle( new SolidBrush( _colorHandle ),
                //    y - handleHei, x - handleWid, 2*handleHei, 2*handleWid );
                
                DrawHandle( e,
                    new Rectangle( y - _handleHei, x - _handleWid, 2*_handleHei, 2*_handleWid ) );
                
            }
            
            
        }
        */



/*
void ZipBarMouseMove(object sender, MouseEventArgs e) {
            if ( mouseDown ) {
                int val = 0;
                int deltaV = _maximum - _minimum;
                int dv = 1;
                int dmv = 0; // odległosć kursora od '_minimum' w pixelach
                int wid = 1;
                
                if ( LayoutDirection == Direction.Horizontal ) {
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
                
                if ( _fix2Nearby ) {
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