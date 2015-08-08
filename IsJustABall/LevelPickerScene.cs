
using System;
using System.Collections.Generic;
using CocosSharp;
namespace IsJustABall
{

		
		
	public class LevelPickerScene : CCScene 
				{// Declare VAriables
		            List<CCSprite> ItemsList;
					CCSprite LevelItem;
					CCSprite Star;
		            CCLabelTtf scoreLabel;
					CCSprite background;


					CCLayer mainLayer;
					CCWindow mainWindowAux;
					CCEventListenerTouchAllAtOnce touchListener;


			public LevelPickerScene(CCWindow mainWindow) : base(mainWindow)
					{
						mainLayer = new CCLayer ();
						AddChild (mainLayer);
						mainWindowAux = mainWindow;
			       ItemsList = new List<CCSprite> ();


						var bounds = mainWindow.WindowSizeInPixels;

			addLevelItem(mainWindow);

						
						addBackground (mainWindow);
						Schedule (RunMenuLogic);


						// New code:

						touchListener = new CCEventListenerTouchAllAtOnce ();
						touchListener.OnTouchesEnded = HandleTouchesEnded; 
						touchListener.OnTouchesBegan = HandleTouchesBegan; 
			            touchListener.OnTouchesMoved = HandleTouchesMoved; 
						AddEventListener (touchListener, this);

					}

					void RunMenuLogic(float frameTimeInSeconds)
					{

					}


		#region HANDLE TOUCHSCREEN
					void HandleTouchesBegan (System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent)
					{
						var bounds = mainWindowAux.WindowSizeInPixels;
						var locationInverted = touches [0].LocationOnScreen;
						CCPoint location = new CCPoint(locationInverted.X,bounds.Height - locationInverted.Y);

			bool hit =  location.IsNear(LevelItem.Position, 100.0f) ;
						if (hit)
						{
				LevelItem.ScaleTo (new CCSize (1.1f*LevelItem.ScaledContentSize.Width,1.1f*LevelItem.ScaledContentSize.Height));
						}

						

					}


					void HandleTouchesEnded(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){
						var bounds = mainWindowAux.WindowSizeInPixels;
						var locationInverted = touches [0].LocationOnScreen;
						CCPoint location = new CCPoint(locationInverted.X,bounds.Height - locationInverted.Y);

						

			bool hit =  location.IsNear(LevelItem.Position, 100.0f) ;
						if (hit)
						{
				LevelItem.ScaleTo (new CCSize (LevelItem.ScaledContentSize.Width/1.1f,LevelItem.ScaledContentSize.Height/1.1f));
							OnePlayerScrollerScene gameScene = new OnePlayerScrollerScene (mainWindowAux);
							mainWindowAux.RunWithScene (gameScene);

						}

					


						//BUG: calling walkRepeat separately as it doesn't run when called in RunActions or CCSpawn


					}

					void HandleTouchesMoved (System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent)
		{

			var bounds = mainWindowAux.WindowSizeInPixels;
			var locationInverted = touches [0].StartLocationOnScreen;
			float delta = touches [0].PreviousLocationOnScreen.Y - touches [0].LocationOnScreen.Y;
			//locationInverted = HandleTouchesMoved;

						CCPoint location = new CCPoint(locationInverted.X,bounds.Height - locationInverted.Y);
			// we only care about the first touch:

			foreach (var LevelItem in ItemsList) {
				LevelItem.PositionY += 1.1f * delta;
							}
		}
		#endregion
					/// OBJECTS AND SPRITES
	                 	void addLevelItem(CCWindow mainWindow){
						var bounds = mainWindow.WindowSizeInPixels;
			LevelItem = new CCSprite ("minefield");
			LevelItem.Scale = 0.001f*bounds.Width;
			LevelItem.PositionX = 0.5f*bounds.Width;
			LevelItem.PositionY = 0.5f*bounds.Height;
			ItemsList.Add (LevelItem);
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















