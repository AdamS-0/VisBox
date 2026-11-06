/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 6.11.2026
 * Time: 15:35
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace VisBox {
    /// <summary>
    /// Description of TreeDetailsViewDeps.
    /// </summary>
    public class TreeDetailsViewDeps {
        public TreeDetailsViewDeps() {
        }
    }
    
    class TreeViewItemBtnInfo {
        public Point Location = new Point(0, 0);
        public TreeDetailsViewItem Node;
        
        public TreeViewItemBtnInfo(Point pt, ref TreeDetailsViewItem node) {
            Location = pt;
            Node = node;
        }
    }
    
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TreeDetailsViewItem : TreeDetailsViewSubItem {
        
        private List<TreeDetailsViewSubItem> _subitems = new List<TreeDetailsViewSubItem>();
         
        [Category("VisBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<TreeDetailsViewSubItem> Subitems {
            get { return _subitems; }
            set { _subitems = value; }
        }
        
        public bool Collapsed { get; set; }
        
        private List<TreeDetailsViewItem> _nodes = new List<TreeDetailsViewItem>();
        [Category("VisBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<TreeDetailsViewItem> Nodes {
            get { return _nodes; }
            set {_nodes = value; }
        }
        
        
        public Rectangle AreaOnCanvas = new Rectangle();
        
        public TreeDetailsViewItem() { }
        
        public TreeDetailsViewItem(string text) {
            if ( text == null ) throw new ArgumentNullException("text");
            this.Text = text;
            
        }
        
        public TreeDetailsViewSubItem AddSubitem(TreeDetailsViewSubItem subItem) {
            _subitems.Add( subItem );
            return subItem;
        }
        
        public TreeDetailsViewSubItem AddSubitem(string text) {
            return AddSubitem( new TreeDetailsViewSubItem( text ) );
        }
        
        
        public TreeDetailsViewItem AddSubNode(TreeDetailsViewItem subNode) {
            _nodes.Add( subNode );
            return subNode;
        }
        
        public TreeDetailsViewItem AddSubNode(string text) {
            return AddSubNode( new TreeDetailsViewItem( text ) );
        }
        
        
        public new SizeF GetItemSize() {
            SizeF size = _gr.MeasureString(Text, Font, PointF.Empty, StringFormat.GenericTypographic);
            size.Height += 1;
            
            float maxHeight = size.Height;
            for ( int idx = 0; idx < _subitems.Count; idx++ ) {
                SizeF subItemSize = _subitems[idx].GetItemSize();
                if ( maxHeight < subItemSize.Height ) {
                    maxHeight = subItemSize.Height;
                }
            }
            
            size.Height = maxHeight;
            
            return size;
        }
        
    }
    
    
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TreeDetailsViewColumnItem : TreeDetailsViewSubItem {
        
        public Rectangle BoundBox = new Rectangle(0, 0, 75, 20);
        
        public int Width {
            get { return BoundBox.Width; }
            set { BoundBox.Width = value; }
        }
        
        public int MinimumWidth = 20;
        
        public bool IsWidthChange   = false;
        public TreeDetailsViewColumnItem() { }
        
        public TreeDetailsViewColumnItem(string text) {
            if ( text == null ) throw new ArgumentNullException("text");
            this.Text = text;
        }
        
    }
    
    
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TreeDetailsViewSubItem {
        public string Text { get; set; }
        
        private Font _font = new Font( "Arial", 10 );
        public Font Font {
            get { return _font; }
            set { _font = value; }
        }
        
        private static Color _foreColorDefault = Color.Black;
        private Color _foreColor = _foreColorDefault;
        public Color ForeColor {
            get { return _foreColor; }
            set {
                _foreColor = value;
                Brush = new SolidBrush( _foreColor );
            }
        }
        
        [NonSerialized]
        public Brush Brush = new SolidBrush(_foreColorDefault);


        private static Color _selectedBackColorDefault = Color.Gainsboro;
        private Color _selectedBackColor = _selectedBackColorDefault;
        public Color SelectedBackColor {
            get { return _selectedBackColorDefault; }
            set {
                _selectedBackColor = value;
                BrushSelection = new SolidBrush( _selectedBackColor );
            }
        }
        
        [NonSerialized]
        public Brush BrushSelection = new SolidBrush(_selectedBackColorDefault);
        
        
        private static Bitmap _bmp = new Bitmap(10, 10);
        protected static Graphics _gr = Graphics.FromImage( _bmp );
        
        public bool IsMouseOver = false;
        public bool IsMouseDown = false;
        
        public delegate object GetObjectEvent();
        public delegate void SetObjectEvent(object obj);
        
        [NonSerialized]
        public GetObjectEvent GetRelatedObject;
        
        [NonSerialized]
        public SetObjectEvent SetRelatedObject;
        
        [NonSerialized]
        public bool ShowRelatedObject = false;
        
        [NonSerialized]
        public object Tag = null;

        [NonSerialized]
        public object Tag2 = null;
        
        [NonSerialized]
        public object Tag3 = null;
        
        public TreeDetailsViewSubItem() { }
        
        public TreeDetailsViewSubItem(string text) {
            if ( text == null ) throw new ArgumentNullException("text");
            this.Text = text;
            
        }
        
        public SizeF GetItemSize() {
            SizeF size = _gr.MeasureString(Text, _font, PointF.Empty, StringFormat.GenericTypographic);
            size.Height += 1;
            return size;
        }
        
        public override string ToString() {
            return this.GetType().ToString() + ": " + this.Text;
        }
    }
}
