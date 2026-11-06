/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 6.11.2026
 * Time: 16:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisBox {
    /// <summary>
    /// Description of TreeDetailsView_Behaviour.
    /// </summary>
    partial class TreeDetailsView {
        
        #region PRIVATE_PROPS
        private int _smallestNodeHeight = int.MaxValue;
        private Point _colMouseDownPoint = new Point(0, 0);
        private int _colMouseDownLastWidth = 0;
        private TreeDetailsViewColumnItem _colMouseDown = null;
        private bool requiredRefresh = false;
        #endregion
        
        private void InitBehaviour() {
            _timerRefresh.Interval = 50;
            _timerRefresh.Tick += MouseMoveTimer_Tick;
            _timerRefresh.Start();
        }
        
        private void RequestRefresh() {
            requiredRefresh = true;
        }
        private void MouseMoveTimer_Tick ( object sender, EventArgs e ) {
            if ( requiredRefresh ) {
                requiredRefresh = false;
                pMain.Refresh();
            }
        }
        
        
        private int GetNumOfVisibleChildNodes(ref TreeDetailsViewItem node) {
            int num = 0;
            for ( int idx = 0; idx < node.Nodes.Count; idx++ ) {
                TreeDetailsViewItem tlvi = node.Nodes[idx];
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
                TreeDetailsViewItem tlvi = _nodes[idx];
                num++;
                if ( !tlvi.Collapsed ) {
                    num += GetNumOfVisibleChildNodes( ref tlvi );
                }
            }
            return num;
        }
        
        
        private int GetHeightOfAllNodes(ref TreeDetailsViewItem node) {
            int totalHeight = 0;
            int nodeHeight  = 0;
            for ( int idx = 0; idx < node.Nodes.Count; idx++ ) {
                TreeDetailsViewItem tlvi = node.Nodes[idx];
                
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
                TreeDetailsViewItem tlvi = _nodes[idx];
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
            try {
                totalHeight += _smallestNodeHeight * 2;
            } catch {}
            
            return totalHeight;
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
        
        
        private void SetNewLogicSize(Size newLogicSize) {
            this.AutoScrollMinSize = newLogicSize;
        }
        
        
        private void VScrlBrValueChanged ( object sender, EventArgs e ) {
            RequestRefresh();
        }
        
        private void HScrlBrValueChanged ( object sender, EventArgs e ) {
            RequestRefresh();
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
        
        
        private void PMainSizeChanged ( object sender, EventArgs e ) {
            NumberOfVisibleNodesChanged();
            ColumnWidthChanged();
        }
        
        /// <summary>
        /// Process expand/collapse buttons click release
        /// </summary>
        private void ProcessMouseUpForCollapseExpandButtons(Point ptClickOnControl) {
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
        
        private void TreeDetailsViewMouseUp ( object sender, MouseEventArgs e ) {
            ProcessMouseUpForCollapseExpandButtons( e.Location );
        }
        
        
        private void PMainMouseMove ( object sender, MouseEventArgs e ) {
            bool requiredRefreshDuringMove = false;
            if ( _columns.Count > 0 ) {
                Point ptRelMouse = new Point( e.X - _colStart.X, e.Y - _colStart.Y);
                
                if ( _colMouseDown != null ) {
                    if ( _colMouseDown.IsWidthChange ) {
                        int newWidth = _colMouseDownLastWidth + ( e.X - _colMouseDownPoint.X );;
                        if ( newWidth >= _colMouseDown.MinimumWidth ) {
                            _colMouseDown.Width = newWidth;
                            requiredRefreshDuringMove = true;
                            ColumnWidthChanged();
                        }
                    }
                }
                
                /* Check if mouse over columns header */
                if ( ( ptRelMouse.Y >= 0 ) && ( ptRelMouse.Y < _columnsHeaderHeight ) ) {
                    /* Mouse over columns header! */
                    foreach ( TreeDetailsViewColumnItem col in _columns ) {
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
                            
                            requiredRefreshDuringMove |= !col.IsMouseOver;
                            col.IsMouseOver = true;
                        } else {
                            requiredRefreshDuringMove |= col.IsMouseOver;
                            col.IsMouseOver = false;
                        }
                        
                        ptRelMouse.X -= col.Width;
                    }
                } else {
                    foreach ( TreeDetailsViewColumnItem col in _columns ) {
                        requiredRefreshDuringMove |= col.IsMouseOver;
                        col.IsMouseOver = false;
                        col.IsMouseDown = false;
                    }
                    pMain.Cursor = Cursors.Default;
                    _colMouseDown = null;
                }
            }
            requiredRefreshDuringMove = requiredRefreshDuringMove || CheckForMouseOnTreeDetailViewItem( e.X, e.Y );
            
            if ( requiredRefreshDuringMove ) { RequestRefresh(); }
        }
        
        private bool CheckForMouseOnTreeDetailViewItem( int mouseX, int mouseY ) {
            bool statusChanged = false;
            foreach ( TreeDetailsViewItem node in _nodes ) {
                statusChanged = statusChanged || CheckForMouseOnTreeDetailViewItemInternal( mouseX, mouseY, node );
            }
            return statusChanged;
        }
        
        private bool CheckForMouseOnTreeDetailViewItemInternal( int mouseX, int mouseY, TreeDetailsViewItem node ) {
            bool statusChanged = false;
            if ( !node.Collapsed ) {
                try {
                    foreach ( TreeDetailsViewItem nodeChild in node.Nodes ) {
                        statusChanged = statusChanged || CheckForMouseOnTreeDetailViewItemInternal( mouseX, mouseY, nodeChild );
                    }
                } catch {}
            }
            
            bool lastMouseOnItem = node.IsMouseOver;
            
            Point mouseRel = new Point( mouseX - node.AreaOnCanvas.X , mouseY - node.AreaOnCanvas.Y );
            if ( ( mouseRel.Y >= 0 ) && ( mouseRel.Y <= node.AreaOnCanvas.Height ) ) { 
                if ( ( mouseRel.X >= 0 ) && ( mouseRel.X <= node.AreaOnCanvas.Width ) ) { 
                    /* MousePointer on element */
                    node.IsMouseOver = true;
                } else { node.IsMouseOver = false; }
            } else { node.IsMouseOver = false; }
            
            if          ( !lastMouseOnItem && node.IsMouseOver ) {
                /* Mouse just entered on item! */
                if ( this.ItemMouseEnter != null ) {
                    this.ItemMouseEnter( node, new EventArgs() );
                }
                statusChanged = true;
            } else if   ( lastMouseOnItem && !node.IsMouseOver ) {
                /* Mouse just leaved item! */
                if ( this.ItemMouseLeave != null ) {
                    this.ItemMouseLeave( node, new EventArgs() );
                }
                statusChanged = true;
            }
            return statusChanged;
        }
        
    }
}
