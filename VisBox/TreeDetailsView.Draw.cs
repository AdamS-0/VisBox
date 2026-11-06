/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 6.11.2026
 * Time: 15:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisBox {
    /// <summary>
    /// Description of TreeDetailsView_Draw.
    /// </summary>
    partial class TreeDetailsView {
        
        #region PRIVATE_PROPS
        private const int _btnWidth     = 9;
        private const int _btnHeight    = 9;
        
        private int _numberOfDrawnNodes = 0;
        private int _columnsHeaderHeight    = 0;
        private Point _colStart             = new Point(0, 0);
        
        private Pen     penColLine          = new Pen( Color.DimGray );
        private Pen     penBtnBorder        = new Pen( Color.DimGray );
        private Brush   brBtnInner          = new SolidBrush( Color.LightGray );
        private Pen     penBtnIconLine      = new Pen( Color.RoyalBlue );
        private Pen     penTreeDottedLine   = new Pen( Color.DimGray );
        #endregion
        
        private void TreeDetailsViewPaint ( object sender, PaintEventArgs e ) {
            _btns.Clear();
            
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
            
            for ( int idNode = 0; idNode < _nodes.Count; idNode++ ) {
                TreeDetailsViewItem nodeI = _nodes[idNode];
                reachedBottomEndOfCanvas = DrawNode( ref gr, ref nodeI, ref areaToDraw, maxClipBounding, idNode == ( _nodes.Count - 1 ) );
                if ( reachedBottomEndOfCanvas ) {
                    break;
                }
            }
            
        }
        
        private int DrawColumnHeaders( ref Graphics gr, ref Rectangle areaToDraw ) {
            _columnsHeaderHeight    = 0;
            _colStart.Y             = 0;
            
            int xOffset = 0;
            /* Get maximum height of columns header */
            foreach ( TreeDetailsViewColumnItem col in _columns ) {
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
            
            foreach ( TreeDetailsViewColumnItem col in _columns ) {
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
        
        private void DrawNodeBtn( ref Graphics gr, ref TreeDetailsViewItem node, int btnCenterX, int btnCenterY, bool collapsed ) {
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
        
        private bool DrawNode( ref Graphics gr, ref TreeDetailsViewItem node, ref Rectangle areaToDraw, RectangleF maxClipBounding, bool isLastChild ) {
            bool reachedBottomEndOfCanvas = false;
            
            if ( areaToDraw.Y >= maxClipBounding.Y + maxClipBounding.Height ) {
                /* There is no space to draw so quit! */
                return reachedBottomEndOfCanvas = true;
            }
            
            int         parentX         = areaToDraw.X;
            
            SizeF       nodeSize        = node.GetItemSize();
            int         rowHeight       = (int)nodeSize.Height;
            
            int         treeLineX       = areaToDraw.X + Indent / 2;
            int         treeLineY       = areaToDraw.Y + rowHeight / 2;
            
            RectangleF  previousClip    = gr.ClipBounds;
            RectangleF  columnClip      = gr.ClipBounds;
            string      itemText        = "";
            
            if ( areaToDraw.Y > -rowHeight ) {
                /* At least part of node is on visible screen, so draw it! */
                
                node.AreaOnCanvas.Y = areaToDraw.Y;
                node.AreaOnCanvas.X = 0;
                node.AreaOnCanvas.Width = areaToDraw.Width;
                node.AreaOnCanvas.Height = rowHeight;
                
                if ( node.IsMouseOver ) {
                    gr.FillRectangle( node.BrushSelection, node.AreaOnCanvas );
                }
                
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
                itemText = node.Text;
                try {
                    if ( node.ShowRelatedObject ) {
                        itemText = node.GetRelatedObject().ToString();
                    }
                } catch {}
                
                gr.DrawString( itemText, node.Font, node.Brush, strBox, _strFormatNodes);
                        
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
                        Math.Max( areaToDraw.X, _columns[idx].BoundBox.Left ),
                        areaToDraw.Y, _columns[idx].Width, rowHeight );
                    strBox.Width = _columns[idx].BoundBox.Right - strBox.Left;
                    
                    itemText = node.Subitems[idx-1].Text;
                    try {
                        if ( ( node.Subitems[idx-1].ShowRelatedObject ) && 
                            ( node.Subitems[idx-1].GetRelatedObject != null ) )
                        {
                            object relObj = node.Subitems[idx-1].GetRelatedObject();
                            itemText = relObj.ToString();
                        }
                    } catch {}
                    
                    gr.DrawString(itemText, node.Subitems[idx-1].Font,
                                  node.Subitems[idx-1].Brush, strBox, _strFormatNodes);
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
                        TreeDetailsViewItem nodeI = node.Nodes[idNode];
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
        
        
    }
}
