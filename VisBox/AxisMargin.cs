/*
 * Created by SharpDevelop.
 * User: AS
 * Date: 16.05.2026
 * Time: 13:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;

namespace VisBox
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class AxisMargin {
        
        [Category("VisBox")]
        [Browsable(true)]
        [DefaultValue("0")]
        public float Left { get; set; }
        
        [Category("VisBox")]
        [Browsable(true)]
        [DefaultValue("0")]
        public float Right { get; set; }
        
        [Category("VisBox")]
        [Browsable(true)]
        [DefaultValue("0")]
        public float Top { get; set; }
        
        [Category("VisBox")]
        [Browsable(true)]
        [DefaultValue("0")]
        public float Bottom { get; set; }
        
        public AxisMargin() { }
        public AxisMargin(float left, float right, float top, float bottom) {
            this.Left = left;
            this.Right = right;
            this.Top = top;
            this.Bottom = bottom;
            
        }
    }
}
