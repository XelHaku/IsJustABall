using System;
using CocosSharp;
using System.Collections.Generic;
using CocosDenshion;
using System.Linq;
namespace IsJustABall
{
	public class IJABScrollerScene : CCScene
	{
		CCLayer mainLayer;

		CCSprite ballSprite;

		List<CCSprite> visibleJewels;
		CCSprite ruby;
		CCSprite diamond;

		List<CCSprite> visiblePivots;
		CCSprite pivotSprite;

		CCLabelTtf scoreLabel;


		float ballXVelocity =360 ;
		float ballYVelocity = 360;
		// How much to modify the ball's y velocity per second:
		float gravity = 140;
		//hookTouchBool=!hookTouchBool// to toggle on Touch
		bool hookTouchBool = true;
		//Speed for scroller level
		int scrollerSpeed= 50;
		//Declare variables for HookedParticle Method
		double dRadius_X;
		double dRadius_Y;
		double Radius;
		double temp;
		double ballSpeed;
		double SinThetaZero;
		double CosThetaZero;
		double CosAlpha;
		double SinAlpha;
		double theta=0;
		double ThetaZero=0;
		double Multiplier =1.05f;
		double wZero;
		double ballSpeedFinal;
		bool ClockwiseRotation = true;
		float minRotationRadius;

		
		/// //////////////////
		//needed for multiple Pivots
		float hookedPivotPosX,hookedPivotPosY;
		int indexHookPivot;
		/// 

		//Movementson Pivots
		  

		CCEventListenerTouchAllAtOnce touchListener;

		public IJABScrollerScene(CCWindow mainWindow) : base(mainWindow)
		{

			mainLayer = new CCLayer ();
			AddChild (mainLayer);
			visiblePivots = new List<CCSprite> ();
			visibleJewels = new List<CCSprite> ();

			var bounds = mainWindow.WindowSizeInPixels;
			minRotationRadius = 0.15f*bounds.Height;

			addBlueBall(mainWindow);

			//addPivot(mainWindow);
			// add ALL pivots of the level
			addLevelPivots (mainWindow);
			addLevelJewels (mainWindow);




			scoreLabel = new CCLabelTtf ("Score: 0", "arial", 22);
			scoreLabel.PositionX = mainLayer.VisibleBoundsWorldspace.MinX + 20;
			scoreLabel.PositionY = mainLayer.VisibleBoundsWorldspace.MaxY - 20;
			scoreLabel.AnchorPoint = CCPoint.AnchorUpperLeft;

			mainLayer.AddChild (scoreLabel);

			Schedule (RunGameLogic);


			// New code:
			touchListener = new CCEventListenerTouchAllAtOnce ();
			touchListener.OnTouchesMoved = HandleTouchesMoved; 
			touchListener.OnTouchesBegan = HandleTouchesBegan; 
			AddEventListener (touchListener, this);

		}

		void RunGameLogic(float frameTimeInSeconds)
		{
			if (hookTouchBool == true) {//Void free Particle
				freeParticle (frameTimeInSeconds);
			} else {
				//void HookedParticle
				hookedParticle (frameTimeInSeconds);
			}
			//movement on pivots over time
			foreach (var pivotSprite in visiblePivots) {

				pivotSprite.PositionY += -scrollerSpeed * frameTimeInSeconds;
				//element.Rotation (1.0f);
						}

			foreach (var ruby in visibleJewels) {

				ruby.PositionY += -scrollerSpeed * frameTimeInSeconds;
				//element.Rotation (1.0f);
			}
			checkJewel ();
		
		}



		void HandleTouchesMoved (System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent)
		{
			// we only care about the first touch:
			//var locationOnScreen = touches [0].LocationOnScreen;
			//paddleSprite.PositionX = locationOnScreen.X;
		}
		void HandleTouchesBegan(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){
			double closestPivot = 10000;
			/*foreach (var pivotSprite in visiblePivots) {
				dRadius_X = ballSprite.PositionX - pivotSprite.PositionX;
				dRadius_Y = ballSprite.PositionY - pivotSprite.PositionY;


				temp = Math.Pow ((double)dRadius_X, 2) + Math.Pow ((double)dRadius_Y, 2);
				temp = Math.Pow (temp, 0.5);

				if (temp < closestPivot) {
					hookedPivotPosX = pivotSprite.PositionX;
					hookedPivotPosY = pivotSprite.PositionY;
					closestPivot = temp;
				
				
				}


			}*/


			for (int i =0; i < visiblePivots.Count;i++) {
				dRadius_X = ballSprite.PositionX - visiblePivots[i].PositionX;
				dRadius_Y = ballSprite.PositionY - visiblePivots[i].PositionY;


				temp = Math.Pow ((double)dRadius_X, 2) + Math.Pow ((double)dRadius_Y, 2);
				temp = Math.Pow (temp, 0.5);

				if (temp < closestPivot) {
					hookedPivotPosX = visiblePivots[i].PositionX;
					hookedPivotPosY = visiblePivots[i].PositionY;
					closestPivot = temp;
					indexHookPivot = i;

				}


			}

			if (closestPivot < minRotationRadius && hookTouchBool == true) {
				hookTouchBool = false;//Toggle hook
				//scoreLabel.Text = "temp:" + temp.ToString () + " \nCircleRadius: " + minRotationRadius.ToString () + " \nball: " + ballSprite.Position.ToString () + " \npivot: " + pivotSprite.Position.ToString ();

			} else if (hookTouchBool == false) {
				hookTouchBool = true;
				//scoreLabel.Text = "Free";
			}







				if (hookTouchBool == false) {
					//Set values for spped and radius or rotation raound Pivot

				dRadius_X = ballSprite.PositionX - visiblePivots[indexHookPivot].PositionX;
				dRadius_Y = ballSprite.PositionY - visiblePivots[indexHookPivot].PositionY;

					Radius = Math.Pow ((double)dRadius_X, 2) + Math.Pow ((double)dRadius_Y, 2);
					Radius = Math.Pow (Radius, 0.5);


					ballSpeed = Math.Pow (ballXVelocity, 2) + Math.Pow (ballYVelocity, 2);
					ballSpeed = Math.Pow (ballSpeed, 0.5d);

					CosThetaZero = dRadius_X / Radius;
					SinThetaZero = dRadius_Y / Radius;

					CosAlpha = (dRadius_X * ballXVelocity + dRadius_Y * ballYVelocity) / (Radius * ballSpeed);

					if (Math.Pow (CosAlpha, 2) < 0.5) {
						CosAlpha = Math.Pow (0.5, 0.5);
					}
					SinAlpha = (1 - Math.Pow (CosAlpha, 2));
					SinAlpha = Math.Pow (SinAlpha, 0.5f);


					wZero = ballSpeed / Radius;
					//ballSpeedFinal = Radius * Multiplier * wZero * SinAlpha;
				ballSpeedFinal = Radius * Multiplier * wZero ;

					ThetaZero = Math.Acos (CosThetaZero);

					//Second Quadrant
					if (SinThetaZero > 0 && CosThetaZero < 0) {
						ThetaZero = (1 / 2) * Math.PI + ThetaZero;
					}
					//Third Quadrant
					if (SinThetaZero < 0 && CosThetaZero < 0) {
						ThetaZero = (2) * Math.PI - ThetaZero;
					}



					//Fourth Quadrant
					if (SinThetaZero < 0 && CosThetaZero > 0) {
						ThetaZero = -ThetaZero;
					}
					theta = ThetaZero;
					//Define if it is clockwise or anticlockwise rotation

					if (dRadius_X * ballYVelocity - dRadius_Y * ballXVelocity <= 0) {
						ClockwiseRotation = false;
						scoreLabel.Text += "ClockwiseRotation: false";
					} else {
						ClockwiseRotation = true;
						scoreLabel.Text += "ClockwiseRotation: true";

					}
				}

	
			
		}



		void freeParticle(float frameTimeInSeconds){
			gravity = 140;
			// This is a linear approximation, so not 100% accurate
			ballXVelocity += frameTimeInSeconds * gravity;
			ballSprite.PositionX += ballXVelocity * frameTimeInSeconds;
			ballSprite.PositionY += ballYVelocity * frameTimeInSeconds;
			// New code:
			//score++;
			//scoreLabel.Text = "Score: " + score;
			// Check if the ball is either too far to the right or left:
			float ballRight = ballSprite.BoundingBoxTransformedToParent.MaxX;
			float ballLeft = ballSprite.BoundingBoxTransformedToParent.MinX;

			float screenRight = mainLayer.VisibleBoundsWorldspace.MaxX;
			float screenLeft = mainLayer.VisibleBoundsWorldspace.MinX;

			bool shouldReflectXVelocity = (ballRight > screenRight && ballXVelocity > 0) ||	(ballLeft < screenLeft && ballXVelocity < 0);


			if (shouldReflectXVelocity)
			{
				ballXVelocity *= -1;

			}

			// Check if the ball is either too far to the right or left:

			float ballTop = ballSprite.BoundingBoxTransformedToParent.MaxY;
			float ballBottom = ballSprite.BoundingBoxTransformedToParent.MinY;

			float screenTop = mainLayer.VisibleBoundsWorldspace.MaxY;
			float screenBottom = mainLayer.VisibleBoundsWorldspace.MinY;

			bool shouldReflectYVelocity = (ballTop > screenTop && ballYVelocity > 0) ||	(ballBottom < screenBottom && ballYVelocity < 0);

			if (shouldReflectYVelocity)
			{
				ballYVelocity *= -1;
			}


		}

		void hookedParticle(float frameTimeInSeconds){
			gravity = 0;

		
			//multiplier on close radius\
			//double multR = (10 / Radius);

			if (ClockwiseRotation == true) {
				//theta+= (double)(Multiplier*wZero*SinAlpha*frameTimeInSeconds);
				theta+= (double)(Multiplier*wZero*frameTimeInSeconds);

				ballXVelocity = (float)(-ballSpeedFinal * Math.Sin (theta));
				ballYVelocity = (float)(ballSpeedFinal * Math.Cos (theta));
							}
			else {
				//theta-= (double)(Multiplier*wZero*SinAlpha*frameTimeInSeconds);
				theta-= (double)(Multiplier*wZero*frameTimeInSeconds);

				ballXVelocity = (float)(ballSpeedFinal * Math.Sin (theta));
				ballYVelocity = (float)(-ballSpeedFinal * Math.Cos (theta));
										}
				/////////
			ballSprite.PositionX =(float)(Radius*Math.Cos(theta) + visiblePivots[indexHookPivot].PositionX);
			ballSprite.PositionY = (float)(Radius*Math.Sin(theta) + visiblePivots[indexHookPivot].PositionY);


			///Remove gone far Pivots
			/*for (int i =0; i < visiblePivots.Count;i++) {


				if (visiblePivots[i].PositionY < -500) {
					visiblePivots.RemoveAt (i);
			}



		}*/
		
		}


		/// OBJECTS AND SPRITES

		void addBlueBall(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			ballSprite = new CCSprite ("blueball");
			ballSprite.Scale = 0.0005f*bounds.Width;
			ballSprite.PositionX = 0.5f*bounds.Width;
			ballSprite.PositionY = -0.2f*bounds.Height;
		
			//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
			mainLayer.AddChild (ballSprite);



		}

		CCSprite addDiamond(CCWindow mainWindow, float diamondPosX,float diamondPosY,float scale){
			var bounds = mainWindow.WindowSizeInPixels;

			diamond = new CCSprite ("diamond");
			diamond.Scale = scale;
			diamond.PositionX = diamondPosX;
			diamond.PositionY = diamondPosY;
			CCRotateBy rotate = new CCRotateBy (0.0f, 90);
			diamond.RunAction (rotate);

			//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
			mainLayer.AddChild (diamond);
			return diamond;
		}

		CCSprite addRuby(CCWindow mainWindow,float rubyPosX,float rubyPosY,float scale){
			var bounds = mainWindow.WindowSizeInPixels;

			ruby = new CCSprite ("ruby");
			ruby.Scale = scale;
			ruby.PositionX = rubyPosX;
			ruby.PositionY = rubyPosY;
			CCRotateBy rotate = new CCRotateBy (0.0f, 90);
			ruby.RunAction (rotate);

			//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
			mainLayer.AddChild (ruby);
			return ruby;
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
			CCMoveBy moveByPivot_UP = new CCMoveBy (3.0f,new CCPoint(0.0f,0.7f*bounds.Width));
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
			CCMoveBy moveByPivot_UP = new CCMoveBy (3.0f,new CCPoint(0.0f,-0.7f*bounds.Width));
			pivotSprite.RepeatForever(moveByPivot_UP,moveByPivot_UP.Reverse());
			pivotSprite.RepeatForever (rotatePivot);
			return pivotSprite;

		}



			void addLevelPivots (CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;
			float pivotScale=0.0002f*bounds.Width;
			String[] PivotMoveType = new String[100]; 
			float[,] PivotPosArray = new float[100,2];

			Level1Array levelArray = new Level1Array ();

			PivotPosArray = levelArray.PosArray();
			PivotMoveType = levelArray.moveArray();

			//

			//scoreLabel.Text = (PivotPosArray.Length/2.0f).ToString();
			for(int i = 0;i<=8;i++){
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


		void addLevelJewels (CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;
			float jewelScale=0.0001f*bounds.Width;
			float[,] JewelPosArray = new float[100,2];

			Level1Array levelArray = new Level1Array ();

			JewelPosArray = levelArray.JewelPosArray();


			//

			//scoreLabel.Text = (PivotPosArray.Length/2.0f).ToString();
			for (int i = 0; i < JewelPosArray.Length/2; i++) {
				JewelPosArray [i, 0] = JewelPosArray [i, 0] * bounds.Width;
				JewelPosArray [i, 1] = JewelPosArray [i, 1] * bounds.Height;

				//visiblePivots.Add (AddSTATIC_Pivots (mainWindow,PivotPosArray[i,0],PivotPosArray[i,1],pivotScale));
				visibleJewels.Add (addRuby (mainWindow, JewelPosArray [i, 0], JewelPosArray [i, 1], jewelScale));

			}
		}


		//Remove jewel and and Score Counter
		void checkJewel(){
			foreach (var ruby in visibleJewels) {
				bool hit = ruby.BoundingBoxTransformedToParent.IntersectsRect(ballSprite.BoundingBoxTransformedToParent);
				if (hit)
				{
					//hitBananas.Add(banana);
					//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
					//Explode(banana.Position);
					ruby.RemoveFromParent();
						

 				}
			}
			/*foreach (var banana in visibleBananas)
            {
#endif
                bool hit = banana.BoundingBoxTransformedToParent.IntersectsRect(monkey.BoundingBoxTransformedToParent);
                if (hit)
                {
                    hitBananas.Add(banana);
                    CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
                    Explode(banana.Position);
                    banana.RemoveFromParent();
                }
#if !NETFX_CORE
            });*/
		}


	}


}

