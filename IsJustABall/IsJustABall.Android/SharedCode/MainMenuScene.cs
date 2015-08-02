
using System;
using System.Collections.Generic;
using CocosSharp;



namespace IsJustABall.Android
{	
	public class MainMenuScene : CCScene 
	{// Declare VAriables
		CCSprite ballSprite;
		CCSprite MultiOption;
		CCSprite title;
		CCSprite background;


		CCLayer mainLayer;
		CCWindow mainWindowAux;
		CCEventListenerTouchAllAtOnce touchListener;


		public MainMenuScene(CCWindow mainWindow) : base(mainWindow)
			{
			//Initialize SQL Database

			 
			    mainLayer = new CCLayer ();
			    AddChild (mainLayer);
			mainWindowAux = mainWindow;

				var bounds = mainWindow.WindowSizeInPixels;
			addGameTitle (mainWindow);
			addSinglePlayerOption(mainWindow);
			addMultiPlayerOption (mainWindow);
			    addBackground (mainWindow);
				Schedule (RunMenuLogic);


				// New code:
		    	
				touchListener = new CCEventListenerTouchAllAtOnce ();
				touchListener.OnTouchesEnded = HandleTouchesEnded; 
		        touchListener.OnTouchesBegan = HandleTouchesBegan; 
				AddEventListener (touchListener, this);

			}

			void RunMenuLogic(float frameTimeInSeconds)
			{
				
			}



		void HandleTouchesBegan (System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent)
			{
			var bounds = mainWindowAux.WindowSizeInPixels;
			var locationInverted = touches [0].LocationOnScreen;
			CCPoint location = new CCPoint(locationInverted.X,bounds.Height - locationInverted.Y);
			CCScaleBy ZoomTouch = new CCScaleBy(0.01f,0.90f*bounds.Width/ballSprite.BoundingBoxTransformedToWorld.Size.Width);
		//	bool hit =  location.IsNear(ballSprite.Position, 100.0f) ;
			bool hit = ballSprite.BoundingBoxTransformedToParent.ContainsPoint (location);
			if (hit)
			{
				//ballSprite.ScaleTo (new CCSize (1.1f*ballSprite.ScaledContentSize.Width,1.1f*ballSprite.ScaledContentSize.Height));
				//CCScaleTo ZoomTouch = new CCScaleTo(0.01f,1.05f);

				ballSprite.RunAction (ZoomTouch);
			}

			hit = MultiOption.BoundingBoxTransformedToParent.ContainsPoint (location);

			if (hit) {
				//MultiOption.ScaleTo (new CCSize (1.1f*MultiOption.ScaledContentSize.Width,1.1f*MultiOption.ScaledContentSize.Height));

				MultiOption.RunAction (ZoomTouch);
			}








			}
		    void HandleTouchesEnded(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){
			var bounds = mainWindowAux.WindowSizeInPixels;
			var locationInverted = touches [0].LocationOnScreen;
			CCPoint location = new CCPoint(locationInverted.X,bounds.Height - locationInverted.Y);

			CCScaleTo ZoomTouch = new CCScaleTo(0.01f,0.80f*bounds.Width/ballSprite.BoundingBox.Size.Width);
			ballSprite.RunAction (ZoomTouch);
			ZoomTouch = new CCScaleTo(0.01f,0.80f*bounds.Width/MultiOption.BoundingBox.Size.Width);
			MultiOption.RunAction (ZoomTouch);


			bool hit = ballSprite.BoundingBoxTransformedToParent.ContainsPoint (location);

			if (hit)
			{
				//ballSprite.ScaleTo (new CCSize (ballSprite.ScaledContentSize.Width/1.1f,ballSprite.ScaledContentSize.Height/1.1f));
				LevelPickerSceneSinglePlayer gameScene = new LevelPickerSceneSinglePlayer (mainWindowAux);
				mainWindowAux.RunWithScene (gameScene);

			}

			hit = MultiOption.BoundingBoxTransformedToParent.ContainsPoint (location);
			if (hit) {
				//MultiOption.ScaleTo (new CCSize (MultiOption.ScaledContentSize.Width/1.1f,MultiOption.ScaledContentSize.Height/1.1f));
				PlayerCountPickerScene gameScene = new PlayerCountPickerScene (mainWindowAux);
				mainWindowAux.RunWithScene (gameScene);
			}

		
			//BUG: calling walkRepeat separately as it doesn't run when called in RunActions or CCSpawn
		

			}

					/// OBJECTS AND SPRITES
		void addGameTitle(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;
			title = new CCSprite ("Labels/menutitle");
			title.Scale = 0.0009f*bounds.Width;
			title.PositionX = 0.5f*bounds.Width;
			title.PositionY = 0.85f*bounds.Height;

			//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
			mainLayer.AddChild (title);

		}
			void addSinglePlayerOption(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			ballSprite = new CCSprite ("button/singleplayermenubutton");
			CCScaleTo ZoomTouch = new CCScaleTo(0.01f,0.80f*bounds.Width/ballSprite.BoundingBox.Size.Width);
			ballSprite.RunAction (ZoomTouch);
				ballSprite.PositionX = 0.5f*bounds.Width;
				ballSprite.PositionY = 0.5f*bounds.Height;

				//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
				mainLayer.AddChild (ballSprite);

			}

		void addMultiPlayerOption(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			MultiOption = new CCSprite ("button/fourplayermenubutton");
			CCScaleTo ZoomTouch = new CCScaleTo(0.01f,0.80f*bounds.Width/MultiOption.BoundingBox.Size.Width);
			MultiOption.RunAction (ZoomTouch);

			MultiOption.PositionX = 0.5f*bounds.Width;
			MultiOption.PositionY = 0.3f*bounds.Height;

			//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
			mainLayer.AddChild (MultiOption);

		}

		void addBackground(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			background = new CCSprite ("background/galaxybackground4");

			background.Scale = 1.8f;
			background.PositionX = bounds.Width/2;
			background.PositionY = background.ContentSize.Height-500.0f;

			mainLayer.AddChild (background);
			mainLayer.ReorderChild (background, -100);

		}
			


			//ENDGAME
			void EndGame (){

				UnscheduleAll();
				


			}
			//







		}

				}
			









			////////










		
	

