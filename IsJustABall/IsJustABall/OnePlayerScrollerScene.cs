using System;
using CocosSharp;
using System.Collections.Generic;
using CocosDenshion;
using System.Linq;
namespace IsJustABall
{
	public class OnePlayerScrollerScene : CCScene
	{
		#region VARIABLES INIT
		CCWindow mainWindowAux;
		CCLayer mainLayer;
		ballPhysics ballPhysicsSingle = new ballPhysics ();
		CCSprite ballSprite;
		List<ballPhysics> ballPhysicsList;
		List<CCSprite> visibleJewels;
		List<CCSprite> hitJewels;
		List<CCSprite> DeleteElement;
		CCSprite ruby;
		CCSprite diamond;
		CCSprite background1;
		CCSprite background2;
		CCSprite PauseButton;
		CCSprite ResumeGame,Restart,MainMenu,menuframe;
		CCSprite levelcleared;
		List<CCSprite> visiblePivots;
		CCSprite pivotSprite;

		List<CCSprite> visibleTraps;
		CCSprite spikeSprite;

		CCLabelTtf scoreLabel;

		// How much to modify the ball's y velocity per second:
		float gravity = 0;
		//hookTouchBool=!hookTouchBool// to toggle on Touch
		//Speed for scroller level
		int scrollerSpeed= 150;
		//Declare variables for HookedParticle Method
		double Multiplier =1.05f;
		float minRotationRadius;
		//needed for multiple Pivots
		/// 
		int score = 0;
		bool PauseGame=true;

		//Movementson Pivots



		CCEventListenerTouchAllAtOnce touchListener;
		#endregion
		public OnePlayerScrollerScene(CCWindow mainWindow) : base(mainWindow)
		{   var bounds = mainWindow.WindowSizeInPixels;
			minRotationRadius = 0.15f*bounds.Height;
			CCSimpleAudioEngine.SharedEngine.PreloadBackgroundMusic ("Sounds/backgroundmusic1");
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



			addLevelPivots (mainWindow);
			addLevelJewels (mainWindow);
			addLevelSpikes (mainWindow);
			addBlueBall(mainWindow);
			addBackground1 (mainWindow);addBackground2 (mainWindow);
			addPauseButton ();
			addMenuOptions ();

			scoreLabel = new CCLabelTtf ("Score: 0", "arial", 22);
			scoreLabel.PositionX = mainLayer.VisibleBoundsWorldspace.MaxX/2 ;
			scoreLabel.PositionY = mainLayer.VisibleBoundsWorldspace.MaxY - 20;
			scoreLabel.AnchorPoint = CCPoint.AnchorUpperRight;

			mainLayer.AddChild (scoreLabel);
			mainLayer.ReorderChild (scoreLabel, 101);

			Schedule (RunGameLogic);
			// TouchListeners:
			touchListener = new CCEventListenerTouchAllAtOnce ();
			touchListener.OnTouchesBegan = HandleTouchesBegan; 
			touchListener.OnTouchesEnded = HandleTouchesEnded;
			AddEventListener (touchListener, this);

		}

		#region RUN GAME LOGIC
		void RunGameLogic(float frameTimeInSeconds)
		{  
			if (PauseGame) {
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
				background1.PositionY += -scrollerSpeed * frameTimeInSeconds / 10.0f;
				background2.PositionY += -scrollerSpeed * frameTimeInSeconds / 10.0f;

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
		//handle TouchScreen
		void HandleTouchesEnded(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){
			var bounds = mainWindowAux.WindowSizeInPixels;
			var locationInverted = touches [0].LocationOnScreen;
			CCPoint location = new CCPoint(locationInverted.X,bounds.Height - locationInverted.Y);

			bool hit =  location.IsNear(ResumeGame.Position, 50.0f) ;
			if (hit)
			{
				//ResumeGame.Scale =  ResumeGame.Scale/1.2f;

				PauseGame = true;
				ResumeGame.ScaleTo (new CCSize (ResumeGame.ScaledContentSize.Width/1.1f,ResumeGame.ScaledContentSize.Height/1.1f));
				//CCSimpleAudioEngine.SharedEngine.PlayBackgroundMusic("Sounds/backgroundmusic1");
				CCSimpleAudioEngine.SharedEngine.ResumeBackgroundMusic ();
				CCMoveBy SlideOut = new CCMoveBy (0.5f,new CCPoint(0.0f,- 0.3f*bounds.Height));
				ResumeGame.RunAction(SlideOut);
				Restart.RunAction(SlideOut);
				MainMenu.RunAction(SlideOut);


			}

			hit =  location.IsNear(Restart.Position, 50.0f) ;
			if (hit) {
				Restart.ScaleTo (new CCSize (Restart.ScaledContentSize.Width/1.1f,Restart.ScaledContentSize.Height/1.1f));
				OnePlayerScrollerScene gameScene1 = new OnePlayerScrollerScene (mainWindowAux);
				mainWindowAux.RunWithScene (gameScene1);
			}

			hit =  location.IsNear(MainMenu.Position, 50.0f) ;

			if (hit) {
				MainMenu.ScaleTo (new CCSize (MainMenu.ScaledContentSize.Width/1.1f,MainMenu.ScaledContentSize.Height/1.1f));
				MainMenuScene gameScene2 = new MainMenuScene (mainWindowAux);
				mainWindowAux.RunWithScene (gameScene2);

			}

			//BUG: calling walkRepeat separately as it doesn't run when called in RunActions or CCSpawn


		}



		void HandleTouchesBegan(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){
			//Pause
			var bounds = mainWindowAux.WindowSizeInPixels;
			var locationInverted = touches [0].LocationOnScreen;
			CCPoint location = new CCPoint(locationInverted.X,bounds.Height - locationInverted.Y);

			bool hit =  location.IsNear(ResumeGame.Position, 50.0f) ;
			if (hit)
			{
				ResumeGame.ScaleTo (new CCSize (1.1f*ResumeGame.ScaledContentSize.Width,1.1f*ResumeGame.ScaledContentSize.Height));

			}

			hit =  location.IsNear(Restart.Position, 50.0f) ;
			if (hit) {
				Restart.ScaleTo (new CCSize (1.1f*Restart.ScaledContentSize.Width,1.1f*Restart.ScaledContentSize.Height));
			}

			hit =  location.IsNear(MainMenu.Position, 50.0f) ;

			if (hit) {
				MainMenu.ScaleTo (new CCSize (1.1f*MainMenu.ScaledContentSize.Width,1.1f*MainMenu.ScaledContentSize.Height));
			}


			hit = location.IsNear (PauseButton.Position, 50.0f) ;

			if (hit) {
				if (PauseGame == true) {
					CCMoveBy SlideIn = new CCMoveBy (0.5f, new CCPoint (0.0f, 0.3f * bounds.Height));
					ResumeGame.RunAction (SlideIn);
					Restart.RunAction (SlideIn);
					MainMenu.RunAction (SlideIn);
					menuframe.RunAction (SlideIn);
					PauseGame = false;
					CCSimpleAudioEngine.SharedEngine.PauseBackgroundMusic ();
				} else {
					CCMoveBy SlideOut = new CCMoveBy (0.5f, new CCPoint (0.0f,- 0.3f * bounds.Height));
					ResumeGame.RunAction (SlideOut);
					Restart.RunAction (SlideOut);
					MainMenu.RunAction (SlideOut);
					menuframe.RunAction (SlideOut);
					PauseGame = true;
					CCSimpleAudioEngine.SharedEngine.ResumeBackgroundMusic ();
					//CCSimpleAudioEngine.SharedEngine.PlayBackgroundMusic("Sounds/backgroundmusic1");
				}
				//MainMenu.Scale *= 1.2f * MainMenu.Scale;
			}

			//BUG: calling walkRepeat separately as it doesn't run when called in RunActions or CCSpawn

			//Pause ended


			double closestPivot = 10000;
			for (int i = 0; i < visiblePivots.Count; i++) {
				ballPhysicsSingle.dRadius_X = ballSprite.PositionX - visiblePivots [i].PositionX;
				ballPhysicsSingle.dRadius_Y = ballSprite.PositionY - visiblePivots [i].PositionY;


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

				ballPhysicsSingle.dRadius_X = ballSprite.PositionX - visiblePivots [ballPhysicsSingle.indexHookPivot].PositionX;
				ballPhysicsSingle.dRadius_Y = ballSprite.PositionY - visiblePivots [ballPhysicsSingle.indexHookPivot].PositionY;

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
				#region ballSpeedFinal 
				ballPhysicsSingle.ballSpeedFinal = ballPhysicsSingle.Radius * Multiplier * ballPhysicsSingle.wZero;///*************************
				#endregion
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

		#endregion
		#region FREE & HOOKED PARTICLE
		void freeParticle(float frameTimeInSeconds){
			gravity = 0;
			// This is a linear approximation, so not 100% accurate
			if (ballPhysicsSingle.hookTouchBool == true) {
				// This is a linear approximation, so not 100% accurate
				//ballPhysicsSingle.ballXVelocity += frameTimeInSeconds * gravity;
				ballSprite.PositionX += ballPhysicsSingle.ballXVelocity * frameTimeInSeconds;
				ballSprite.PositionY += ballPhysicsSingle.ballYVelocity * frameTimeInSeconds;
				// New code:
				//score++;
				//scoreLabel.Text = "Score: " + score;
				// Check if the ball is either too far to the right or left:
				float ballRight = ballSprite.BoundingBoxTransformedToParent.MaxX;
				float ballLeft = ballSprite.BoundingBoxTransformedToParent.MinX;

				float screenRight = mainLayer.VisibleBoundsWorldspace.MaxX;
				float screenLeft = mainLayer.VisibleBoundsWorldspace.MinX;

				bool shouldReflectXVelocity = (ballRight > screenRight && ballPhysicsSingle.ballXVelocity > 0) ||	(ballLeft < screenLeft && ballPhysicsSingle.ballXVelocity < 0);


				if (shouldReflectXVelocity) {
					ballPhysicsSingle.ballXVelocity *= -1;

				}

				// Check if the ball is either too far to the right or left:

				float ballTop = ballSprite.BoundingBoxTransformedToParent.MaxY;
				float ballBottom = ballSprite.BoundingBoxTransformedToParent.MinY;

				float screenTop = mainLayer.VisibleBoundsWorldspace.MaxY;
				float screenBottom = mainLayer.VisibleBoundsWorldspace.MinY;

				bool shouldReflectYVelocity = (ballTop > screenTop && ballPhysicsSingle.ballYVelocity > 0) ||	(ballBottom < screenBottom && ballPhysicsSingle.ballYVelocity < 0);

				if (shouldReflectYVelocity) {
					ballPhysicsSingle.ballYVelocity *= -1;
				}
			}

		}

		void hookedParticle(float frameTimeInSeconds){
			gravity = 0;

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
					ballPhysicsSingle.theta -= (double)(Multiplier * ballPhysicsSingle.wZero*  frameTimeInSeconds);

					ballPhysicsSingle.ballXVelocity = (float)(ballPhysicsSingle.ballSpeedFinal * Math.Sin (ballPhysicsSingle.theta));
					ballPhysicsSingle.ballYVelocity = (float)(-ballPhysicsSingle.ballSpeedFinal * Math.Cos (ballPhysicsSingle.theta));
				}
				/////////
				ballSprite.PositionX = (float)(ballPhysicsSingle.Radius * Math.Cos (ballPhysicsSingle.theta) + visiblePivots [ballPhysicsSingle.indexHookPivot].PositionX);
				ballSprite.PositionY = (float)(ballPhysicsSingle.Radius * Math.Sin (ballPhysicsSingle.theta) + visiblePivots [ballPhysicsSingle.indexHookPivot].PositionY);


				///Remove gone far Pivots
				for (int i = 0; i < visibleJewels.Count; i++) {


					if (visibleJewels [i].PositionY < -500) {
						visibleJewels.RemoveAt (i);
					}



				}
			}

		}
		//////
		/// 
		#endregion

		#region OBJECTS AND SPRITES

		void addBlueBall(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			ballSprite = new CCSprite ("blueball");
			ballSprite.Scale = 0.0005f*bounds.Width;
			ballSprite.PositionX = 0.6f*bounds.Width;
			ballSprite.PositionY = -0.1f*bounds.Height;

			//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
			mainLayer.AddChild (ballSprite);

			ballPhysicsSingle.index = 1;
			ballPhysicsSingle.ballSprite= ballSprite;
			ballPhysicsSingle.ballXVelocity = 0;
			ballPhysicsSingle.ballYVelocity = 300;
			ballPhysicsSingle.hookTouchBool = true;
			ballPhysicsSingle.theta = 0;
			ballPhysicsSingle.ThetaZero = 0;
			ballPhysicsSingle.ClockwiseRotation = true;
			ballPhysicsList.Add (ballPhysicsSingle);



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

		#region CHECK COLLISION
		//Remove jewel and and Score Counter
		void checkJewel(){
			foreach (var ruby in visibleJewels) {
				bool hit = ruby.BoundingBoxTransformedToParent.IntersectsRect(ballSprite.BoundingBoxTransformedToParent);
				if (hit)
				{
					hitJewels.Add(ruby);
					CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/jewel2");
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
					//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/bomb02");
					//Explode(banana.Position);
					diamond.RemoveFromParent();



				}
			}

			hitJewels.Clear();


		}
		//SPIKE

		void checkTrap(){
			foreach (var spikeSprite in visibleTraps) {
				bool hit = spikeSprite.BoundingBoxTransformedToParent.IntersectsRect(ballSprite.BoundingBoxTransformedToParent);
				if (hit)
				{


					CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/bomb02");
					Explode(spikeSprite.Position);
					spikeSprite.RemoveFromParent(true);
					visibleTraps.Remove (spikeSprite);


					//hitJewels.Add(ruby);
					//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
					//Explode(banana.Position);
					//ruby.RemoveFromParent();
					score -= 50;
					DisplayScore (score);

					ShouldEndGame ();
					break;
				}
			}


		}
		#endregion

		#region LEVEL  HANDLERS
		void ShouldEndGame (){
			if (score <= -100) {
				EndGame ();
			}


		}
		void EndGame(){
			OnePlayerScrollerScene gameScene = new OnePlayerScrollerScene (mainWindowAux);
			mainWindowAux.RunWithScene (gameScene);

		}

		void DisplayScore(float score ){

			scoreLabel.Text = "Score: " + score;
			//
		}

		void addPauseButton(){
			var bounds = mainWindowAux.WindowSizeInPixels;

			float scale =0.0012f*bounds.Width;

			PauseButton = new CCSprite ("PauseButton");
			PauseButton.Scale = scale; 
			PauseButton.PositionX = bounds.Width-40;
			PauseButton.PositionY = bounds.Height-40;
			mainLayer.AddChild (PauseButton);
		}

		void addMenuOptions (){
			var bounds = mainWindowAux.WindowSizeInPixels;
			float scale =0.002f*bounds.Width;

			ResumeGame = new CCSprite ("ResumeButton");
			ResumeGame.Scale = scale; 
			ResumeGame.PositionX = 0.5f*bounds.Width;
			ResumeGame.PositionY = -0.2f*bounds.Height;
			mainLayer.AddChild (ResumeGame);

			Restart = new CCSprite ("RestartButton");
			Restart.Scale = scale; 
			Restart.PositionX = 0.75f*bounds.Width;
			Restart.PositionY = -0.2f*bounds.Height;
			mainLayer.AddChild (Restart);

			MainMenu = new CCSprite ("MainMenuButton");
			MainMenu.Scale = scale; 
			MainMenu.PositionX = 0.25f*bounds.Width;
			MainMenu.PositionY = -0.2f*bounds.Height;
			mainLayer.AddChild (MainMenu);

			menuframe = new CCSprite ("layerbackground");
			menuframe.Scale = scale; 
			menuframe.PositionX = 0.5f*bounds.Width;
			menuframe.PositionY = -0.4f*bounds.Height;
			mainLayer.AddChild (menuframe);

			mainLayer.ReorderChild (ResumeGame, 101);
			mainLayer.ReorderChild (Restart, 100);
			mainLayer.ReorderChild (MainMenu, 100);
			mainLayer.ReorderChild (menuframe, 98);
		
		}
		#endregion

	}

}



