
using System;
using System.Collections.Generic;
using CocosSharp;
namespace IsJustABall
{

		
		
	public class LevelPickerSceneSinglePlayer : CCScene 
				{// Declare VAriables
		            List<CCSprite> ItemsList;
					CCSprite LevelItem;
					//CCSprite Star;
		           // CCLabelTtf scoreLabel;
					CCSprite background;


					CCLayer mainLayer;
					CCWindow mainWindowAux;
					CCEventListenerTouchAllAtOnce touchListener;
		            CCPoint templocation;


			public LevelPickerSceneSinglePlayer(CCWindow mainWindow) : base(mainWindow)
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
			            templocation = touches [0].LocationOnScreen;
						CCPoint location = new CCPoint(locationInverted.X,bounds.Height - locationInverted.Y);

			foreach (var LevelItem in ItemsList) {	
				bool hit = LevelItem.BoundingBoxTransformedToParent.ContainsPoint (location);

				if (hit) {
					LevelItem.ScaleTo (new CCSize (1.1f * LevelItem.ScaledContentSize.Width, 1.1f * LevelItem.ScaledContentSize.Height));
				}
				//
						
			}
					}


			void HandleTouchesEnded(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){
			var bounds = mainWindowAux.WindowSizeInPixels;
			var locationInverted = touches [0].LocationOnScreen;
			CCPoint location = new CCPoint (locationInverted.X, bounds.Height - locationInverted.Y);



			foreach (var LevelItem in ItemsList) {					
				bool hit = LevelItem.BoundingBoxTransformedToParent.ContainsPoint (location);
				if (hit) {
					switch (LevelItem.Name) {
					case "tutorial":
						LevelItem.ScaleTo (new CCSize (LevelItem.ScaledContentSize.Width / 1.1f, LevelItem.ScaledContentSize.Height / 1.1f));
						if (Math.Abs (templocation.Y - locationInverted.Y) <= 5.0f) {
							OnePlayerScrollerScene gameScene = new OnePlayerScrollerScene (mainWindowAux, LevelItem.Name);
							mainWindowAux.RunWithScene (gameScene);
						}
						break;
					case "railgun":
						LevelItem.ScaleTo (new CCSize (LevelItem.ScaledContentSize.Width / 1.1f, LevelItem.ScaledContentSize.Height / 1.1f));
						if (Math.Abs (templocation.Y - locationInverted.Y) <= 5.0f) {
							OnePlayerScrollerScene gameScene2 = new OnePlayerScrollerScene (mainWindowAux, LevelItem.Name);
							mainWindowAux.RunWithScene (gameScene2);
						}
						break;
					case "minefield":
						LevelItem.ScaleTo (new CCSize (LevelItem.ScaledContentSize.Width / 1.1f, LevelItem.ScaledContentSize.Height / 1.1f));
						if (Math.Abs (templocation.Y - locationInverted.Y) <= 5.0f) {
							OnePlayerScrollerScene gameScene3 = new OnePlayerScrollerScene (mainWindowAux, LevelItem.Name);
							mainWindowAux.RunWithScene (gameScene3);
						}
						break;
					case "blackhole":
						LevelItem.ScaleTo (new CCSize (LevelItem.ScaledContentSize.Width / 1.1f, LevelItem.ScaledContentSize.Height / 1.1f));
						if (Math.Abs (templocation.Y - locationInverted.Y) <= 5.0f) {
							OnePlayerScrollerScene gameScene4 = new OnePlayerScrollerScene (mainWindowAux, LevelItem.Name);
							mainWindowAux.RunWithScene (gameScene4);
						}
						break;
					case "testgrounds":
						LevelItem.ScaleTo (new CCSize (LevelItem.ScaledContentSize.Width / 1.1f, LevelItem.ScaledContentSize.Height / 1.1f));
						if (Math.Abs (templocation.Y - locationInverted.Y) <= 1) {
							OnePlayerScrollerScene gameScene5 = new OnePlayerScrollerScene (mainWindowAux, LevelItem.Name);
							mainWindowAux.RunWithScene (gameScene5);
						}
						break;
					default:
						break;
					

					}
				}
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
			LevelItem = new CCSprite ("tutorial");
			LevelItem.Name = "tutorial";
			LevelItem.Scale = 0.001f*bounds.Width;
			LevelItem.PositionX = 0.5f*bounds.Width;
			LevelItem.PositionY = 0.8f*bounds.Height;
			ItemsList.Add (LevelItem);
			mainLayer.AddChild (LevelItem);

			LevelItem = new CCSprite ("railgun");
			LevelItem.Name = "railgun";
			LevelItem.Scale = 0.001f*bounds.Width;
			LevelItem.PositionX = 0.5f*bounds.Width;
			LevelItem.PositionY = (0.8f*bounds.Height-1*(LevelItem.BoundingBoxTransformedToParent.Size.Height+0.05f*bounds.Height));
			ItemsList.Add (LevelItem);
			mainLayer.AddChild (LevelItem);

			LevelItem = new CCSprite ("minefield");
			LevelItem.Name = "minefield";
			LevelItem.Scale = 0.001f*bounds.Width;
			LevelItem.PositionX = 0.5f*bounds.Width;
			LevelItem.PositionY = (0.8f*bounds.Height-2*(LevelItem.BoundingBoxTransformedToParent.Size.Height+0.05f*bounds.Height));
			ItemsList.Add (LevelItem);
			mainLayer.AddChild (LevelItem);

			LevelItem = new CCSprite ("blackholeLevel");
			LevelItem.Name = "blackhole";
			LevelItem.Scale = 0.001f*bounds.Width;
			LevelItem.PositionX = 0.5f*bounds.Width;
			LevelItem.PositionY = (0.8f*bounds.Height-3*(LevelItem.BoundingBoxTransformedToParent.Size.Height+0.05f*bounds.Height));
			ItemsList.Add (LevelItem);
			mainLayer.AddChild (LevelItem);

			LevelItem = new CCSprite ("testgrounds");
			LevelItem.Name = "testgrounds";
			LevelItem.Scale = 0.001f*bounds.Width;
			LevelItem.PositionX = 0.5f*bounds.Width;
			LevelItem.PositionY = (0.8f*bounds.Height-4*(LevelItem.BoundingBoxTransformedToParent.Size.Height+0.05f*bounds.Height));
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















