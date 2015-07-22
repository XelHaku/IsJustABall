

	using System;
	using System.Collections.Generic;
	using CocosSharp;
	namespace IsJustABall
	{



	public class PlayerCountPickerScene : CCScene 
		{// Declare VAriables
			
			CCSprite LevelItem;
			CCSprite background;


			CCLayer mainLayer;
			CCWindow mainWindowAux;
			CCEventListenerTouchAllAtOnce touchListener;


		public PlayerCountPickerScene(CCWindow mainWindow) : base(mainWindow)
			{
				mainLayer = new CCLayer ();
				AddChild (mainLayer);
				mainWindowAux = mainWindow;
				


				var bounds = mainWindow.WindowSizeInPixels;

				addLevelItem(mainWindow);


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


			#region HANDLE TOUCHSCREEN
			void HandleTouchesBegan (System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent)
			{		}


			void HandleTouchesEnded(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){
				var bounds = mainWindowAux.WindowSizeInPixels;
				var locationInverted = touches [0].LocationOnScreen;
				CCPoint location = new CCPoint(locationInverted.X,bounds.Height - locationInverted.Y);

			    
			CCPoint buttonPoint = new CCPoint (0.5f * bounds.Width, 0.75f * bounds.Height);
			bool hit =  location.IsNear(buttonPoint, 200.0f) ;
				if (hit)
				{
					LevelItem.ScaleTo (new CCSize (LevelItem.ScaledContentSize.Width/1.1f,LevelItem.ScaledContentSize.Height/1.1f));
				MultiPlayerScrollerScene gameScene = new MultiPlayerScrollerScene (mainWindowAux,4);
					mainWindowAux.RunWithScene (gameScene);

				}

			buttonPoint = new CCPoint (0.75f * bounds.Width, 0.25f * bounds.Height);
			hit =  location.IsNear(buttonPoint, 200.0f) ;
			if (hit)
			{
				LevelItem.ScaleTo (new CCSize (LevelItem.ScaledContentSize.Width/1.1f,LevelItem.ScaledContentSize.Height/1.1f));
				MultiPlayerScrollerScene gameScene = new MultiPlayerScrollerScene (mainWindowAux,3);
				mainWindowAux.RunWithScene (gameScene);

			}

			buttonPoint = new CCPoint (0.25f * bounds.Width, 0.25f * bounds.Height);
			hit =  location.IsNear(buttonPoint, 200.0f) ;
			if (hit)
			{
				LevelItem.ScaleTo (new CCSize (LevelItem.ScaledContentSize.Width/1.1f,LevelItem.ScaledContentSize.Height/1.1f));
				MultiPlayerScrollerScene gameScene = new MultiPlayerScrollerScene (mainWindowAux,2);
				mainWindowAux.RunWithScene (gameScene);

			}
				//BUG: calling walkRepeat separately as it doesn't run when called in RunActions or CCSpawn


			}


			#endregion
			/// OBJECTS AND SPRITES
			void addLevelItem(CCWindow mainWindow){
				var bounds = mainWindow.WindowSizeInPixels;
				LevelItem = new CCSprite ("playercountmenu");
				LevelItem.Scale = 0.002f*bounds.Width;
				LevelItem.PositionX = 0.5f*bounds.Width;
				LevelItem.PositionY = 0.5f*bounds.Height;

				mainLayer.AddChild (LevelItem);

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















