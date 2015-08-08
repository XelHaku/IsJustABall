

	using System;
	using System.Collections.Generic;
	using CocosSharp;
namespace IsJustABall.Android
	{



	public class PlayerCountPickerScene : CCScene 
		{// Declare VAriables
			
			CCSprite LevelItem;
			CCSprite background;
		    CCSprite backbone; 
	     	List<CCSprite> LevelItemList;
		    CCScaleTo ZoomTouch;

			CCLayer mainLayer;
			CCWindow mainWindowAux;
			CCEventListenerTouchAllAtOnce touchListener;
		CCPoint templocation;

		public PlayerCountPickerScene(CCWindow mainWindow) : base(mainWindow)
			{
				mainLayer = new CCLayer ();
				AddChild (mainLayer);
				mainWindowAux = mainWindow;
			CCScaleTo ZoomTouch = new CCScaleTo(0,0);
			LevelItemList =new List<CCSprite>();

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

		{
			var locationInverted = touches [0].LocationOnScreen;
			templocation = touches [0].LocationOnScreen;
			CCPoint location = new CCPoint(locationInverted.X,mainWindowAux.WindowSizeInPixels.Height - locationInverted.Y);

			foreach(var Levelitem in LevelItemList){	
				
			
				bool hit = Levelitem.BoundingBoxTransformedToParent.ContainsPoint (location);
				if (hit) {
					//ballSprite.ScaleTo (new CCSize (1.1f*ballSprite.ScaledContentSize.Width,1.1f*ballSprite.ScaledContentSize.Height));
					//CCScaleTo ZoomTouch = new CCScaleTo(0.01f,1.05f);

					Levelitem.RunAction (ZoomTouch);
				}	}	}


			void HandleTouchesEnded(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){
				var bounds = mainWindowAux.WindowSizeInPixels;
				var locationInverted = touches [0].LocationOnScreen;
				CCPoint location = new CCPoint(locationInverted.X,bounds.Height - locationInverted.Y);

			foreach (var Levelitem in LevelItemList) {
				bool hit = Levelitem.BoundingBoxTransformedToParent.ContainsPoint (location);
				if(hit)	{
					ZoomTouch = new CCScaleTo(0.0f,0.25f*mainWindowAux.WindowSizeInPixels.Width/backbone.BoundingBoxTransformedToWorld.Size.Width);
					Levelitem.RunAction(ZoomTouch);
					//LevelItem.RunAction (new CCMoveBy (5.0f, new CCPoint (0.2f, 900.0f)));

					if (Math.Abs (templocation.Y - locationInverted.Y) <= 5.0f) {
						MultiPlayerScrollerScene gameScene = new MultiPlayerScrollerScene (mainWindowAux,"multi4level1",LevelItemList.IndexOf(Levelitem)+1);
						mainWindowAux.RunWithScene (gameScene);
					}
				}
			}



			}




			#endregion
			/// OBJECTS AND SPRITES
			void addLevelItem(CCWindow mainWindow){
				var bounds = mainWindow.WindowSizeInPixels;

				 backbone = new CCSprite ("button/playerbuttonshadow");
			CCScaleBy Resize = new CCScaleBy (0.0f,0.80f* mainWindowAux.WindowSizeInPixels.Width/backbone.BoundingBoxTransformedToWorld.Size.Width);  
			backbone.RunAction (Resize);
			backbone.PositionX = 0.5f*bounds.Width;
			backbone.PositionY = 0.5f*bounds.Height;
			mainLayer.AddChild (backbone);
			ZoomTouch = new CCScaleTo(0.01f,0.35f*mainWindow.WindowSizeInPixels.Width/backbone.BoundingBoxTransformedToWorld.Size.Width);

			Resize = new CCScaleBy (0.0f,0.30f* mainWindowAux.WindowSizeInPixels.Width/backbone.BoundingBoxTransformedToWorld.Size.Width);  
			    
			LevelItem = new CCSprite ("button/playerbutton1");
			    LevelItem.RunAction (Resize);
				LevelItem.PositionX = 0.27f*bounds.Width;
				LevelItem.PositionY = 0.74f*bounds.Height;
				LevelItemList.Add (LevelItem);
			mainLayer.AddChild (LevelItem);
			mainLayer.ReorderChild (LevelItem, 100);
			 
			LevelItem = new CCSprite ("button/playerbutton2");
			LevelItem.RunAction (Resize);
			LevelItem.PositionX = 0.72f*bounds.Width;
			LevelItem.PositionY = 0.64f*bounds.Height;
			LevelItemList.Add (LevelItem);
			mainLayer.AddChild (LevelItem);
			mainLayer.ReorderChild (LevelItem, 100);

			LevelItem = new CCSprite ("button/playerbutton3");
			LevelItem.RunAction (Resize);
			LevelItem.PositionX = 0.72f*bounds.Width;
			LevelItem.PositionY = 0.365f*bounds.Height;
			LevelItemList.Add (LevelItem);
			mainLayer.AddChild (LevelItem);
			mainLayer.ReorderChild (LevelItem, 100);

			LevelItem = new CCSprite ("button/playerbutton4");
			LevelItem.RunAction (Resize);
			LevelItem.PositionX = 0.28f*bounds.Width;
			LevelItem.PositionY = 0.26f*bounds.Height;
			LevelItemList.Add (LevelItem);
			mainLayer.AddChild (LevelItem);
			mainLayer.ReorderChild (LevelItem, 100);

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















