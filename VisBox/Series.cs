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
        
		private void FindLimits( ref int idxStart, ref int idxStop, float axMin, float axMax) {
            idxStart = 0; idxStop = dataX.Count;
            
            /* Find first point that can be put on visible chart */
            for ( idxStart = 0; idxStart < dataX.Count - 1; idxStart++ ) {
                if ( dataX[idxStart + 1] >= axMin ) { break; }
            }
           
            /* Find last point that can be put on visible chart */
            for ( idxStop = dataX.Count - 1; idxStop > idxStart; idxStop-- ) {
                if ( dataX[idxStop] < axMax ) { idxStop++; break; }
            }
            idxStop = Math.Min( idxStop, dataX.Count );
        }
		
        public void DrawSeries ( ref Graphics gr, float scaleX, float scaleY, float axMin, float axMax, float ayMin, float canvHeightPx ) {
            if ( dataX.Count != dataY.Count ) {
                throw new Exception("Length of two vectors are not equal!");
            }
            
            int idxStart = 0;
            int idxStop = dataX.Count;
            FindLimits( ref idxStart, ref idxStop, axMin, axMax );
            
            int drawX = (int)( ( (float)dataX [ idxStart ] - axMin ) * scaleX );
            int drawY = (int)( canvHeightPx - ( dataY [ idxStart ] - ayMin ) * scaleY );
//            PointF drawLast  new PointF(drawX, drawY);
            
            int pxXMin = 0, pxXMax = 0;
            int pxYMin = 0, pxYMax = 0;
            Point pxLast = new Point( drawX, drawY );
            bool canSkipThisLine = false;
            
            // Draw series
            for ( int idx = idxStart + 1; idx < idxStop; idx++ ) {
                canSkipThisLine = false;
                drawX = (int)( ( dataX [ idx ] - axMin ) * scaleX );
                drawY = (int)( canvHeightPx - ( dataY [ idx ] - ayMin ) * scaleY );
                
                /* Check for redundant draw instructions in one column */
                if ( pxLast.X == drawX ) {
                    /* Points are on the same column */
                    if      ( pxYMin > drawY ) { pxYMin = drawY; }
                    else if ( pxYMax < drawY ) { pxYMax = drawY; }
                    else {
                        /* This point is between previously painted ones, so we can skip it */
                        canSkipThisLine = true;
                    }
                } else { pxYMin = pxYMax = drawY; } /* Update column's limits */
                
                if ( !canSkipThisLine ) {
                    /* Check for redundant draw instructions in one row */
                    if ( pxLast.Y == drawY ) {
                        /* Points are on the same row */
                        if      ( pxXMin > drawX ) { pxXMin = drawX; }
                        else if ( pxXMax < drawX ) { pxXMax = drawX; }
                        else {
                            /* This point is between previously painted ones, so we can skip it */
                            canSkipThisLine = true;
                        }
                    } else { pxXMin = pxXMax = drawX; } /* Update row's limits */
                }
                
                if ( !canSkipThisLine ) {
                    gr.DrawLine( Pen, pxLast.X, pxLast.Y, drawX, drawY );
                }
                
                pxLast.X = drawX;
                pxLast.Y = drawY;
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


