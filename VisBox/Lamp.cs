/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 02.05.2021
 * Time: 08:14
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
	/// Description of Lamp.
	/// </summary>
	public partial class Lamp : VisElement {
		
		public Lamp() {
			InitializeComponent();
//			_currentColor = _colorOff;
			_borderWidth = 2;
		}
		
		
		void LampPaint(object sender, PaintEventArgs e) {
			
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			
			Rectangle r1 = GetInnerSpace();
			
			r1.Width += -1 + (int)( _borderWidth );
			r1.Height += -1 + (int)( _borderWidth );
			
			r1.X -= (int)( _borderWidth / 2 );
			r1.Y -= (int)( _borderWidth / 2 );
			
			e.Graphics.FillEllipse( new SolidBrush( _state ? _colorOn : _colorOff ), r1 );
			
			e.Graphics.DrawEllipse( new Pen( _colorBorder, _borderWidth ), r1 );
			
		}
		
		
	}
}



