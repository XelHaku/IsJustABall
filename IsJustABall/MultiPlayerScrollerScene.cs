using System;
using CocosSharp;
using System.Collections.Generic;
using CocosDenshion;
using System.Linq;
namespace IsJustABall
{
	public class MultiPlayerScrollerScene : CCScene
	{  
		#region VARIABLES INIT
		CCWindow mainWindowAux;
		CCLayer mainLayer;

		CCSprite ballSprite;

		List<ballPhysics> ballPhysicsList;

		List<CCSprite> visibleJewels;
		List<CCSprite> hitJewels;
		List<CCSprite> DeleteElement;
		CCSprite ruby;
		CCSprite diamond;
		CCSprite background1;
		CCSprite background2;

		List<CCSprite> visiblePivots;
		CCSprite pivotSprite;


		List<CCSprite> visibleTraps;
		CCSprite spikeSprite;

		List<CCSprite> PlayerButtonList;



		CCLabel scoreLabel;
		float gravity = 0;
		double Multiplier =1.05f;
		float minRotationRadius;
		int scrollerSpeed= 25;
		CCEventListenerTouchAllAtOnce touchListener;
		#endregion

		public MultiPlayerScrollerScene(CCWindow mainWindow,int playerCount) : base(mainWindow)
		{  CCSimpleAudioEngine.SharedEngine.PreloadBackgroundMusic ("Sounds/backgroundmusic1");
			CCSimpleAudioEngine.SharedEngine.PlayBackgroundMusic("Sounds/backgroundmusic1");


			mainWindowAux = mainWindow;
			mainLayer = new CCLayer ();
			AddChild (mainLayer);
			visiblePivots = new List<CCSprite> ();
			visibleJewels = new List<CCSprite> ();
			hitJewels = new List<CCSprite> ();
			visibleTraps = new List<CCSprite>();
			DeleteElement = new List<CCSprite> ();
			ballPhysicsList = new List<ballPhysics> ();
			PlayerButtonList = new List<CCSprite> ();
			var bounds = mainWindow.WindowSizeInPixels;
			minRotationRadius = 0.15f*bounds.Height;



			//addPivot(mainWindow);
			// add ALL pivots of the level
			addFourBalls addBallsClass = new addFourBalls ();
			addLevelPivots (mainWindow);
			addLevelJewels (mainWindow);
			addLevelSpikes (mainWindow);
			addBallsClass.addGameBall(playerCount, mainWindowAux, ballPhysicsList );////TESTING here
			foreach (var ballPhysicsSingle in ballPhysicsList) {
				mainLayer.AddChild (ballPhysicsSingle.ballSprite);
			
			}
			addBackground1 (mainWindow);addBackground2 (mainWindow);
			addPlayerButton (playerCount);


			scoreLabel = new CCLabel ("Score: 0", "arial", 22);
			scoreLabel.PositionX = mainLayer.VisibleBoundsWorldspace.MaxX/2 ;
			scoreLabel.PositionY = mainLayer.VisibleBoundsWorldspace.MaxY - 20;
			scoreLabel.AnchorPoint = CCPoint.AnchorUpperRight;


			mainLayer.AddChild (scoreLabel);
			mainLayer.ReorderChild (scoreLabel, 101);


			Schedule (RunGameLogic);



			// New code:
			touchListener = new CCEventListenerTouchAllAtOnce ();
			 
			touchListener.OnTouchesBegan = HandleTouchesBegan; 
			AddEventListener (touchListener, this);

		}
		#region RUNGAMELOGIC
		void RunGameLogic(float frameTimeInSeconds)
		{ foreach(var ballPhysicsSingle in ballPhysicsList){  

				if (ballPhysicsSingle.hookTouchBool == true) {//Void free Particle
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
		}
		#endregion
		#region HANDLE TOUCHSCREEN
		void HandleTouchesBegan (System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent)
		{
			var bounds = mainWindowAux.WindowSizeInPixels;
			var locationInverted = touches [0].LocationOnScreen;
			CCPoint location = new CCPoint(locationInverted.X,bounds.Height - locationInverted.Y);

			CCPoint touchPoint = new CCPoint (0.0f*bounds.Width, 0.0f*bounds.Height);
			// 1 FIRST PLAYER
			bool hit =  location.IsNear(touchPoint, 0.4f*bounds.Width) ;
			if (hit)
			{
				CalculateHookPhysics (1);

			}
			// 2 SECOND PLAYER
			touchPoint.X = bounds.Width;
			hit =  location.IsNear(touchPoint, 0.4f*bounds.Width) ;
			if (hit)
			{
				CalculateHookPhysics (2);

			}
			// 3 THIRD PLAYER
			touchPoint.X = 0.0f;touchPoint.Y = bounds.Height;
			hit =  location.IsNear(touchPoint, 0.4f*bounds.Width) ;
			if (hit)
			{
				CalculateHookPhysics (3);

			}
			// 4 FOURTH PLAYER
			touchPoint.X =bounds.Width;touchPoint.Y = bounds.Height;
			hit =  location.IsNear(touchPoint, 0.4f*bounds.Width) ;
			if (hit)
			{
				CalculateHookPhysics (4);

			}



		}
	

		#endregion
		#region Free and Hooked Particle States
		void freeParticle(float frameTimeInSeconds){
			gravity = 0;
			foreach (var ballPhysicsSingle in ballPhysicsList){
				if (ballPhysicsSingle.hookTouchBool == true) {
					// This is a linear approximation, so not 100% accurate
					ballPhysicsSingle.ballXVelocity += frameTimeInSeconds * gravity;
					ballPhysicsSingle.ballSprite.PositionX += ballPhysicsSingle.ballXVelocity * frameTimeInSeconds;
					ballPhysicsSingle.ballSprite.PositionY += ballPhysicsSingle.ballYVelocity * frameTimeInSeconds;
					// New code:
					//score++;
					//scoreLabel.Text = "Score: " + score;
					// Check if the ball is either too far to the right or left:
					float ballRight = ballPhysicsSingle.ballSprite.BoundingBoxTransformedToParent.MaxX;
					float ballLeft = ballPhysicsSingle.ballSprite.BoundingBoxTransformedToParent.MinX;

					float screenRight = mainLayer.VisibleBoundsWorldspace.MaxX;
					float screenLeft = mainLayer.VisibleBoundsWorldspace.MinX;

					bool shouldReflectXVelocity = (ballRight > screenRight && ballPhysicsSingle.ballXVelocity > 0) ||	(ballLeft < screenLeft && ballPhysicsSingle.ballXVelocity < 0);


					if (shouldReflectXVelocity) {
						ballPhysicsSingle.ballXVelocity *= -1;

					}

					// Check if the ball is either too far to the right or left:

					float ballTop = ballPhysicsSingle.ballSprite.BoundingBoxTransformedToParent.MaxY;
					float ballBottom = ballPhysicsSingle.ballSprite.BoundingBoxTransformedToParent.MinY;

					float screenTop = mainLayer.VisibleBoundsWorldspace.MaxY;
					float screenBottom = mainLayer.VisibleBoundsWorldspace.MinY;

					bool shouldReflectYVelocity = (ballTop > screenTop && ballPhysicsSingle.ballYVelocity > 0) ||	(ballBottom < screenBottom && ballPhysicsSingle.ballYVelocity < 0);

					if (shouldReflectYVelocity) {
						ballPhysicsSingle.ballYVelocity *= -1;
					}
				}
		}
		}

		void hookedParticle(float frameTimeInSeconds){
			gravity = 0;
			foreach (var ballPhysicsSingle in ballPhysicsList){
				if (ballPhysicsSingle.hookTouchBool == false) {
					//multiplier on close radius\
					//double multR = (10 / Radius);
			
					if (ballPhysicsSingle.ClockwiseRotation == true) {
						//theta+= (double)(Multiplier*wZero*SinAlpha*frameTimeInSeconds);
						ballPhysicsSingle.theta += (double)(Multiplier * ballPhysicsSingle.wZero * frameTimeInSeconds);

						ballPhysicsSingle.ballXVelocity = (float)(-ballPhysicsSingle.ballSpeedFinal * Math.Sin (ballPhysicsSingle.theta));
						ballPhysicsSingle.ballYVelocity = (float)(ballPhysicsSingle.ballSpeedFinal * Math.Cos (ballPhysicsSingle.theta));
					} else {
						//theta-= (double)(Multiplier*wZero*SinAlpha*frameTimeInSeconds);
						ballPhysicsSingle.theta -= (double)(Multiplier * ballPhysicsSingle.wZero * frameTimeInSeconds);

						ballPhysicsSingle.ballXVelocity = (float)(ballPhysicsSingle.ballSpeedFinal * Math.Sin (ballPhysicsSingle.theta));
						ballPhysicsSingle.ballYVelocity = (float)(-ballPhysicsSingle.ballSpeedFinal * Math.Cos (ballPhysicsSingle.theta));
					}
					/////////
					ballPhysicsSingle.ballSprite.PositionX = (float)(ballPhysicsSingle.Radius * Math.Cos (ballPhysicsSingle.theta) + visiblePivots [ballPhysicsSingle.indexHookPivot].PositionX);
					ballPhysicsSingle.ballSprite.PositionY = (float)(ballPhysicsSingle.Radius * Math.Sin (ballPhysicsSingle.theta) + visiblePivots [ballPhysicsSingle.indexHookPivot].PositionY);


					///Remove gone far Pivots
					for (int i = 0; i < visibleJewels.Count; i++) {


						if (visibleJewels [i].PositionY < -500) {
							visibleJewels.RemoveAt (i);
						}



					}
				}
		}//end foreach

		}
		#endregion

		/// OBJECTS AND SPRITES
			#region OBJECTS AND SPRITES
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
				ballSprite.PositionX = 0.8f*bounds.Width;
				ballSprite.PositionY = -0.1f*bounds.Height;
				break;
			case 3:
				ballSprite = new CCSprite ("greenball");
				ballSprite.PositionX = 0.6f*bounds.Width;
				ballSprite.PositionY = -0.1f*bounds.Height;
				break;
			case 4:
				ballSprite = new CCSprite ("yellowball");
				ballSprite.PositionX = 0.2f*bounds.Width;
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

		//Corner buttons for each Player
		void addPlayerButton(int playerCount){
			var bounds = mainWindowAux.WindowSizeInPixels;
			float scale = 0.002f * bounds.Width;
			for (int i = 1; i <= playerCount; i++) {
				switch (i) {
				case 1:
					ballSprite = new CCSprite ("blueballButton");
					ballSprite.PositionX = 0.0f * bounds.Width;
					ballSprite.PositionY = 0.0f * bounds.Height;
					ballSprite.Scale = scale;
					mainLayer.AddChild (ballSprite);
					break;
				case 2:
					ballSprite = new CCSprite ("redballButton");
					ballSprite.PositionX = 1.0f * bounds.Width;
					ballSprite.PositionY = 0.0f * bounds.Height;
					ballSprite.Scale = scale;
					mainLayer.AddChild (ballSprite);
					break;
				case 3:
					ballSprite = new CCSprite ("greenballButton");
					ballSprite.PositionX = 0.0f * bounds.Width;
					ballSprite.PositionY = 1.0f * bounds.Height;
					ballSprite.Scale = scale;
					mainLayer.AddChild (ballSprite);
					break;
				case 4:
					ballSprite = new CCSprite ("yellowballButton");
					ballSprite.PositionX = 1.0f * bounds.Width;
					ballSprite.PositionY = 1.0f * bounds.Height;
					ballSprite.Scale = scale;
					mainLayer.AddChild (ballSprite);
					break;
				default:
					ballSprite = new CCSprite ("blueballButton");
					ballSprite.PositionX = 0.0f * bounds.Width;
					ballSprite.PositionY = 0.0f * bounds.Height;
					ballSprite.Scale = scale;
					mainLayer.AddChild (ballSprite);
					break;
				}

			
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

	


		#region PIVOTS

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
			Multi4Level1 LevelClass = new Multi4Level1 ();
			List<Multi4Level1.Pivot> ClassList = new List<Multi4Level1.Pivot> ();

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
		#endregion
		//JEWELS

		void addLevelJewels (CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;
			float jewelScale=0.0004f*bounds.Width;

			Multi4Level1 LevelClass = new Multi4Level1 ();
			List<Multi4Level1.Jewel> ClassList = new List<Multi4Level1.Jewel> ();

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


	
	
		#region SPIKES
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
			Multi4Level1 LevelClass = new Multi4Level1 ();
			List<Multi4Level1.Spike> ClassList = new List<Multi4Level1.Spike> ();

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
		#endregion
		
	#endregion

		public void CalculateHookPhysics(int index){
			foreach(var ballPhysicsSingle in ballPhysicsList){
				if(ballPhysicsSingle.index==index){
				double closestPivot = 10000;
				for (int i = 0; i < visiblePivots.Count; i++) {
					ballPhysicsSingle.dRadius_X = ballPhysicsSingle.ballSprite.PositionX - visiblePivots [i].PositionX;
					ballPhysicsSingle.dRadius_Y = ballPhysicsSingle.ballSprite.PositionY - visiblePivots [i].PositionY;


					ballPhysicsSingle.temp = Math.Pow ((double)ballPhysicsSingle.dRadius_X, 2) + Math.Pow ((double)ballPhysicsSingle.dRadius_Y, 2);
					ballPhysicsSingle.temp = Math.Pow (ballPhysicsSingle.temp, 0.5);

					if (ballPhysicsSingle.temp < closestPivot) {
						closestPivot = ballPhysicsSingle.temp;
						ballPhysicsSingle.indexHookPivot = i;

					}


				}

				if (closestPivot < minRotationRadius && ballPhysicsSingle.hookTouchBool == true) {
					ballPhysicsSingle.hookTouchBool = false;//Toggle hook
					//scoreLabel.Text = "temp:" + temp.ToString () + " \nCircleRadius: " + minRotationRadius.ToString () + " \nball: " + ballSprite.Position.ToString () + " \npivot: " + pivotSprite.Position.ToString ();

				} else if (ballPhysicsSingle.hookTouchBool == false) {
					ballPhysicsSingle.hookTouchBool = true;
					//scoreLabel.Text = "Free";
				}







				if (ballPhysicsSingle.hookTouchBool == false) {
					//Set values for spped and radius or rotation raound Pivot

					ballPhysicsSingle.dRadius_X = ballPhysicsSingle.ballSprite.PositionX - visiblePivots [ballPhysicsSingle.indexHookPivot].PositionX;
					ballPhysicsSingle.dRadius_Y = ballPhysicsSingle.ballSprite.PositionY - visiblePivots [ballPhysicsSingle.indexHookPivot].PositionY;

					ballPhysicsSingle.Radius = Math.Pow ((double)ballPhysicsSingle.dRadius_X, 2) + Math.Pow ((double)ballPhysicsSingle.dRadius_Y, 2);
					ballPhysicsSingle.Radius = Math.Pow (ballPhysicsSingle.Radius, 0.5);


					ballPhysicsSingle.ballSpeed = Math.Pow (ballPhysicsSingle.ballXVelocity, 2) + Math.Pow (ballPhysicsSingle.ballYVelocity, 2);
					ballPhysicsSingle.ballSpeed = Math.Pow (ballPhysicsSingle.ballSpeed, 0.5d);

					ballPhysicsSingle.CosThetaZero = ballPhysicsSingle.dRadius_X / ballPhysicsSingle.Radius;
					ballPhysicsSingle.SinThetaZero = ballPhysicsSingle.dRadius_Y / ballPhysicsSingle.Radius;

					ballPhysicsSingle.CosAlpha = (ballPhysicsSingle.dRadius_X * ballPhysicsSingle.ballXVelocity + ballPhysicsSingle.dRadius_Y * ballPhysicsSingle.ballYVelocity) / (ballPhysicsSingle.Radius * ballPhysicsSingle.ballSpeed);

					if (Math.Pow (ballPhysicsSingle.CosAlpha, 2) < 0.5) {
						ballPhysicsSingle.CosAlpha = Math.Pow (0.5, 0.5);
					}
					ballPhysicsSingle.SinAlpha = (1 - Math.Pow (ballPhysicsSingle.CosAlpha, 2));
					ballPhysicsSingle.SinAlpha = Math.Pow (ballPhysicsSingle.SinAlpha, 0.5f);


					ballPhysicsSingle.wZero = ballPhysicsSingle.ballSpeed / ballPhysicsSingle.Radius;
					//ballSpeedFinal = Radius * Multiplier * wZero * SinAlpha;
					ballPhysicsSingle.ballSpeedFinal = ballPhysicsSingle.Radius * Multiplier * ballPhysicsSingle.wZero;

					ballPhysicsSingle.ThetaZero = Math.Acos (ballPhysicsSingle.CosThetaZero);

					//Second Quadrant
					if (ballPhysicsSingle.SinThetaZero > 0 && ballPhysicsSingle.CosThetaZero < 0) {
						ballPhysicsSingle.ThetaZero = (1 / 2) * Math.PI + ballPhysicsSingle.ThetaZero;
					}
					//Third Quadrant
					if (ballPhysicsSingle.SinThetaZero < 0 && ballPhysicsSingle.CosThetaZero < 0) {
						ballPhysicsSingle.ThetaZero = (2) * Math.PI - ballPhysicsSingle.ThetaZero;
					}



					//Fourth Quadrant
					if (ballPhysicsSingle.SinThetaZero < 0 && ballPhysicsSingle.CosThetaZero > 0) {
						ballPhysicsSingle.ThetaZero = -ballPhysicsSingle.ThetaZero;
					}
					ballPhysicsSingle.theta = ballPhysicsSingle.ThetaZero;
					//Define if it is clockwise or anticlockwise rotation

					if (ballPhysicsSingle.dRadius_X * ballPhysicsSingle.ballYVelocity - ballPhysicsSingle.dRadius_Y * ballPhysicsSingle.ballXVelocity <= 0) {
						ballPhysicsSingle.ClockwiseRotation = false;
						//scoreLabel.Text += "ClockwiseRotation: false";
					} else {
						ballPhysicsSingle.ClockwiseRotation = true;
						//scoreLabel.Text += "ClockwiseRotation: true";

					}
				}

				}
			}//foreach
			
		}



	#region CHECK COLLISION
	//Remove jewel and and Score Counter
		void checkJewel(){
		foreach (var ruby in visibleJewels) {
			foreach (var ballPhysicsSingle in ballPhysicsList) {
				bool hit = ruby.BoundingBoxTransformedToParent.IntersectsRect (ballPhysicsSingle.ballSprite.BoundingBoxTransformedToParent);
				if (hit) {
					hitJewels.Add (ruby);
					//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
					//Explode(banana.Position);
					ruby.RemoveFromParent (true);
					visibleJewels.Remove (ruby);
					ballPhysicsSingle.score += 10;
					DisplayScore (ballPhysicsSingle.score);
					break;

				}
			}
		}

		}
	
		void checkTrap(){
			foreach (var spikeSprite in visibleTraps) {
				foreach (var ballPhysicsSingle in ballPhysicsList) {

					bool hit = spikeSprite.BoundingBoxTransformedToParent.IntersectsRect (ballPhysicsSingle.ballSprite.BoundingBoxTransformedToParent);
					if (hit) {


						//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
						Explode (spikeSprite.Position);
						spikeSprite.RemoveFromParent (true);
						visibleTraps.Remove (spikeSprite);


						//hitJewels.Add(ruby);
						//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
						//Explode(banana.Position);
						//ruby.RemoveFromParent();
						ballPhysicsSingle.score -= 50;
						DisplayScore (ballPhysicsSingle.score);

						//ShouldEndGame ();
						break;
					}
				}
				break;
			}

		}
		#endregion
	#region PARTICLE EFFECTS
		void Explode (CCPoint pt)
		{
			var explosion = new CCParticleExplosion (pt); //TODO: manage "better" for performance when "many" particles
			explosion.TotalParticles = 18;
			explosion.AutoRemoveOnFinish = true;
			mainLayer.AddChild (explosion);
		}

		#endregion
		//ENDGAME
		#region LEVEL HANDLERS
		void ShouldEndGame (){
			//if (score <= -100) {
				//EndGame ();
		//	}


		}
		void EndGame(){
			MainMenuScene gameScene = new MainMenuScene (mainWindowAux);
			mainWindowAux.RunWithScene (gameScene);

		}

		void DisplayScore(float score ){

			scoreLabel.Text = "Score: " + score;
			//
		}
		#endregion
	}

}




