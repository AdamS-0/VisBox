/*
 * Created by SharpDevelop.
 * User: AdamS-0
 * Date: 10.05.2021
 * Time: 09:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Drawing;

namespace VisBox
{
	/// <summary>
	/// Description of LCD5x8Char.
	/// </summary>
	public static class LCD5x8Char
	{
		public static float blockSize = 3;
		public static float space = 1;
		
		
		// org: 30x30 space = 8
		// segWid:segSpace = 20:3
		
		
		
		public static void Draw(Graphics graph, byte[] bits, PointF relCent, Color colorOn, Color colorOff)
		{
			PointF offset = relCent;
			
//			space = (float)Math.Round( blockSize*8/30.0f, 0);
			
//			offset.X = relCent.X - ( blockSize*( 5 + 6*30.0f/8 ) ) / 2;
//			offset.Y = relCent.Y - ( blockSize*( 8 + 9*30.0f/8 ) ) / 2;
			
			//int charId = 0;
			/*
			for (int j = 0; j < 8; j++) {
//				byte activeByte = _chars[charId,j];
				byte activeByte = bits[j];
				for (int i = 0; i < 5; i++) {
					bool active = (activeByte & (1 << i)) != 0;
					DrawBlock(graph, new PointF(
						offset.X + i * blockSize + (i+1)*space, offset.Y + j * blockSize  + (j+1)*space),
						active, colorOn, colorOff);
				}
			}
			*/
			
			for( int i = 0; i < 5; i ++ ) {
				byte curByte = bits[i];
				for( int j = 0; j < 8; j++ ) {
					bool active = (curByte & (1 << j)) != 0;
					DrawBlock(graph, new PointF(
						offset.X + i * blockSize + (i+1)*space, offset.Y + j * blockSize  + (j+1)*space),
						active, colorOn, colorOff);
				}
			}
			
		}
		
		private static void DrawBlock(Graphics graph, PointF relLeftUp, bool active, Color colorOn, Color colorOff)
		{
			graph.FillRectangle(new SolidBrush(active ? colorOn : colorOff),
				relLeftUp.X, relLeftUp.Y, blockSize, blockSize);
		}
		
		
		
		
		static byte[,] _chars = {
			{ 0x0, 0x1, 0x2, 0x3, 0x4, 0x5, 0x6, 0x7 },
			{ 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff, 0xff }
		};
		
		
		
		
		
		
		
	}
		
}
