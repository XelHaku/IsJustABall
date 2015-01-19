using System;
using CocosSharp;
using System.Collections.Generic;
using CocosDenshion;
using System.Linq;

namespace IsJustABall
{
	public class addLevelPivots_1
	{
		public addLevelPivots_1 (CCWindow mainWindow, List<CCSprite> visiblePivots )
		{
			var bounds = mainWindow.WindowSizeInPixels;
			float pivotScale=0.0002f*bounds.Width;
			String[] PivotMoveType = new String[100]; 
			float[,] PivotPosArray = new float[100,2];
			//PivotPosArray[i,0] = Xposition; PivotPosArray[i,1] = Yposition;
			PivotPosArray[0,0] = 0.5f; PivotPosArray[0,1] =0.25f; PivotMoveType [0] = "STATIC"; 
			PivotPosArray[1,0] = 0.15f; PivotPosArray[1,1] =0.5f; PivotMoveType [1] = "UP";
			PivotPosArray[2,0] = 0.85f; PivotPosArray[2,1] =0.5f; PivotMoveType [2] = "DOWN";
			PivotPosArray[3,0] = 0.5f; PivotPosArray[3,1] =0.75f; PivotMoveType [3] = "LEFT";
			PivotPosArray[4,0] = 0.15f; PivotPosArray[4,1] =1.0f; PivotMoveType [4] = "RIGHT";
			PivotPosArray[5,0] = 0.85f; PivotPosArray[5,1] =1.0f; 
			PivotPosArray[6,0] = 0.15f; PivotPosArray[6,1] =1.25f;
			PivotPosArray[7,0] = 0.85f; PivotPosArray[7,1] =1.25f;
			PivotPosArray[8,0] = 0.5f; PivotPosArray[8,1] =1.5f;
			PivotPosArray[9,0] = 0.15f; PivotPosArray[9,1] =1.75f;
			PivotPosArray[10,0] = 0.85f; PivotPosArray[10,1] =1.75f;

			PivotPosArray[11,0] = 0.15f; PivotPosArray[11,1] =2.0f;
			PivotPosArray[12,0] = 0.85f; PivotPosArray[12,1] =2.0f;
			PivotPosArray[13,0] = 0.15f; PivotPosArray[13,1] =2.25f;
			PivotPosArray[14,0] = 0.85f; PivotPosArray[14,1] =2.25f;
			PivotPosArray[15,0] = 0.5f; PivotPosArray[15,1] =2.5f;
			PivotPosArray[16,0] = 0.15f; PivotPosArray[16,1] =2.75f;
			PivotPosArray[17,0] = 0.85f; PivotPosArray[17,1] =2.75f;

			//

			//scoreLabel.Text = (PivotPosArray.Length/2.0f).ToString();
			for(int i = 0;i<=17;i++){
				PivotPosArray[i,0] = PivotPosArray[i,0]*bounds.Width;
				PivotPosArray[i,1] = PivotPosArray[i,1]*bounds.Height;

				switch(PivotMoveType[i]){
				case "STATIC":
					visiblePivots.Add (AddSTATIC_Pivots (mainWindow,PivotPosArray[i,0],PivotPosArray[i,1],pivotScale));
					break;
				case "UP":
					visiblePivots.Add (AddUP_Pivots (mainWindow,PivotPosArray[i,0],PivotPosArray[i,1],pivotScale));
					break;
				case "DOWN":
					visiblePivots.Add (AddDOWN_Pivots (mainWindow,PivotPosArray[i,0],PivotPosArray[i,1],pivotScale));
					break;
				case "RIGHT":
					visiblePivots.Add (AddRIGHT_Pivots (mainWindow,PivotPosArray[i,0],PivotPosArray[i,1],pivotScale));
					break;
				case "LEFT":
					visiblePivots.Add (AddLEFT_Pivots (mainWindow,PivotPosArray[i,0],PivotPosArray[i,1],pivotScale));
					break;
				default:
					visiblePivots.Add (AddSTATIC_Pivots (mainWindow,PivotPosArray[i,0],PivotPosArray[i,1],pivotScale));

					break;

				}

			}

		}

	
		CCSprite AddSTATIC_Pivots (CCWindow mainWindow,float pivotPosX,float pivotPosY,float scale)
		{   

			pivotSprite = new CCSprite ("pivot");
			pivotSprite.Scale = scale;
			pivotSprite.PositionX = pivotPosX;
			pivotSprite.PositionY = pivotPosY;
			float h= (float)pivotSprite.ContentSize.Height/2.0f;
			CCPoint tempPos = new CCPoint(h,h);
			//var galaxy = new CCParticleGalaxy (tempPos); //TODO: manage "better" for performance when "many" particles
			var CircleDraw = new CCDrawNode();
			var BlueColor = new CCColor4B (0, 0, 255, 1);
			/* DrawCircle(CCPoint, float, CCColor4B)
			)*/
			var bounds = mainWindow.WindowSizeInPixels;
			CircleDraw.DrawCircle (tempPos, 1.0f*bounds.Width,BlueColor);
			//galaxy.Scale = 6.0f;


			//pivotSprite.AddChild (galaxy);
			pivotSprite.AddChild (CircleDraw);

			//mainLayer.AddChild (pivotSprite);
			mainLayer.AddChild(pivotSprite);

			CCRotateBy rotatePivot = new CCRotateBy (1.0f, 360);

			pivotSprite.RepeatForever(rotatePivot);
			return pivotSprite;
		}

		CCSprite AddUP_Pivots(CCWindow mainWindow,float pivotPosX,float pivotPosY,float scale)
		{   


			pivotSprite = new CCSprite ("pivot");
			pivotSprite.Scale = scale;
			pivotSprite.PositionX = pivotPosX;
			pivotSprite.PositionY = pivotPosY;
			float h = (float)pivotSprite.ContentSize.Height / 2.0f;
			CCPoint tempPos = new CCPoint (h, h);
			//var galaxy = new CCParticleGalaxy (tempPos); //TODO: manage "better" for performance when "many" particles
			var CircleDraw = new CCDrawNode ();
			var BlueColor = new CCColor4B (0, 0, 255, 1);
			var bounds = mainWindow.WindowSizeInPixels;
			CircleDraw.DrawCircle (tempPos, 1.0f * bounds.Width, BlueColor);
			pivotSprite.AddChild (CircleDraw);
			mainLayer.AddChild (pivotSprite);
			CCRotateBy rotatePivot = new CCRotateBy (1.0f, 360);
			CCMoveBy moveByPivot_UP = new CCMoveBy (3.0f,new CCPoint(0.7f*bounds.Width,0.0f));
			pivotSprite.RepeatForever(moveByPivot_UP,moveByPivot_UP.Reverse());
			pivotSprite.RepeatForever (rotatePivot);
			return pivotSprite;

		}		


		CCSprite AddDOWN_Pivots(CCWindow mainWindow,float pivotPosX,float pivotPosY,float scale)
		{   


			pivotSprite = new CCSprite ("pivot");
			pivotSprite.Scale = scale;
			pivotSprite.PositionX = pivotPosX;
			pivotSprite.PositionY = pivotPosY;
			float h = (float)pivotSprite.ContentSize.Height / 2.0f;
			CCPoint tempPos = new CCPoint (h, h);
			//var galaxy = new CCParticleGalaxy (tempPos); //TODO: manage "better" for performance when "many" particles
			var CircleDraw = new CCDrawNode ();
			var BlueColor = new CCColor4B (0, 0, 255, 1);
			var bounds = mainWindow.WindowSizeInPixels;
			CircleDraw.DrawCircle (tempPos, 1.0f * bounds.Width, BlueColor);
			pivotSprite.AddChild (CircleDraw);
			mainLayer.AddChild (pivotSprite);
			CCRotateBy rotatePivot = new CCRotateBy (1.0f, 360);
			CCMoveBy moveByPivot_UP = new CCMoveBy (3.0f,new CCPoint(-0.7f*bounds.Width,0.0f));
			pivotSprite.RepeatForever(moveByPivot_UP,moveByPivot_UP.Reverse());
			pivotSprite.RepeatForever (rotatePivot);
			return pivotSprite;

		}CCSprite AddRIGHT_Pivots(CCWindow mainWindow,float pivotPosX,float pivotPosY,float scale)
		{   


			pivotSprite = new CCSprite ("pivot");
			pivotSprite.Scale = scale;
			pivotSprite.PositionX = pivotPosX;
			pivotSprite.PositionY = pivotPosY;
			float h = (float)pivotSprite.ContentSize.Height / 2.0f;
			CCPoint tempPos = new CCPoint (h, h);
			//var galaxy = new CCParticleGalaxy (tempPos); //TODO: manage "better" for performance when "many" particles
			var CircleDraw = new CCDrawNode ();
			var BlueColor = new CCColor4B (0, 0, 255, 1);
			var bounds = mainWindow.WindowSizeInPixels;
			CircleDraw.DrawCircle (tempPos, 1.0f * bounds.Width, BlueColor);
			pivotSprite.AddChild (CircleDraw);
			mainLayer.AddChild (pivotSprite);
			CCRotateBy rotatePivot = new CCRotateBy (1.0f, 360);
			CCMoveBy moveByPivot_UP = new CCMoveBy (3.0f,new CCPoint(0.0f,-0.7f*bounds.Width));
			pivotSprite.RepeatForever(moveByPivot_UP,moveByPivot_UP.Reverse());
			pivotSprite.RepeatForever (rotatePivot);
			return pivotSprite;

		}

		CCSprite AddLEFT_Pivots(CCWindow mainWindow,float pivotPosX,float pivotPosY,float scale)
		{   


			pivotSprite = new CCSprite ("pivot");
			pivotSprite.Scale = scale;
			pivotSprite.PositionX = pivotPosX;
			pivotSprite.PositionY = pivotPosY;
			float h = (float)pivotSprite.ContentSize.Height / 2.0f;
			CCPoint tempPos = new CCPoint (h, h);
			//var galaxy = new CCParticleGalaxy (tempPos); //TODO: manage "better" for performance when "many" particles
			var CircleDraw = new CCDrawNode ();
			var BlueColor = new CCColor4B (0, 0, 255, 1);
			var bounds = mainWindow.WindowSizeInPixels;
			CircleDraw.DrawCircle (tempPos, 1.0f * bounds.Width, BlueColor);
			pivotSprite.AddChild (CircleDraw);
			mainLayer.AddChild (pivotSprite);
			CCRotateBy rotatePivot = new CCRotateBy (1.0f, 360);
			CCMoveBy moveByPivot_UP = new CCMoveBy (3.0f,new CCPoint(0.0f,0.7f*bounds.Width));
			pivotSprite.RepeatForever(moveByPivot_UP,moveByPivot_UP.Reverse());
			pivotSprite.RepeatForever (rotatePivot);
			return pivotSprite;

		}
	
	
	}
}
