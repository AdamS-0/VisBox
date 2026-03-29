/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 09.05.2021
 * Time: 11:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace VisBox {
	
	public class PushButtonManager : System.ComponentModel.Component {
		
		System.Collections.Generic.List<PushButton> _buttons = new System.Collections.Generic.List<PushButton>();
		
		public PushButtonManager() {
			
		}
		
		public void AddButton( PushButton pBtn ) {
			int id = -1;
			try { id = _buttons.FindIndex( x => x == pBtn ); } catch {}
			
			if( id == -1 ) _buttons.Add( pBtn );
		}
		
		public void OneElementChanged( PushButton pBtn ) {
			bool btnState = pBtn.State;
			
			foreach( PushButton btn in _buttons )
				btn.State = false;
			
			pBtn.State = !btnState;
			
		}
		
	}
}
