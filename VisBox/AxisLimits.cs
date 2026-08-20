/*
 * Created by SharpDevelop.
 * User: AS
 * Date: 16.05.2026
 * Time: 11:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;

namespace VisBox {
    /// <summary>
    /// Description of AxisLimits.
    /// </summary>
    /// 
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class AxisLimits {
        
        [Category("VisBox")]
        [Browsable(true)]
        [DefaultValue(typeof(float), "-0,1")]
        public float Min { get; set; }
        
        [Category("VisBox")]
        [Browsable(true)]
        [DefaultValue(typeof(float), "1,1")]
        public float Max { get; set; }
        
        [Category("VisBox")]
        [Browsable(true)]
        [Description("Overrides user defined axis limits")]
        [DefaultValue(typeof(bool), "False")]
        public bool Autoscale { get; set; }
        
        public AxisLimits() { }
        public AxisLimits(float min, float max, bool autoscale) {
            this.Min = min;
            this.Max = max;
            this.Autoscale = autoscale;
            
        }
        
    }
    
} 