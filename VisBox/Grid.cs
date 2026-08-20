/*
 * Created by SharpDevelop.
 * User: AS
 * Date: 16.05.2026
 * Time: 11:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace VisBox {

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class GridDot {
        [Category("VisBox")]
        public float Value { get; set; }
        
        [Category("VisBox")]
        public string Name { get; set; }
        
        public GridDot(float value, string name = "") {
            this.Name = name;
            this.Value = value;
        }
    }
    
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Grid {
        [Category("VisBox")]
        [Browsable(true)]
        [Description("Overrides user defined grid settings")]
        [DefaultValue(typeof(bool), "False")]
        public bool Autoscale { get; set; }
        
        [Browsable(true)]
        [Category("VisBox")]
        [DefaultValue(typeof(bool), "True")]
        public bool GridOn { get; set; }

        [Browsable(true)]
        [Category("VisBox")]
        [DefaultValue(typeof(bool), "True")]
        public bool ShowLables { get; set;  }
        
        [Browsable(true)]
        [Category("VisBox")]
        [DefaultValue("0,5")]
        [Description("Used during Autoscale option is set. Describes space bewteen neartest grid lines, in % of total length")]
        public float ScaleFactor { get; set; }
        
        public Brush LabelBrush = new SolidBrush(Color.DimGray);
        [Browsable(true)]
        [Category("VisBox")]
        [DefaultValue(typeof(Color), "DimGray")]
        public Color LabelColor {
            get { return ((SolidBrush)LabelBrush).Color; }
            set { ((SolidBrush)LabelBrush).Color = value; }
        }
        

        protected string _format = "0.###E-0";
        
        [Browsable(true)]
        [Category("VisBox")]
        [DefaultValue("0.###E-0")]
        [Description("Used during Autoscale option is set. Converts floating point values to given format")]
        public string Format {
            get { return _format; }
            set { _format = value; }
        }
        
        protected Pen _pen = new Pen(Color.Black);
        public Pen Pen {
            get { return _pen; }
            set { _pen = value; }
        }
        
        [Browsable(true)]
        [Category("VisBox")]
        [DefaultValue(typeof(Color), "Red")]
        public Color LineColor {
            get { return _pen.Color; }
            set { _pen.Color = value; }
        }
        
        [Browsable(true)]
        [Category("VisBox")]
        [DefaultValue(typeof(float), "1")]
        public float LineWidth {
            get { return _pen.Width; }
            set { _pen.Width = value; }
        }
        
        
        protected List<GridDot> _dots = new List<GridDot>();
        [Category("VisBox")]
        public List<GridDot> Dots {
            get { return _dots; }
            set { _dots = value; }
        }
        
        public Grid(bool gridOn = false) {
            this.GridOn = gridOn;
        }
        
        public Grid(List<GridDot> dots, bool gridOn = false) {
            this.GridOn = gridOn;
            this.Dots = dots;
        }
        
        /// <summary>
        /// Create Grid object for given limits
        /// </summary>
        /// <param name="gridMin"></param>
        /// <param name="gridMax"></param>
        /// <param name="usersFormat"></param>
        /// <param name="gridOn"></param>
        public Grid(float gridMin, float gridMax, string usersFormat = "", bool gridOn = false) {
            this.GridOn = gridOn;
            this.Format = usersFormat;
            ReCalculateGrid( gridMin, gridMax );
        }
        
        
        /// <summary>
        /// Recalculate grid dots for given conditions
        /// </summary>
        /// <param name="gridMin"></param>
        /// <param name="gridMax"></param>
        public void ReCalculateGrid ( float gridMin, float gridMax, float userScale = 1.0f ) {
            if ( userScale == 0 ) { userScale = 1.0f; }
            if ( Dots != null ) { Dots.Clear(); }
            
            if ( gridMin > gridMax ) {
                float swapMem = gridMin;
                gridMin = gridMax;
                gridMax = swapMem;
            }
            
            Dots = GetGridFromLimits( gridMin, gridMax, this.Format, userScale );
        }
        
        
        /// <summary>
        /// Calculate grid for given limits without creating new instance of an Grid objct
        /// </summary>
        /// <param name="axisMin"></param>
        /// <param name="axisMax"></param>
        /// <param name="usersFormat"></param>
        /// <returns></returns>
        public static List<GridDot> GetGridFromLimits ( float axisMin, float axisMax, string usersFormat = "", float userScale = 1.0f ) {
            List<GridDot> gridDots = new List<GridDot>();
            string gridDotNameFormat = "";
            float gridWidth = 1;
            float gridScale = 1;
            int gridNum = 0;
            
            if ( axisMin == axisMax ) {
                axisMin -= 0.1f;
                axisMax += 0.1f;
            }
            
            float deltaAxis = axisMax - axisMin;
            
            if ( usersFormat.Length == 0 ) {
                gridDotNameFormat = deltaAxis > 99999.0f || deltaAxis < 0.001 ? "0.###E-0" : "";
            } else {
                gridDotNameFormat = usersFormat;
            }
            
            gridWidth = deltaAxis;
            gridScale = 1;
            
            // Calculate grid scale
            while ( gridWidth < 1 ) {
                gridWidth *= 10.0f;
                gridScale *= 0.1f;
            }
            while ( gridWidth > 1 ) {
                gridWidth *= 0.1f;
                gridScale *= 10.0f;
            }
            gridScale *= 0.1f;
            
            gridNum = (int)( deltaAxis / gridScale );
            
            if      ( gridNum > 11 ) { gridScale *= 5; }
            else if ( gridNum >  6 ) { gridScale *= 2; }
            else if ( gridNum <  2 ) { gridScale *= 0.2f; }
            else if ( gridNum <  4 ) { gridScale *= 0.5f; }
            
            gridScale *= userScale;
            
            // Calculatee next grid points
            float fGridDot = (int)( axisMin / gridScale ) * gridScale;
            while ( fGridDot <= axisMax ) {
                gridDots.Add( new GridDot(fGridDot, fGridDot.ToString( gridDotNameFormat )) );
                fGridDot += gridScale;
            }
            
            return gridDots;
        }
    }
}
