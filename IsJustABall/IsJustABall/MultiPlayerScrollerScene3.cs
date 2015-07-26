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
		CCLabel Bluepoints;
		CCLabel Redpoints;
		CCLabel Greenpoints;
		CCLabel Yellowpoints;

		List<CCSprite> PlayerButtonList;



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
		float GameTime =0;
		//Movementson Pivots
		int playerCount;


		CCEventListenerTouchAllAtOnce touchListener;
		#endregion
		public MultiPlayerScrollerScene(CCWindow mainWindow,string LevelName,int playerCounter) : base(mainWindow)
		{   var bounds = mainWindow.WindowSizeInPixels;
			minRotationRadius = 0.25f*bounds.Width;
			CCSimpleAudioEngine.SharedEngine.PreloadBackgroundMusic ("Sounds/backgroundmusic1");
			CCSimpleAudioEngine.SharedEngine.PlayBackgroundMusic("Sounds/backgroundmusic1");
			playerCount = playerCounter;
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
			ballPhysicsList = new List<ballPhysics> ();
			PlayerButtonList = new List<CCSprite> ();
			hitJewels = new List<CCSprite> ();
			visibleTraps = new List<CCSprite>();
			StarList = new List<CCSprite> ();
			ballPhysicsList = new List<ballPhysics> ();


			scrollerSpeed = (int)(0.1 * bounds.Width);
			topSpeed = (int)(0.9 * bounds.Width);



			addLevelPivots (mainWindow);
			addLevelJewels (mainWindow);
			addLevelSpikes (mainWindow);

			addLevelWalls (mainWindow);
			addLevelBlackholes (mainWindow);


			addFourBalls addBallsClass = new addFourBalls ();
			addBallsClass.addGameBall(playerCount, mainWindowAux, ballPhysicsList );
			foreach (var ballPhysicsSingle in ballPhysicsList) {
				mainLayer.AddChild (ballPhysicsSingle.ballSprite);

			}

			addPlayerButton (playerCount);

			addBackground (mainWindow);
			addPauseButton ();
			addMenuOptions ();
					//scoreLabel = new CCLabel ("Score: 0", "arial", 78);
			scoreLabel = new CCLabel("Score:","nasalizationbold.ttf",78);
			scoreLabel.PositionX = 0 ;
			scoreLabel.PositionY = mainLayer.VisibleBoundsWorldspace.MaxY - 20;
			scoreLabel.AnchorPoint = CCPoint.AnchorUpperLeft;

			Bluepoints = new CCLabel("0000","nasalizationbold.ttf",78);
			Bluepoints.PositionX = mainLayer.VisibleBoundsWorldspace.MaxX/3 ;
			Bluepoints.PositionY = 0;
			Bluepoints.AnchorPoint = CCPoint.AnchorMiddleBottom;
			CCColor3B fontColor = new CCColor3B(72,118,255) ;
			Bluepoints.UpdateDisplayedColor (fontColor);

			Redpoints = new CCLabel("","nasalizationbold.ttf",78);
			Redpoints.RunAction ( new CCRotateBy (0.0f, 180.0f));
			Redpoints.PositionX =2.0f* mainLayer.VisibleBoundsWorldspace.MaxX / 3;
			Redpoints.PositionY = mainLayer.VisibleBoundsWorldspace.MaxY;
			Redpoints.AnchorPoint = CCPoint.AnchorMiddleBottom;
			fontColor = new CCColor3B(255,48,48) ;
			Redpoints.UpdateDisplayedColor (fontColor);

			Greenpoints = new CCLabel("","nasalizationbold.ttf",78);
			Greenpoints.RunAction ( new CCRotateBy (0.0f, 270.0f));
			Greenpoints.PositionX = mainLayer.VisibleBoundsWorldspace.MaxX -30;
			Greenpoints.PositionY = mainLayer.VisibleBoundsWorldspace.MaxY*0.20f;
			Greenpoints.AnchorPoint = CCPoint.AnchorMiddleRight;
			fontColor = new CCColor3B(0,238,118) ;
			Greenpoints.UpdateDisplayedColor (fontColor);

			Yellowpoints = new CCLabel("","nasalizationbold.ttf",78);
			Yellowpoints.RunAction ( new CCRotateBy (0.0f, 90.0f));
			Yellowpoints.PositionX =30;
			Yellowpoints.PositionY = mainLayer.VisibleBoundsWorldspace.MaxY-mainLayer.VisibleBoundsWorldspace.MaxY*0.150f;
			Yellowpoints.AnchorPoint = CCPoint.AnchorMiddleLeft;
			fontColor = new CCColor3B(255,215,0) ;
			Yellowpoints.UpdateDisplayedColor (fontColor);

		

		//	mainLayer.AddChild (scoreLabel);
		//	mainLayer.ReorderChild (scoreLabel, 200);
			mainLayer.AddChild (Bluepoints);
			mainLayer.AddChild(Redpoints);
			mainLayer.AddChild(Greenpoints);
			mainLayer.AddChild(Yellowpoints);
			mainLayer.ReorderChild(Bluepoints,200);
			mainLayer.ReorderChild(Redpoints,200);
			mainLayer.ReorderChild(Greenpoints,200);
			mainLayer.ReorderChild(Yellowpoints,200);


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
			GameTime += frameTimeInSeconds;
			//pointsLabel.Text = "" + (int)GameTime;
			foreach (var ballSinglePhysics in ballPhysicsList) {  
				if (PauseGame) {
					if (ballSinglePhysics.hookTouchBool == true) {//Void free Particle
						freeParticle (frameTimeInSeconds);
					} else {
						//void HookedParticle
						hookedParticle (frameTimeInSeconds);
					}
		
				}
		
				checkJewel (ballSinglePhysics);
				//checkSpike ();
				//checkWall ();
				//checkBlackhole ();
					
			}
				mainLayer.ReorderChild (scoreLabel, 101);
			
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
				MultiPlayerScrollerScene gameScene1 = new MultiPlayerScrollerScene (mainWindowAux,ThisLevelName,playerCount);
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

			}
					

			location = new CCPoint(locationInverted.X,bounds.Height - locationInverted.Y);

			CCPoint touchPoint = new CCPoint (0.0f*bounds.Width, 0.0f*bounds.Height);
			// 1 FIRST PLAYER
			hit =  location.IsNear(touchPoint, 0.4f*bounds.Width) ;
			if (hit)
			{
				CalculateHookPhysics (1);

			}
			// 2 SECOND PLAYER
			touchPoint.X = bounds.Width;
			hit =  location.IsNear(touchPoint, 0.4f*bounds.Width) ;
			if (hit)
			{
				CalculateHookPhysics (3);

			}
			// 3 THIRD PLAYER
			touchPoint.X = 0.0f;touchPoint.Y = bounds.Height;
			hit =  location.IsNear(touchPoint, 0.4f*bounds.Width) ;
			if (hit)
			{
				CalculateHookPhysics (4);

			}
			// 4 FOURTH PLAYER
			touchPoint.X =bounds.Width;touchPoint.Y = bounds.Height;
			hit =  location.IsNear(touchPoint, 0.4f*bounds.Width) ;
			if (hit)
			{
				CalculateHookPhysics (2);

			}

		}

		#endregion
		#region FREE & HOOKED PARTICLE
		void freeParticle(float frameTimeInSeconds){
			
			foreach (var ballPhysicsSingle in ballPhysicsList){
				if (ballPhysicsSingle.hookTouchBool == true) {
					// This is a linear approximation, so not 100% accurate
					//ballPhysicsSingle.ballXVelocity += frameTimeInSeconds * gravity;
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
			//gravity = 0;
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
			//drawSweptAreaLine(ballPhysicsSingle);
		}
		//////
		/// 
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

		#region OBJECTS AND SPRITES

		void addPlayerButton(int playerCount){
			var bounds = mainWindowAux.WindowSizeInPixels;
			float scale = 0.002f * bounds.Width;
			CCSprite buttonSprite = new CCSprite ();
			for (int i = 1; i <= playerCount; i++) {
				switch (i) {
				case 1:
					buttonSprite = new CCSprite ("blueballButton");
					buttonSprite.PositionX = 0.0f * bounds.Width;
					buttonSprite.PositionY = 0.0f * bounds.Height;
					buttonSprite.Scale = scale;
					mainLayer.AddChild (buttonSprite);
					break;
				case 2:
					buttonSprite = new CCSprite ("redballButton");
					buttonSprite.PositionX = 1.0f * bounds.Width;
					buttonSprite.PositionY = 1.0f * bounds.Height;
					buttonSprite.Scale = scale;
					mainLayer.AddChild (buttonSprite);
					break;
				case 3:
					buttonSprite = new CCSprite ("greenballButton");
					buttonSprite.PositionX = 1.0f * bounds.Width;
					buttonSprite.PositionY = 0.0f * bounds.Height;
					buttonSprite.Scale = scale;
					mainLayer.AddChild (buttonSprite);
					break;
				case 4:
					buttonSprite = new CCSprite ("yellowballButton");
					buttonSprite.PositionX = 0.0f * bounds.Width;
					buttonSprite.PositionY = 1.0f * bounds.Height;
					buttonSprite.Scale = scale;
					mainLayer.AddChild (buttonSprite);
					break;
				default:
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
			mainLayer.AddChild (diamond);
			return diamond;
		}

		CCSprite addRuby(CCWindow mainWindow,float rubyPosX,float rubyPosY,float scale){
			var bounds = mainWindow.WindowSizeInPixels;

			ruby = new CCSprite ("ruby");
			ruby.Scale = scale;
			ruby.PositionX = rubyPosX;
			ruby.PositionY = rubyPosY;
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
			case "multi4level1":
				background1 = new CCSprite ("triangles3background");
				CCScaleBy SpriteSize = new CCScaleBy (0.0f, 1.0f * bounds.Width / background1.BoundingBoxTransformedToWorld.Size.Width);
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
			default:
				break;

			}
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
			mainLayer.ReorderChild (pivotSprite, 109);

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
			mainLayer.ReorderChild (pivotSprite, 109);
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
			mainLayer.ReorderChild (pivotSprite, 109);
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
			mainLayer.ReorderChild (pivotSprite, 109);
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

			switch (ThisLevelName) {
			case "multi4level1":
				Multi4Level1 LevelClass1 = new Multi4Level1 ();
				List<Multi4Level1.Pivot> ClassListMulti4Level1 = new List<Multi4Level1.Pivot> ();
				ClassListMulti4Level1 = LevelClass1.PivotMaker ();
				foreach (var Pivot in ClassListMulti4Level1) {
					Pivot.PosX = Pivot.PosX * bounds.Width;
					Pivot.PosY = Pivot.PosY * bounds.Height;

					switch (Pivot.MoveType) {
					case "STATIC":
						visiblePivots.Add (AddSTATIC_Pivots (mainWindow, Pivot.PosX, Pivot.PosY, pivotScale));
						break;
					case "UP":
						visiblePivots.Add (AddUP_Pivots (mainWindow, Pivot.PosX, Pivot.PosY, pivotScale));
						break;
					case "DOWN":
						visiblePivots.Add (AddDOWN_Pivots (mainWindow, Pivot.PosX, Pivot.PosY, pivotScale));
						break;
					case "RIGHT":
						visiblePivots.Add (AddRIGHT_Pivots (mainWindow, Pivot.PosX, Pivot.PosY, pivotScale));
						break;
					case "LEFT":
						visiblePivots.Add (AddLEFT_Pivots (mainWindow, Pivot.PosX, Pivot.PosY, pivotScale));
						break;
					default:
						visiblePivots.Add (AddSTATIC_Pivots (mainWindow, Pivot.PosX, Pivot.PosY, pivotScale));
						break;
					}
				}
				break;
			//case :"multi4level2":
			//break;
			default:
				break;

			}//switch itemlevel end

		}//addLevelPivots end

		//JEWELS

		void addLevelJewels (CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;
			float jewelScale=0.0004f*bounds.Width;

			switch(ThisLevelName){
			case "multi4level1":
				Multi4Level1 LevelClass1 = new Multi4Level1 ();
				List<Multi4Level1.Jewel> ClassListMulti4Level1 = new List<Multi4Level1.Jewel> ();
				ClassListMulti4Level1 = LevelClass1.JewelMaker ();
				foreach(var Jewel in ClassListMulti4Level1){
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
			case "multi4level1":
				Multi4Level1 LevelClass1 = new Multi4Level1 ();
				List<Multi4Level1.Spike> ClassListMulti4Level1 = new List<Multi4Level1.Spike> ();
				ClassListMulti4Level1 = LevelClass1.SpikeMaker ();
				//foreach
				foreach(var Spike in ClassListMulti4Level1){
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
			case "multi4level1":
				Multi4Level1 LevelClass1 = new Multi4Level1 ();
				List<Multi4Level1.Wall> ClassListMulti4Level1 = new List<Multi4Level1.Wall> ();
				ClassListMulti4Level1 = LevelClass1.WallMaker ();
				//foreach
				foreach(var Wall in ClassListMulti4Level1){
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
			case "multi4level1":
				Multi4Level1 LevelClass1 = new Multi4Level1 ();
				List<Multi4Level1.Blackhole> ClassListMulti4Level1 = new List<Multi4Level1.Blackhole> ();
				ClassListMulti4Level1 = LevelClass1.BlackholeMaker ();
				//foreach
				foreach(var Blackhole in ClassListMulti4Level1){
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



		// 
		void drawSweptAreaLine (ballPhysics ballSinglePhysics){
			var sweptAreaLine = new CCDrawNode ();

			float pivotScale=0.0002f*mainWindowAux.WindowSizeInPixels.Width;
			float ballScale=0.00047f*mainWindowAux.WindowSizeInPixels.Width;
			CCPoint ballTemp = new CCPoint();
			CCPoint pivotTemp = new CCPoint();
			ballTemp.X = ballSinglePhysics.ballSprite.BoundingBox.Center.X-visiblePivots [ballSinglePhysics.indexHookPivot].BoundingBox.Center.X+ballSinglePhysics.ballSprite.BoundingBox.Size.Width*ballScale/2;
			ballTemp.Y = ballSinglePhysics.ballSprite.BoundingBox.Center.Y - visiblePivots [ballSinglePhysics.indexHookPivot].BoundingBox.Center.Y + ballSinglePhysics.ballSprite.BoundingBox.Size.Height * ballScale / 2;
			pivotTemp.X = 0+visiblePivots [ballSinglePhysics.indexHookPivot].BoundingBox.Size.Width*pivotScale/2;
			pivotTemp.Y = 0+visiblePivots [ballSinglePhysics.indexHookPivot].BoundingBox.Size.Height*pivotScale/2				;
			var tempColor = new CCColor3B (0,0,0);

			switch(ballSinglePhysics.index){
			case 1:
				tempColor = new CCColor3B (72,118,255);
				break;
			case 2:
				tempColor = new CCColor3B (255,48,48);
				break;
			case 3:
				tempColor = new CCColor3B (0,238,118	);
				break;
			case 4:
				tempColor = new CCColor3B (255,215,0);
				break;
			}

			var purpleColor = new CCColor4F (tempColor);

			sweptAreaLine.Scale = 1 / pivotScale;
			sweptAreaLine.DrawSegment( pivotTemp,ballTemp,1.0f, purpleColor);
			CCRemoveSelf removeLine = new CCRemoveSelf ();
			CCDelayTime waitLine = new CCDelayTime(0.80f);
			sweptAreaLine.RunActions (waitLine,removeLine);
			visiblePivots [ballSinglePhysics.indexHookPivot].AddChild (sweptAreaLine);
			mainLayer.ReorderChild (sweptAreaLine, -100);

			if (ballSinglePhysics.hookTouchBool == true) {
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
		void checkJewel(ballPhysics ballSinglePhysics){
			foreach (var ruby in visibleJewels) {
				bool hit = ruby.BoundingBoxTransformedToParent.IntersectsRect (ballSinglePhysics.ballSprite.BoundingBoxTransformedToParent);
					if (hit) {
						hitJewels.Add (ruby);
						//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
						//Explode(banana.Position);
						ruby.RemoveFromParent (true);
						visibleJewels.Remove (ruby);
					ballSinglePhysics.Score += 10;
					DisplayScore (ballSinglePhysics.index,ballSinglePhysics.Score);
						break;

				
				}
			}

		}
		//SPIKE
		void checkSpike(){
			foreach (var spikeSprite in visibleTraps) {
				foreach (var ballPhysicsSingle in ballPhysicsList) {
					bool hit = spikeSprite.BoundingBoxTransformedToParent.IntersectsRect (ballSprite.BoundingBoxTransformedToParent);
					if (hit) {

						CCSimpleAudioEngine.SharedEngine.PlayEffect ("Sounds/explosion-02.wav");
						Explode (spikeSprite.Position);
						CCScaleTo bounceScale = new CCScaleTo (0.2f, 0.0008f * mainWindowAux.WindowSizeInPixels.Width);
				
						CCRemoveSelf removeSpike = new CCRemoveSelf ();
						spikeSprite.RunActions (bounceScale, removeSpike);


						//spikeSprite.RemoveFromParent(true);
						visibleTraps.Remove (spikeSprite);


						//hitJewels.Add(ruby);
						//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
						//Explode(banana.Position);
						//ruby.RemoveFromParent();
						score -= 50;
						//DisplayScore (score);

						ShouldEndGame ();
						break;
					}
				}

			}

		}
		//WALL
		void checkWall(){
			foreach (var WallSprite in visibleWalls) {
				foreach (var ballPhysicsSingle in ballPhysicsList) {
					bool hit = WallSprite.BoundingBoxTransformedToParent.IntersectsRect (ballSprite.BoundingBoxTransformedToParent);
					if (hit) {
						CCSimpleAudioEngine.SharedEngine.PlayEffect ("Sounds/explosion1.wav");
						//Explode(WallSprite.Position);
						//animation for jewel
						CCScaleTo bounceScale = new CCScaleTo (0.2f, 0.0f);
						CCRemoveSelf removeWall = new CCRemoveSelf ();
						WallSprite.RunActions (bounceScale, removeWall);

						//WallSprite.RemoveFromParent(true);
						//WallSprite.Cleanup ();
						//WallSprite.Dispose ();


						//ANALYSE THE DIRECTION OF IMPACT

						float wX = ballSprite.BoundingBoxTransformedToParent.Center.X - WallSprite.BoundingBoxTransformedToParent.Center.X;
						float wY = ballSprite.BoundingBoxTransformedToParent.Center.Y - WallSprite.BoundingBoxTransformedToParent.Center.Y;				
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
						}

						visibleWalls.Remove (WallSprite);

						//ShouldEndGame ();
						break;
					}
				}
			}

		}

		//BLACKHOLE
		void checkBlackhole(){
			float RvecX, RvecY;
			double Radius;
			float alphaFactor = 25000 * mainWindowAux.WindowSizeInPixels.Width;

			foreach (var BlackholeSprite in visibleBlackholes) {
						foreach (var ballPhysicsSingle in ballPhysicsList) {						
				//change gravity
				RvecX = ballSprite.BoundingBoxTransformedToParent.Center.X - BlackholeSprite.BoundingBoxTransformedToParent.Center.X;
				RvecY = ballSprite.BoundingBoxTransformedToParent.Center.Y - BlackholeSprite.BoundingBoxTransformedToParent.Center.Y;
				Radius = Math.Pow (RvecX, 2.0f) + Math.Pow (RvecY, 2.0f);
				Radius = Math.Pow (Radius, 0.5f);
				Radius = Math.Pow (Radius, 3f);

				ballPhysicsSingle.gravityX = -alphaFactor * RvecX / Radius;
				ballPhysicsSingle.gravityY = -alphaFactor * RvecY / Radius;
				//
				bool hit = BlackholeSprite.BoundingBoxTransformedToParent.Center.IsNear (ballSprite.BoundingBoxTransformedToParent.Center, 20.0f);
				if (hit) {
					EndGame ();
				}

				hit = BlackholeSprite.BoundingBoxTransformedToParent.Center.IsNear (ballSprite.BoundingBoxTransformedToParent.Center, 0.2f * mainWindowAux.WindowSizeInPixels.Width);
				if (hit) {
					CCRotateBy rotate = new CCRotateBy (2.0f, -2 * 360f);
					BlackholeSprite.RunAction (rotate);
				}



				//OUT OF BOUNDS DELETE
				if (BlackholeSprite.PositionY < -mainWindowAux.WindowSizeInPixels.Height / 4) {
					BlackholeSprite.RemoveFromParent (true);
					visibleBlackholes.Remove (BlackholeSprite);
				
				}

				//ShouldEndGame ();
				break;
			}
		}
			}

		void BlueBallAnimation (){
			CCScaleTo bounceScale = new CCScaleTo (0.1f, 0.0004f*mainWindowAux.WindowSizeInPixels.Width);
			CCDelayTime wait = new CCDelayTime (0.1f);
			CCScaleTo bounceReduce = new CCScaleTo (0.1f, 0.0003f*mainWindowAux.WindowSizeInPixels.Width);
			ballPhysicsSingle.ballSprite.RunActions (bounceScale,wait,bounceReduce);
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
			//DisplayScore (score);
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

		void DisplayScore(int index,int plus){
			
			switch (index) {
			case 1:
				Bluepoints.Text = "" + plus;
				break;
			case 2:
				Redpoints.Text = "" + plus;
				break;
			case 3:
				Greenpoints.Text = "" + plus;
				break;
			case 4:
				Yellowpoints.Text = "" + plus;
				break;
			default:
				break;

			}

		}


		void addPauseButton(){
			var bounds = mainWindowAux.WindowSizeInPixels;

			float scale =0.0012f*bounds.Width;

			PauseButton = new CCSprite ("PauseButton");
			PauseButton.Scale = scale; 
			PauseButton.PositionX = bounds.Width-60;
			PauseButton.PositionY = bounds.Height/2;
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



