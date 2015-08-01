
using System;
using System.Collections.Generic;
using CocosSharp;
using System.Threading.Tasks;
using SQLite;

namespace  IsJustABall.Android
{

		
		
	public  class  LevelPickerSceneSinglePlayer : CCScene 
				{	// Declare VAriables
		            List<CCSprite> ItemsList;
					CCSprite LevelItem;
					
		           
					CCSprite background;


					CCLayer mainLayer;
					CCWindow mainWindowAux;
					CCEventListenerTouchAllAtOnce touchListener;
		            CCPoint templocation;
		    

		public  LevelPickerSceneSinglePlayer(CCWindow mainWindow) : base(mainWindow)
					{
			//SQL INITI

			var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
			var pathToDatabase = System.IO.Path.Combine(docsFolder, "db_sqlcompnet_LevelRecord.db");
			sqlMethods sqlMethod = new sqlMethods ();
			var result = sqlMethod.createDatabase(pathToDatabase);
			result = sqlMethod.initializeDatabase (pathToDatabase);
			 
			//Create tables for SQL LevelRecord
		


						mainLayer = new CCLayer ();
						AddChild (mainLayer);
						mainWindowAux = mainWindow;
			       ItemsList = new List<CCSprite> ();


						var bounds = mainWindow.WindowSizeInPixels;

			//mainLayer.AddChild (scoreLabel);
			//mainLayer.ReorderChild (scoreLabel, 200);
			addLevelItem(mainWindow,pathToDatabase);

						
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
					//LevelItem.ScaleTo (new CCSize (1.1f * LevelItem.ScaledContentSize.Width, 1.1f * LevelItem.ScaledContentSize.Height));
					CCScaleBy ZoomTouch = new CCScaleBy(0.01f,0.90f*bounds.Width/LevelItem.BoundingBoxTransformedToWorld.Size.Width);
					LevelItem.RunAction (ZoomTouch);
				}
				//
						
			}
					}


			void HandleTouchesEnded(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){
			var bounds = mainWindowAux.WindowSizeInPixels;
			var locationInverted = touches [0].LocationOnScreen;
			CCPoint location = new CCPoint (locationInverted.X, bounds.Height - locationInverted.Y);



			foreach (var LevelItem in ItemsList) {					
				CCScaleBy ZoomTouch = new CCScaleBy(0.01f,0.82f*bounds.Width/LevelItem.BoundingBoxTransformedToWorld .Size.Width);
				LevelItem.RunAction(ZoomTouch);
				bool hit = LevelItem.BoundingBoxTransformedToParent.ContainsPoint (location);
				if (hit) {
					
					switch (LevelItem.Name) {
					case "tutorial":
						//LevelItem.ScaleTo (new CCSize (LevelItem.ScaledContentSize.Width / 1.1f, LevelItem.ScaledContentSize.Height / 1.1f));
					
						if (Math.Abs (templocation.Y - locationInverted.Y) <= 5.0f) {
							OnePlayerScrollerScene gameScene = new OnePlayerScrollerScene (mainWindowAux, LevelItem.Name);
							mainWindowAux.RunWithScene (gameScene);
						}
						break;
					case "railgun":
						//LevelItem.ScaleTo (new CCSize (LevelItem.ScaledContentSize.Width / 1.1f, LevelItem.ScaledContentSize.Height / 1.1f));
						if (Math.Abs (templocation.Y - locationInverted.Y) <= 5.0f) {
							OnePlayerScrollerScene gameScene2 = new OnePlayerScrollerScene (mainWindowAux, LevelItem.Name);
							mainWindowAux.RunWithScene (gameScene2);
						}
						break;
					case "minefield":
						//LevelItem.ScaleTo (new CCSize (LevelItem.ScaledContentSize.Width / 1.1f, LevelItem.ScaledContentSize.Height / 1.1f));
						if (Math.Abs (templocation.Y - locationInverted.Y) <= 5.0f) {
							OnePlayerScrollerScene gameScene3 = new OnePlayerScrollerScene (mainWindowAux, LevelItem.Name);
							mainWindowAux.RunWithScene (gameScene3);
						}
						break;
					case "blackhole":
						//LevelItem.ScaleTo (new CCSize (LevelItem.ScaledContentSize.Width / 1.1f, LevelItem.ScaledContentSize.Height / 1.1f));
						if (Math.Abs (templocation.Y - locationInverted.Y) <= 5.0f) {
							OnePlayerScrollerScene gameScene4 = new OnePlayerScrollerScene (mainWindowAux, LevelItem.Name);
							mainWindowAux.RunWithScene (gameScene4);
						}
						break;
					case "testgrounds":
						//LevelItem.ScaleTo (new CCSize (LevelItem.ScaledContentSize.Width / 1.1f, LevelItem.ScaledContentSize.Height / 1.1f));
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
		async void  addLevelItem(CCWindow mainWindow,string pathToDatabase ){
						var bounds = mainWindow.WindowSizeInPixels;
			//////////////DELETE

			////////////////

			//Star.RunAction (ZoomStar);
			int StarsCount = 0;


			LevelItem = new CCSprite ("tutorial");
			CCScaleBy ZoomTouch = new CCScaleBy(0.01f,0.82f*bounds.Width/LevelItem.BoundingBoxTransformedToWorld.Size.Width);


			LevelItem.Name = "tutorial";
			LevelItem.RunAction (ZoomTouch);
			LevelItem.PositionX = 0.5f*bounds.Width;
			LevelItem.PositionY = 0.8f*bounds.Height;
			StarsCount =await SqlGetStar (1,pathToDatabase);
			LevelItem =  addStarsToLevelItem (StarsCount,LevelItem);
			LevelItem = await addScoreFromData (1,pathToDatabase,LevelItem);
			ItemsList.Add (LevelItem);
			mainLayer.AddChild (LevelItem);




			LevelItem = new CCSprite ("railgun");
			LevelItem.Name = "railgun";
			LevelItem.RunAction (ZoomTouch);
			LevelItem.PositionX = 0.5f*bounds.Width;
			LevelItem.PositionY = (0.8f*bounds.Height-1*(LevelItem.BoundingBoxTransformedToParent.Size.Height+0.1f*bounds.Height));
			StarsCount =await SqlGetStar (2,pathToDatabase);
			LevelItem =  addStarsToLevelItem (StarsCount,LevelItem);
			LevelItem = await addScoreFromData (2,pathToDatabase,LevelItem);
			ItemsList.Add (LevelItem);
			mainLayer.AddChild (LevelItem);

			LevelItem = new CCSprite ("minefield");
			LevelItem.Name = "minefield";
			LevelItem.RunAction (ZoomTouch);
			LevelItem.PositionX = 0.5f*bounds.Width;
			LevelItem.PositionY = (0.8f*bounds.Height-2*(LevelItem.BoundingBoxTransformedToParent.Size.Height+0.1f*bounds.Height));
			StarsCount =await SqlGetStar (3,pathToDatabase);
			LevelItem =  addStarsToLevelItem (StarsCount,LevelItem);
			LevelItem = await addScoreFromData (3,pathToDatabase,LevelItem);
			ItemsList.Add (LevelItem);
			mainLayer.AddChild (LevelItem);

			LevelItem = new CCSprite ("blackholeLevel");
			LevelItem.Name = "blackhole";
			LevelItem.RunAction (ZoomTouch);
			LevelItem.PositionX = 0.5f*bounds.Width;
			LevelItem.PositionY = (0.8f*bounds.Height-3*(LevelItem.BoundingBoxTransformedToParent.Size.Height+0.1f*bounds.Height));
			StarsCount =await SqlGetStar (4,pathToDatabase);
			LevelItem =  addStarsToLevelItem (StarsCount,LevelItem);
			LevelItem = await addScoreFromData (4,pathToDatabase,LevelItem);
			ItemsList.Add (LevelItem);
			mainLayer.AddChild (LevelItem);

			LevelItem = new CCSprite ("testgrounds");
			LevelItem.Name = "testgrounds";
			LevelItem.RunAction (ZoomTouch);
			LevelItem.PositionX = 0.5f*bounds.Width;
			LevelItem.PositionY = (0.8f*bounds.Height-4*(LevelItem.BoundingBoxTransformedToParent.Size.Height+0.1f*bounds.Height));
			StarsCount =await SqlGetStar (5,pathToDatabase);
			LevelItem =  addStarsToLevelItem (StarsCount,LevelItem);
			LevelItem = await addScoreFromData (5,pathToDatabase,LevelItem);
			ItemsList.Add (LevelItem);
			mainLayer.AddChild (LevelItem);
					}

		CCSprite addStarsToLevelItem(int StarsCount,CCSprite LevelItem ){
			CCSprite Star1a;
			CCSprite Star2a;
			CCSprite Star3a;
			CCScaleBy ZoomStar = new CCScaleBy(0.01f,0.05f*mainWindowAux.WindowSizeInPixels.Width/LevelItem.BoundingBoxTransformedToWorld.Size.Width);

			Star1a = new CCSprite ("star");
			Star1a.RunAction (ZoomStar);
			Star1a.PositionX = 0.83f*LevelItem.ContentSize.Width;
			Star1a.PositionY = 0.25f*LevelItem.ContentSize.Height;

			Star2a = new CCSprite ("star");
			Star2a.RunAction (ZoomStar);
			Star2a.PositionX = 0.89f*LevelItem.ContentSize.Width;
			Star2a.PositionY = 0.25f*LevelItem.ContentSize.Height;

			Star3a = new CCSprite ("star");
			Star3a.RunAction (ZoomStar);
			Star3a.PositionX = 0.95f*LevelItem.ContentSize.Width;
			Star3a.PositionY = 0.25f*LevelItem.ContentSize.Height;

			if(StarsCount>=1){
				LevelItem.AddChild (Star1a);
				if (StarsCount >= 2) {
					LevelItem.AddChild (Star2a);
				}
				if (StarsCount >= 3) {
					LevelItem.AddChild (Star3a);
				}
			}

			return LevelItem;
		}

		async Task<int> SqlGetStar (int IDlevel,string pathToDatabase){
			
			int StarsCount = 0;
			int flag_Stars=0;
			try
			{
				var db = new SQLiteAsyncConnection(pathToDatabase);

				List<LevelRecord> dataList = new List<LevelRecord> ();
				dataList = await db.QueryAsync <LevelRecord>("SELECT * FROM LevelRecord");//WHERE ID=0 LIMIT 1 WHERE ID ="+IDlevel
				{     
					

					foreach(var dataElement in dataList){
						if(dataElement.Stars>flag_Stars && dataElement.ID==IDlevel)
						{
							flag_Stars=dataElement.Stars;
						}

					}
					//scoreLabel.Text= "It Has "+ flag_Stars + "Stars";
					StarsCount = flag_Stars;
				}
				//return "Single data file inserted or updated";
			}
			catch (SQLiteException ex)
			{

			}


			return StarsCount;
		}
					

		async Task<CCSprite> addScoreFromData(int IDlevel,string pathToDatabase,CCSprite LevelItem){
			string ScoreText = "0";

			CCLabel scoreLabel = new CCLabel("","nasalizationbold.ttf",50);
			scoreLabel.PositionX = 8.0f*LevelItem.ContentSize.Width/10 ;
			scoreLabel.PositionY =0.6f* LevelItem.ContentSize.Height/10;
			scoreLabel.AnchorPoint = CCPoint.AnchorLowerLeft;


			try
			{
				var db = new SQLiteAsyncConnection(pathToDatabase);

				List<LevelRecord> dataList = new List<LevelRecord> ();
				dataList = await db.QueryAsync <LevelRecord>("SELECT * FROM LevelRecord");//WHERE ID=0 LIMIT 1
				{     

					int flag_Score=0;
					foreach(var dataElement in dataList){
						if(dataElement.Score>flag_Score && dataElement.ID==IDlevel)
						{
							flag_Score=dataElement.Score;
						}

					}
					scoreLabel.Text= ""+ flag_Score ;
					ScoreText =flag_Score.ToString();
				}
				//return "Single data file inserted or updated";
			}
			catch (SQLiteException ex)
			{

			}

			LevelItem.AddChild (scoreLabel);

			return LevelItem;
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















