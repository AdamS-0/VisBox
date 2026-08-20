/*
 * Created by SharpDevelop.
 * User: AS
 * Date: 19.08.2026
 * Time: 06:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VisBox {
    /// <summary>
    /// Description of TreeListView.
    /// </summary>
    public partial class TreeListView : VisElement {
        
        private class TreeViewItemBtnInfo {
            public Point Location = new Point(0, 0);
            public TreeListViewItem Node;
            
            public TreeViewItemBtnInfo(Point pt, ref TreeListViewItem node) {
                Location = pt;
                Node = node;
            }
        }
        
        private int _idNodeToShow = 0;
        
        private List<TreeListViewItem> _nodes = new List<TreeListViewItem>();
        
        [Category("VisBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<TreeListViewItem> Nodes {
            get { return _nodes; }
            set {_nodes = value; }
        }
        

        private List<TreeListViewColumnItem> _columns = new List<TreeListViewColumnItem>();
        
        [Category("VisBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<TreeListViewColumnItem> Columns {
            get { return _columns; }
            set { _columns = value; }
        }
        
        
        private int GetNumOfVisibleChildNodes(ref TreeListViewItem node) {
            int num = 0;
            for ( int idx = 0; idx < node.Nodes.Count; idx++ ) {
                TreeListViewItem tlvi = node.Nodes[idx];
                num++;
                if ( !tlvi.Collapsed ) {
                    num += GetNumOfVisibleChildNodes( ref tlvi );
                }
            }
            return num;
        }
        
        private int GetNumOfVisibleNodes() {
            int num = 0;
            for ( int idx = 0; idx < _nodes.Count; idx++ ) {
                TreeListViewItem tlvi = _nodes[idx];
                num++;
                if ( !tlvi.Collapsed ) {
                    num += GetNumOfVisibleChildNodes( ref tlvi );
                }
            }
            return num;
        }
        
        
        private int _smallestNodeHeight = int.MaxValue;
        private int GetHeightOfAllNodes(ref TreeListViewItem node) {
            int totalHeight = 0;
            int nodeHeight  = 0;
            for ( int idx = 0; idx < node.Nodes.Count; idx++ ) {
                TreeListViewItem tlvi = node.Nodes[idx];
                
                nodeHeight   = (int)tlvi.GetItemSize().Height;
                totalHeight += nodeHeight;
                if ( _smallestNodeHeight > nodeHeight ) {
                    _smallestNodeHeight = nodeHeight;
                }
                
                if ( !tlvi.Collapsed ) {
                    totalHeight += GetHeightOfAllNodes( ref tlvi );
                }
            }
            return totalHeight;
        }
        
        private int GetHeightOfAllNodes() {
            _smallestNodeHeight = int.MaxValue;
            int totalHeight     = 0;
            int nodeHeight      = 0;
            for ( int idx = 0; idx < _nodes.Count; idx++ ) {
                TreeListViewItem tlvi = _nodes[idx];
                nodeHeight   = (int)tlvi.GetItemSize().Height;
                totalHeight += nodeHeight;
                if ( _smallestNodeHeight > nodeHeight ) {
                    _smallestNodeHeight = nodeHeight;
                }
                
                if ( !tlvi.Collapsed ) {
                    totalHeight += GetHeightOfAllNodes( ref tlvi );
                }
            }
            
            vScrlBr.SmallChange = _smallestNodeHeight;
            return totalHeight + _smallestNodeHeight;
        }
        
        
        
        public void NumberOfVisibleNodesChanged() {
            int maxHeight = GetHeightOfAllNodes();
            vScrlBr.Maximum = maxHeight;
            vScrlBr.LargeChange = pMain.Height;
            if (maxHeight > pMain.Height) {
                vScrlBr.Visible = true;
            } else {
                vScrlBr.Visible = false;
                vScrlBr.Value = 0;
            }
            
        }
        
        private void ColumnWidthChanged() {
            int totalWidth = 0;
            for( int idx = 0; idx < _columns.Count; idx++ ) {
                totalWidth += _columns[idx].Width;
            }
            
            hScrlBr.Maximum = totalWidth;
            hScrlBr.LargeChange = pMain.Width;
            if ( totalWidth > pMain.Width ) {
                hScrlBr.Visible = true;
            } else {
                hScrlBr.Visible = false;
                hScrlBr.Value = 0;
            }
        }
        
        
        private List<TreeViewItemBtnInfo> _btns = new List<TreeViewItemBtnInfo>();
        private int _btnWidth    = 9;
        private int _btnHeight   = 9;
        
        private int _indent = 19;
        [Category("VisBox")]
        [DefaultValue(typeof(int), "19")]
        public int Indent {
            get { return _indent; }
            set { _indent = value; }
        }
        
        private Pen _penTreeLine { get; set; }
        public Pen TreeLine {
            get { return _penTreeLine; }
            set { _penTreeLine = value; }
        }
        
        
        private StringFormat _strFormatNodes = new StringFormat();
        public TreeListView() {
            InitializeComponent();
            
            
            _strFormatNodes.LineAlignment   = StringAlignment.Center;
            _strFormatNodes.Trimming        = StringTrimming.EllipsisCharacter;
            _strFormatNodes.FormatFlags     = StringFormatFlags.NoWrap;
            
            pMain.MouseWheel += PMainMouseWheel;
            
            typeof(Panel).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | 
                System.Reflection.BindingFlags.Instance | 
                System.Reflection.BindingFlags.NonPublic, 
                null, pMain, new object[] { true });
            
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint |
                    ControlStyles.ResizeRedraw, true );
            
            NumberOfVisibleNodesChanged();
        }
        
        
        
        
        public TreeListViewItem AddNode(TreeListViewItem subItem) {
            _nodes.Add( subItem );
            NumberOfVisibleNodesChanged();
            return subItem;
        }
        
        public TreeListViewItem AddNode(string text) {
            return AddNode( new TreeListViewItem( text ) );
        }
        
        public TreeListViewColumnItem AddColumn(TreeListViewColumnItem subItem) {
            _columns.Add( subItem );
            ColumnWidthChanged();
            return subItem;
        }
        
        public TreeListViewColumnItem AddColumn(string text) {
            return AddColumn( new TreeListViewColumnItem( text ) );
        }
        
        
        
        
        void VScrlBrValueChanged ( object sender, EventArgs e ) {
            this.Refresh();
        }
        
        void HScrlBrValueChanged ( object sender, EventArgs e ) {
            this.Refresh();
        }
       
        private void PMainMouseWheel(object sender, MouseEventArgs e) {
            try {
                int currVal = vScrlBr.Value;
                currVal -= vScrlBr.SmallChange * ( e.Delta > 0 ? 1 : -1 );
                if ( currVal < 0 ) { currVal = 0; }
                else if ( currVal >= ( vScrlBr.Maximum - vScrlBr.LargeChange ) ) {
                    currVal = vScrlBr.Maximum - vScrlBr.LargeChange;
                }
                vScrlBr.Value = currVal;
            } catch {}
        }
        
        void PMainSizeChanged ( object sender, EventArgs e ) {
            NumberOfVisibleNodesChanged();
        }
        
        void TreeListViewMouseUp ( object sender, MouseEventArgs e ) {
            Point ptClickOnControl = e.Location;
            Point ptBtnRel = new Point(0, 0);
            
            foreach ( TreeViewItemBtnInfo btn in _btns ) {
                ptBtnRel.X = btn.Location.X - ptClickOnControl.X;
                ptBtnRel.Y = btn.Location.Y - ptClickOnControl.Y;
                
                if ( !( ( ptBtnRel.X >= -_btnWidth/2 ) &&
                        ( ptBtnRel.X <= _btnWidth/2 ) ) )
                {
                    /* Click out of range OX relative to button */
                    continue;
                }
                
                if ( !( ( ptBtnRel.Y >= -_btnHeight/2 ) &&
                        ( ptBtnRel.Y <= _btnHeight/2 ) ) )
                {
                    /* Click out of range OY relative to button */
                    continue;
                }
                
                /* Click in range of button */
                btn.Node.Collapsed = !btn.Node.Collapsed;
                NumberOfVisibleNodesChanged();
                this.pMain.Invalidate();
                this.Invalidate();
                break;
            }
            
        }
        
        
        
        void PMainMouseDown ( object sender, MouseEventArgs e ) {
            
        }
        
        private Point _colMouseDownPoint = new Point(0, 0);
        private int _colMouseDownLastWidth = 0;
        private TreeListViewColumnItem _colMouseDown = null;
        void PMainMouseMove ( object sender, MouseEventArgs e ) {
            bool requiredRefresh = false;
            if ( _columns.Count > 0 ) {                
                Point ptRelMouse = new Point( e.X - _colStart.X, e.Y - _colStart.Y);
                
                if ( _colMouseDown != null ) {
                    if ( _colMouseDown.IsWidthChange ) {
                        _colMouseDown.Width = _colMouseDownLastWidth + ( e.X - _colMouseDownPoint.X );
                        requiredRefresh = true;
                        ColumnWidthChanged();
                    }
                }
                
                /* Check if mouse over columns header */
                if ( ( ptRelMouse.Y >= 0 ) && ( ptRelMouse.Y < _columnsHeaderHeight ) ) {
                    /* Mouse over columns header! */
                    foreach ( TreeListViewColumnItem col in _columns ) {
                        if ( ( ptRelMouse.X > 0 ) && ( ptRelMouse.X <= col.Width + 1 ) ) {
                            
                            if ( e.Button == MouseButtons.Left ) {
                                /* MouseDown now! */
                                if ( !col.IsMouseDown && ( _colMouseDown == null ) ) {
                                    /* Mouse down first! */
                                    _colMouseDownPoint = new Point( e.X, e.Y );
                                    _colMouseDownLastWidth = col.Width;
                                    _colMouseDown = col;
                                    if ( ptRelMouse.X > ( col.Width - 3 ) ) { col.IsWidthChange = true; }
                                }
                                col.IsMouseDown = true;
                            } else {
                                if ( col.IsMouseDown ) {
                                    /* Last event of mouse down */
                                    _colMouseDown = null;
                                }
                                col.IsMouseDown = false;
                                col.IsWidthChange = false;
                            }
                            
                            /* Found column header under mouse pointer */
                            if ( ptRelMouse.X > ( col.Width - 3 ) ) {
                                /* Mouse pointer on splitter */
                                pMain.Cursor = Cursors.SizeWE;
                            } else {
                                pMain.Cursor = Cursors.Default;
                            }
                            
                            if ( !col.IsMouseOver ) {
                                requiredRefresh = true;
                            }
                            col.IsMouseOver = true;
                        } else {
                            if ( col.IsMouseOver ) { requiredRefresh = true; }
                            col.IsMouseOver = false;
                        }
                        
                        ptRelMouse.X -= col.Width;
                    }
                } else {
                    foreach ( TreeListViewColumnItem col in _columns ) {
                        if ( col.IsMouseOver ) { requiredRefresh = true; }
                        col.IsMouseOver = false;
                        col.IsMouseDown = false;
                    }
                    pMain.Cursor = Cursors.Default;
                    _colMouseDown = null;
                }
            }
            
            if ( requiredRefresh ) {
                pMain.Refresh();
            }
        }
        
        private int _numberOfDrawnNodes = 0;
        void TreeListViewPaint ( object sender, PaintEventArgs e ) {
            _numberOfDrawnNodes = 0;
            Graphics gr = e.Graphics;
            base.OnPaint(e);
            penTreeDottedLine.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            
            Rectangle areaToDraw = GetInnerSpace();
            gr.SetClip( areaToDraw );
            RectangleF maxClipBounding = gr.ClipBounds;
            
            areaToDraw.X -= hScrlBr.Value;
            
            if ( _columns.Count > 0 ) {
                DrawColumnHeaders( ref gr, ref areaToDraw );
                areaToDraw.Y += 1;
                areaToDraw.Height -= 1;
                maxClipBounding.Y = areaToDraw.Y;
                maxClipBounding.Height = areaToDraw.Height;
                
                gr.SetClip( maxClipBounding );
            }
            
            areaToDraw.Y -= vScrlBr.Value;
            int height = this.Height;
            
            bool reachedBottomEndOfCanvas = false;
            
            for ( int idNode = _idNodeToShow; idNode < _nodes.Count; idNode++ ) {
                TreeListViewItem nodeI = _nodes[idNode];
                reachedBottomEndOfCanvas = DrawNode( ref gr, ref nodeI, ref areaToDraw, maxClipBounding, idNode == ( _nodes.Count - 1 ) );
                if ( reachedBottomEndOfCanvas ) {
                    break;
                }
            }
            
        }
        
        
        private int _columnsHeaderHeight    = 0;
        private Point _colStart             = new Point(0, 0);
        
        private int DrawColumnHeaders( ref Graphics gr, ref Rectangle areaToDraw ) {
            _columnsHeaderHeight    = 0;
            _colStart.Y             = 0;
            
            int xOffset = 0;
            /* Get maximum height of columns header */
            foreach ( TreeListViewColumnItem col in _columns ) {
                int colHdrHeight = (int)col.GetItemSize().Height;
                if ( _columnsHeaderHeight < colHdrHeight ) {
                    _columnsHeaderHeight = colHdrHeight;
                }
            }
            
            _colStart.X = areaToDraw.X;
            _colStart.Y = areaToDraw.Y;

            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Trimming = StringTrimming.EllipsisCharacter;
            format.FormatFlags = StringFormatFlags.NoWrap;
            
            foreach ( TreeListViewColumnItem col in _columns ) {
                int treeLineX = areaToDraw.X + Indent / 2;
                int treeLineY = (int)( areaToDraw.Y + _columnsHeaderHeight / 2);
                
                Brush brText = new SolidBrush(col.ForeColor);
                
                col.BoundBox.X = areaToDraw.X + xOffset + 1;
                col.BoundBox.Y = areaToDraw.Y;
                
                if ( col.IsMouseOver ) {
                    gr.FillRectangle( new SolidBrush(Color.Gainsboro),
                                     areaToDraw.X + xOffset + 1, areaToDraw.Y,
                                     col.Width - 1, _columnsHeaderHeight + 1 );
                }

                gr.DrawString(col.Text, col.Font, brText,
                              new RectangleF(areaToDraw.X + xOffset + 1, areaToDraw.Y,
                                     col.Width - 1, _columnsHeaderHeight + 1 ),
                              format);
                
                xOffset += col.Width;
                gr.DrawLine( penColLine,
                            areaToDraw.X + xOffset, areaToDraw.Y,
                            areaToDraw.X + xOffset, areaToDraw.Y + _columnsHeaderHeight );
            }
            
            areaToDraw.Y += _columnsHeaderHeight + 1;
            areaToDraw.Height -= _columnsHeaderHeight + 1;
            
            return _columnsHeaderHeight;
        }
        
        Pen     penColLine          = new Pen( Color.DimGray );
        Pen     penBtnBorder        = new Pen( Color.DimGray );
        Brush   brBtnInner          = new SolidBrush( Color.LightGray );
        Pen     penBtnIconLine      = new Pen( Color.RoyalBlue );
        Pen     penTreeDottedLine   = new Pen( Color.DimGray );
        
        private void DrawNodeBtn( ref Graphics gr, ref TreeListViewItem node, int btnCenterX, int btnCenterY, bool collapsed ) {
            gr.FillRectangle( brBtnInner, btnCenterX - _btnWidth/2, btnCenterY - _btnHeight/2, _btnWidth - 1, _btnHeight - 1 );
            gr.DrawRectangle( penBtnBorder, btnCenterX - _btnWidth/2, btnCenterY - _btnHeight/2, _btnWidth - 1, _btnHeight - 1 );
            
            _btns.Add( new TreeViewItemBtnInfo( new Point( btnCenterX, btnCenterY ), ref node ) );
            
            // -
            gr.DrawLine( penBtnIconLine, btnCenterX - _btnWidth/4, btnCenterY, btnCenterX + _btnWidth/4, btnCenterY );
            
            if ( collapsed ) {
                // |
                gr.DrawLine( penBtnIconLine, btnCenterX, btnCenterY - _btnHeight/4, btnCenterX, btnCenterY + _btnHeight/4 );
            }
        }
        
        
        private bool DrawNode( ref Graphics gr, ref TreeListViewItem node, ref Rectangle areaToDraw, RectangleF maxClipBounding, bool isLastChild ) {
            bool reachedBottomEndOfCanvas = false;
            
            if ( areaToDraw.Y >= maxClipBounding.Y + maxClipBounding.Height ) {
                /* There is no space to draw so quit! */
                return reachedBottomEndOfCanvas = true;
            }
            
            int     parentX     = areaToDraw.X;
            
            SizeF   nodeSize    = node.GetItemSize();
            int     rowHeight   = (int)nodeSize.Height;
            
            int     treeLineX   = areaToDraw.X + Indent / 2;
            int     treeLineY   = areaToDraw.Y + rowHeight / 2;
            
            RectangleF previousClip = gr.ClipBounds;
            RectangleF columnClip   = gr.ClipBounds;
            
            if ( areaToDraw.Y > -rowHeight ) {
                /* At least part of node is on visible screen, so draw it! */
                
                RectangleF strBox = new RectangleF(
                    areaToDraw.X + Indent, areaToDraw.Y,
                    areaToDraw.Width, rowHeight );
                
                /* Draw first column, tree lines and buttons */
                if ( _columns.Count > 0 ) {
                    columnClip.X = Math.Max( _columns[0].BoundBox.Left, maxClipBounding.Left );
                    columnClip.Width = _columns[0].BoundBox.Right - columnClip.X;
                    strBox.X = Math.Max( areaToDraw.X + Indent, _columns[0].BoundBox.Left );
                    strBox.Width = columnClip.Width;
                }
                gr.SetClip( columnClip );
                
                /* Draw first column text ============================================== */
                gr.DrawString(node.Text, node.Font, node.Brush, strBox, _strFormatNodes);
                        
                /* Draw tree lines ===================================================== */
                /* Draw horizontal dotted line to node's text */
                gr.DrawLine( penTreeDottedLine, treeLineX, treeLineY, areaToDraw.X + Indent, treeLineY );
                /* Draw vertical line */
                gr.DrawLine( penTreeDottedLine, treeLineX, areaToDraw.Y, treeLineX,
                            isLastChild ? treeLineY : areaToDraw.Y + rowHeight );
                
                /* Draw other columns data */
                for ( int idx = 1; idx < _columns.Count && (idx - 1) < node.Subitems.Count; idx++ ) {
                    columnClip.X = Math.Max( _columns[idx].BoundBox.Left , previousClip.X );
                    columnClip.Width = _columns[idx].BoundBox.Right - columnClip.X;
                    
                    gr.SetClip( columnClip );
                    
                    strBox = new RectangleF(
                        Math.Max( areaToDraw.X + Indent, _columns[idx].BoundBox.Left ),
                        areaToDraw.Y, _columns[idx].Width, rowHeight );
                    strBox.Width = _columns[idx].BoundBox.Right - strBox.Left;
                    gr.DrawString(node.Subitems[idx-1].Text,
                                  node.Subitems[idx-1].Font, node.Subitems[idx-1].Brush, strBox, _strFormatNodes);
                }
                
                _numberOfDrawnNodes++;
            }
            areaToDraw.Y += rowHeight;
            areaToDraw.Height -= rowHeight;
            
            gr.SetClip( previousClip );
            if ( node.Nodes.Count > 0 ) {
                if ( !node.Collapsed ) {
                    /* This node is not collapsed so draw his childs */
                    areaToDraw.X += Indent;
                    for ( int idNode = 0; idNode < node.Nodes.Count; idNode++ ) {
                        TreeListViewItem nodeI = node.Nodes[idNode];
                        reachedBottomEndOfCanvas = DrawNode( ref gr, ref nodeI, ref areaToDraw, maxClipBounding, idNode == ( node.Nodes.Count - 1 ) );
                        if ( reachedBottomEndOfCanvas ) { break; }
                    }
                }
                
                if ( areaToDraw.Y > -rowHeight ) {
                    gr.SetClip( previousClip );
                    if ( _columns.Count > 0 ) {
                        columnClip.X = Math.Max( _columns[0].BoundBox.Left , previousClip.X );
                        columnClip.Width = _columns[0].BoundBox.Right - columnClip.X;
                        gr.SetClip( columnClip );
                    }
                    
                    /* At least part of node is on visible screen, so draw it! */
                    if ( !isLastChild ) {
                        gr.DrawLine( penTreeDottedLine, treeLineX, treeLineY, treeLineX, areaToDraw.Y );
                    }
                    
                    /* Draw tree buttons =================================================== */
                    /* This node does have at least one child, so draw button to collapse/expand */
                    DrawNodeBtn( ref gr, ref node, treeLineX, treeLineY, node.Collapsed );
                }
                gr.SetClip( previousClip );
            }
            areaToDraw.X = parentX;
            return reachedBottomEndOfCanvas;
        }
        
        private void SetNewLogicSize(Size newLogicSize) {
            this.AutoScrollMinSize = newLogicSize;
        }
        
        
        
    }
    
    
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TreeListViewItem : TreeListViewSubItem {
        
        private List<TreeListViewSubItem> _subitems = new List<TreeListViewSubItem>();
         
        [Category("VisBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<TreeListViewSubItem> Subitems {
            get { return _subitems; }
            set { _subitems = value; }
        }
        
        public bool Collapsed { get; set; }
        
        private List<TreeListViewItem> _nodes = new List<TreeListViewItem>();
        [Category("VisBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<TreeListViewItem> Nodes {
            get { return _nodes; }
            set {_nodes = value; }
        }
        
        public TreeListViewItem() { }
        
        public TreeListViewItem(string text) {
            if ( text == null ) throw new ArgumentNullException("text");
            this.Text = text;
            
        }
        
        public TreeListViewSubItem AddSubitem(TreeListViewSubItem subItem) {
            _subitems.Add( subItem );
            return subItem;
        }
        
        public TreeListViewSubItem AddSubitem(string text) {
            return AddSubitem( new TreeListViewSubItem( text ) );
        }
        
    }
    
    
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TreeListViewColumnItem : TreeListViewSubItem {
        
        public Rectangle BoundBox = new Rectangle(0, 0, 75, 20);
        
        public int Width {
            get { return BoundBox.Width; }
            set { BoundBox.Width = value; }
        }
        
        public bool IsWidthChange   = false;
        public TreeListViewColumnItem() { }
        
        public TreeListViewColumnItem(string text) {
            if ( text == null ) throw new ArgumentNullException("text");
            this.Text = text;
        }
        
    }
    
    
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TreeListViewSubItem {
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
        
        
        private static Bitmap _bmp = new Bitmap(10, 10);
        private static Graphics _gr = Graphics.FromImage( _bmp );
        
        public bool IsMouseOver = false;
        public bool IsMouseDown = false;
        
        public TreeListViewSubItem() { }
        
        public TreeListViewSubItem(string text) {
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
