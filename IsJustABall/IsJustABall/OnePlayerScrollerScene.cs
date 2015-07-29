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
		String ThisLevelName;
		CCLayer mainLayer;
		ballPhysics ballPhysicsSingle = new ballPhysics ();
		CCSprite ballSprite;
		List<ballPhysics> ballPhysicsList;
		List<CCSprite> visibleJewels;
		List<CCSprite> visibleEmerald;
		List<CCSprite> hitJewels;
		List<CCSprite> StarList;
		CCSprite ruby;
		CCSprite diamond;
		CCSprite background1;
		CCSprite background2;
		CCSprite backgroundRotational;
		CCSprite PauseButton;
		CCSprite ResumeGame,Restart,MainMenu,menuframe,Star;
	//	CCSprite levelcleared;
		List<CCSprite> visiblePivots;
		CCSprite pivotSprite;

		List<CCSprite> visibleTraps;
		CCSprite spikeSprite;
		List<CCSprite> visibleWalls;
		List<CCSprite> visibleBlackholes;
		List<CCSprite> visibleTutorialSteps;
		CCSprite WallSprite;
		CCSprite BlackholeSprite;

		 
		CCLabel scoreLabel;
		CCLabel pointsLabel;
		byte R,G,B;

		// How much to modify the ball's y velocity per second:
		//float gravity = 0;
		//hookTouchBool=!hookTouchBool// to toggle on Touch
		//Speed for scroller level
		int scrollerSpeed= 150;
		int topSpeed;
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
		public OnePlayerScrollerScene(CCWindow mainWindow,string LevelName) : base(mainWindow)
		{   var bounds = mainWindow.WindowSizeInPixels;
			minRotationRadius = 0.25f*bounds.Width;
			CCSimpleAudioEngine.SharedEngine.PreloadBackgroundMusic ("Sounds/backgroundmusic1");
			CCSimpleAudioEngine.SharedEngine.PlayBackgroundMusic("Sounds/backgroundmusic1");

			mainWindowAux = mainWindow;
			ThisLevelName = LevelName;
			mainLayer = new CCLayer ();
			AddChild (mainLayer);
			visiblePivots = new List<CCSprite> ();
			visibleJewels = new List<CCSprite> ();
			visibleEmerald = new List<CCSprite> ();
			visibleWalls = new List<CCSprite> ();
			visibleBlackholes = new List<CCSprite> ();
			visibleTutorialSteps = new List<CCSprite> ();

			hitJewels = new List<CCSprite> ();
			visibleTraps = new List<CCSprite>();
			StarList = new List<CCSprite> ();
			ballPhysicsList = new List<ballPhysics> ();

			scrollerSpeed = (int)(0.1 * bounds.Width);
			topSpeed = (int)(0.9 * bounds.Width);



			addLevelPivots (mainWindow);
			addLevelJewels (mainWindow);
			addLevelSpikes (mainWindow);
			addBlueBall(mainWindow);
			addLevelWalls (mainWindow);
			addLevelBlackholes (mainWindow);
			addLevelTutorialSteps (mainWindow);

			addBackground (mainWindow);
			addPauseButton ();
			addMenuOptions ();
			//addLevelStars ();//maybe?
		

			//scoreLabel = new CCLabel ("Score: 0", "arial", 78);
			scoreLabel = new CCLabel("Score:","nasalizationbold.ttf",78);
			scoreLabel.PositionX = 0 ;
			scoreLabel.PositionY = mainLayer.VisibleBoundsWorldspace.MaxY - 20;
			scoreLabel.AnchorPoint = CCPoint.AnchorUpperLeft;

			pointsLabel = new CCLabel("","nasalizationbold.ttf",78);
			pointsLabel.PositionX = scoreLabel.ContentSize.Width ;
			pointsLabel.PositionY = mainLayer.VisibleBoundsWorldspace.MaxY - 20;
			pointsLabel.AnchorPoint = CCPoint.AnchorUpperLeft;
			CCColor3B fontColor = new CCColor3B(255	,62	,150) ;
			pointsLabel.UpdateDisplayedColor (fontColor);



			mainLayer.AddChild (scoreLabel);
			mainLayer.ReorderChild (scoreLabel, 200);
			mainLayer.AddChild (pointsLabel);
			mainLayer.ReorderChild (pointsLabel, 200);


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

				foreach (var diamond in visibleEmerald) {

					diamond.PositionY += -scrollerSpeed * frameTimeInSeconds;
					//element.Rotation (1.0f);
				}

				foreach (var spikeSprite in visibleTraps) {

					spikeSprite.PositionY += -scrollerSpeed * frameTimeInSeconds;
					//element.Rotation (1.0f);
				}

				foreach (var WallSprite in visibleWalls) {

					WallSprite.PositionY += -scrollerSpeed * frameTimeInSeconds;
					if(WallSprite.PositionY < -0.2f*mainWindowAux.WindowSizeInPixels.Width){
						WallSprite.RemoveFromParent(true);
						WallSprite.Cleanup ();
						WallSprite.Dispose ();
						//visibleWalls.Remove (WallSprite);
						//break;				
					}
				}
				foreach (var BlackholeSprite in visibleBlackholes) {

					BlackholeSprite.PositionY += -scrollerSpeed * frameTimeInSeconds;
					//element.Rotation (1.0f);
				}

				foreach (var BlackholeSprite in visibleTutorialSteps) {

					BlackholeSprite.PositionY += -scrollerSpeed * frameTimeInSeconds;
					//element.Rotation (1.0f);
				}

				checkJewel ();
				checkSpike ();
				checkWall ();
				checkBlackhole ();

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


			CCScaleBy ZoomTouch = new CCScaleBy(0.01f,(0.18f)* mainWindowAux.WindowSizeInPixels.Width/ResumeGame.BoundingBoxTransformedToWorld.Size.Width);
			ResumeGame.RunAction (ZoomTouch);

			ZoomTouch = new CCScaleBy(0.01f,(0.18f)* mainWindowAux.WindowSizeInPixels.Width/Restart.BoundingBoxTransformedToWorld.Size.Width);
			Restart.RunAction (ZoomTouch);

			ZoomTouch = new CCScaleBy(0.01f,(0.18f)* mainWindowAux.WindowSizeInPixels.Width/MainMenu.BoundingBoxTransformedToWorld.Size.Width);
			MainMenu.RunAction (ZoomTouch);


			bool hit = ResumeGame.BoundingBoxTransformedToParent.ContainsPoint (location);

			if (hit)
			{
				//ResumeGame.Scale =  ResumeGame.Scale/1.2f;

				PauseGame = true;

				//ResumeGame.ScaleTo (new CCSize (ResumeGame.ScaledContentSize.Width/1.1f,ResumeGame.ScaledContentSize.Height/1.1f));
				//CCSimpleAudioEngine.SharedEngine.PlayBackgroundMusic("Sounds/backgroundmusic1");
				CCSimpleAudioEngine.SharedEngine.ResumeBackgroundMusic ();
				CCMoveBy SlideOut = new CCMoveBy (0.5f,new CCPoint(0.0f,- 0.3f*bounds.Height));
				ResumeGame.RunAction(SlideOut);
				Restart.RunAction(SlideOut);
				MainMenu.RunAction(SlideOut);


			}

			hit = Restart.BoundingBoxTransformedToParent.ContainsPoint (location);

			if (hit) {
				//Restart.ScaleTo (new CCSize (Restart.ScaledContentSize.Width/1.1f,Restart.ScaledContentSize.Height/1.1f));
				OnePlayerScrollerScene gameScene1 = new OnePlayerScrollerScene (mainWindowAux,ThisLevelName);
				mainWindowAux.RunWithScene (gameScene1);
			}

			hit = MainMenu.BoundingBoxTransformedToParent.ContainsPoint (location);

			if (hit) {
				//MainMenu.ScaleTo (new CCSize (MainMenu.ScaledContentSize.Width/1.1f,MainMenu.ScaledContentSize.Height/1.1f));
				MainMenuScene gameScene2 = new MainMenuScene (mainWindowAux);
				mainWindowAux.RunWithScene (gameScene2);

			}

			//BUG: calling walkRepeat separately as it doesn't run when called in RunActions or CCSpawn


		}



		void HandleTouchesBegan(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){
			//random colors
			var randomColor = new Random();
			R = Convert.ToByte( randomColor.Next (50,255));
			G = Convert.ToByte(randomColor.Next (50,255));
			B = Convert.ToByte(randomColor.Next (50,255));

			CCScaleBy ZoomTouch = new CCScaleBy(0.01f,0.21f* mainWindowAux.WindowSizeInPixels.Width/ResumeGame.BoundingBoxTransformedToWorld.Size.Width);
			//Pause
			var bounds = mainWindowAux.WindowSizeInPixels;
			var locationInverted = touches [0].LocationOnScreen;
			CCPoint location = new CCPoint(locationInverted.X,bounds.Height - locationInverted.Y);


			bool hit = ResumeGame.BoundingBoxTransformedToParent.ContainsPoint (location);
			if (hit)
			{
				//ResumeGame.ScaleTo (new CCSize (1.1f*ResumeGame.ScaledContentSize.Width,1.1f*ResumeGame.ScaledContentSize.Height));
				ResumeGame.RunAction(ZoomTouch);
				CCMoveBy SlideOut = new CCMoveBy (0.5f, new CCPoint (0.0f,- 0.4f * bounds.Height));
				menuframe.RunAction (SlideOut);////
			}

			hit = Restart.BoundingBoxTransformedToParent.ContainsPoint (location);

			if (hit) {
				//Restart.ScaleTo (new CCSize (1.1f*Restart.ScaledContentSize.Width,1.1f*Restart.ScaledContentSize.Height));
				ZoomTouch = new CCScaleBy(0.01f,0.21f* mainWindowAux.WindowSizeInPixels.Width/Restart.BoundingBoxTransformedToWorld.Size.Width);
				Restart.RunAction(ZoomTouch);
			}

			hit = MainMenu.BoundingBoxTransformedToParent.ContainsPoint (location);

			if (hit) {
				//MainMenu.ScaleTo (new CCSize (1.1f*MainMenu.ScaledContentSize.Width,1.1f*MainMenu.ScaledContentSize.Height));
				ZoomTouch = new CCScaleBy(0.01f,0.21f* mainWindowAux.WindowSizeInPixels.Width/MainMenu.BoundingBoxTransformedToWorld.Size.Width);
				MainMenu.RunAction(ZoomTouch);
			}

			hit = PauseButton.BoundingBoxTransformedToParent.ContainsPoint (location);


			if (hit) {
				if (PauseGame == true) {
					CCMoveBy SlideIn = new CCMoveBy (0.5f, new CCPoint (0.0f, 0.4f * bounds.Height));
					ResumeGame.RunAction (SlideIn);
					Restart.RunAction (SlideIn);
					MainMenu.RunAction (SlideIn);
					menuframe.RunAction (SlideIn);
					PauseGame = false;
					CCSimpleAudioEngine.SharedEngine.PauseBackgroundMusic ();
				} else {
					CCMoveBy SlideOut = new CCMoveBy (0.5f, new CCPoint (0.0f,- 0.4f * bounds.Height));
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
		//	gravity = 0;
			// This is a linear approximation, so not 100% accurate
			if (ballPhysicsSingle.hookTouchBool == true) {
				visiblePivots [ballPhysicsSingle.indexHookPivot].RemoveAllChildren(true);//sweptAreaLine Delete
				// This is a linear approximation, so not 100% accurate
				//ballPhysicsSingle.ballXVelocity += frameTimeInSeconds * gravity;
				ballPhysicsSingle.ballXVelocity += frameTimeInSeconds * (float)ballPhysicsSingle.gravityX;
				ballPhysicsSingle.ballYVelocity += frameTimeInSeconds * (float)ballPhysicsSingle.gravityY;

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

			if (ballPhysicsSingle.ballYVelocity > topSpeed) {
				ballPhysicsSingle.ballYVelocity = topSpeed;
			}
			if (ballPhysicsSingle.ballXVelocity > topSpeed) {
				ballPhysicsSingle.ballXVelocity = topSpeed;
			}
		}



		void hookedParticle(float frameTimeInSeconds){
		//	gravity = 0;

			if (ballPhysicsSingle.hookTouchBool == false) {
				//multiplier on close radius\
				//double multR = (10 / Radius);
				//min SPEED to avoid sink of th ball
				if (ballPhysicsSingle.ballSpeedFinal < 180) {
					ballPhysicsSingle.ballSpeedFinal = 180;
				}
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
				ballSprite.PositionX = (float)(ballPhysicsSingle.Radius * Math.Cos (ballPhysicsSingle.theta) + visiblePivots [ballPhysicsSingle.indexHookPivot].PositionX);
				ballSprite.PositionY = (float)(ballPhysicsSingle.Radius * Math.Sin (ballPhysicsSingle.theta) + visiblePivots [ballPhysicsSingle.indexHookPivot].PositionY);


				///Remove gone far Pivots
				for (int i = 0; i < visibleJewels.Count; i++) {


					if (visibleJewels [i].PositionY < -500) {
						visibleJewels.RemoveAt (i);
					}



				}

				//////////TESTING SWEPT AREA LINE drawSweptAreaLine ()
			
			drawSweptAreaLine (R,G,B);
			}



		}
		//////
		/// 
		#endregion

		#region OBJECTS AND SPRITES

		void addBlueBall(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			ballSprite = new CCSprite ("blueball");
			ballSprite.Scale = 0.0003f*bounds.Width;
			ballSprite.PositionX = 0.6f*bounds.Width;
			ballSprite.PositionY = -0.1f*bounds.Height;

			//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
			mainLayer.AddChild (ballSprite);
			mainLayer.ReorderChild (ballSprite, 110);

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

		CCSprite addStar(CCWindow mainWindow,float rubyPosX,float rubyPosY,float scale,string starType){
			var bounds = mainWindow.WindowSizeInPixels;
			switch (starType) {
			case "onestar":
				Star = new CCSprite ("onestar");
				break;
			case "twostar":
				Star = new CCSprite ("twostar");
				break;
			case "thirdstar":
				Star = new CCSprite ("thirdstar");
				break;
			}

			Star.Scale = scale;
			Star.PositionX = rubyPosX;
			Star.PositionY = rubyPosY;
			//CCRotateBy rotate = new CCRotateBy (0.0f, 90);
			//ruby.RunAction (rotate);

			//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);

			mainLayer.AddChild (Star);
			mainLayer.ReorderChild (Star, 102);
			return Star;
		}

		void addBackground(CCWindow mainWindow){
			background1 = new CCSprite ("galaxybackground4");
			background2 = new CCSprite ("galaxybackground4");
			backgroundRotational= new CCSprite ("freepik03");
			var bounds = mainWindow.WindowSizeInPixels;
			switch(ThisLevelName){
			case "minefield":
				CCScaleBy SpriteSize = new CCScaleBy (0.0f, 4.2f * bounds.Width / backgroundRotational.BoundingBoxTransformedToWorld.Size.Height);

				backgroundRotational.RunAction (SpriteSize);

				//backgroundRotational.PositionX = bounds.Width / 2;
				//backgroundRotational.PositionY = -background1.ContentSize.Height;
				backgroundRotational.Opacity = 150;
				backgroundRotational.PositionX = bounds.Width/2;;
				backgroundRotational.PositionY = 0;
				backgroundRotational.AnchorPoint = CCPoint.AnchorMiddle;
				mainLayer.AddChild (backgroundRotational);
				mainLayer.ReorderChild (backgroundRotational, -100);
				CCRotateBy rotateBG = new CCRotateBy (200.0f, 360.0f);
				backgroundRotational.RepeatForever (rotateBG);
				break;
			case "railgun":
				background1 = new CCSprite ("triangles3background");
				SpriteSize = new CCScaleBy (0.0f, 1.0f * bounds.Width / background1.BoundingBoxTransformedToWorld.Size.Width);
				background1.RunAction (SpriteSize);
				background1.Opacity = 200;
				background1.PositionX = bounds.Width/2;;
				background1.PositionY = 0;
				background1.AnchorPoint = CCPoint.AnchorMiddleBottom;
				mainLayer.AddChild (background1);
				mainLayer.ReorderChild (background1,- 100);
				CCMoveBy moveBG = new CCMoveBy (25.0f, new CCPoint (0.0f,background1.BoundingBoxTransformedToWorld.Size.Height));
				backgroundRotational.RepeatForever (moveBG);
				break;
			case "blackhole":
			 SpriteSize = new CCScaleBy(0.01f,1.0f*bounds.Width/background1.BoundingBoxTransformedToWorld.Size.Width);
		
			background1.RunAction(SpriteSize);
			background1.PositionX = bounds.Width/2;
			background1.PositionY = background1.ContentSize.Height-500.0f;
		    mainLayer.AddChild (background1);
			mainLayer.ReorderChild (background1,- 100);
			
			
			background2.RunAction(SpriteSize);
			background2.PositionX = bounds.Width/2;
			background2.PositionY = 2*background2.ContentSize.Height;
			mainLayer.AddChild (background2);
			mainLayer.ReorderChild (background2,- 99);
					
				break;
			default:
				break;

			}
			}

	



		CCSprite AddSTATIC_Pivots (CCWindow mainWindow,float pivotPosX,float pivotPosY,float scale)
		{   

			pivotSprite = new CCSprite ("pivot");
			CCScaleTo Resize = new CCScaleTo (0.0f, 0.06f * mainWindow.WindowSizeInPixels.Width / pivotSprite.BoundingBoxTransformedToParent.Size.Width);
			pivotSprite.RunAction (Resize);
			pivotSprite.PositionX = pivotPosX;
			pivotSprite.PositionY = pivotPosY;
			float h= (float)pivotSprite.ContentSize.Height/2.0f;
			CCPoint tempPos = new CCPoint(h,h);

			var bounds = mainWindow.WindowSizeInPixels;

			mainLayer.AddChild(pivotSprite);
			mainLayer.ReorderChild (pivotSprite, 109);

			CCRotateBy rotatePivot = new CCRotateBy (4.0f, 360);

			//pivotSprite.RepeatForever(rotatePivot);
			return pivotSprite;
		}

		CCSprite AddUP_Pivots(CCWindow mainWindow,float pivotPosX,float pivotPosY,float scale)
		{   


			pivotSprite = new CCSprite ("pivot");
			CCScaleTo Resize = new CCScaleTo (0.0f, 0.06f * mainWindow.WindowSizeInPixels.Width / pivotSprite.BoundingBoxTransformedToParent.Size.Width);
			pivotSprite.RunAction (Resize);
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
			mainLayer.ReorderChild (pivotSprite, 109);
			CCRotateBy rotatePivot = new CCRotateBy (4.0f, 360);
			CCMoveBy moveByPivot_UP = new CCMoveBy (3.0f,new CCPoint(-0.7f*bounds.Width,0.0f));
			pivotSprite.RepeatForever(moveByPivot_UP,moveByPivot_UP.Reverse());
			//pivotSprite.RepeatForever (rotatePivot);
			return pivotSprite;

		}		


		CCSprite AddDOWN_Pivots(CCWindow mainWindow,float pivotPosX,float pivotPosY,float scale)
		{   


			pivotSprite = new CCSprite ("pivot");
			CCScaleTo Resize = new CCScaleTo (0.0f, 0.06f * mainWindow.WindowSizeInPixels.Width / pivotSprite.BoundingBoxTransformedToParent.Size.Width);
			pivotSprite.RunAction (Resize);
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
			mainLayer.ReorderChild (pivotSprite, 109);
			CCRotateBy rotatePivot = new CCRotateBy (4.0f, 360);
			CCMoveBy moveByPivot_UP = new CCMoveBy (3.0f,new CCPoint(0.7f*bounds.Width,0.0f));
			pivotSprite.RepeatForever(moveByPivot_UP,moveByPivot_UP.Reverse());
			//pivotSprite.RepeatForever (rotatePivot);
			return pivotSprite;

		}CCSprite AddRIGHT_Pivots(CCWindow mainWindow,float pivotPosX,float pivotPosY,float scale)
		{   


			pivotSprite = new CCSprite ("pivot");
			CCScaleTo Resize = new CCScaleTo (0.0f, 0.06f * mainWindow.WindowSizeInPixels.Width / pivotSprite.BoundingBoxTransformedToParent.Size.Width);
			pivotSprite.RunAction (Resize);
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
			mainLayer.ReorderChild (pivotSprite, 109);
			CCRotateBy rotatePivot = new CCRotateBy (4.0f, 360);
			CCMoveBy moveByPivot_UP = new CCMoveBy (3.0f,new CCPoint(0.0f,0.7f*bounds.Width));
			pivotSprite.RepeatForever(moveByPivot_UP,moveByPivot_UP.Reverse());
			//pivotSprite.RepeatForever (rotatePivot);
			return pivotSprite;

		}

		CCSprite AddLEFT_Pivots(CCWindow mainWindow,float pivotPosX,float pivotPosY,float scale)
		{   


			pivotSprite = new CCSprite ("pivot");
			CCScaleTo Resize = new CCScaleTo (0.0f, 0.06f * mainWindow.WindowSizeInPixels.Width / pivotSprite.BoundingBoxTransformedToParent.Size.Width);
			pivotSprite.RunAction (Resize);
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
			mainLayer.ReorderChild (pivotSprite, 109);
			CCRotateBy rotatePivot = new CCRotateBy (4.0f, 360);
			CCMoveBy moveByPivot_UP = new CCMoveBy (3.0f,new CCPoint(0.0f,-0.7f*bounds.Width));
			pivotSprite.RepeatForever(moveByPivot_UP,moveByPivot_UP.Reverse());
			//pivotSprite.RepeatForever (rotatePivot);
			return pivotSprite;

		}



		void addLevelPivots (CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;
			float pivotScale=0.0002f*bounds.Width;

			switch(ThisLevelName){
			case "tutorial":
				LevelTutorial LevelClass1 = new LevelTutorial ();
				List<LevelTutorial.Pivot> ClassListTutorial = new List<LevelTutorial.Pivot> ();
				ClassListTutorial = LevelClass1.PivotMaker ();
				foreach(var Pivot in ClassListTutorial){
					Pivot.PosX = Pivot.PosX*bounds.Width;
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
				break;
			case "railgun":
				LevelRailGun LevelClass2 = new LevelRailGun ();
				List<LevelRailGun.Pivot> ClassListRailGun = new List<LevelRailGun.Pivot> ();
				ClassListRailGun = LevelClass2.PivotMaker ();
				foreach(var Pivot in ClassListRailGun){
					Pivot.PosX = Pivot.PosX*bounds.Width;
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
				break;
			case "minefield":
				LevelMineField LevelClass3 = new LevelMineField ();
				List<LevelMineField.Pivot> ClassListMineField = new List<LevelMineField.Pivot> ();
				ClassListMineField = LevelClass3.PivotMaker ();
				foreach(var Pivot in ClassListMineField){
					Pivot.PosX = Pivot.PosX*bounds.Width;
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
						//blackhole level pivots
					
					}
				}
				break;
			case "blackhole":
				LevelBlackhole LevelClass4 = new LevelBlackhole ();
				List<LevelBlackhole.Pivot> ClassListBlackhole = new List<LevelBlackhole.Pivot> ();
				ClassListBlackhole = LevelClass4.PivotMaker ();
				foreach(var Pivot in ClassListBlackhole){
					Pivot.PosX = Pivot.PosX*bounds.Width;
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
						//blackhole level pivots

					}
				}break;
				//TestGrounds
			case "testgrounds":
				LevelTestGrounds LevelClass5 = new LevelTestGrounds ();
				List<LevelTestGrounds.Pivot> ClassListTestGrounds = new List<LevelTestGrounds.Pivot> ();
				ClassListTestGrounds = LevelClass5.PivotMaker ();
				foreach(var Pivot in ClassListTestGrounds){
					Pivot.PosX = Pivot.PosX*bounds.Width;
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
				}break;


			default:
				break;

			}//switch itemlevel end

		}//addLevelPivots end

		//JEWELS

		void addLevelJewels (CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;
			float jewelScale=0.0004f*bounds.Width;

			switch(ThisLevelName){
			case "tutorial":
				LevelTutorial LevelClass1 = new LevelTutorial ();
				List<LevelTutorial.Jewel> ClassListTutorial = new List<LevelTutorial.Jewel> ();
				ClassListTutorial = LevelClass1.JewelMaker ();
				foreach(var Jewel in ClassListTutorial){
					Jewel.PosX = Jewel.PosX*bounds.Width;
					Jewel.PosY = Jewel.PosY*bounds.Height;

					switch(Jewel.JewelType){
					case "RUBY":
						visibleJewels.Add (addRuby (mainWindow, Jewel.PosX, Jewel.PosY, jewelScale));
						break;
					case "DIAMOND":
						visibleEmerald.Add (addDiamond (mainWindow, Jewel.PosX, Jewel.PosY, jewelScale));
						break;
					default:
						visibleJewels.Add (addRuby (mainWindow, Jewel.PosX,Jewel.PosY, jewelScale));
						break;
					}
				}
				break;
			case "railgun":
				LevelRailGun LevelClass2 = new LevelRailGun ();
				List<LevelRailGun.Jewel> ClassListRailGun = new List<LevelRailGun.Jewel> ();
				ClassListRailGun = LevelClass2.JewelMaker ();
				foreach(var Jewel in ClassListRailGun){
					Jewel.PosX = Jewel.PosX*bounds.Width;
					Jewel.PosY = Jewel.PosY*bounds.Height;

					switch(Jewel.JewelType){
					case "RUBY":
						visibleJewels.Add (addRuby (mainWindow, Jewel.PosX, Jewel.PosY, jewelScale));
						break;
					case "DIAMOND":
						visibleEmerald.Add (addDiamond (mainWindow, Jewel.PosX, Jewel.PosY, jewelScale));
						break;
					default:
						visibleJewels.Add (addRuby (mainWindow, Jewel.PosX,Jewel.PosY, jewelScale));
						break;
					}
				}
				break;
			case "minefield":
				LevelMineField LevelClass = new LevelMineField ();
				List<LevelMineField.Jewel> ClassListMineField = new List<LevelMineField.Jewel> ();
				ClassListMineField = LevelClass.JewelMaker ();
				foreach(var Jewel in ClassListMineField){
					Jewel.PosX = Jewel.PosX*bounds.Width;
					Jewel.PosY = Jewel.PosY*bounds.Height;

					switch(Jewel.JewelType){
					case "RUBY":
						visibleJewels.Add (addRuby (mainWindow, Jewel.PosX, Jewel.PosY, jewelScale));
						break;
					case "DIAMOND":
						visibleEmerald.Add (addDiamond (mainWindow, Jewel.PosX, Jewel.PosY, jewelScale));
						break;
					default:
						visibleJewels.Add (addRuby (mainWindow, Jewel.PosX,Jewel.PosY, jewelScale));
						break;
					}
				}
				break;

			case "blackhole":
				LevelBlackhole LevelClass3 = new LevelBlackhole ();
				List<LevelBlackhole.Jewel> ClassListBlackhole = new List<LevelBlackhole.Jewel> ();
				ClassListBlackhole = LevelClass3.JewelMaker ();
				foreach(var Jewel in ClassListBlackhole){
					Jewel.PosX = Jewel.PosX*bounds.Width;
					Jewel.PosY = Jewel.PosY*bounds.Height;

					switch(Jewel.JewelType){
					case "RUBY":
						visibleJewels.Add (addRuby (mainWindow, Jewel.PosX, Jewel.PosY, jewelScale));
						break;
					case "DIAMOND":
						visibleEmerald.Add (addDiamond (mainWindow, Jewel.PosX, Jewel.PosY, jewelScale));
						break;
					default:
						visibleJewels.Add (addRuby (mainWindow, Jewel.PosX,Jewel.PosY, jewelScale));
						break;
					}
				}
				break;

			case "testgrounds":
				LevelTestGrounds LevelClass4 = new LevelTestGrounds ();
				List<LevelTestGrounds.Jewel> ClassListTestGrounds = new List<LevelTestGrounds.Jewel> ();
				ClassListTestGrounds = LevelClass4.JewelMaker ();
				foreach(var Jewel in ClassListTestGrounds){
					Jewel.PosX = Jewel.PosX*bounds.Width;
					Jewel.PosY = Jewel.PosY*bounds.Height;

					switch(Jewel.JewelType){
					case "RUBY":
						visibleJewels.Add (addRuby (mainWindow, Jewel.PosX, Jewel.PosY, jewelScale));
						break;
					case "DIAMOND":
						visibleEmerald.Add (addDiamond (mainWindow, Jewel.PosX, Jewel.PosY, jewelScale));
						break;
					default:
						visibleJewels.Add (addRuby (mainWindow, Jewel.PosX,Jewel.PosY, jewelScale));
						break;
					}
				}
				break;
			
			default:
				break;

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
			switch(ThisLevelName){
			case "tutorial":
				LevelTutorial LevelClass1 = new LevelTutorial ();
				List<LevelTutorial.Spike> ClassListTutorial = new List<LevelTutorial.Spike> ();
				ClassListTutorial = LevelClass1.SpikeMaker ();
				//foreach
				foreach(var Spike in ClassListTutorial){
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
				break;
			case "railgun":
				LevelRailGun LevelClass2 = new LevelRailGun ();
				List<LevelRailGun.Spike> ClassListRailGun = new List<LevelRailGun.Spike> ();
				ClassListRailGun = LevelClass2.SpikeMaker ();
				//foreach
				foreach(var Spike in ClassListRailGun){
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
				break;
			case "minefield":
				LevelMineField LevelClass3 = new LevelMineField ();
				List<LevelMineField.Spike> ClassListMineField = new List<LevelMineField.Spike> ();
				ClassListMineField = LevelClass3.SpikeMaker ();
				//foreach
				foreach(var Spike in ClassListMineField){
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
				break;
			case "blackhole":
				LevelBlackhole LevelClass4 = new LevelBlackhole ();
				List<LevelBlackhole.Spike> ClassListBlackhole = new List<LevelBlackhole.Spike> ();
				ClassListBlackhole = LevelClass4.SpikeMaker ();
				//foreach
				foreach(var Spike in ClassListBlackhole){
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
				break;

				case "testgrounds":
				LevelTestGrounds LevelClass5 = new LevelTestGrounds ();
				List<LevelTestGrounds.Spike> ClassListTestGrounds = new List<LevelTestGrounds.Spike> ();
				ClassListTestGrounds = LevelClass5.SpikeMaker ();
				//foreach
				foreach(var Spike in ClassListTestGrounds){
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
				break;
			default:
				break;

			}



			}

		CCSprite AddSTATIC_Wall (CCWindow mainWindow,float wallPosX,float wallPosY,float scale)
		{   
			var bounds = mainWindow.WindowSizeInPixels;
			WallSprite = new CCSprite ("wallbrick");
			//WallSprite.Scale = scale;
			CCSize wallSize = new CCSize();
			wallSize.Height = bounds.Height/20;
			wallSize.Width = bounds.Width/10;
			//0.3f*bounds.Width/BlackholeSprite.BoundingBoxTransformedToWorld.Size.Width
			CCScaleBy SpriteSize = new CCScaleBy(0.0f,0.1f*bounds.Width/WallSprite.BoundingBoxTransformedToWorld.Size.Width);
			WallSprite.RunAction(SpriteSize);
			//WallSprite.ScaleTo (wallSize);
			WallSprite.PositionX = wallPosX;
			WallSprite.PositionY = wallPosY;


			mainLayer.AddChild(WallSprite);


			return WallSprite;
		}

		CCSprite AddRIGHT_Wall (CCWindow mainWindow,float wallPosX,float wallPosY,float scale)
		{   
			var bounds = mainWindow.WindowSizeInPixels;
			WallSprite = new CCSprite ("wallbrick");
			//WallSprite.Scale = scale;
			CCSize wallSize = new CCSize();
			wallSize.Height = bounds.Height/20;
			wallSize.Width = bounds.Width/10;
			//0.3f*bounds.Width/BlackholeSprite.BoundingBoxTransformedToWorld.Size.Width
			CCScaleBy SpriteSize = new CCScaleBy(0.0f,0.1f*bounds.Width/WallSprite.BoundingBoxTransformedToWorld.Size.Width);
			WallSprite.RunAction(SpriteSize);
			//WallSprite.ScaleTo (wallSize);
			WallSprite.PositionX = wallPosX;
			WallSprite.PositionY = wallPosY;

			mainLayer.AddChild(WallSprite);

			CCMoveBy moveByWall_RIGHT = new CCMoveBy (5.0f,new CCPoint(0.7f*bounds.Width,0.0f));
			WallSprite.RepeatForever(moveByWall_RIGHT,moveByWall_RIGHT.Reverse());


			return WallSprite;
		}


		CCSprite AddLEFT_Wall (CCWindow mainWindow,float wallPosX,float wallPosY,float scale)
		{   
			var bounds = mainWindow.WindowSizeInPixels;
			WallSprite = new CCSprite ("wallbrick");
			//WallSprite.Scale = scale;
			CCSize wallSize = new CCSize();
			wallSize.Height = bounds.Height/20;
			wallSize.Width = bounds.Width/10;
			//0.3f*bounds.Width/BlackholeSprite.BoundingBoxTransformedToWorld.Size.Width
			CCScaleBy SpriteSize = new CCScaleBy(0.0f,0.1f*bounds.Width/WallSprite.BoundingBoxTransformedToWorld.Size.Width);
			WallSprite.RunAction(SpriteSize);
			//WallSprite.ScaleTo (wallSize);
			WallSprite.PositionX = wallPosX;
			WallSprite.PositionY = wallPosY;


			mainLayer.AddChild(WallSprite);
		    CCMoveBy moveByWall_LEFT = new CCMoveBy (5.0f,new CCPoint(-0.7f*bounds.Width,0.0f));
			WallSprite.RepeatForever(moveByWall_LEFT,moveByWall_LEFT.Reverse());


			return WallSprite;
		}

		void addLevelWalls (CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;
			float pivotScale=0.0004f*bounds.Width;
			switch(ThisLevelName){
			case "tutorial":
				LevelTutorial LevelClass1 = new LevelTutorial ();
				List<LevelTutorial.Wall> ClassListTutorial = new List<LevelTutorial.Wall> ();
				ClassListTutorial = LevelClass1.WallMaker ();
				//foreach
				foreach(var Wall in ClassListTutorial){
					Wall.PosX =Wall.PosX*bounds.Width;
					Wall.PosY = Wall.PosY*bounds.Height;

					switch(Wall.MoveType){
					case "STATIC":
						visibleWalls.Add (AddSTATIC_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;
					case "RIGHT":
						visibleWalls.Add (AddRIGHT_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;
					case "LEFT":
						visibleWalls.Add (AddLEFT_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;


					default:
						visibleWalls.Add (AddSTATIC_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;

					}

				}
				break;
			case "railgun":
				LevelRailGun LevelClass2 = new LevelRailGun ();
				List<LevelRailGun.Wall> ClassListRailGun = new List<LevelRailGun.Wall> ();
				ClassListRailGun = LevelClass2.WallMaker ();
				//foreach
				foreach(var Wall in ClassListRailGun){
					Wall.PosX =Wall.PosX*bounds.Width;
					Wall.PosY = Wall.PosY*bounds.Height;

					switch(Wall.MoveType){
					case "STATIC":
						visibleWalls.Add (AddSTATIC_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;
					case "RIGHT":
						visibleWalls.Add (AddRIGHT_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;
					case "LEFT":
						visibleWalls.Add (AddLEFT_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;


					default:
						visibleWalls.Add (AddSTATIC_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;

					}

				}
				break;
			case "minefield":
				LevelMineField LevelClass3 = new LevelMineField ();
				List<LevelMineField.Wall> ClassListMineField = new List<LevelMineField.Wall> ();
				ClassListMineField = LevelClass3.WallMaker ();
				//foreach
				foreach(var Wall in ClassListMineField){
					Wall.PosX =Wall.PosX*bounds.Width;
					Wall.PosY = Wall.PosY*bounds.Height;

					switch(Wall.MoveType){
					case "STATIC":
						visibleWalls.Add (AddSTATIC_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;
					case "RIGHT":
						visibleWalls.Add (AddRIGHT_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;
					case "LEFT":
						visibleWalls.Add (AddLEFT_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;


					default:
						visibleWalls.Add (AddSTATIC_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;

					}

				}
				break;


			case "blackhole":
				LevelBlackhole LevelClass4 = new LevelBlackhole();
				List<LevelBlackhole.Wall> ClassListBlackhole= new List<LevelBlackhole.Wall> ();
				ClassListBlackhole = LevelClass4.WallMaker ();
				//foreach
				foreach(var Wall in ClassListBlackhole){
					Wall.PosX =Wall.PosX*bounds.Width;
					Wall.PosY = Wall.PosY*bounds.Height;

					switch(Wall.MoveType){
					case "STATIC":
						visibleWalls.Add (AddSTATIC_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;
					case "RIGHT":
						visibleWalls.Add (AddRIGHT_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;
					case "LEFT":
						visibleWalls.Add (AddLEFT_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;


					default:
						visibleWalls.Add (AddSTATIC_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;

					}

				}
				break;


			case "testgrounds":
				LevelTestGrounds LevelClass5 = new LevelTestGrounds ();
				List<LevelTestGrounds.Wall> ClassListTestGrounds = new List<LevelTestGrounds.Wall> ();
				ClassListTestGrounds = LevelClass5.WallMaker ();
				//foreach
				foreach(var Wall in ClassListTestGrounds){
					Wall.PosX =Wall.PosX*bounds.Width;
					Wall.PosY = Wall.PosY*bounds.Height;

					switch(Wall.MoveType){
					case "STATIC":
						visibleWalls.Add (AddSTATIC_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;
					case "RIGHT":
						visibleWalls.Add (AddRIGHT_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;
					case "LEFT":
						visibleWalls.Add (AddLEFT_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;


					default:
						visibleWalls.Add (AddSTATIC_Wall (mainWindow,Wall.PosX,Wall.PosY,pivotScale));
						break;

					}
				}
				break;
			default:
				break;

			}

					

		}
		//BLACKHOLE SPRITES
		CCSprite AddSTATIC_Blackhole (CCWindow mainWindow,float blackholePosX,float blackholePosY,float scale)
		{   
			var bounds = mainWindow.WindowSizeInPixels;
			BlackholeSprite = new CCSprite ("blackholetransparent");
			//WallSprite.Scale = scale;
			//CCSize blackholeSize = new CCSize();
			//blackholeSize.Width = bounds.Width/4;
			//blackholeSize.Height = blackholeSize.Width;
			CCScaleBy SpriteSize = new CCScaleBy(0.0f,0.3f*bounds.Width/BlackholeSprite.BoundingBoxTransformedToWorld.Size.Width);
			BlackholeSprite.RunAction(SpriteSize);
			BlackholeSprite.PositionX = blackholePosX;
			BlackholeSprite.PositionY = blackholePosY;

			CCRotateBy rotateForever = new CCRotateBy (0.25f, 5);
			mainLayer.AddChild(BlackholeSprite);
			mainLayer.ReorderChild (BlackholeSprite, -99);
			BlackholeSprite.RepeatForever (rotateForever);


			return BlackholeSprite;
		}

		void addLevelBlackholes (CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;
			float pivotScale=0.0004f*bounds.Width;
			switch(ThisLevelName){
			case "tutorial":
				LevelTutorial LevelClass1 = new LevelTutorial ();
				List<LevelTutorial.Blackhole> ClassListTutorial = new List<LevelTutorial.Blackhole> ();
				ClassListTutorial = LevelClass1.BlackholeMaker ();
				//foreach
				foreach(var Blackhole in ClassListTutorial){
					Blackhole.PosX =Blackhole.PosX*bounds.Width;
					Blackhole.PosY = Blackhole.PosY*bounds.Height;

					switch(Blackhole.MoveType){
					case "STATIC":
						visibleBlackholes.Add (AddSTATIC_Blackhole (mainWindow,Blackhole.PosX,Blackhole.PosY,pivotScale));
						break;
					case "RIGHT":
						//	visibleTraps.Add (AddRIGHT_Spike (mainWindow,Spike.PosX,Spike.PosY,pivotScale));
						break;

					default:
						//	visibleTraps.Add (AddSTATIC_Spike (mainWindow,Spike.PosX,Spike.PosY,pivotScale));

						break;

					}

				}
				break;
			case "railgun":
				LevelRailGun LevelClass2 = new LevelRailGun ();
				List<LevelRailGun.Blackhole> ClassListRailGun = new List<LevelRailGun.Blackhole> ();
				ClassListRailGun = LevelClass2.BlackholeMaker ();
				//foreach
				foreach(var Blackhole in ClassListRailGun){
					Blackhole.PosX =Blackhole.PosX*bounds.Width;
					Blackhole.PosY = Blackhole.PosY*bounds.Height;

					switch(Blackhole.MoveType){
					case "STATIC":
						visibleBlackholes.Add (AddSTATIC_Blackhole (mainWindow,Blackhole.PosX,Blackhole.PosY,pivotScale));
						break;
					case "RIGHT":
						//	visibleTraps.Add (AddRIGHT_Spike (mainWindow,Spike.PosX,Spike.PosY,pivotScale));
						break;

					default:
						//	visibleTraps.Add (AddSTATIC_Spike (mainWindow,Spike.PosX,Spike.PosY,pivotScale));

						break;

					}

				}
				break;
			case "minefield":
				LevelMineField LevelClass3 = new LevelMineField ();
				List<LevelMineField.Blackhole> ClassListMineField = new List<LevelMineField.Blackhole> ();
				ClassListMineField = LevelClass3.BlackholeMaker ();
				//foreach
				foreach(var Blackhole in ClassListMineField){
					Blackhole.PosX =Blackhole.PosX*bounds.Width;
					Blackhole.PosY = Blackhole.PosY*bounds.Height;

					switch(Blackhole.MoveType){
					case "STATIC":
						visibleBlackholes.Add (AddSTATIC_Blackhole (mainWindow,Blackhole.PosX,Blackhole.PosY,pivotScale));
						break;
					case "RIGHT":
						//	visibleTraps.Add (AddRIGHT_Spike (mainWindow,Spike.PosX,Spike.PosY,pivotScale));
						break;

					default:
						//	visibleTraps.Add (AddSTATIC_Spike (mainWindow,Spike.PosX,Spike.PosY,pivotScale));

						break;

					}

				}
				break;


			case "blackhole":
				LevelBlackhole LevelClass4 = new LevelBlackhole();
				List<LevelBlackhole.Blackhole> ClassListBlackhole= new List<LevelBlackhole.Blackhole> ();
				ClassListBlackhole = LevelClass4.BlackholeMaker ();
				//foreach
				foreach(var Blackhole in ClassListBlackhole){
					Blackhole.PosX =Blackhole.PosX*bounds.Width;
					Blackhole.PosY = Blackhole.PosY*bounds.Height;

					switch(Blackhole.MoveType){
					case "STATIC":
						visibleBlackholes.Add (AddSTATIC_Blackhole (mainWindow,Blackhole.PosX,Blackhole.PosY,pivotScale));
						break;
					case "RIGHT":
						//	visibleTraps.Add (AddRIGHT_Spike (mainWindow,Spike.PosX,Spike.PosY,pivotScale));
						break;

					default:
						//	visibleTraps.Add (AddSTATIC_Spike (mainWindow,Spike.PosX,Spike.PosY,pivotScale));

						break;

					}

				}
				break;


			case "testgrounds":
				LevelTestGrounds LevelClass5 = new LevelTestGrounds ();
				List<LevelTestGrounds.Blackhole> ClassListTestGrounds = new List<LevelTestGrounds.Blackhole> ();
				ClassListTestGrounds = LevelClass5.BlackholeMaker ();
				//foreach
				foreach(var Blackhole in ClassListTestGrounds){
					Blackhole.PosX =Blackhole.PosX*bounds.Width;
					Blackhole.PosY = Blackhole.PosY*bounds.Height;

					switch(Blackhole.MoveType){
					case "STATIC":
						visibleBlackholes.Add (AddSTATIC_Blackhole (mainWindow,Blackhole.PosX,Blackhole.PosY,pivotScale));
						break;
					case "RIGHT":
						//	visibleTraps.Add (AddRIGHT_Spike (mainWindow,Spike.PosX,Spike.PosY,pivotScale));
						break;

					default:
						//	visibleTraps.Add (AddSTATIC_Spike (mainWindow,Spike.PosX,Spike.PosY,pivotScale));

						break;

					}

				}
				break;
			default:
				break;

			}



		}

		CCSprite Add_TutorialSteps (CCWindow mainWindow,float blackholePosX,float blackholePosY,string spriteNameStep)
		{   
			var bounds = mainWindow.WindowSizeInPixels;
			BlackholeSprite = new CCSprite (spriteNameStep);
			BlackholeSprite.Scale = 0.0006f*bounds.Width;;

			BlackholeSprite.PositionX = blackholePosX;
			BlackholeSprite.PositionY = blackholePosY;

			mainLayer.AddChild(BlackholeSprite);
			mainLayer.ReorderChild (BlackholeSprite, -97);



			return BlackholeSprite;
		}

		void addLevelTutorialSteps (CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;
			float pivotScale=0.001f*bounds.Width;
			switch (ThisLevelName) {
			case "tutorial":
				LevelTutorial LevelClass1 = new LevelTutorial ();
				List<LevelTutorial.TutorialSteps> ClassListTutorial = new List<LevelTutorial.TutorialSteps> ();
				ClassListTutorial = LevelClass1.TutorialStepsMaker ();
				//foreach
				foreach (var TutorialSteps in ClassListTutorial) {
					TutorialSteps.PosX = TutorialSteps.PosX * bounds.Width;
					TutorialSteps.PosY = TutorialSteps.PosY * bounds.Height;

				
					visibleTutorialSteps.Add(Add_TutorialSteps (mainWindow, TutorialSteps.PosX, TutorialSteps.PosY, TutorialSteps.MoveType));
					

				}
				break;
			
			}
					}

		

		// 
		void drawSweptAreaLine (byte R,byte G,byte B){
			var sweptAreaLine = new CCDrawNode ();


			float pivotScale=0.00025f*mainWindowAux.WindowSizeInPixels.Width;
			//float pivotScale = 0.6f* mainWindowAux.WindowSizeInPixels.Width / pivotSprite.BoundingBoxTransformedToParent.Size.Width;
			float ballScale=0.00047f*mainWindowAux.WindowSizeInPixels.Width;
			CCPoint ballTemp = new CCPoint();
			CCPoint pivotTemp = new CCPoint();
			ballTemp.X = ballSprite.BoundingBox.Center.X-visiblePivots [ballPhysicsSingle.indexHookPivot].BoundingBox.Center.X+ballSprite.BoundingBox.Size.Width*ballScale/2;
			ballTemp.Y = ballSprite.BoundingBox.Center.Y - visiblePivots [ballPhysicsSingle.indexHookPivot].BoundingBox.Center.Y + ballSprite.BoundingBox.Size.Height * ballScale / 2;
			pivotTemp.X = 0+visiblePivots [ballPhysicsSingle.indexHookPivot].BoundingBox.Size.Width*pivotScale/2;
			pivotTemp.Y = 0+visiblePivots [ballPhysicsSingle.indexHookPivot].BoundingBox.Size.Height*pivotScale/2				;
			var tempColor = new CCColor3B (R, G,B);
			var purpleColor = new CCColor4F (tempColor);

			sweptAreaLine.Scale = 1 / pivotScale;
			sweptAreaLine.DrawSegment( pivotTemp,ballTemp,1.0f, purpleColor);
			CCRemoveSelf removeLine = new CCRemoveSelf ();
			CCDelayTime waitLine = new CCDelayTime(0.80f);
			sweptAreaLine.RunActions (waitLine,removeLine);
			visiblePivots [ballPhysicsSingle.indexHookPivot].AddChild (sweptAreaLine);
			mainLayer.ReorderChild (sweptAreaLine, 100);
			mainLayer.ReorderChild (visiblePivots [ballPhysicsSingle.indexHookPivot], 99);

			if (ballPhysicsSingle.hookTouchBool == true) {
				//visiblePivots [ballPhysicsSingle.indexHookPivot].RemoveAllChildren(true);//sweptAreaLine
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

		void Explode2 (CCPoint pt)
		{
			var explosion = new CCParticleGalaxy (pt); //TODO: manage "better" for performance when "many" particles
			explosion.TotalParticles = 50;
			explosion.AutoRemoveOnFinish = true;
			mainLayer.AddChild (explosion);
			mainLayer.ReorderChild (explosion, 101);
		}





		#endregion

		#region CHECK COLLISION
		//Remove jewel and and Score Counter
		void checkJewel(){


			foreach (var ruby in visibleJewels) {
				bool hit = ruby.BoundingBoxTransformedToParent.IntersectsRect(ballSprite.BoundingBoxTransformedToParent);

				if (hit)
				{   BlueBallAnimation ();
					//animation for jewel
					CCScaleTo bounceScale = new CCScaleTo (0.2f, 0.0f);
					CCRemoveSelf removeRuby = new CCRemoveSelf ();
					ruby.RunActions (bounceScale,removeRuby);

					hitJewels.Add(ruby);
					CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/jewel2.wav");
					//Explode(banana.Position);
					//ruby.RemoveFromParent(true);
					visibleJewels.Remove (ruby);

					score += 10;
					DisplayScore (score);


					break;

				}
			}

			foreach (var diamond in visibleEmerald) {
				bool hit = diamond.BoundingBoxTransformedToParent.IntersectsRect(ballSprite.BoundingBoxTransformedToParent);
				if (hit)
				{
					hitJewels.Add(diamond);
					CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/jewelsound1.wav");
					LevelClearGame (mainWindowAux);



				    diamond.RemoveFromParent();
					ballSprite.RemoveFromParent ();



				}
			}

			hitJewels.Clear();


		}
		//SPIKE
		void checkSpike(){
			foreach (var spikeSprite in visibleTraps) {
				bool hit = spikeSprite.BoundingBoxTransformedToParent.IntersectsRect(ballSprite.BoundingBoxTransformedToParent);
				if (hit)
				{

					CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/explosion-02.wav");
					Explode(spikeSprite.Position);
					CCScaleTo bounceScale = new CCScaleTo (0.2f, 0.0008f*mainWindowAux.WindowSizeInPixels.Width);
				
					CCRemoveSelf removeSpike = new CCRemoveSelf ();
					spikeSprite.RunActions (bounceScale,removeSpike);


					//spikeSprite.RemoveFromParent(true);
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
		//WALL
		void checkWall(){
			foreach (var WallSprite in visibleWalls) {
				bool hit = WallSprite.BoundingBoxTransformedToParent.IntersectsRect(ballSprite.BoundingBoxTransformedToParent);
				if (hit)
				{
					CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/explosion1.wav");
					//Explode(WallSprite.Position);
					//animation for jewel
					CCScaleTo bounceScale = new CCScaleTo (0.2f, 0.0f);
					CCRemoveSelf removeWall = new CCRemoveSelf ();
					WallSprite.RunActions (bounceScale,removeWall);

					//WallSprite.RemoveFromParent(true);
					//WallSprite.Cleanup ();
					//WallSprite.Dispose ();


					//ANALYSE THE DIRECTION OF IMPACT

					float wX = ballSprite.BoundingBoxTransformedToParent.Center.X-WallSprite.BoundingBoxTransformedToParent.Center.X;
					float wY = ballSprite.BoundingBoxTransformedToParent.Center.Y-WallSprite.BoundingBoxTransformedToParent.Center.Y;				
					double Radial = Math.Pow ((double)wX, 2) + Math.Pow ((double)wY, 2);
					Radial = Math.Pow (Radial, 0.5);
					double SineAngle = wY / Radial;

					if (ballPhysicsSingle.hookTouchBool == true) {
						if (Math.Abs (SineAngle) <= 0.707106) {
							ballPhysicsSingle.ballXVelocity = -1.01f * ballPhysicsSingle.ballXVelocity;
							ballPhysicsSingle.ballYVelocity = 1.01f * ballPhysicsSingle.ballYVelocity;
						} else if (Math.Abs (SineAngle) > 0.706) {
							ballPhysicsSingle.ballYVelocity = -1.01f * ballPhysicsSingle.ballYVelocity;
							ballPhysicsSingle.ballXVelocity = 1.01f * ballPhysicsSingle.ballXVelocity;
						}
					} else {
						ballPhysicsSingle.ClockwiseRotation = !ballPhysicsSingle.ClockwiseRotation;
					
					}

					visibleWalls.Remove (WallSprite);

					//ShouldEndGame ();
				break;
				}
			}


		}

		//BLACKHOLE
		void checkBlackhole(){
			float RvecX, RvecY;
			double Radius;
			float alphaFactor= 25000*mainWindowAux.WindowSizeInPixels.Width;

			foreach (var BlackholeSprite in visibleBlackholes) {
				//change gravity
				RvecX = ballSprite.BoundingBoxTransformedToParent.Center.X - BlackholeSprite.BoundingBoxTransformedToParent.Center.X;
				RvecY = ballSprite.BoundingBoxTransformedToParent.Center.Y- BlackholeSprite.BoundingBoxTransformedToParent.Center.Y;
				Radius = Math.Pow (RvecX, 2.0f) + Math.Pow (RvecY, 2.0f);
				Radius = Math.Pow (Radius, 0.5f);
				Radius = Math.Pow (Radius, 3f);

				ballPhysicsSingle.gravityX =-alphaFactor * RvecX / Radius ;
				ballPhysicsSingle.gravityY =-alphaFactor * RvecY / Radius ;
				//
				bool hit = BlackholeSprite.BoundingBoxTransformedToParent.Center.IsNear(ballSprite.BoundingBoxTransformedToParent.Center,20.0f);
				if (hit)
				{
						EndGame();
					}

				hit = BlackholeSprite.BoundingBoxTransformedToParent.Center.IsNear(ballSprite.BoundingBoxTransformedToParent.Center,0.2f*mainWindowAux.WindowSizeInPixels.Width);
				if (hit)
				{
					CCRotateBy rotate = new CCRotateBy (2.0f, -2*360f);
					BlackholeSprite.RunAction(rotate);
				}



				//OUT OF BOUNDS DELETE
				if (BlackholeSprite.PositionY < -mainWindowAux.WindowSizeInPixels.Height / 4) {
					BlackholeSprite.RemoveFromParent(true);
					visibleBlackholes.Remove (BlackholeSprite);
				
				}

					//ShouldEndGame ();
					break;
				}
			}

		void BlueBallAnimation (){
			CCScaleTo bounceScale = new CCScaleTo (0.1f, 0.0004f*mainWindowAux.WindowSizeInPixels.Width);
			CCDelayTime wait = new CCDelayTime (0.1f);
			CCScaleTo bounceReduce = new CCScaleTo (0.1f, 0.0003f*mainWindowAux.WindowSizeInPixels.Width);
			ballSprite.RunActions (bounceScale,wait,bounceReduce);
					}

		#endregion

		#region LEVEL  HANDLERS
		void ShouldEndGame (){
			if (score <= -100) {
				//EndGame ();
			}
		}


			// End game when reaching Diamond Goal and display Stars and final Score
		void LevelClearGame (CCWindow mainWindow){
			CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/bomb02");
			Explode2(diamond.Position);
			Explode (ballSprite.Position);


			score += 100;
			DisplayScore (score);
			addLevelStars (mainWindowAux,score);

			// add Resume, Restart and MainMenu button. A frame, (1 2 3)Stars display Score 
			PauseGame = false;
			var bounds = mainWindowAux.WindowSizeInPixels;
			CCMoveBy SlideIn = new CCMoveBy (0f, new CCPoint (0.0f, 0.4f * bounds.Height));

			//ResumeGame.RunAction (SlideIn);
			Restart.RunAction (SlideIn);
			MainMenu.RunAction (SlideIn);
			menuframe.RunAction (SlideIn);

			CCSimpleAudioEngine.SharedEngine.PauseBackgroundMusic ();
				

		}

		void addLevelStars(CCWindow mainWindow,int score){

				var bounds = mainWindow.WindowSizeInPixels;
				float jewelScale=0.0003f*bounds.Width;
							
			//1 STAR
			if (score >= 20) {
				StarList.Add (addStar (mainWindow, 0.3f * bounds.Width, 0.4f * bounds.Height, jewelScale,"onestar"));
				Explode2 (new CCPoint(0.3f * bounds.Width, 0.4f * bounds.Height));
			}
			//2 STAR
			if (score >= 90) {
				StarList.Add (addStar (mainWindow, 0.5f * bounds.Width, 0.42f * bounds.Height, jewelScale, "twostar"));
				Explode2 (new CCPoint(0.5f * bounds.Width, 0.42f * bounds.Height));
			}
			//3 STAR
			if (score >= 130) {
				StarList.Add (addStar (mainWindow, 0.7f * bounds.Width, 0.4f * bounds.Height, jewelScale, "thirdstar"));
				Explode2 (new CCPoint(0.7f * bounds.Width, 0.4f * bounds.Height));
			}



		}
			
		

		void EndGame(){
			OnePlayerScrollerScene gameScene = new OnePlayerScrollerScene (mainWindowAux,ThisLevelName);
			mainWindowAux.RunWithScene (gameScene);

		}

		void DisplayScore(float score ){

			pointsLabel.Text = ""+score;
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
			CCScaleBy ZoomTouch = new CCScaleBy(0.01f,0.18f* mainWindowAux.WindowSizeInPixels.Width/ResumeGame.BoundingBoxTransformedToWorld.Size.Width);

			ResumeGame.RunAction(ZoomTouch); 
			ResumeGame.PositionX = 0.5f*bounds.Width;
			ResumeGame.PositionY = -0.2f*bounds.Height;
			mainLayer.AddChild (ResumeGame);

			Restart = new CCSprite ("RestartButton");
			Restart.RunAction(ZoomTouch); 
			Restart.PositionX = 0.75f*bounds.Width;
			Restart.PositionY = -0.2f*bounds.Height;
			mainLayer.AddChild (Restart);

			MainMenu = new CCSprite ("MainMenuButton");
			MainMenu.RunAction(ZoomTouch); 
			MainMenu.PositionX = 0.25f*bounds.Width;
			MainMenu.PositionY = -0.2f*bounds.Height;
			mainLayer.AddChild (MainMenu);


			menuframe = new CCSprite ("layerbackground");
			ZoomTouch = new CCScaleBy(0.01f,0.95f* mainWindowAux.WindowSizeInPixels.Width/menuframe.BoundingBoxTransformedToWorld.Size.Width);
			menuframe.RunAction(ZoomTouch);  
			menuframe.PositionX = 0.5f*bounds.Width;
			menuframe.PositionY = -0.4f*bounds.Height;
			mainLayer.AddChild (menuframe);

			mainLayer.ReorderChild (ResumeGame, 120);
			mainLayer.ReorderChild (Restart, 120);
			mainLayer.ReorderChild (MainMenu, 120);
			mainLayer.ReorderChild (menuframe, 119);
		
		}
		#endregion

	}

}



