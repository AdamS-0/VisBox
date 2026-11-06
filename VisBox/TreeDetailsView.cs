/*
 * Created by SharpDevelop.
 * User: AdamS-0
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
    /// Description of TreeDetailsView.
    /// </summary>
    public partial class TreeDetailsView : VisElement {
        
        public delegate void ItemMouseEvent(object sender, EventArgs e);
        public ItemMouseEvent ItemMouseEnter;
        public ItemMouseEvent ItemMouseLeave;
        
        #region PRIVATE_PROPS        
        private Timer _timerRefresh = new Timer();
        private List<TreeDetailsViewItem> _nodes = new List<TreeDetailsViewItem>();
        
        private List<TreeViewItemBtnInfo> _btns = new List<TreeViewItemBtnInfo>();
        private StringFormat _strFormatNodes = new StringFormat();
        #endregion
        
        #region PUBLIC_PROPS
        [Category("VisBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<TreeDetailsViewItem> Nodes {
            get { return _nodes; }
            set {_nodes = value; }
        }
        
        private int _indent = 19;
        [Category("VisBox")]
        [DefaultValue(typeof(int), "19")]
        public int Indent {
            get { return _indent; }
            set { _indent = value; }
        }
        
        private List<TreeDetailsViewColumnItem> _columns = new List<TreeDetailsViewColumnItem>();
        [Category("VisBox")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<TreeDetailsViewColumnItem> Columns {
            get { return _columns; }
            set { _columns = value; }
        }
        
        private Pen _penTreeLine { get; set; }
        public Pen TreeLine {
            get { return _penTreeLine; }
            set { _penTreeLine = value; }
        }
        
        private bool _fitColumnOnDoubleClick = true;
        [Category("VisBox")]
        [DefaultValue(typeof(bool), "true")]
        public bool FitColumnOnDoubleClick {
            get { return _fitColumnOnDoubleClick; }
            set { _fitColumnOnDoubleClick = value; }
        }
        #endregion

        public TreeDetailsView() {
            InitializeComponent();
            this.ResizeDelay = 300;
            this.ResizeDelayEnabled = true;
            
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
            
            InitBehaviour();
            NumberOfVisibleNodesChanged();
        }
        
        public TreeDetailsViewItem AddNode(TreeDetailsViewItem subNode) {
            _nodes.Add( subNode );
            NumberOfVisibleNodesChanged();
            return subNode;
        }
        
        public TreeDetailsViewItem AddNode(string text) {
            return AddNode( new TreeDetailsViewItem( text ) );
        }
        
        public TreeDetailsViewColumnItem AddColumn(TreeDetailsViewColumnItem subItem) {
            _columns.Add( subItem );
            ColumnWidthChanged();
            return subItem;
        }
        
        public TreeDetailsViewColumnItem AddColumn(string text) {
            return AddColumn( new TreeDetailsViewColumnItem( text ) );
        }
        
        public void NumberOfVisibleNodesChanged() {
            int maxHeight = GetHeightOfAllNodes();
            vScrlBr.Maximum = maxHeight;
            if ( vScrlBr.Maximum == vScrlBr.Minimum ) {
                vScrlBr.Maximum = vScrlBr.Minimum + 1;
            }
            vScrlBr.LargeChange = pMain.Height;
            if (maxHeight > pMain.Height) {
                vScrlBr.Visible = true;
            } else {
                vScrlBr.Visible = false;
                try {
                    vScrlBr.Value = 0;
                } catch {}
            }
        }
        
    }
    
}
