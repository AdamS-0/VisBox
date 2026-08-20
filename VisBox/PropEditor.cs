/*
 * Created by SharpDevelop.
 * User: AS
 * Date: 25.05.2026
 * Time: 17:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace VisBox {
    /// <summary>
    /// Description of PropEditor.
    /// </summary>
    public partial class PropEditor : Form {
        public PropEditor() {
            InitializeComponent();
            this.FormClosing += PropEditorFormClosing;
            propertyGrid1.BrowsableAttributes = new AttributeCollection( new CategoryAttribute("VisBox") );
        }
        
        public void ShowPropertyOf(object obj) {
            if ( obj == null ) { return; }
            propertyGrid1.SelectedObject = obj;
            
            this.Show();
        }
        
        void PropEditorFormClosing ( object sender, FormClosingEventArgs e ) {
            e.Cancel = true;
            this.Hide();
        }
    }
}
