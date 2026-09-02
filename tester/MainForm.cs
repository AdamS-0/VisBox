/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 02.05.2021
 * Time: 08:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using VisBox;

namespace tester
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form {
		
		
		Random rand = new Random();
		static List<float> dataX = new List<float>();
		static List<float> dataY = new List<float>();
        static List<float> dataY2 = new List<float>();
        
		int nSampl = 200;
		
		VisBox.Series ser1 = new VisBox.Series(ref dataX, ref dataY, new VisBox.Marker(Color.Yellow, ' '), new Pen(Color.Blue), "Data1");
		VisBox.Series ser2 = new VisBox.Series(ref dataX, ref dataY2, new VisBox.Marker(Color.Purple, ' '), new Pen(Color.Yellow), "Data2");
        
		public MainForm() {
			InitializeComponent();
			
			displaySegmentManager1.Displays.Add( displaySegment1 );
			displaySegmentManager1.Displays.Add( displaySegment2 );
			displaySegmentManager1.Displays.Add( displaySegment3 );
			displaySegmentManager1.Displays.Add( displaySegment4 );
			displaySegmentManager1.Displays.Add( displaySegment5 );
			displaySegmentManager1.Displays.Add( displaySegment6 );
			
			displaySegmentManager2.Displays.Add( display14Segment1 );
			displaySegmentManager2.Displays.Add( display14Segment2 );
			displaySegmentManager2.Displays.Add( display14Segment3 );
			displaySegmentManager2.Displays.Add( display14Segment4 );
			displaySegmentManager2.Displays.Add( display14Segment5 );
			displaySegmentManager2.Displays.Add( display14Segment6 );
			displaySegmentManager2.Displays.Add( display14Segment7 );
			displaySegmentManager2.Displays.Add( display14Segment8 );
			displaySegmentManager2.Displays.Add( display14Segment9 );
			displaySegmentManager2.Displays.Add( display14Segment10 );
			
//			displaySegmentManager3.Displays.Add( display14Segment11 );
//			displaySegmentManager3.Displays.Add( display14Segment12 );
//			displaySegmentManager3.Displays.Add( display14Segment13 );
//			displaySegmentManager3.Displays.Add( display14Segment14 );
//			displaySegmentManager3.Displays.Add( display14Segment15 );
//			displaySegmentManager3.Displays.Add( display14Segment16 );
			
			for( int i = 0; i < nSampl; i++ ) {
				dataX.Add(i);
				dataY.Add(0);
				dataY2.Add(0);
			}
			
			plot1.AddSeries(ref ser1);
//			plot1.AddSeries(ref ser2);
			
//			plot1.ColorInner = Color.Black;
//			plot1.gridY.Pen.Color = Color.Green;
//			ser1.Pen.Color = Color.LightBlue;
//			plot1.AxisLimitsY.Min = -.4f;
//			plot1.AxisLimitsY.Max = 1.1f;
//			plot1.AxisLimitsY.Autoscale = false;
//			plot1.gridY.Dots = new List<VisBox.GridDot> { new VisBox.GridDot(0, "zero"), new VisBox.GridDot(1, "One"), new VisBox.GridDot(-.1f, "negative") };
//			plot1.gridY.Format = "0.000";
//			
//			plot1.gridYminor.GridOn = true;
//			plot1.gridYminor.ScaleFactor = 0.25f;
//			plot1.gridYminor.ShowLables = false;

			
//			TreeDetailsView treeDetailsView1 = new TreeDetailsView();
			treeDetailsView1.Left = 700;
			treeDetailsView1.Top = 100;
			treeDetailsView1.FlatStyle = VisBox.VisElement.VisFlatStyle.Collapsed;
			treeDetailsView1.Width = 400;
			treeDetailsView1.Height = 120;
//			treeDetailsView1.Columns.Clear();
			treeDetailsView1.Nodes.Clear();
            for (int idx = 0; idx < 10; idx++) {
                TreeDetailsViewItem ti = treeDetailsView1.AddNode( new TreeDetailsViewItem( "Node idx: " + idx ) );
                for (int idx2 = 0; idx2 < 10; idx2++) {
                    ti.AddSubNode( "Node idx: " + idx + (char)('A' + idx2) );
                }
            }
            
//			Controls.Add( treeDetailsView1 );
//			treeDetailsView1.BringToFront();
			
//			treeDetailsView1.AddColumn( "Name" );
//			treeDetailsView1.AddColumn( "Type" );
//			treeDetailsView1.AddColumn( "Value" );
//            
//            TreeDetailsViewItem trvi = new TreeDetailsViewItem("Node A");
//            
//            TreeDetailsViewItem trviA2 = new TreeDetailsViewItem( "Node A2");
//            trviA2.Font = new Font( "Times New Roman", 15 );
//            trviA2.Nodes.Add( new TreeDetailsViewItem("A2a") );
//            trviA2.Nodes.Add( new TreeDetailsViewItem("A2b") );
//            trviA2.Subitems.Add( new TreeDetailsViewSubItem("test1") );
//            trviA2.Subitems.Add( new TreeDetailsViewSubItem("test2") );
//            trvi.Nodes.Add( new TreeDetailsViewItem( "Node A1") );
//            trvi.Nodes.Add( trviA2 );
//            trvi.Nodes.Add( new TreeDetailsViewItem( "Node A3") );
//            
//            treeDetailsView1.Nodes.Add( trvi );
//            treeDetailsView1.Nodes.Add( new TreeDetailsViewItem("Node B") );
//            treeDetailsView1.Nodes.Add( new TreeDetailsViewItem("Node C") );
////            treeDetailsView1.Nodes.Add( new TreeDetailsViewItem("Node D") );
////            treeDetailsView1.Nodes.Add( new TreeDetailsViewItem("Node E") );
////            treeDetailsView1.Nodes.Add( new TreeDetailsViewItem("Node F") );
////            treeDetailsView1.Nodes.Add( new TreeDetailsViewItem("Node G") );
////            treeDetailsView1.Nodes.Add( new TreeDetailsViewItem("Node H") );
////            treeDetailsView1.Nodes.Add( new TreeDetailsViewItem("Node I") );
////            treeDetailsView1.Nodes.Add( new TreeDetailsViewItem("Node J") );
////            treeDetailsView1.Nodes.Add( new TreeDetailsViewItem("Node K") );
////            treeDetailsView1.Nodes.Add( new TreeDetailsViewItem("Node L") );
////            
////            for (int idx = 0; idx < 1000; idx++) {
////                treeDetailsView1.Nodes.Add( new TreeDetailsViewItem("Node idx: " + idx) );
////            }
            
            TreeDetailsViewItem tdvi = treeDetailsView1.AddNode( "Related object!" );
            TreeDetailsViewSubItem tdvsi = tdvi.AddSubitem("Empty string?");
            
//            tdvsi.GetRelatedObject = () => zipBar7.Value;
            
            tdvsi.ShowRelatedObject = true;
            treeDetailsView1.NumberOfVisibleNodesChanged();
            treeDetailsView1.ItemMouseEnter += TreeDetailsView1ItemMouseEnter;
		}
		
		private void TreeDetailsView1ItemMouseEnter(object sender, EventArgs e) {
		    int dummy1 = 0;
		    TreeDetailsViewItem node = sender as TreeDetailsViewItem;
		    label3.Text = node.Text;
		}
		
		
		void MainFormLoad(object sender, EventArgs e) {
			timer1.Start();
			displaySegmentManager2.ShowString( "2.1/\\   \\/" );
			
			lcdDisplay1.SetCustomCharacter( 0, new byte[]{ 0x08, 0x08, 0x2A, 0x1C, 0x08 }, 5 );
			//lcdDisplay1.Text = "" + (char)0 + "A";
			lcdDisplay1.Clear();
			lcdDisplay1.Print( "" + (char)0 + "A" );
		}
		
		
		int ic = '0', iLoading = 0;
		int iSegMan = 0;
		void Timer1Tick(object sender, EventArgs e) {
			//if( bar1.Value > 1 ) bar1.Value = 0;
			//bar1.Value += 0.1f;
//			lamp1.Toggle();
			
//			segmentDisplay1.ShowChar( (char)ic );
			
			Stopwatch sp = new Stopwatch();
			sp.Start();
			analogMeter1.Value = zipBar2.Value;
//			analogMeter1.Value += (float)rand.Next(-2, 3)/100;
			//analogMeter1.Value = (float)( iSegMan / 10 );
			analogMeter2.Value = (float)( iSegMan % 100 )/100;
			
			
			// rysowanie wykresu
			
			for( int idx = 0; idx < nSampl - 1; idx++) {
			    dataY[idx] = dataY[idx + 1];
			    dataY2[idx] = dataY2[idx+1];
			}
			dataY[nSampl - 1] = analogMeter1.Value;
			dataY2[nSampl - 1] = analogMeter2.Value;
            
//			if( dataYI >= nSampl ) dataYI = 0;
//			dataY[dataYI++] = 12*analogMeter1.Value;
			plot1.Draw();
			
			
			string str = (-iSegMan).ToString( "0000" );
			//string str = Cursor.Position.X.ToString( "000000" );
			
			string pi = (controlKnob1.Value*100).ToString("+00.00;-00.00") + Math.PI.ToString( "0.0000" );
			if( !switch1.State ) pi = "          ";
			
			displaySegmentManager1.ShowString( str );
			displaySegmentManager2.ShowString( pi );
			
//			lcdDisplay1.Text = "" + (char)0 + str;
//			lcdDisplay1.Invalidate();
			//lcdDisplay1.SetCursor( 0, 0 );
			//lcdDisplay1.Print( "" + (char)0 + str );
			
			//controlKnob1.Value = (float)iSegMan;
			
			if( iSegMan % 10 == 0 ) { ic++; }
			
			iLoading++;
			if( iLoading == 0 ) display14SegmentLoading.ShowChar( '/' );
			else if( iLoading == 1 ) display14SegmentLoading.ShowChar( '-' );
			else if( iLoading == 2 ) display14SegmentLoading.ShowChar( '\\' );
			else if( iLoading == 3 ) { display14SegmentLoading.ShowChar( '|' ); iLoading = -1; }
			
			
			if( ic == '9' + 1 ) ic = 'a';
			if( ic == 'z' + 1 ) ic = '0';
//			ssegmentDisplay141.ShowChar( (char)ic );
			
			iSegMan++;
			if( iSegMan > 999 ) iSegMan = 0;
			sp.Stop();
			Text = sp.Elapsed.TotalMilliseconds + " ms";
		}
		
		
		void Lamp1DoubleClick(object sender, EventArgs e) {
			lamp1.Toggle();
		}
		
		
		void ZipBar1ValueChanged(object sender, EventArgs e) {
			bar1.Value = (float)zipBar1.Value;
		}
		
		
		void PushButton1StateChanged(object sender, EventArgs e) {
			lamp1.State = pushButton1.State;
		}
		
		void PushButton2StateChanged(object sender, EventArgs e) {
			lamp3.State = pushButton2.State;
		}
		
		void PushButton3StateChanged(object sender, EventArgs e) {
			lamp4.State = pushButton3.State;
		}
		
		void ZipBar10ValueChanged(object sender, EventArgs e) {
			VisBox.ZipBar ziper = sender as VisBox.ZipBar;
			label2.Text = "" + ziper.GetScaledValue( ziper.Parts - 1 ) + ";" + ziper.Value + ";" + ziper.Text;
		}
		
		void ZipBar2ValueChanged(object sender, EventArgs e) {
//			segmentDisplay141.Scale = (float)( zipBar2.Value )/(100);
//			analogMeter1.Value = (float)( zipBar2.Value );
			
			VisBox.ZipBar ziper = sender as VisBox.ZipBar;
			label2.Text = "" + ziper.GetScaledValue( ziper.Parts - 1 ) + ";" + ziper.Text;
		}
		
		
		void Button1Click(object sender, EventArgs e) {
			lcdDisplay1.Clear();
			lcdDisplay1.Print( textBox1.Text );
		}
		
		
        void TxtBxPlotMarkerTextChanged(object sender, EventArgs e) {
		    if( txtBxPlotMarker.Text.Length <= 0 ) { plot1.Series[0].Marker.Symbol = ' '; }
		    else {
		        plot1.Series[0].Marker.Symbol = txtBxPlotMarker.Text[0];
		    }
        }
		
		
		
		void BtnShowPlotPropertyClick ( object sender, EventArgs e ) {
        }
		
		
		private int _cntrPaint = 0;
        void TreeDetailsView1Paint ( object sender, PaintEventArgs e ) {
		    _cntrPaint++;
		    label3.Text += "\r\n" + _cntrPaint;
        }
		
		
		
		
		
		
	}
}
