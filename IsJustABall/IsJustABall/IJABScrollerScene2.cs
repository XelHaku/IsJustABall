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
		List<CCSprite> hitJewels;
		CCSprite ruby;
		CCSprite diamond;

		List<CCSprite> visiblePivots;
		CCSprite pivotSprite;

		List<CCSprite> visibleTraps;
		CCSprite spikeSprite;

		CCLabelTtf scoreLabel;


		float ballXVelocity =360 ;
		float ballYVelocity = 360;
		// How much to modify the ball's y velocity per second:
		float gravity = 0;
		//hookTouchBool=!hookTouchBool// to toggle on Touch
		bool hookTouchBool = true;
		//Speed for scroller level
		int scrollerSpeed= 100;
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
		double Multiplier =1.1f;
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

		public IJABScrollerScene(CCWindow mainWindow) : base(mainWindow)
		{

			mainLayer = new CCLayer ();
			AddChild (mainLayer);
			visiblePivots = new List<CCSprite> ();
			visibleJewels = new List<CCSprite> ();
			hitJewels = new List<CCSprite> ();
			visibleTraps = new List<CCSprite>();


			var bounds = mainWindow.WindowSizeInPixels;
			minRotationRadius = 0.15f*bounds.Height;

			addBlueBall(mainWindow);

			//addPivot(mainWindow);
			// add ALL pivots of the level
			addLevelPivots (mainWindow);
			addLevelJewels (mainWindow);
			addLevelSpikes (mainWindow);




			scoreLabel = new CCLabelTtf ("Score: 0", "arial", 22);
			scoreLabel.PositionX = mainLayer.VisibleBoundsWorldspace.MaxX/2 ;
			scoreLabel.PositionY = mainLayer.VisibleBoundsWorldspace.MaxY - 20;
			scoreLabel.AnchorPoint = CCPoint.AnchorUpperRight;

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

			foreach (var spikeSprite in visibleTraps) {

				spikeSprite.PositionY += -scrollerSpeed * frameTimeInSeconds;
				//element.Rotation (1.0f);
			}
			checkJewel ();
			checkTrap ();
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
					//scoreLabel.Text += "ClockwiseRotation: false";
				} else {
					ClockwiseRotation = true;
					//scoreLabel.Text += "ClockwiseRotation: true";

				}
			}



		}



		void freeParticle(float frameTimeInSeconds){
			gravity = 0;
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
			//CCRotateBy rotate = new CCRotateBy (0.0f, 90);
			//ruby.RunAction (rotate);

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
			String[] PivotMoveType = new String[10]; 
			float[,] PivotPosArray = new float[10,2];

			Level1Array levelArray = new Level1Array ();

			PivotPosArray = levelArray.PivotPosArray();
			PivotMoveType = levelArray.PivotTypeArray();

			//

			//scoreLabel.Text = (PivotPosArray.Length/2.0f).ToString();
			for(int i = 0;i<PivotPosArray.Length/2;i++){
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

		//JEWELS

		void addLevelJewels (CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;
			float jewelScale=0.0001f*bounds.Width;
			float[,] JewelPosArray = new float[10,2];

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
					hitJewels.Add(ruby);
					//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
					//Explode(banana.Position);
					ruby.RemoveFromParent();

					score += 10;
					scoreLabel.Text = "Score: " + score;

				}
			}


			foreach (var ruby  in hitJewels)
			{
				visibleJewels.Remove(ruby);
			}
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
			CCMoveBy moveBySpike_UP = new CCMoveBy (5.0f,new CCPoint(0.7f*bounds.Width,0.0f));
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
			float spikeScale=0.0001f*bounds.Width;
			String[] SpikeMoveType = new String[10]; 
			float[,] SpikePosArray = new float[10,2];

			Level1Array levelArray = new Level1Array ();

			SpikePosArray = levelArray.SpikePosArray();
			SpikeMoveType = levelArray.SpikeTypeArray();


			//

			//scoreLabel.Text = (PivotPosArray.Length/2.0f).ToString();
			for (int i = 0; i < SpikePosArray.Length/2; i++) {
				SpikePosArray [i, 0] = SpikePosArray [i, 0] * bounds.Width;
				SpikePosArray [i, 1] = SpikePosArray [i, 1] * bounds.Height;


				switch(SpikeMoveType[i]){
				case "STATIC":
					visibleTraps.Add (AddSTATIC_Spike (mainWindow, SpikePosArray [i, 0], SpikePosArray [i, 1], spikeScale));
					break;
				case "UP":
					visibleTraps.Add (AddUP_Spike (mainWindow, SpikePosArray [i, 0], SpikePosArray [i, 1], spikeScale));
					break;

				case "RIGHT":
					visibleTraps.Add (AddRIGHT_Spike (mainWindow, SpikePosArray [i, 0], SpikePosArray [i, 1], spikeScale));
					break;

				default:
					visibleTraps.Add (AddSTATIC_Spike (mainWindow, SpikePosArray [i, 0], SpikePosArray [i, 1], spikeScale));

					break;

				}

			}

		}

		void checkTrap(){
			foreach (var spikeSprite in visibleTraps) {
				bool hit = spikeSprite.BoundingBoxTransformedToParent.IntersectsRect(ballSprite.BoundingBoxTransformedToParent);
				if (hit)
				{
					//hitJewels.Add(ruby);
					//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
					//Explode(banana.Position);
					//ruby.RemoveFromParent();
					//score += 10;
					//scoreLabel.Text = "Score: " + score;

					EndGame ();
				}
			}


		}

		//ENDGAME
		void EndGame (){

			UnscheduleAll();
			scoreLabel.Text="ENDGAME";


		}
		//

	}

}



 u s i n g   C o c o s D e n s h i o n ;  
 u s i n g   S y s t e m . L i n q ;  
 n a m e s p a c e   I s J u s t A B a l l  
 {  
 	 p u b l i c   c l a s s   I J A B S c r o l l e r S c e n e   :   C C S c e n e  
 	 {  
 	 	 C C L a y e r   m a i n L a y e r ;  
  
 	 	 C C S p r i t e   b a l l S p r i t e ;  
  
 	 	 L i s t < C C S p r i t e >   v i s i b l e J e w e l s ;  
 	 	 L i s t < C C S p r i t e >   h i t J e w e l s ;  
 	 	 C C S p r i t e   r u b y ;  
 	 	 C C S p r i t e   d i a m o n d ;  
  
 	 	 L i s t < C C S p r i t e >   v i s i b l e P i v o t s ;  
 	 	 C C S p r i t e   p i v o t S p r i t e ;  
  
 	 	 L i s t < C C S p r i t e >   v i s i b l e T r a p s ;  
 	 	 C C S p r i t e   s p i k e S p r i t e ;  
  
 	 	 C C L a b e l T t f   s c o r e L a b e l ;  
  
  
 	 	 f l o a t   b a l l X V e l o c i t y   = 3 6 0   ;  
 	 	 f l o a t   b a l l Y V e l o c i t y   =   3 6 0 ;  
 	 	 / /   H o w   m u c h   t o   m o d i f y   t h e   b a l l ' s   y   v e l o c i t y   p e r   s e c o n d :  
 	 	 f l o a t   g r a v i t y   =   0 ;  
 	 	 / / h o o k T o u c h B o o l = ! h o o k T o u c h B o o l / /   t o   t o g g l e   o n   T o u c h  
 	 	 b o o l   h o o k T o u c h B o o l   =   t r u e ;  
 	 	 / / S p e e d   f o r   s c r o l l e r   l e v e l  
 	 	 i n t   s c r o l l e r S p e e d =   1 0 0 ;  
 	 	 / / D e c l a r e   v a r i a b l e s   f o r   H o o k e d P a r t i c l e   M e t h o d  
 	 	 d o u b l e   d R a d i u s _ X ;  
 	 	 d o u b l e   d R a d i u s _ Y ;  
 	 	 d o u b l e   R a d i u s ;  
 	 	 d o u b l e   t e m p ;  
 	 	 d o u b l e   b a l l S p e e d ;  
 	 	 d o u b l e   S i n T h e t a Z e r o ;  
 	 	 d o u b l e   C o s T h e t a Z e r o ;  
 	 	 d o u b l e   C o s A l p h a ;  
 	 	 d o u b l e   S i n A l p h a ;  
 	 	 d o u b l e   t h e t a = 0 ;  
 	 	 d o u b l e   T h e t a Z e r o = 0 ;  
 	 	 d o u b l e   M u l t i p l i e r   = 1 . 1 f ;  
 	 	 d o u b l e   w Z e r o ;  
 	 	 d o u b l e   b a l l S p e e d F i n a l ;  
 	 	 b o o l   C l o c k w i s e R o t a t i o n   =   t r u e ;  
 	 	 f l o a t   m i n R o t a t i o n R a d i u s ;  
  
 	 	  
 	 	 / / /   / / / / / / / / / / / / / / / / / /  
 	 	 / / n e e d e d   f o r   m u l t i p l e   P i v o t s  
 	 	 f l o a t   h o o k e d P i v o t P o s X , h o o k e d P i v o t P o s Y ;  
 	 	 i n t   i n d e x H o o k P i v o t ;  
 	 	 / / /    
 	 	 i n t   s c o r e   =   0 ;  
  
 	 	 / / M o v e m e n t s o n   P i v o t s  
 	 	      
  
 	 	 C C E v e n t L i s t e n e r T o u c h A l l A t O n c e   t o u c h L i s t e n e r ;  
  
 	 	 p u b l i c   I J A B S c r o l l e r S c e n e ( C C W i n d o w   m a i n W i n d o w )   :   b a s e ( m a i n W i n d o w )  
 	 	 {  
  
 	 	 	 m a i n L a y e r   =   n e w   C C L a y e r   ( ) ;  
 	 	 	 A d d C h i l d   ( m a i n L a y e r ) ;  
 	 	 	 v i s i b l e P i v o t s   =   n e w   L i s t < C C S p r i t e >   ( ) ;  
 	 	 	 v i s i b l e J e w e l s   =   n e w   L i s t < C C S p r i t e >   ( ) ;  
 	 	 	 h i t J e w e l s   =   n e w   L i s t < C C S p r i t e >   ( ) ;  
 	 	 	 v i s i b l e T r a p s   =   n e w   L i s t < C C S p r i t e > ( ) ;  
  
  
 	 	 	 v a r   b o u n d s   =   m a i n W i n d o w . W i n d o w S i z e I n P i x e l s ;  
 	 	 	 m i n R o t a t i o n R a d i u s   =   0 . 1 5 f * b o u n d s . H e i g h t ;  
  
 	 	 	 a d d B l u e B a l l ( m a i n W i n d o w ) ;  
  
 	 	 	 / / a d d P i v o t ( m a i n W i n d o w ) ;  
 	 	 	 / /   a d d   A L L   p i v o t s   o f   t h e   l e v e l  
 	 	 	 a d d L e v e l P i v o t s   ( m a i n W i n d o w ) ;  
 	 	 	 a d d L e v e l J e w e l s   ( m a i n W i n d o w ) ;  
 	 	 	 a d d L e v e l S p i k e s   ( m a i n W i n d o w ) ;  
  
  
  
  
 	 	 	 s c o r e L a b e l   =   n e w   C C L a b e l T t f   ( " S c o r e :   0 " ,   " a r i a l " ,   2 2 ) ;  
 	 	 	 s c o r e L a b e l . P o s i t i o n X   =   m a i n L a y e r . V i s i b l e B o u n d s W o r l d s p a c e . M a x X / 2   ;  
 	 	 	 s c o r e L a b e l . P o s i t i o n Y   =   m a i n L a y e r . V i s i b l e B o u n d s W o r l d s p a c e . M a x Y   -   2 0 ;  
 	 	 	 s c o r e L a b e l . A n c h o r P o i n t   =   C C P o i n t . A n c h o r U p p e r R i g h t ;  
  
 	 	 	 m a i n L a y e r . A d d C h i l d   ( s c o r e L a b e l ) ;  
  
 	 	 	 S c h e d u l e   ( R u n G a m e L o g i c ) ;  
  
  
 	 	 	 / /   N e w   c o d e :  
 	 	 	 t o u c h L i s t e n e r   =   n e w   C C E v e n t L i s t e n e r T o u c h A l l A t O n c e   ( ) ;  
 	 	 	 t o u c h L i s t e n e r . O n T o u c h e s M o v e d   =   H a n d l e T o u c h e s M o v e d ;    
 	 	 	 t o u c h L i s t e n e r . O n T o u c h e s B e g a n   =   H a n d l e T o u c h e s B e g a n ;    
 	 	 	 A d d E v e n t L i s t e n e r   ( t o u c h L i s t e n e r ,   t h i s ) ;  
  
 	 	 }  
  
 	 	 v o i d   R u n G a m e L o g i c ( f l o a t   f r a m e T i m e I n S e c o n d s )  
 	 	 {  
 	 	 	 i f   ( h o o k T o u c h B o o l   = =   t r u e )   { / / V o i d   f r e e   P a r t i c l e  
 	 	 	 	 f r e e P a r t i c l e   ( f r a m e T i m e I n S e c o n d s ) ;  
 	 	 	 }   e l s e   {  
 	 	 	 	 / / v o i d   H o o k e d P a r t i c l e  
 	 	 	 	 h o o k e d P a r t i c l e   ( f r a m e T i m e I n S e c o n d s ) ;  
 	 	 	 }  
 	 	 	 / / m o v e m e n t   o n   p i v o t s   o v e r   t i m e  
 	 	 	 f o r e a c h   ( v a r   p i v o t S p r i t e   i n   v i s i b l e P i v o t s )   {  
  
 	 	 	 	 p i v o t S p r i t e . P o s i t i o n Y   + =   - s c r o l l e r S p e e d   *   f r a m e T i m e I n S e c o n d s ;  
 	 	 	 	 / / e l e m e n t . R o t a t i o n   ( 1 . 0 f ) ;  
 	 	 	 	 	 	 }  
  
 	 	 	 f o r e a c h   ( v a r   r u b y   i n   v i s i b l e J e w e l s )   {  
  
 	 	 	 	 r u b y . P o s i t i o n Y   + =   - s c r o l l e r S p e e d   *   f r a m e T i m e I n S e c o n d s ;  
 	 	 	 	 / / e l e m e n t . R o t a t i o n   ( 1 . 0 f ) ;  
 	 	 	 }  
  
 	 	 	 f o r e a c h   ( v a r   s p i k e S p r i t e   i n   v i s i b l e T r a p s )   {  
  
 	 	 	 	 s p i k e S p r i t e . P o s i t i o n Y   + =   - s c r o l l e r S p e e d   *   f r a m e T i m e I n S e c o n d s ;  
 	 	 	 	 / / e l e m e n t . R o t a t i o n   ( 1 . 0 f ) ;  
 	 	 	 }  
 	 	 	 c h e c k J e w e l   ( ) ;  
 	 	 	 c h e c k T r a p   ( ) ;  
 	 	 }  
  
  
  
 	 	 v o i d   H a n d l e T o u c h e s M o v e d   ( S y s t e m . C o l l e c t i o n s . G e n e r i c . L i s t < C C T o u c h >   t o u c h e s ,   C C E v e n t   t o u c h E v e n t )  
 	 	 {  
 	 	 	 / /   w e   o n l y   c a r e   a b o u t   t h e   f i r s t   t o u c h :  
 	 	 	 / / v a r   l o c a t i o n O n S c r e e n   =   t o u c h e s   [ 0 ] . L o c a t i o n O n S c r e e n ;  
 	 	 	 / / p a d d l e S p r i t e . P o s i t i o n X   =   l o c a t i o n O n S c r e e n . X ;  
 	 	 }  
 	 	 v o i d   H a n d l e T o u c h e s B e g a n ( S y s t e m . C o l l e c t i o n s . G e n e r i c . L i s t < C C T o u c h >   t o u c h e s ,   C C E v e n t   t o u c h E v e n t ) {  
 	 	 	 d o u b l e   c l o s e s t P i v o t   =   1 0 0 0 0 ;  
 	 	 	 / * f o r e a c h   ( v a r   p i v o t S p r i t e   i n   v i s i b l e P i v o t s )   {  
 	 	 	 	 d R a d i u s _ X   =   b a l l S p r i t e . P o s i t i o n X   -   p i v o t S p r i t e . P o s i t i o n X ;  
 	 	 	 	 d R a d i u s _ Y   =   b a l l S p r i t e . P o s i t i o n Y   -   p i v o t S p r i t e . P o s i t i o n Y ;  
  
  
 	 	 	 	 t e m p   =   M a t h . P o w   ( ( d o u b l e ) d R a d i u s _ X ,   2 )   +   M a t h . P o w   ( ( d o u b l e ) d R a d i u s _ Y ,   2 ) ;  
 	 	 	 	 t e m p   =   M a t h . P o w   ( t e m p ,   0 . 5 ) ;  
  
 	 	 	 	 i f   ( t e m p   <   c l o s e s t P i v o t )   {  
 	 	 	 	 	 h o o k e d P i v o t P o s X   =   p i v o t S p r i t e . P o s i t i o n X ;  
 	 	 	 	 	 h o o k e d P i v o t P o s Y   =   p i v o t S p r i t e . P o s i t i o n Y ;  
 	 	 	 	 	 c l o s e s t P i v o t   =   t e m p ;  
 	 	 	 	  
 	 	 	 	  
 	 	 	 	 }  
  
  
 	 	 	 } * /  
  
  
 	 	 	 f o r   ( i n t   i   = 0 ;   i   <   v i s i b l e P i v o t s . C o u n t ; i + + )   {  
 	 	 	 	 d R a d i u s _ X   =   b a l l S p r i t e . P o s i t i o n X   -   v i s i b l e P i v o t s [ i ] . P o s i t i o n X ;  
 	 	 	 	 d R a d i u s _ Y   =   b a l l S p r i t e . P o s i t i o n Y   -   v i s i b l e P i v o t s [ i ] . P o s i t i o n Y ;  
  
  
 	 	 	 	 t e m p   =   M a t h . P o w   ( ( d o u b l e ) d R a d i u s _ X ,   2 )   +   M a t h . P o w   ( ( d o u b l e ) d R a d i u s _ Y ,   2 ) ;  
 	 	 	 	 t e m p   =   M a t h . P o w   ( t e m p ,   0 . 5 ) ;  
  
 	 	 	 	 i f   ( t e m p   <   c l o s e s t P i v o t )   {  
 	 	 	 	 	 h o o k e d P i v o t P o s X   =   v i s i b l e P i v o t s [ i ] . P o s i t i o n X ;  
 	 	 	 	 	 h o o k e d P i v o t P o s Y   =   v i s i b l e P i v o t s [ i ] . P o s i t i o n Y ;  
 	 	 	 	 	 c l o s e s t P i v o t   =   t e m p ;  
 	 	 	 	 	 i n d e x H o o k P i v o t   =   i ;  
  
 	 	 	 	 }  
  
  
 	 	 	 }  
  
 	 	 	 i f   ( c l o s e s t P i v o t   <   m i n R o t a t i o n R a d i u s   & &   h o o k T o u c h B o o l   = =   t r u e )   {  
 	 	 	 	 h o o k T o u c h B o o l   =   f a l s e ; / / T o g g l e   h o o k  
 	 	 	 	 / / s c o r e L a b e l . T e x t   =   " t e m p : "   +   t e m p . T o S t r i n g   ( )   +   "   \ n C i r c l e R a d i u s :   "   +   m i n R o t a t i o n R a d i u s . T o S t r i n g   ( )   +   "   \ n b a l l :   "   +   b a l l S p r i t e . P o s i t i o n . T o S t r i n g   ( )   +   "   \ n p i v o t :   "   +   p i v o t S p r i t e . P o s i t i o n . T o S t r i n g   ( ) ;  
  
 	 	 	 }   e l s e   i f   ( h o o k T o u c h B o o l   = =   f a l s e )   {  
 	 	 	 	 h o o k T o u c h B o o l   =   t r u e ;  
 	 	 	 	 / / s c o r e L a b e l . T e x t   =   " F r e e " ;  
 	 	 	 }  
  
  
  
  
  
  
  
 	 	 	 	 i f   ( h o o k T o u c h B o o l   = =   f a l s e )   {  
 	 	 	 	 	 / / S e t   v a l u e s   f o r   s p p e d   a n d   r a d i u s   o r   r o t a t i o n   r a o u n d   P i v o t  
  
 	 	 	 	 d R a d i u s _ X   =   b a l l S p r i t e . P o s i t i o n X   -   v i s i b l e P i v o t s [ i n d e x H o o k P i v o t ] . P o s i t i o n X ;  
 	 	 	 	 d R a d i u s _ Y   =   b a l l S p r i t e . P o s i t i o n Y   -   v i s i b l e P i v o t s [ i n d e x H o o k P i v o t ] . P o s i t i o n Y ;  
  
 	 	 	 	 	 R a d i u s   =   M a t h . P o w   ( ( d o u b l e ) d R a d i u s _ X ,   2 )   +   M a t h . P o w   ( ( d o u b l e ) d R a d i u s _ Y ,   2 ) ;  
 	 	 	 	 	 R a d i u s   =   M a t h . P o w   ( R a d i u s ,   0 . 5 ) ;  
  
  
 	 	 	 	 	 b a l l S p e e d   =   M a t h . P o w   ( b a l l X V e l o c i t y ,   2 )   +   M a t h . P o w   ( b a l l Y V e l o c i t y ,   2 ) ;  
 	 	 	 	 	 b a l l S p e e d   =   M a t h . P o w   ( b a l l S p e e d ,   0 . 5 d ) ;  
  
 	 	 	 	 	 C o s T h e t a Z e r o   =   d R a d i u s _ X   /   R a d i u s ;  
 	 	 	 	 	 S i n T h e t a Z e r o   =   d R a d i u s _ Y   /   R a d i u s ;  
  
 	 	 	 	 	 C o s A l p h a   =   ( d R a d i u s _ X   *   b a l l X V e l o c i t y   +   d R a d i u s _ Y   *   b a l l Y V e l o c i t y )   /   ( R a d i u s   *   b a l l S p e e d ) ;  
  
 	 	 	 	 	 i f   ( M a t h . P o w   ( C o s A l p h a ,   2 )   <   0 . 5 )   {  
 	 	 	 	 	 	 C o s A l p h a   =   M a t h . P o w   ( 0 . 5 ,   0 . 5 ) ;  
 	 	 	 	 	 }  
 	 	 	 	 	 S i n A l p h a   =   ( 1   -   M a t h . P o w   ( C o s A l p h a ,   2 ) ) ;  
 	 	 	 	 	 S i n A l p h a   =   M a t h . P o w   ( S i n A l p h a ,   0 . 5 f ) ;  
  
  
 	 	 	 	 	 w Z e r o   =   b a l l S p e e d   /   R a d i u s ;  
 	 	 	 	 	 / / b a l l S p e e d F i n a l   =   R a d i u s   *   M u l t i p l i e r   *   w Z e r o   *   S i n A l p h a ;  
 	 	 	 	 b a l l S p e e d F i n a l   =   R a d i u s   *   M u l t i p l i e r   *   w Z e r o   ;  
  
 	 	 	 	 	 T h e t a Z e r o   =   M a t h . A c o s   ( C o s T h e t a Z e r o ) ;  
  
 	 	 	 	 	 / / S e c o n d   Q u a d r a n t  
 	 	 	 	 	 i f   ( S i n T h e t a Z e r o   >   0   & &   C o s T h e t a Z e r o   <   0 )   {  
 	 	 	 	 	 	 T h e t a Z e r o   =   ( 1   /   2 )   *   M a t h . P I   +   T h e t a Z e r o ;  
 	 	 	 	 	 }  
 	 	 	 	 	 / / T h i r d   Q u a d r a n t  
 	 	 	 	 	 i f   ( S i n T h e t a Z e r o   <   0   & &   C o s T h e t a Z e r o   <   0 )   {  
 	 	 	 	 	 	 T h e t a Z e r o   =   ( 2 )   *   M a t h . P I   -   T h e t a Z e r o ;  
 	 	 	 	 	 }  
  
  
  
 	 	 	 	 	 / / F o u r t h   Q u a d r a n t  
 	 	 	 	 	 i f   ( S i n T h e t a Z e r o   <   0   & &   C o s T h e t a Z e r o   >   0 )   {  
 	 	 	 	 	 	 T h e t a Z e r o   =   - T h e t a Z e r o ;  
 	 	 	 	 	 }  
 	 	 	 	 	 t h e t a   =   T h e t a Z e r o ;  
 	 	 	 	 	 / / D e f i n e   i f   i t   i s   c l o c k w i s e   o r   a n t i c l o c k w i s e   r o t a t i o n  
  
 	 	 	 	 	 i f   ( d R a d i u s _ X   *   b a l l Y V e l o c i t y   -   d R a d i u s _ Y   *   b a l l X V e l o c i t y   < =   0 )   {  
 	 	 	 	 	 	 C l o c k w i s e R o t a t i o n   =   f a l s e ;  
 	 	 	 	 	 	 / / s c o r e L a b e l . T e x t   + =   " C l o c k w i s e R o t a t i o n :   f a l s e " ;  
 	 	 	 	 	 }   e l s e   {  
 	 	 	 	 	 	 C l o c k w i s e R o t a t i o n   =   t r u e ;  
 	 	 	 	 	 	 / / s c o r e L a b e l . T e x t   + =   " C l o c k w i s e R o t a t i o n :   t r u e " ;  
  
 	 	 	 	 	 }  
 	 	 	 	 }  
  
 	  
 	 	 	  
 	 	 }  
  
  
  
 	 	 v o i d   f r e e P a r t i c l e ( f l o a t   f r a m e T i m e I n S e c o n d s ) {  
 	 	 	 g r a v i t y   =   0 ;  
 	 	 	 / /   T h i s   i s   a   l i n e a r   a p p r o x i m a t i o n ,   s o   n o t   1 0 0 %   a c c u r a t e  
 	 	 	 b a l l X V e l o c i t y   + =   f r a m e T i m e I n S e c o n d s   *   g r a v i t y ;  
 	 	 	 b a l l S p r i t e . P o s i t i o n X   + =   b a l l X V e l o c i t y   *   f r a m e T i m e I n S e c o n d s ;  
 	 	 	 b a l l S p r i t e . P o s i t i o n Y   + =   b a l l Y V e l o c i t y   *   f r a m e T i m e I n S e c o n d s ;  
 	 	 	 / /   N e w   c o d e :  
 	 	 	 / / s c o r e + + ;  
 	 	 	 / / s c o r e L a b e l . T e x t   =   " S c o r e :   "   +   s c o r e ;  
 	 	 	 / /   C h e c k   i f   t h e   b a l l   i s   e i t h e r   t o o   f a r   t o   t h e   r i g h t   o r   l e f t :  
 	 	 	 f l o a t   b a l l R i g h t   =   b a l l S p r i t e . B o u n d i n g B o x T r a n s f o r m e d T o P a r e n t . M a x X ;  
 	 	 	 f l o a t   b a l l L e f t   =   b a l l S p r i t e . B o u n d i n g B o x T r a n s f o r m e d T o P a r e n t . M i n X ;  
  
 	 	 	 f l o a t   s c r e e n R i g h t   =   m a i n L a y e r . V i s i b l e B o u n d s W o r l d s p a c e . M a x X ;  
 	 	 	 f l o a t   s c r e e n L e f t   =   m a i n L a y e r . V i s i b l e B o u n d s W o r l d s p a c e . M i n X ;  
  
 	 	 	 b o o l   s h o u l d R e f l e c t X V e l o c i t y   =   ( b a l l R i g h t   >   s c r e e n R i g h t   & &   b a l l X V e l o c i t y   >   0 )   | | 	 ( b a l l L e f t   <   s c r e e n L e f t   & &   b a l l X V e l o c i t y   <   0 ) ;  
  
  
 	 	 	 i f   ( s h o u l d R e f l e c t X V e l o c i t y )  
 	 	 	 {  
 	 	 	 	 b a l l X V e l o c i t y   * =   - 1 ;  
  
 	 	 	 }  
  
 	 	 	 / /   C h e c k   i f   t h e   b a l l   i s   e i t h e r   t o o   f a r   t o   t h e   r i g h t   o r   l e f t :  
  
 	 	 	 f l o a t   b a l l T o p   =   b a l l S p r i t e . B o u n d i n g B o x T r a n s f o r m e d T o P a r e n t . M a x Y ;  
 	 	 	 f l o a t   b a l l B o t t o m   =   b a l l S p r i t e . B o u n d i n g B o x T r a n s f o r m e d T o P a r e n t . M i n Y ;  
  
 	 	 	 f l o a t   s c r e e n T o p   =   m a i n L a y e r . V i s i b l e B o u n d s W o r l d s p a c e . M a x Y ;  
 	 	 	 f l o a t   s c r e e n B o t t o m   =   m a i n L a y e r . V i s i b l e B o u n d s W o r l d s p a c e . M i n Y ;  
  
 	 	 	 b o o l   s h o u l d R e f l e c t Y V e l o c i t y   =   ( b a l l T o p   >   s c r e e n T o p   & &   b a l l Y V e l o c i t y   >   0 )   | | 	 ( b a l l B o t t o m   <   s c r e e n B o t t o m   & &   b a l l Y V e l o c i t y   <   0 ) ;  
  
 	 	 	 i f   ( s h o u l d R e f l e c t Y V e l o c i t y )  
 	 	 	 {  
 	 	 	 	 b a l l Y V e l o c i t y   * =   - 1 ;  
 	 	 	 }  
  
  
 	 	 }  
  
 	 	 v o i d   h o o k e d P a r t i c l e ( f l o a t   f r a m e T i m e I n S e c o n d s ) {  
 	 	 	 g r a v i t y   =   0 ;  
  
 	 	  
 	 	 	 / / m u l t i p l i e r   o n   c l o s e   r a d i u s \  
 	 	 	 / / d o u b l e   m u l t R   =   ( 1 0   /   R a d i u s ) ;  
  
 	 	 	 i f   ( C l o c k w i s e R o t a t i o n   = =   t r u e )   {  
 	 	 	 	 / / t h e t a + =   ( d o u b l e ) ( M u l t i p l i e r * w Z e r o * S i n A l p h a * f r a m e T i m e I n S e c o n d s ) ;  
 	 	 	 	 t h e t a + =   ( d o u b l e ) ( M u l t i p l i e r * w Z e r o * f r a m e T i m e I n S e c o n d s ) ;  
  
 	 	 	 	 b a l l X V e l o c i t y   =   ( f l o a t ) ( - b a l l S p e e d F i n a l   *   M a t h . S i n   ( t h e t a ) ) ;  
 	 	 	 	 b a l l Y V e l o c i t y   =   ( f l o a t ) ( b a l l S p e e d F i n a l   *   M a t h . C o s   ( t h e t a ) ) ;  
 	 	 	 	 	 	 	 }  
 	 	 	 e l s e   {  
 	 	 	 	 / / t h e t a - =   ( d o u b l e ) ( M u l t i p l i e r * w Z e r o * S i n A l p h a * f r a m e T i m e I n S e c o n d s ) ;  
 	 	 	 	 t h e t a - =   ( d o u b l e ) ( M u l t i p l i e r * w Z e r o * f r a m e T i m e I n S e c o n d s ) ;  
  
 	 	 	 	 b a l l X V e l o c i t y   =   ( f l o a t ) ( b a l l S p e e d F i n a l   *   M a t h . S i n   ( t h e t a ) ) ;  
 	 	 	 	 b a l l Y V e l o c i t y   =   ( f l o a t ) ( - b a l l S p e e d F i n a l   *   M a t h . C o s   ( t h e t a ) ) ;  
 	 	 	 	 	 	 	 	 	 	 }  
 	 	 	 	 / / / / / / / / /  
 	 	 	 b a l l S p r i t e . P o s i t i o n X   = ( f l o a t ) ( R a d i u s * M a t h . C o s ( t h e t a )   +   v i s i b l e P i v o t s [ i n d e x H o o k P i v o t ] . P o s i t i o n X ) ;  
 	 	 	 b a l l S p r i t e . P o s i t i o n Y   =   ( f l o a t ) ( R a d i u s * M a t h . S i n ( t h e t a )   +   v i s i b l e P i v o t s [ i n d e x H o o k P i v o t ] . P o s i t i o n Y ) ;  
  
  
 	 	 	 / / / R e m o v e   g o n e   f a r   P i v o t s  
 	 	 	 / * f o r   ( i n t   i   = 0 ;   i   <   v i s i b l e P i v o t s . C o u n t ; i + + )   {  
  
  
 	 	 	 	 i f   ( v i s i b l e P i v o t s [ i ] . P o s i t i o n Y   <   - 5 0 0 )   {  
 	 	 	 	 	 v i s i b l e P i v o t s . R e m o v e A t   ( i ) ;  
 	 	 	 }  
  
  
  
 	 	 } * /  
 	 	  
 	 	 }  
  
  
 	 	 / / /   O B J E C T S   A N D   S P R I T E S  
  
 	 	 v o i d   a d d B l u e B a l l ( C C W i n d o w   m a i n W i n d o w ) {  
 	 	 	 v a r   b o u n d s   =   m a i n W i n d o w . W i n d o w S i z e I n P i x e l s ;  
  
 	 	 	 b a l l S p r i t e   =   n e w   C C S p r i t e   ( " b l u e b a l l " ) ;  
 	 	 	 b a l l S p r i t e . S c a l e   =   0 . 0 0 0 5 f * b o u n d s . W i d t h ;  
 	 	 	 b a l l S p r i t e . P o s i t i o n X   =   0 . 5 f * b o u n d s . W i d t h ;  
 	 	 	 b a l l S p r i t e . P o s i t i o n Y   =   - 0 . 2 f * b o u n d s . H e i g h t ;  
 	 	  
 	 	 	 / / p a r t i c l e E f f e t O n B a l l ( b a l l S p r i t e . P o s i t i o n X , b a l l S p r i t e . P o s i t i o n Y ) ;  
 	 	 	 m a i n L a y e r . A d d C h i l d   ( b a l l S p r i t e ) ;  
  
  
  
 	 	 }  
  
 	 	 C C S p r i t e   a d d D i a m o n d ( C C W i n d o w   m a i n W i n d o w ,   f l o a t   d i a m o n d P o s X , f l o a t   d i a m o n d P o s Y , f l o a t   s c a l e ) {  
 	 	 	 v a r   b o u n d s   =   m a i n W i n d o w . W i n d o w S i z e I n P i x e l s ;  
  
 	 	 	 d i a m o n d   =   n e w   C C S p r i t e   ( " d i a m o n d " ) ;  
 	 	 	 d i a m o n d . S c a l e   =   s c a l e ;  
 	 	 	 d i a m o n d . P o s i t i o n X   =   d i a m o n d P o s X ;  
 	 	 	 d i a m o n d . P o s i t i o n Y   =   d i a m o n d P o s Y ;  
 	 	 	 C C R o t a t e B y   r o t a t e   =   n e w   C C R o t a t e B y   ( 0 . 0 f ,   9 0 ) ;  
 	 	 	 d i a m o n d . R u n A c t i o n   ( r o t a t e ) ;  
  
 	 	 	 / / p a r t i c l e E f f e t O n B a l l ( b a l l S p r i t e . P o s i t i o n X , b a l l S p r i t e . P o s i t i o n Y ) ;  
 	 	 	 m a i n L a y e r . A d d C h i l d   ( d i a m o n d ) ;  
 	 	 	 r e t u r n   d i a m o n d ;  
 	 	 }  
  
 	 	 C C S p r i t e   a d d R u b y ( C C W i n d o w   m a i n W i n d o w , f l o a t   r u b y P o s X , f l o a t   r u b y P o s Y , f l o a t   s c a l e ) {  
 	 	 	 v a r   b o u n d s   =   m a i n W i n d o w . W i n d o w S i z e I n P i x e l s ;  
  
 	 	 	 r u b y   =   n e w   C C S p r i t e   ( " r u b y " ) ;  
 	 	 	 r u b y . S c a l e   =   s c a l e ;  
 	 	 	 r u b y . P o s i t i o n X   =   r u b y P o s X ;  
 	 	 	 r u b y . P o s i t i o n Y   =   r u b y P o s Y ;  
 	 	 	 / / C C R o t a t e B y   r o t a t e   =   n e w   C C R o t a t e B y   ( 0 . 0 f ,   9 0 ) ;  
 	 	 	 / / r u b y . R u n A c t i o n   ( r o t a t e ) ;  
  
 	 	 	 / / p a r t i c l e E f f e t O n B a l l ( b a l l S p r i t e . P o s i t i o n X , b a l l S p r i t e . P o s i t i o n Y ) ;  
 	 	 	 m a i n L a y e r . A d d C h i l d   ( r u b y ) ;  
 	 	 	 r e t u r n   r u b y ;  
 	 	 }  
 	  
  
 	 	 C C S p r i t e   A d d S T A T I C _ P i v o t s   ( C C W i n d o w   m a i n W i n d o w , f l o a t   p i v o t P o s X , f l o a t   p i v o t P o s Y , f l o a t   s c a l e )  
 	 	 {        
  
 	 	 	 p i v o t S p r i t e   =   n e w   C C S p r i t e   ( " p i v o t " ) ;  
 	 	 	 p i v o t S p r i t e . S c a l e   =   s c a l e ;  
 	 	 	 p i v o t S p r i t e . P o s i t i o n X   =   p i v o t P o s X ;  
 	 	 	 p i v o t S p r i t e . P o s i t i o n Y   =   p i v o t P o s Y ;  
 	 	 	 f l o a t   h =   ( f l o a t ) p i v o t S p r i t e . C o n t e n t S i z e . H e i g h t / 2 . 0 f ;  
 	 	 	 C C P o i n t   t e m p P o s   =   n e w   C C P o i n t ( h , h ) ;  
 	 	 	 / / v a r   g a l a x y   =   n e w   C C P a r t i c l e G a l a x y   ( t e m p P o s ) ;   / / T O D O :   m a n a g e   " b e t t e r "   f o r   p e r f o r m a n c e   w h e n   " m a n y "   p a r t i c l e s  
 	 	 	 v a r   C i r c l e D r a w   =   n e w   C C D r a w N o d e ( ) ;  
 	 	 	 v a r   B l u e C o l o r   =   n e w   C C C o l o r 4 B   ( 0 ,   0 ,   2 5 5 ,   1 ) ;  
 	 	 	 / *   D r a w C i r c l e ( C C P o i n t ,   f l o a t ,   C C C o l o r 4 B )  
 	 	 	 ) * /  
 	 	 	 v a r   b o u n d s   =   m a i n W i n d o w . W i n d o w S i z e I n P i x e l s ;  
 	 	 	 C i r c l e D r a w . D r a w C i r c l e   ( t e m p P o s ,   1 . 0 f * b o u n d s . W i d t h , B l u e C o l o r ) ;  
 	 	 	 / / g a l a x y . S c a l e   =   6 . 0 f ;  
  
  
 	 	 	 / / p i v o t S p r i t e . A d d C h i l d   ( g a l a x y ) ;  
 	 	 	 p i v o t S p r i t e . A d d C h i l d   ( C i r c l e D r a w ) ;  
  
 	 	 	 / / m a i n L a y e r . A d d C h i l d   ( p i v o t S p r i t e ) ;  
 	 	 	 m a i n L a y e r . A d d C h i l d ( p i v o t S p r i t e ) ;  
  
 	 	 	 C C R o t a t e B y   r o t a t e P i v o t   =   n e w   C C R o t a t e B y   ( 1 . 0 f ,   3 6 0 ) ;  
  
 	 	 	 p i v o t S p r i t e . R e p e a t F o r e v e r ( r o t a t e P i v o t ) ;  
 	 	 	 r e t u r n   p i v o t S p r i t e ;  
 	 	 }  
  
 	 	 C C S p r i t e   A d d U P _ P i v o t s ( C C W i n d o w   m a i n W i n d o w , f l o a t   p i v o t P o s X , f l o a t   p i v o t P o s Y , f l o a t   s c a l e )  
 	 	 {        
  
  
 	 	 	 p i v o t S p r i t e   =   n e w   C C S p r i t e   ( " p i v o t " ) ;  
 	 	 	 p i v o t S p r i t e . S c a l e   =   s c a l e ;  
 	 	 	 p i v o t S p r i t e . P o s i t i o n X   =   p i v o t P o s X ;  
 	 	 	 p i v o t S p r i t e . P o s i t i o n Y   =   p i v o t P o s Y ;  
 	 	 	 f l o a t   h   =   ( f l o a t ) p i v o t S p r i t e . C o n t e n t S i z e . H e i g h t   /   2 . 0 f ;  
 	 	 	 C C P o i n t   t e m p P o s   =   n e w   C C P o i n t   ( h ,   h ) ;  
 	 	 	 / / v a r   g a l a x y   =   n e w   C C P a r t i c l e G a l a x y   ( t e m p P o s ) ;   / / T O D O :   m a n a g e   " b e t t e r "   f o r   p e r f o r m a n c e   w h e n   " m a n y "   p a r t i c l e s  
 	 	 	 v a r   C i r c l e D r a w   =   n e w   C C D r a w N o d e   ( ) ;  
 	 	 	 v a r   B l u e C o l o r   =   n e w   C C C o l o r 4 B   ( 0 ,   0 ,   2 5 5 ,   1 ) ;  
 	 	 	 v a r   b o u n d s   =   m a i n W i n d o w . W i n d o w S i z e I n P i x e l s ;  
 	 	 	 C i r c l e D r a w . D r a w C i r c l e   ( t e m p P o s ,   1 . 0 f   *   b o u n d s . W i d t h ,   B l u e C o l o r ) ;  
 	 	 	 p i v o t S p r i t e . A d d C h i l d   ( C i r c l e D r a w ) ;  
 	 	 	 m a i n L a y e r . A d d C h i l d   ( p i v o t S p r i t e ) ;  
 	 	 	 C C R o t a t e B y   r o t a t e P i v o t   =   n e w   C C R o t a t e B y   ( 1 . 0 f ,   3 6 0 ) ;  
 	 	 	 C C M o v e B y   m o v e B y P i v o t _ U P   =   n e w   C C M o v e B y   ( 3 . 0 f , n e w   C C P o i n t ( 0 . 7 f * b o u n d s . W i d t h , 0 . 0 f ) ) ;  
 	 	 	 p i v o t S p r i t e . R e p e a t F o r e v e r ( m o v e B y P i v o t _ U P , m o v e B y P i v o t _ U P . R e v e r s e ( ) ) ;  
 	 	 	 p i v o t S p r i t e . R e p e a t F o r e v e r   ( r o t a t e P i v o t ) ;  
 	 	 	 r e t u r n   p i v o t S p r i t e ;  
  
 	 	 } 	 	  
  
  
 	 	 C C S p r i t e   A d d D O W N _ P i v o t s ( C C W i n d o w   m a i n W i n d o w , f l o a t   p i v o t P o s X , f l o a t   p i v o t P o s Y , f l o a t   s c a l e )  
 	 	 {        
  
  
 	 	 	 p i v o t S p r i t e   =   n e w   C C S p r i t e   ( " p i v o t " ) ;  
 	 	 	 p i v o t S p r i t e . S c a l e   =   s c a l e ;  
 	 	 	 p i v o t S p r i t e . P o s i t i o n X   =   p i v o t P o s X ;  
 	 	 	 p i v o t S p r i t e . P o s i t i o n Y   =   p i v o t P o s Y ;  
 	 	 	 f l o a t   h   =   ( f l o a t ) p i v o t S p r i t e . C o n t e n t S i z e . H e i g h t   /   2 . 0 f ;  
 	 	 	 C C P o i n t   t e m p P o s   =   n e w   C C P o i n t   ( h ,   h ) ;  
 	 	 	 / / v a r   g a l a x y   =   n e w   C C P a r t i c l e G a l a x y   ( t e m p P o s ) ;   / / T O D O :   m a n a g e   " b e t t e r "   f o r   p e r f o r m a n c e   w h e n   " m a n y "   p a r t i c l e s  
 	 	 	 v a r   C i r c l e D r a w   =   n e w   C C D r a w N o d e   ( ) ;  
 	 	 	 v a r   B l u e C o l o r   =   n e w   C C C o l o r 4 B   ( 0 ,   0 ,   2 5 5 ,   1 ) ;  
 	 	 	 v a r   b o u n d s   =   m a i n W i n d o w . W i n d o w S i z e I n P i x e l s ;  
 	 	 	 C i r c l e D r a w . D r a w C i r c l e   ( t e m p P o s ,   1 . 0 f   *   b o u n d s . W i d t h ,   B l u e C o l o r ) ;  
 	 	 	 p i v o t S p r i t e . A d d C h i l d   ( C i r c l e D r a w ) ;  
 	 	 	 m a i n L a y e r . A d d C h i l d   ( p i v o t S p r i t e ) ;  
 	 	 	 C C R o t a t e B y   r o t a t e P i v o t   =   n e w   C C R o t a t e B y   ( 1 . 0 f ,   3 6 0 ) ;  
 	 	 	 C C M o v e B y   m o v e B y P i v o t _ U P   =   n e w   C C M o v e B y   ( 3 . 0 f , n e w   C C P o i n t ( - 0 . 7 f * b o u n d s . W i d t h , 0 . 0 f ) ) ;  
 	 	 	 p i v o t S p r i t e . R e p e a t F o r e v e r ( m o v e B y P i v o t _ U P , m o v e B y P i v o t _ U P . R e v e r s e ( ) ) ;  
 	 	 	 p i v o t S p r i t e . R e p e a t F o r e v e r   ( r o t a t e P i v o t ) ;  
 	 	 	 r e t u r n   p i v o t S p r i t e ;  
  
 	 	 } C C S p r i t e   A d d R I G H T _ P i v o t s ( C C W i n d o w   m a i n W i n d o w , f l o a t   p i v o t P o s X , f l o a t   p i v o t P o s Y , f l o a t   s c a l e )  
 	 	 {        
  
  
 	 	 	 p i v o t S p r i t e   =   n e w   C C S p r i t e   ( " p i v o t " ) ;  
 	 	 	 p i v o t S p r i t e . S c a l e   =   s c a l e ;  
 	 	 	 p i v o t S p r i t e . P o s i t i o n X   =   p i v o t P o s X ;  
 	 	 	 p i v o t S p r i t e . P o s i t i o n Y   =   p i v o t P o s Y ;  
 	 	 	 f l o a t   h   =   ( f l o a t ) p i v o t S p r i t e . C o n t e n t S i z e . H e i g h t   /   2 . 0 f ;  
 	 	 	 C C P o i n t   t e m p P o s   =   n e w   C C P o i n t   ( h ,   h ) ;  
 	 	 	 / / v a r   g a l a x y   =   n e w   C C P a r t i c l e G a l a x y   ( t e m p P o s ) ;   / / T O D O :   m a n a g e   " b e t t e r "   f o r   p e r f o r m a n c e   w h e n   " m a n y "   p a r t i c l e s  
 	 	 	 v a r   C i r c l e D r a w   =   n e w   C C D r a w N o d e   ( ) ;  
 	 	 	 v a r   B l u e C o l o r   =   n e w   C C C o l o r 4 B   ( 0 ,   0 ,   2 5 5 ,   1 ) ;  
 	 	 	 v a r   b o u n d s   =   m a i n W i n d o w . W i n d o w S i z e I n P i x e l s ;  
 	 	 	 C i r c l e D r a w . D r a w C i r c l e   ( t e m p P o s ,   1 . 0 f   *   b o u n d s . W i d t h ,   B l u e C o l o r ) ;  
 	 	 	 p i v o t S p r i t e . A d d C h i l d   ( C i r c l e D r a w ) ;  
 	 	 	 m a i n L a y e r . A d d C h i l d   ( p i v o t S p r i t e ) ;  
 	 	 	 C C R o t a t e B y   r o t a t e P i v o t   =   n e w   C C R o t a t e B y   ( 1 . 0 f ,   3 6 0 ) ;  
 	 	 	 C C M o v e B y   m o v e B y P i v o t _ U P   =   n e w   C C M o v e B y   ( 3 . 0 f , n e w   C C P o i n t ( 0 . 0 f , 0 . 7 f * b o u n d s . W i d t h ) ) ;  
 	 	 	 p i v o t S p r i t e . R e p e a t F o r e v e r ( m o v e B y P i v o t _ U P , m o v e B y P i v o t _ U P . R e v e r s e ( ) ) ;  
 	 	 	 p i v o t S p r i t e . R e p e a t F o r e v e r   ( r o t a t e P i v o t ) ;  
 	 	 	 r e t u r n   p i v o t S p r i t e ;  
  
 	 	 }  
  
 	 	 C C S p r i t e   A d d L E F T _ P i v o t s ( C C W i n d o w   m a i n W i n d o w , f l o a t   p i v o t P o s X , f l o a t   p i v o t P o s Y , f l o a t   s c a l e )  
 	 	 {        
  
  
 	 	 	 p i v o t S p r i t e   =   n e w   C C S p r i t e   ( " p i v o t " ) ;  
 	 	 	 p i v o t S p r i t e . S c a l e   =   s c a l e ;  
 	 	 	 p i v o t S p r i t e . P o s i t i o n X   =   p i v o t P o s X ;  
 	 	 	 p i v o t S p r i t e . P o s i t i o n Y   =   p i v o t P o s Y ;  
 	 	 	 f l o a t   h   =   ( f l o a t ) p i v o t S p r i t e . C o n t e n t S i z e . H e i g h t   /   2 . 0 f ;  
 	 	 	 C C P o i n t   t e m p P o s   =   n e w   C C P o i n t   ( h ,   h ) ;  
 	 	 	 / / v a r   g a l a x y   =   n e w   C C P a r t i c l e G a l a x y   ( t e m p P o s ) ;   / / T O D O :   m a n a g e   " b e t t e r "   f o r   p e r f o r m a n c e   w h e n   " m a n y "   p a r t i c l e s  
 	 	 	 v a r   C i r c l e D r a w   =   n e w   C C D r a w N o d e   ( ) ;  
 	 	 	 v a r   B l u e C o l o r   =   n e w   C C C o l o r 4 B   ( 0 ,   0 ,   2 5 5 ,   1 ) ;  
 	 	 	 v a r   b o u n d s   =   m a i n W i n d o w . W i n d o w S i z e I n P i x e l s ;  
 	 	 	 C i r c l e D r a w . D r a w C i r c l e   ( t e m p P o s ,   1 . 0 f   *   b o u n d s . W i d t h ,   B l u e C o l o r ) ;  
 	 	 	 p i v o t S p r i t e . A d d C h i l d   ( C i r c l e D r a w ) ;  
 	 	 	 m a i n L a y e r . A d d C h i l d   ( p i v o t S p r i t e ) ;  
 	 	 	 C C R o t a t e B y   r o t a t e P i v o t   =   n e w   C C R o t a t e B y   ( 1 . 0 f ,   3 6 0 ) ;  
 	 	 	 C C M o v e B y   m o v e B y P i v o t _ U P   =   n e w   C C M o v e B y   ( 3 . 0 f , n e w   C C P o i n t ( 0 . 0 f , - 0 . 7 f * b o u n d s . W i d t h ) ) ;  
 	 	 	 p i v o t S p r i t e . R e p e a t F o r e v e r ( m o v e B y P i v o t _ U P , m o v e B y P i v o t _ U P . R e v e r s e ( ) ) ;  
 	 	 	 p i v o t S p r i t e . R e p e a t F o r e v e r   ( r o t a t e P i v o t ) ;  
 	 	 	 r e t u r n   p i v o t S p r i t e ;  
  
 	 	 }  
  
  
  
 	 	 	 v o i d   a d d L e v e l P i v o t s   ( C C W i n d o w   m a i n W i n d o w ) {  
 	 	 	 v a r   b o u n d s   =   m a i n W i n d o w . W i n d o w S i z e I n P i x e l s ;  
 	 	 	 f l o a t   p i v o t S c a l e = 0 . 0 0 0 2 f * b o u n d s . W i d t h ;  
 	 	 	 S t r i n g [ ]   P i v o t M o v e T y p e   =   n e w   S t r i n g [ 1 0 ] ;    
 	 	 	 f l o a t [ , ]   P i v o t P o s A r r a y   =   n e w   f l o a t [ 1 0 , 2 ] ;  
  
 	 	 	 L e v e l 1 A r r a y   l e v e l A r r a y   =   n e w   L e v e l 1 A r r a y   ( ) ;  
  
 	 	 	 P i v o t P o s A r r a y   =   l e v e l A r r a y . P i v o t P o s A r r a y ( ) ;  
 	 	 	 P i v o t M o v e T y p e   =   l e v e l A r r a y . P i v o t T y p e A r r a y ( ) ;  
  
 	 	 	 / /  
  
 	 	 	 / / s c o r e L a b e l . T e x t   =   ( P i v o t P o s A r r a y . L e n g t h / 2 . 0 f ) . T o S t r i n g ( ) ;  
 	 	 	 f o r ( i n t   i   =   0 ; i < P i v o t P o s A r r a y . L e n g t h / 2 ; i + + ) {  
 	 	 	 P i v o t P o s A r r a y [ i , 0 ]   =   P i v o t P o s A r r a y [ i , 0 ] * b o u n d s . W i d t h ;  
 	 	         P i v o t P o s A r r a y [ i , 1 ]   =   P i v o t P o s A r r a y [ i , 1 ] * b o u n d s . H e i g h t ;  
                          
 	 	 	 	 s w i t c h ( P i v o t M o v e T y p e [ i ] ) {  
 	 	 	 	 c a s e   " S T A T I C " :  
 	 	 	 	 v i s i b l e P i v o t s . A d d   ( A d d S T A T I C _ P i v o t s   ( m a i n W i n d o w , P i v o t P o s A r r a y [ i , 0 ] , P i v o t P o s A r r a y [ i , 1 ] , p i v o t S c a l e ) ) ;  
 	 	 	 	 	 b r e a k ;  
 	 	 	 	 c a s e   " U P " :  
 	 	 	 	 	 v i s i b l e P i v o t s . A d d   ( A d d U P _ P i v o t s   ( m a i n W i n d o w , P i v o t P o s A r r a y [ i , 0 ] , P i v o t P o s A r r a y [ i , 1 ] , p i v o t S c a l e ) ) ;  
 	 	 	 	 	 b r e a k ;  
 	 	 	 	 c a s e   " D O W N " :  
 	 	 	 	 	 v i s i b l e P i v o t s . A d d   ( A d d D O W N _ P i v o t s   ( m a i n W i n d o w , P i v o t P o s A r r a y [ i , 0 ] , P i v o t P o s A r r a y [ i , 1 ] , p i v o t S c a l e ) ) ;  
 	 	 	 	 	 b r e a k ;  
 	 	 	 	 c a s e   " R I G H T " :  
 	 	 	 	 	 v i s i b l e P i v o t s . A d d   ( A d d R I G H T _ P i v o t s   ( m a i n W i n d o w , P i v o t P o s A r r a y [ i , 0 ] , P i v o t P o s A r r a y [ i , 1 ] , p i v o t S c a l e ) ) ;  
 	 	 	 	 	 b r e a k ;  
 	 	 	 	 c a s e   " L E F T " :  
 	 	 	 	 	 v i s i b l e P i v o t s . A d d   ( A d d L E F T _ P i v o t s   ( m a i n W i n d o w , P i v o t P o s A r r a y [ i , 0 ] , P i v o t P o s A r r a y [ i , 1 ] , p i v o t S c a l e ) ) ;  
 	 	 	 	 	 b r e a k ;  
 	 	 	 	 d e f a u l t :  
 	 	 	 	 	 v i s i b l e P i v o t s . A d d   ( A d d S T A T I C _ P i v o t s   ( m a i n W i n d o w , P i v o t P o s A r r a y [ i , 0 ] , P i v o t P o s A r r a y [ i , 1 ] , p i v o t S c a l e ) ) ;  
  
 	 	 	 	 	 b r e a k ;  
  
 	 	 	 	 }  
  
 	 	 	 	 }  
  
 	 	 	 }  
  
 	 	 / / J E W E L S  
  
 	 	 v o i d   a d d L e v e l J e w e l s   ( C C W i n d o w   m a i n W i n d o w ) {  
 	 	 	 v a r   b o u n d s   =   m a i n W i n d o w . W i n d o w S i z e I n P i x e l s ;  
 	 	 	 f l o a t   j e w e l S c a l e = 0 . 0 0 0 1 f * b o u n d s . W i d t h ;  
 	 	 	 f l o a t [ , ]   J e w e l P o s A r r a y   =   n e w   f l o a t [ 1 0 , 2 ] ;  
  
 	 	 	 L e v e l 1 A r r a y   l e v e l A r r a y   =   n e w   L e v e l 1 A r r a y   ( ) ;  
  
 	 	 	 J e w e l P o s A r r a y   =   l e v e l A r r a y . J e w e l P o s A r r a y ( ) ;  
  
  
 	 	 	 / /  
  
 	 	 	 / / s c o r e L a b e l . T e x t   =   ( P i v o t P o s A r r a y . L e n g t h / 2 . 0 f ) . T o S t r i n g ( ) ;  
 	 	 	 f o r   ( i n t   i   =   0 ;   i   <   J e w e l P o s A r r a y . L e n g t h / 2 ;   i + + )   {  
 	 	 	 	 J e w e l P o s A r r a y   [ i ,   0 ]   =   J e w e l P o s A r r a y   [ i ,   0 ]   *   b o u n d s . W i d t h ;  
 	 	 	 	 J e w e l P o s A r r a y   [ i ,   1 ]   =   J e w e l P o s A r r a y   [ i ,   1 ]   *   b o u n d s . H e i g h t ;  
  
 	 	 	 	 / / v i s i b l e P i v o t s . A d d   ( A d d S T A T I C _ P i v o t s   ( m a i n W i n d o w , P i v o t P o s A r r a y [ i , 0 ] , P i v o t P o s A r r a y [ i , 1 ] , p i v o t S c a l e ) ) ;  
 	 	 	 	 v i s i b l e J e w e l s . A d d   ( a d d R u b y   ( m a i n W i n d o w ,   J e w e l P o s A r r a y   [ i ,   0 ] ,   J e w e l P o s A r r a y   [ i ,   1 ] ,   j e w e l S c a l e ) ) ;  
  
 	 	 	 }  
 	 	 }  
  
  
 	 	 / / R e m o v e   j e w e l   a n d   a n d   S c o r e   C o u n t e r  
 	 	 v o i d   c h e c k J e w e l ( ) {  
 	 	 	 f o r e a c h   ( v a r   r u b y   i n   v i s i b l e J e w e l s )   {  
 	 	 	 	 b o o l   h i t   =   r u b y . B o u n d i n g B o x T r a n s f o r m e d T o P a r e n t . I n t e r s e c t s R e c t ( b a l l S p r i t e . B o u n d i n g B o x T r a n s f o r m e d T o P a r e n t ) ;  
 	 	 	 	 i f   ( h i t )  
 	 	 	 	 {  
 	 	 	 	 	 h i t J e w e l s . A d d ( r u b y ) ;  
 	 	 	 	 	 / / C C S i m p l e A u d i o E n g i n e . S h a r e d E n g i n e . P l a y E f f e c t ( " S o u n d s / t a p " ) ;  
 	 	 	 	 	 / / E x p l o d e ( b a n a n a . P o s i t i o n ) ;  
 	 	 	 	 	 r u b y . R e m o v e F r o m P a r e n t ( ) ;  
  
 	 	 	 	 	 s c o r e   + =   1 0 ;  
 	 	 	 	 	 s c o r e L a b e l . T e x t   =   " S c o r e :   "   +   s c o r e ;  
  
   	 	 	 	 }  
 	 	 	 }  
  
  
 	 	 	 f o r e a c h   ( v a r   r u b y     i n   h i t J e w e l s )  
 	 	 	 {  
 	 	 	 	 v i s i b l e J e w e l s . R e m o v e ( r u b y ) ;  
 	 	 	 }  
 	 	 }  
 	 	 / / S P I K E  
  
 	 	 C C S p r i t e   A d d S T A T I C _ S p i k e   ( C C W i n d o w   m a i n W i n d o w , f l o a t   s p i k e P o s X , f l o a t   s p i k e P o s Y , f l o a t   s c a l e )  
 	 	 {        
  
 	 	 	 s p i k e S p r i t e   =   n e w   C C S p r i t e   ( " s p i k e " ) ;  
 	 	 	 s p i k e S p r i t e . S c a l e   =   s c a l e ;  
 	 	 	 s p i k e S p r i t e . P o s i t i o n X   =   s p i k e P o s X ;  
 	 	 	 s p i k e S p r i t e . P o s i t i o n Y   =   s p i k e P o s Y ;  
 	 	 	 v a r   b o u n d s   =   m a i n W i n d o w . W i n d o w S i z e I n P i x e l s ;  
  
 	 	 	 m a i n L a y e r . A d d C h i l d ( s p i k e S p r i t e ) ;  
  
  
 	 	 	 r e t u r n   s p i k e S p r i t e ;  
 	 	 }  
  
 	 	 C C S p r i t e   A d d U P _ S p i k e ( C C W i n d o w   m a i n W i n d o w , f l o a t   s p i k e P o s X , f l o a t   s p i k e P o s Y , f l o a t   s c a l e )  
 	 	 {        
  
 	 	 	 s p i k e S p r i t e   =   n e w   C C S p r i t e   ( " s p i k e " ) ;  
 	 	 	 s p i k e S p r i t e . S c a l e   =   s c a l e ;  
 	 	 	 s p i k e S p r i t e . P o s i t i o n X   =   s p i k e P o s X ;  
 	 	 	 s p i k e S p r i t e . P o s i t i o n Y   =   s p i k e P o s Y ;  
 	 	 	 v a r   b o u n d s   =   m a i n W i n d o w . W i n d o w S i z e I n P i x e l s ;  
  
 	 	 	 m a i n L a y e r . A d d C h i l d ( s p i k e S p r i t e ) ;  
  
 	 	 	 C C R o t a t e B y   r o t a t e S p i k e   =   n e w   C C R o t a t e B y   ( 4 . 0 f ,   3 6 0 ) ;  
  
 	 	 	 s p i k e S p r i t e . R e p e a t F o r e v e r ( r o t a t e S p i k e ) ;  
 	 	 	 C C M o v e B y   m o v e B y S p i k e _ U P   =   n e w   C C M o v e B y   ( 5 . 0 f , n e w   C C P o i n t ( 0 . 7 f * b o u n d s . W i d t h , 0 . 0 f ) ) ;  
 	 	 	 s p i k e S p r i t e . R e p e a t F o r e v e r ( m o v e B y S p i k e _ U P , m o v e B y S p i k e _ U P . R e v e r s e ( ) ) ;  
 	 	 	 s p i k e S p r i t e . R e p e a t F o r e v e r   ( r o t a t e S p i k e ) ;  
  
 	 	 	 r e t u r n   s p i k e S p r i t e ;  
  
 	 	 } 	 	  
  
  
  
 	 	 C C S p r i t e   A d d R I G H T _ S p i k e ( C C W i n d o w   m a i n W i n d o w , f l o a t   s p i k e P o s X , f l o a t   s p i k e P o s Y , f l o a t   s c a l e )  
 	 	 {        
 	 	 	 s p i k e S p r i t e   =   n e w   C C S p r i t e   ( " s p i k e " ) ;  
 	 	 	 s p i k e S p r i t e . S c a l e   =   s c a l e ;  
 	 	 	 s p i k e S p r i t e . P o s i t i o n X   =   s p i k e P o s X ;  
 	 	 	 s p i k e S p r i t e . P o s i t i o n Y   =   s p i k e P o s Y ;  
 	 	 	 v a r   b o u n d s   =   m a i n W i n d o w . W i n d o w S i z e I n P i x e l s ;  
  
 	 	 	 m a i n L a y e r . A d d C h i l d ( s p i k e S p r i t e ) ;  
  
 	 	 	 C C R o t a t e B y   r o t a t e S p i k e   =   n e w   C C R o t a t e B y   ( 4 . 0 f ,   3 6 0 ) ;  
  
 	 	 	 s p i k e S p r i t e . R e p e a t F o r e v e r ( r o t a t e S p i k e ) ;  
 	 	 	 C C M o v e B y   m o v e B y S p i k e _ U P   =   n e w   C C M o v e B y   ( 5 . 0 f , n e w   C C P o i n t ( 0 . 0 f , 0 . 7 f * b o u n d s . W i d t h ) ) ;  
 	 	 	 s p i k e S p r i t e . R e p e a t F o r e v e r ( m o v e B y S p i k e _ U P , m o v e B y S p i k e _ U P . R e v e r s e ( ) ) ;  
 	 	 	 s p i k e S p r i t e . R e p e a t F o r e v e r   ( r o t a t e S p i k e ) ;  
  
 	 	 	 r e t u r n   s p i k e S p r i t e ;  
  
  
  
  
 	 	 }  
  
 	  
 	 	 v o i d   a d d L e v e l S p i k e s   ( C C W i n d o w   m a i n W i n d o w ) {  
 	 	 	 v a r   b o u n d s   =   m a i n W i n d o w . W i n d o w S i z e I n P i x e l s ;  
 	 	 	 f l o a t   s p i k e S c a l e = 0 . 0 0 0 1 f * b o u n d s . W i d t h ;  
 	 	 	 S t r i n g [ ]   S p i k e M o v e T y p e   =   n e w   S t r i n g [ 1 0 ] ;    
 	 	 	 f l o a t [ , ]   S p i k e P o s A r r a y   =   n e w   f l o a t [ 1 0 , 2 ] ;  
  
 	 	 	 L e v e l 1 A r r a y   l e v e l A r r a y   =   n e w   L e v e l 1 A r r a y   ( ) ;  
  
 	 	 	 S p i k e P o s A r r a y   =   l e v e l A r r a y . S p i k e P o s A r r a y ( ) ;  
 	 	 	 S p i k e M o v e T y p e   =   l e v e l A r r a y . S p i k e T y p e A r r a y ( ) ;  
  
  
 	 	 	 / /  
  
 	 	 	 / / s c o r e L a b e l . T e x t   =   ( P i v o t P o s A r r a y . L e n g t h / 2 . 0 f ) . T o S t r i n g ( ) ;  
 	 	 	 f o r   ( i n t   i   =   0 ;   i   <   S p i k e P o s A r r a y . L e n g t h / 2 ;   i + + )   {  
 	 	 	 	 S p i k e P o s A r r a y   [ i ,   0 ]   =   S p i k e P o s A r r a y   [ i ,   0 ]   *   b o u n d s . W i d t h ;  
 	 	 	 	 S p i k e P o s A r r a y   [ i ,   1 ]   =   S p i k e P o s A r r a y   [ i ,   1 ]   *   b o u n d s . H e i g h t ;  
  
 	 	 	  
 	 	 	 	 s w i t c h ( S p i k e M o v e T y p e [ i ] ) {  
 	 	 	 	 	 c a s e   " S T A T I C " :  
 	 	 	 	 	 	 v i s i b l e T r a p s . A d d   ( A d d S T A T I C _ S p i k e   ( m a i n W i n d o w ,   S p i k e P o s A r r a y   [ i ,   0 ] ,   S p i k e P o s A r r a y   [ i ,   1 ] ,   s p i k e S c a l e ) ) ;  
 	 	 	 	 	 	 b r e a k ;  
 	 	 	 	 	 c a s e   " U P " :  
 	 	 	 	 	 v i s i b l e T r a p s . A d d   ( A d d U P _ S p i k e   ( m a i n W i n d o w ,   S p i k e P o s A r r a y   [ i ,   0 ] ,   S p i k e P o s A r r a y   [ i ,   1 ] ,   s p i k e S c a l e ) ) ;  
 	 	 	 	 	 	 b r e a k ;  
 	 	 	 	  
 	 	 	 	 	 c a s e   " R I G H T " :  
 	 	 	 	 	 v i s i b l e T r a p s . A d d   ( A d d R I G H T _ S p i k e   ( m a i n W i n d o w ,   S p i k e P o s A r r a y   [ i ,   0 ] ,   S p i k e P o s A r r a y   [ i ,   1 ] ,   s p i k e S c a l e ) ) ;  
 	 	 	 	 	 	 b r e a k ;  
 	 	 	 	 	  
 	 	 	 	 	 d e f a u l t :  
 	 	 	 	 	 v i s i b l e T r a p s . A d d   ( A d d S T A T I C _ S p i k e   ( m a i n W i n d o w ,   S p i k e P o s A r r a y   [ i ,   0 ] ,   S p i k e P o s A r r a y   [ i ,   1 ] ,   s p i k e S c a l e ) ) ;  
  
 	 	 	 	 	 	 b r e a k ;  
  
 	 	 	 	 	 }  
  
 	 	 	 	 }  
  
 	 	 	 }  
  
 	 	 v o i d   c h e c k T r a p ( ) {  
 	 	 	 f o r e a c h   ( v a r   s p i k e S p r i t e   i n   v i s i b l e T r a p s )   {  
 	 	 	 	 b o o l   h i t   =   s p i k e S p r i t e . B o u n d i n g B o x T r a n s f o r m e d T o P a r e n t . I n t e r s e c t s R e c t ( b a l l S p r i t e . B o u n d i n g B o x T r a n s f o r m e d T o P a r e n t ) ;  
 	 	 	 	 i f   ( h i t )  
 	 	 	 	 {  
 	 	 	 	 	 / / h i t J e w e l s . A d d ( r u b y ) ;  
 	 	 	 	 	 / / C C S i m p l e A u d i o E n g i n e . S h a r e d E n g i n e . P l a y E f f e c t ( " S o u n d s / t a p " ) ;  
 	 	 	 	 	 / / E x p l o d e ( b a n a n a . P o s i t i o n ) ;  
 	 	 	 	 	 / / r u b y . R e m o v e F r o m P a r e n t ( ) ;  
 	 	 	 	 	 / / s c o r e   + =   1 0 ;  
 	 	 	 	 	 / / s c o r e L a b e l . T e x t   =   " S c o r e :   "   +   s c o r e ;  
  
 	 	 	 	 	 E n d G a m e   ( ) ;  
 	 	 	 	 }  
 	 	 	 }  
  
  
 	 	 }  
  
 	 	 / / E N D G A M E  
 	 	   v o i d   E n d G a m e   ( ) {  
  
 	 	 	 U n s c h e d u l e A l l ( ) ;  
 	 	 	 s c o r e L a b e l . T e x t = " E N D G A M E " ;  
  
 	 	  
 	 	 }  
 	 	 / /  
  
 	 	 }  
  
 	 }  
  
  
 