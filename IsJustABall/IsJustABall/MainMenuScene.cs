
using System;
using System.Collections.Generic;
using CocosSharp;
namespace IsJustABall
{
	public class MainMenuScene : CCScene 
	{// Declare VAriables
		CCSprite ballSprite;
		CCSprite MultiOption;
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
		     	addBlueBall (mainWindow);
			addMultiOption (mainWindow);
			    addBackground (mainWindow);
				Schedule (RunMenuLogic);


				// New code:
		    	
				touchListener = new CCEventListenerTouchAllAtOnce ();
				touchListener.OnTouchesMoved = HandleTouchesMoved; 
		        touchListener.OnTouchesBegan = HandleTouchesBegan; 
				AddEventListener (touchListener, this);

			}

			void RunMenuLogic(float frameTimeInSeconds)
			{
				
			}



			void HandleTouchesMoved (System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent)
			{
				// we only care about the first touch:
				//var locationOnScreen = touches [0].LocationOnScreen;
				//paddleSprite.PositionX = locationOnScreen.X;
			}
		    void HandleTouchesBegan(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){
				
		
			var location = touches [0].LocationOnScreen;
			bool hit =  location.IsNear(ballSprite.PositionWorldspace, 100.0f) ;
			if (hit)
			{
				OnePlayerScrollerScene gameScene = new OnePlayerScrollerScene (mainWindowAux);
				mainWindowAux.RunWithScene (gameScene);

			}

			hit =  location.IsNear(MultiOption.PositionWorldspace, 100.0f) ;
			if (hit) {
				MultiPlayerScrollerScene gameScene = new MultiPlayerScrollerScene (mainWindowAux);
				mainWindowAux.RunWithScene (gameScene);
			}

		
			//BUG: calling walkRepeat separately as it doesn't run when called in RunActions or CCSpawn
		

			}

					/// OBJECTS AND SPRITES

			void addBlueBall(CCWindow mainWindow){
				var bounds = mainWindow.WindowSizeInPixels;

				ballSprite = new CCSprite ("blueball");
				ballSprite.Scale = 0.001f*bounds.Width;
				ballSprite.PositionX = 0.5f*bounds.Width;
				ballSprite.PositionY = 0.5f*bounds.Height;

				//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
				mainLayer.AddChild (ballSprite);

			}

		void addMultiOption(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			MultiOption = new CCSprite ("redball");
			MultiOption.Scale = 0.001f*bounds.Width;
			MultiOption.PositionX = 0.5f*bounds.Width;
			MultiOption.PositionY = 0.8f*bounds.Height;

			//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
			mainLayer.AddChild (MultiOption);

		}

		void addBackground(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			background = new CCSprite ("galaxybackground4");

			background.Scale = 1.8f;
			background.PositionX = bounds.Width/2;
			background.PositionY = background.ContentSize.Height;

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










		
	

