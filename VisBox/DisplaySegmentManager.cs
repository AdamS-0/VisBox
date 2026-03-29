/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 06.05.2021
 * Time: 18:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace VisBox {
	
	public class DisplaySegmentManager : System.ComponentModel.Component {
		
		
//		[EditorBrowsable(EditorBrowsableState.Always)]
//		[Browsable(true)]
//		[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
//		[Bindable(true)]
		
		public List<DisplaySegment> Displays = new List<DisplaySegment>();
		
		public DisplaySegmentManager() {
			
			
		}
		
		
		public void ShowString( string msg ) {
			int j = 0;
			for( int i = 0; i < msg.Length && j < Displays.Count; i++, j++ ) {
				bool showDot = false;
				
				if( i + 1 < msg.Length ) {
					if( msg[i + 1] == '.' || msg[i + 1] == ',' ) {
						showDot = true;
					}
				}
				
				Displays[j].ShowChar( msg[i], showDot );
				if( showDot ) i++;
			}
			
		}
		
		
	}
}
