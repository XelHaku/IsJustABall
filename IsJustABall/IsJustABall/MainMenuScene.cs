
using System;
using System.Collections.Generic;
using CocosSharp;
namespace IsJustABall
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

			bool hit =  location.IsNear(ballSprite.Position, 100.0f) ;
			if (hit)
			{
				ballSprite.ScaleTo (new CCSize (1.1f*ballSprite.ScaledContentSize.Width,1.1f*ballSprite.ScaledContentSize.Height));
			}

			hit =  location.IsNear(MultiOption.Position, 100.0f) ;
			if (hit) {
				MultiOption.ScaleTo (new CCSize (1.1f*MultiOption.ScaledContentSize.Width,1.1f*MultiOption.ScaledContentSize.Height));
			}








			}
		    void HandleTouchesEnded(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){
			var bounds = mainWindowAux.WindowSizeInPixels;
			var locationInverted = touches [0].LocationOnScreen;
			CCPoint location = new CCPoint(locationInverted.X,bounds.Height - locationInverted.Y);
		

			bool hit =  location.IsNear(ballSprite.Position, 100.0f) ;
			if (hit)
			{
				ballSprite.ScaleTo (new CCSize (ballSprite.ScaledContentSize.Width/1.1f,ballSprite.ScaledContentSize.Height/1.1f));
				OnePlayerScrollerScene gameScene = new OnePlayerScrollerScene (mainWindowAux);
				mainWindowAux.RunWithScene (gameScene);

			}

			hit =  location.IsNear(MultiOption.Position, 100.0f) ;
			if (hit) {
				MultiOption.ScaleTo (new CCSize (MultiOption.ScaledContentSize.Width/1.1f,MultiOption.ScaledContentSize.Height/1.1f));
				MultiPlayerScrollerScene gameScene = new MultiPlayerScrollerScene (mainWindowAux);
				mainWindowAux.RunWithScene (gameScene);
			}

		
			//BUG: calling walkRepeat separately as it doesn't run when called in RunActions or CCSpawn
		

			}

					/// OBJECTS AND SPRITES
		void addGameTitle(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;
			title = new CCSprite ("menutitle");
			title.Scale = 0.0009f*bounds.Width;
			title.PositionX = 0.5f*bounds.Width;
			title.PositionY = 0.85f*bounds.Height;

			//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
			mainLayer.AddChild (title);

		}
			void addSinglePlayerOption(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

				ballSprite = new CCSprite ("singleplayermenubutton");
			ballSprite.Scale = 0.0008f*bounds.Width;
				ballSprite.PositionX = 0.5f*bounds.Width;
				ballSprite.PositionY = 0.5f*bounds.Height;

				//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
				mainLayer.AddChild (ballSprite);

			}

		void addMultiPlayerOption(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			MultiOption = new CCSprite ("fourplayermenubutton");
			MultiOption.Scale = 0.0008f*bounds.Width;
			MultiOption.PositionX = 0.5f*bounds.Width;
			MultiOption.PositionY = 0.3f*bounds.Height;

			//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
			mainLayer.AddChild (MultiOption);

		}

		void addBackground(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			background = new CCSprite ("galaxybackground4");

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










		
	

