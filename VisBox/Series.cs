/*
 * Created by SharpDevelop.
 * User: AS
 * Date: 16.05.2026
 * Time: 12:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace VisBox {
//    [TypeConverter( typeof(ExpandableObjectConverter))]
//    [Serializable]
    public class Series {
        
        [Category("VisBox")]
        public List<float> dataX { get; set; }
        
        [Category("VisBox")]
        public List<float> dataY { get; set; }
        
        [Category("VisBox")]
        public Marker Marker { get; set; }
        
        [Category("VisBox")]
        public Pen Pen { get; set; }
        
        [Category("VisBox")]
        public string Name { get; set; }
        
        public Series() {
            
        }
        
        public Series(ref List<float> dataX, ref List<float> dataY) {
            if ( dataX == null ) throw new ArgumentNullException("dataX");
            if ( dataY == null ) throw new ArgumentNullException("dataY");
            this.dataX = dataX;
            this.dataY = dataY;
            
        }
        
        public Series(ref List<float> dataX, ref List<float> dataY, Marker marker, Pen pen, string name = "") {
            if ( dataX == null ) throw new ArgumentNullException("dataX");
            if ( dataY == null ) throw new ArgumentNullException("dataY");
            if ( marker == null ) throw new ArgumentNullException("marker");
            if ( pen == null ) throw new ArgumentNullException("pen");
            this.dataX = dataX;
            this.dataY = dataY;
            this.Marker = marker;
            this.Pen = pen;
            this.Name = name;
            
        }
        
        public void DrawSeries ( ref Graphics gr, float scaleX, float scaleY, float axMin, float ayMin, float canvHeightPx ) {
            float drawX = 0, drawY = 0;
            
            if ( dataX.Count != dataY.Count ) {
                throw new Exception("Length of two vectors are not equal!");
            }
            
            drawX = ( (float)dataX [ 0 ] - axMin ) * scaleX;
            drawY = canvHeightPx - ( dataY [ 0 ] - ayMin ) * scaleY;
            PointF pL = new PointF(drawX, drawY);
            
            // Draw series
            for ( int idx = 0; idx < dataX.Count; idx++ ) {
                drawX = ( dataX [ idx ] - axMin ) * scaleX;
                drawY = canvHeightPx - ( dataY [ idx ] - ayMin ) * scaleY;
                
                gr.DrawLine( Pen, pL.X, pL.Y, drawX, drawY );
                
                pL.X = (float)drawX;
                pL.Y = (float)drawY;
            }
        }
        
        public void DrawMarkers ( ref Graphics gr, float scaleX, float scaleY, float axMin, float ayMin, float canvHeightPx ) {
            if ( Marker.Symbol == ' ' ) { return; }
            
            if ( dataX.Count != dataY.Count ) {
                throw new Exception("Length of two vectors are not equal!");
            }
            
            Brush markerBrush = new SolidBrush(Marker.Color);
            Font markerFont = new Font("Arial", 10);
            float drawX = 0, drawY = 0;
            
            StringFormat markerFormat = new StringFormat();
            markerFormat.LineAlignment = StringAlignment.Center;
            markerFormat.Alignment = StringAlignment.Center;
            
            // Draw markers
            for ( int i = 0; i < dataX.Count; i++ ) {
                drawX = ( dataX [ i ] - axMin ) * scaleX;
                drawY = canvHeightPx - ( dataY [ i ] - ayMin ) * scaleY;
                gr.DrawString( Marker.Symbol.ToString(), markerFont, markerBrush, drawX, drawY, markerFormat );
            } 
        }
    }
}


