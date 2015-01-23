using System;
using CocosSharp;
using System.Collections.Generic;
using CocosDenshion;
using System.Linq;
namespace IsJustABall
{
	public class MultiPlayerScrollerScene : CCScene
	{
		CCWindow mainWindowAux;
		CCLayer mainLayer;

		CCSprite ballSprite;

		List<CCSprite> ballList;
		List<CCSprite> visibleJewels;
		List<CCSprite> hitJewels;
		List<CCSprite> DeleteElement;
		CCSprite ruby;
		CCSprite diamond;
		CCSprite background1;
		CCSprite background2;

		List<CCSprite> visiblePivots;
		CCSprite pivotSprite;
		CCSprite shadow;

		List<CCSprite> visibleTraps;
		CCSprite spikeSprite;

		CCLabelTtf scoreLabel;


		float ballXVelocity =0 ;
		float ballYVelocity = 300;
		// How much to modify the ball's y velocity per second:
		float gravity = 0;
		//hookTouchBool=!hookTouchBool// to toggle on Touch
		bool hookTouchBool = true;
		//Speed for scroller level
		int scrollerSpeed= 150;
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
		int score = 0;

		//Movementson Pivots


		CCEventListenerTouchAllAtOnce touchListener;

		public MultiPlayerScrollerScene(CCWindow mainWindow) : base(mainWindow)
		{
			mainWindowAux = mainWindow;
			mainLayer = new CCLayer ();
			AddChild (mainLayer);
			visiblePivots = new List<CCSprite> ();
			visibleJewels = new List<CCSprite> ();
			hitJewels = new List<CCSprite> ();
			visibleTraps = new List<CCSprite>();
			DeleteElement = new List<CCSprite> ();
			ballList = new List<CCSprite> ();

			var bounds = mainWindow.WindowSizeInPixels;
			minRotationRadius = 0.15f*bounds.Height;



			//addPivot(mainWindow);
			// add ALL pivots of the level

			addLevelPivots (mainWindow);
			addLevelJewels (mainWindow);
			addLevelSpikes (mainWindow);
			addGameBalls(4);
			addBackground1 (mainWindow);addBackground2 (mainWindow);



			scoreLabel = new CCLabelTtf ("Score: 0", "arial", 22);
			scoreLabel.PositionX = mainLayer.VisibleBoundsWorldspace.MaxX/2 ;
			scoreLabel.PositionY = mainLayer.VisibleBoundsWorldspace.MaxY - 20;
			scoreLabel.AnchorPoint = CCPoint.AnchorUpperRight;


			mainLayer.AddChild (scoreLabel);
			mainLayer.ReorderChild (scoreLabel, 101);


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

			foreach (var spikeSprite in visibleTraps) {

				spikeSprite.PositionY += -scrollerSpeed * frameTimeInSeconds;
				//element.Rotation (1.0f);
			}
			checkJewel ();
			checkTrap ();

			//backgroundScoller
			background1.PositionY += -scrollerSpeed * frameTimeInSeconds/10.0f;
			background2.PositionY += -scrollerSpeed * frameTimeInSeconds/10.0f;

			if (background1.PositionY + background1.ContentSize.Height == 0) {
				background1.PositionY = background2.PositionY + background1.ContentSize.Height;
			}

			if (background2.PositionY + background2.ContentSize.Height == 0) {
				background2.PositionY = background1.PositionY + background2.ContentSize.Height;

			}

			mainLayer.ReorderChild (scoreLabel, 101);

		}



		void HandleTouchesMoved (System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent)
		{
			// we only care about the first touch:
			//var locationOnScreen = touches [0].LocationOnScreen;
			//paddleSprite.PositionX = locationOnScreen.X;
		}
		void HandleTouchesBegan(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){
			double closestPivot = 10000;
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
					//scoreLabel.Text += "ClockwiseRotation: false";
				} else {
					ClockwiseRotation = true;
					//scoreLabel.Text += "ClockwiseRotation: true";

				}
			}



		}



		void freeParticle(float frameTimeInSeconds){
			gravity = 0;
			foreach (var ballSprite in ballList){
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


			if (shouldReflectXVelocity) {
				ballXVelocity *= -1;

			}

			// Check if the ball is either too far to the right or left:

			float ballTop = ballSprite.BoundingBoxTransformedToParent.MaxY;
			float ballBottom = ballSprite.BoundingBoxTransformedToParent.MinY;

			float screenTop = mainLayer.VisibleBoundsWorldspace.MaxY;
			float screenBottom = mainLayer.VisibleBoundsWorldspace.MinY;

			bool shouldReflectYVelocity = (ballTop > screenTop && ballYVelocity > 0) ||	(ballBottom < screenBottom && ballYVelocity < 0);

			if (shouldReflectYVelocity) {
				ballYVelocity *= -1;
			}

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
			for (int i =0; i < visibleJewels.Count;i++) {


				if (visibleJewels[i].PositionY < -500) {
					visibleJewels.RemoveAt (i);
				}



			}

		}


		/// OBJECTS AND SPRITES

		CCSprite addBall(CCWindow mainWindow, int ballColor){
			var bounds = mainWindow.WindowSizeInPixels;
			switch (ballColor) {
			case 1:
				ballSprite = new CCSprite ("blueball");
				ballSprite.PositionX = 0.2f*bounds.Width;
				ballSprite.PositionY = -0.1f*bounds.Height;
				break;
			case 2:
				ballSprite = new CCSprite ("redball");
				ballSprite.PositionX = 0.4f*bounds.Width;
				ballSprite.PositionY = -0.1f*bounds.Height;
				break;
			case 3:
				ballSprite = new CCSprite ("greenball");
				ballSprite.PositionX = 0.6f*bounds.Width;
				ballSprite.PositionY = -0.1f*bounds.Height;
				break;
			case 4:
				ballSprite = new CCSprite ("yellowball");
				ballSprite.PositionX = 0.8f*bounds.Width;
				ballSprite.PositionY = -0.1f*bounds.Height;
				break;
			default:
				ballSprite = new CCSprite ("blueball");
				ballSprite.PositionX = 0.2f*bounds.Width;
				ballSprite.PositionY = -0.1f*bounds.Height;
				break;
			}
			ballSprite.Scale = 0.0005f*bounds.Width;


			//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
			mainLayer.AddChild (ballSprite);
			return ballSprite;
		}

		void addGameBalls(int playersCount){
			for (int i = 1; i <= playersCount; i++) {
				ballList.Add(addBall (mainWindowAux, i));
			
			}		
		}

		CCSprite addDiamond(CCWindow mainWindow, float diamondPosX,float diamondPosY,float scale){
			var bounds = mainWindow.WindowSizeInPixels;

			diamond = new CCSprite ("diamond");
			diamond.Scale = scale;
			diamond.PositionX = diamondPosX;
			diamond.PositionY = diamondPosY;
			//CCRotateBy rotate = new CCRotateBy (0.0f, 90);
			//diamond.RunAction (rotate);

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
			//CCRotateBy rotate = new CCRotateBy (0.0f, 90);
			//ruby.RunAction (rotate);

			//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
			mainLayer.AddChild (ruby);
			return ruby;
		}

		void addBackground1(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			background1 = new CCSprite ("galaxybackground4");

			background1.Scale = 1.8f;
			background1.PositionX = bounds.Width/2;
			background1.PositionY = background1.ContentSize.Height;

			mainLayer.AddChild (background1);
			mainLayer.ReorderChild (background1, -100);

		}

		void addBackground2(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			background2 = new CCSprite ("galaxybackground4");
			background2.Scale = 1.8f;
			background2.PositionX = bounds.Width/2;
			background2.PositionY = 2*background2.ContentSize.Height;

			mainLayer.AddChild (background2);
			mainLayer.ReorderChild (background2, -99);


		}



		CCSprite AddSTATIC_Pivots (CCWindow mainWindow,float pivotPosX,float pivotPosY,float scale)
		{   

			pivotSprite = new CCSprite ("pivot3");

			pivotSprite.Scale = scale;
			pivotSprite.PositionX = pivotPosX;
			pivotSprite.PositionY = pivotPosY;
			float h= (float)pivotSprite.ContentSize.Height/2.0f;
			CCPoint tempPos = new CCPoint(h,h);

			var bounds = mainWindow.WindowSizeInPixels;

			mainLayer.AddChild(pivotSprite);

			CCRotateBy rotatePivot = new CCRotateBy (4.0f, 360);

			//pivotSprite.RepeatForever(rotatePivot);
			return pivotSprite;
		}

		CCSprite AddUP_Pivots(CCWindow mainWindow,float pivotPosX,float pivotPosY,float scale)
		{   


			pivotSprite = new CCSprite ("pivot3");
			pivotSprite.Scale = scale;
			pivotSprite.PositionX = pivotPosX;
			pivotSprite.PositionY = pivotPosY;
			float h = (float)pivotSprite.ContentSize.Height / 2.0f;
			CCPoint tempPos = new CCPoint (h, h);
			//var galaxy = new CCParticleGalaxy (tempPos); //TODO: manage "better" for performance when "many" particles
			var CircleDraw = new CCDrawNode ();
			var BlueColor = new CCColor4B (0, 255, 255, 0.001f);
			var bounds = mainWindow.WindowSizeInPixels;
			CircleDraw.DrawSolidCircle (tempPos, 1.0f * bounds.Width, BlueColor);
			//pivotSprite.AddChild (CircleDraw);
			//pivotSprite.ReorderChild (CircleDraw, 10);
			mainLayer.AddChild (pivotSprite);
			CCRotateBy rotatePivot = new CCRotateBy (4.0f, 360);
			CCMoveBy moveByPivot_UP = new CCMoveBy (3.0f,new CCPoint(-0.7f*bounds.Width,0.0f));
			pivotSprite.RepeatForever(moveByPivot_UP,moveByPivot_UP.Reverse());
			//pivotSprite.RepeatForever (rotatePivot);
			return pivotSprite;

		}		


		CCSprite AddDOWN_Pivots(CCWindow mainWindow,float pivotPosX,float pivotPosY,float scale)
		{   


			pivotSprite = new CCSprite ("pivot3");
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
			//pivotSprite.AddChild (CircleDraw);
			mainLayer.AddChild (pivotSprite);
			CCRotateBy rotatePivot = new CCRotateBy (4.0f, 360);
			CCMoveBy moveByPivot_UP = new CCMoveBy (3.0f,new CCPoint(0.7f*bounds.Width,0.0f));
			pivotSprite.RepeatForever(moveByPivot_UP,moveByPivot_UP.Reverse());
			//pivotSprite.RepeatForever (rotatePivot);
			return pivotSprite;

		}CCSprite AddRIGHT_Pivots(CCWindow mainWindow,float pivotPosX,float pivotPosY,float scale)
		{   


			pivotSprite = new CCSprite ("pivot3");
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
			//pivotSprite.AddChild (CircleDraw);
			mainLayer.AddChild (pivotSprite);
			CCRotateBy rotatePivot = new CCRotateBy (4.0f, 360);
			CCMoveBy moveByPivot_UP = new CCMoveBy (3.0f,new CCPoint(0.0f,0.7f*bounds.Width));
			pivotSprite.RepeatForever(moveByPivot_UP,moveByPivot_UP.Reverse());
			//pivotSprite.RepeatForever (rotatePivot);
			return pivotSprite;

		}

		CCSprite AddLEFT_Pivots(CCWindow mainWindow,float pivotPosX,float pivotPosY,float scale)
		{   


			pivotSprite = new CCSprite ("pivot3");
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
			//pivotSprite.AddChild (CircleDraw);
			mainLayer.AddChild (pivotSprite);
			CCRotateBy rotatePivot = new CCRotateBy (4.0f, 360);
			CCMoveBy moveByPivot_UP = new CCMoveBy (3.0f,new CCPoint(0.0f,-0.7f*bounds.Width));
			pivotSprite.RepeatForever(moveByPivot_UP,moveByPivot_UP.Reverse());
			//pivotSprite.RepeatForever (rotatePivot);
			return pivotSprite;

		}



		void addLevelPivots (CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;
			float pivotScale=0.0002f*bounds.Width;
			Level2Array LevelClass = new Level2Array ();
			List<Level2Array.Pivot> ClassList = new List<Level2Array.Pivot> ();

			ClassList = LevelClass.PivotMaker ();

			foreach(var Pivot in ClassList){
				Pivot.PosX =Pivot.PosX*bounds.Width;
				Pivot.PosY = Pivot.PosY*bounds.Height;

				switch(Pivot.MoveType){
				case "STATIC":
					visiblePivots.Add (AddSTATIC_Pivots (mainWindow,Pivot.PosX,Pivot.PosY,pivotScale));
					break;
				case "UP":
					visiblePivots.Add (AddUP_Pivots (mainWindow,Pivot.PosX,Pivot.PosY,pivotScale));
					break;
				case "DOWN":
					visiblePivots.Add (AddDOWN_Pivots (mainWindow,Pivot.PosX,Pivot.PosY,pivotScale));
					break;
				case "RIGHT":
					visiblePivots.Add (AddRIGHT_Pivots (mainWindow,Pivot.PosX,Pivot.PosY,pivotScale));
					break;
				case "LEFT":
					visiblePivots.Add (AddLEFT_Pivots (mainWindow,Pivot.PosX,Pivot.PosY,pivotScale));
					break;
				default:
					visiblePivots.Add (AddSTATIC_Pivots (mainWindow,Pivot.PosX,Pivot.PosY,pivotScale));

					break;

				}

			}

		}

		//JEWELS

		void addLevelJewels (CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;
			float jewelScale=0.0004f*bounds.Width;

			Level2Array LevelClass = new Level2Array ();
			List<Level2Array.Jewel> ClassList = new List<Level2Array.Jewel> ();

			ClassList = LevelClass.JewelMaker ();

			foreach(var Jewel in ClassList){
				Jewel.PosX = Jewel.PosX*bounds.Width;
				Jewel.PosY = Jewel.PosY*bounds.Height;

				switch(Jewel.JewelType){
				case "RUBY":
					visibleJewels.Add (addRuby (mainWindow, Jewel.PosX, Jewel.PosY, jewelScale));
					break;
				case "DIAMOND":
					visibleJewels.Add (addDiamond (mainWindow, Jewel.PosX, Jewel.PosY, jewelScale));
					break;
				default:
					visibleJewels.Add (addRuby (mainWindow, Jewel.PosX,Jewel.PosY, jewelScale));
					break;
				}
			}
		}


		//Remove jewel and and Score Counter
		void checkJewel(){
			foreach (var ruby in visibleJewels) {
				bool hit = ruby.BoundingBoxTransformedToParent.IntersectsRect(ballSprite.BoundingBoxTransformedToParent);
				if (hit)
				{
					hitJewels.Add(ruby);
					//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
					//Explode(banana.Position);
					ruby.RemoveFromParent(true);
					visibleJewels.Remove (ruby);
					score += 10;
					DisplayScore (score);
					break;

				}
			}

			foreach (var diamond in visibleJewels) {
				bool hit = diamond.BoundingBoxTransformedToParent.IntersectsRect(ballSprite.BoundingBoxTransformedToParent);
				if (hit)
				{
					hitJewels.Add(diamond);
					//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
					//Explode(banana.Position);
					diamond.RemoveFromParent();



				}
			}

			/*
			foreach (var diamond  in hitJewels)
			{

				score += 50;
				scoreLabel.Text = "Score: " + score;
			}
			foreach (var ruby  in hitJewels)
			{   
				ruby.RemoveFromParent(true);

				score += 10;
				scoreLabel.Text = "Score: " + score;
				break;

			}*/

			hitJewels.Clear();


		}
		//SPIKE

		CCSprite AddSTATIC_Spike (CCWindow mainWindow,float spikePosX,float spikePosY,float scale)
		{   

			spikeSprite = new CCSprite ("spike");
			spikeSprite.Scale = scale;
			spikeSprite.PositionX = spikePosX;
			spikeSprite.PositionY = spikePosY;
			var bounds = mainWindow.WindowSizeInPixels;

			mainLayer.AddChild(spikeSprite);


			return spikeSprite;
		}

		CCSprite AddUP_Spike(CCWindow mainWindow,float spikePosX,float spikePosY,float scale)
		{   

			spikeSprite = new CCSprite ("spike");
			spikeSprite.Scale = scale;
			spikeSprite.PositionX = spikePosX;
			spikeSprite.PositionY = spikePosY;
			var bounds = mainWindow.WindowSizeInPixels;

			mainLayer.AddChild(spikeSprite);

			CCRotateBy rotateSpike = new CCRotateBy (4.0f, 360);

			spikeSprite.RepeatForever(rotateSpike);
			CCMoveBy moveBySpike_UP = new CCMoveBy (5.0f,new CCPoint(-0.7f*bounds.Width,0.0f));
			spikeSprite.RepeatForever(moveBySpike_UP,moveBySpike_UP.Reverse());
			spikeSprite.RepeatForever (rotateSpike);

			return spikeSprite;

		}		



		CCSprite AddRIGHT_Spike(CCWindow mainWindow,float spikePosX,float spikePosY,float scale)
		{   
			spikeSprite = new CCSprite ("spike");
			spikeSprite.Scale = scale;
			spikeSprite.PositionX = spikePosX;
			spikeSprite.PositionY = spikePosY;
			var bounds = mainWindow.WindowSizeInPixels;

			mainLayer.AddChild(spikeSprite);

			CCRotateBy rotateSpike = new CCRotateBy (4.0f, 360);

			spikeSprite.RepeatForever(rotateSpike);
			CCMoveBy moveBySpike_UP = new CCMoveBy (5.0f,new CCPoint(0.0f,0.7f*bounds.Width));
			spikeSprite.RepeatForever(moveBySpike_UP,moveBySpike_UP.Reverse());
			spikeSprite.RepeatForever (rotateSpike);

			return spikeSprite;

		}


		void addLevelSpikes (CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;
			float pivotScale=0.0004f*bounds.Width;
			Level2Array LevelClass = new Level2Array ();
			List<Level2Array.Spike> ClassList = new List<Level2Array.Spike> ();

			ClassList = LevelClass.SpikeMaker ();

			foreach(var Spike in ClassList){
				Spike.PosX =Spike.PosX*bounds.Width;
				Spike.PosY = Spike.PosY*bounds.Height;

				switch(Spike.MoveType){
				case "STATIC":
					visibleTraps.Add (AddSTATIC_Spike (mainWindow,Spike.PosX,Spike.PosY,pivotScale));
					break;
				case "UP":
					visibleTraps.Add (AddUP_Spike (mainWindow,Spike.PosX,Spike.PosY,pivotScale));
					break;

				case "RIGHT":
					visibleTraps.Add (AddRIGHT_Spike (mainWindow,Spike.PosX,Spike.PosY,pivotScale));
					break;

				default:
					visibleTraps.Add (AddSTATIC_Spike (mainWindow,Spike.PosX,Spike.PosY,pivotScale));

					break;

				}

			}

		}


		void Explode (CCPoint pt)
		{
			var explosion = new CCParticleExplosion (pt); //TODO: manage "better" for performance when "many" particles
			explosion.TotalParticles = 18;
			explosion.AutoRemoveOnFinish = true;
			mainLayer.AddChild (explosion);
		}

		void checkTrap(){
			foreach (var spikeSprite in visibleTraps) {
				bool hit = spikeSprite.BoundingBoxTransformedToParent.IntersectsRect(ballSprite.BoundingBoxTransformedToParent);
				if (hit)
				{


					//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
					Explode(spikeSprite.Position);
					spikeSprite.RemoveFromParent(true);
					visibleTraps.Remove (spikeSprite);


					//hitJewels.Add(ruby);
					//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
					//Explode(banana.Position);
					//ruby.RemoveFromParent();
					score -= 50;
					DisplayScore (score);

					//ShouldEndGame ();
					break;
				}
			}


		}

		//ENDGAME
		void ShouldEndGame (){
			if (score <= -100) {
				EndGame ();
			}


		}
		void EndGame(){
			MultiPlayerScrollerScene gameScene = new MultiPlayerScrollerScene (mainWindowAux);
			mainWindowAux.RunWithScene (gameScene);

		}

		void DisplayScore(float score ){

			scoreLabel.Text = "Score: " + score;
			//
		}
	}

}




