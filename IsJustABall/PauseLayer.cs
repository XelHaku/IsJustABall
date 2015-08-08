

	
	/*	protected override void AddedToScene ()
		{
			base.AddedToScene ();

			Scene.SceneResolutionPolicy = CCSceneResolutionPolicy.ShowAll;

			var scoreLabel = new CCLabelTtf (scoreMessage, "arial", 22) {
				Position = new CCPoint (VisibleBoundsWorldspace.Size.Center.X, VisibleBoundsWorldspace.Size.Center.Y + 50),
				Color = new CCColor3B (CCColor4B.Yellow),
				HorizontalAlignment = CCTextAlignment.Center,
				VerticalAlignment = CCVerticalTextAlignment.Center,
				AnchorPoint = CCPoint.AnchorMiddle
			};

			AddChild (scoreLabel);

			var playAgainLabel = new CCLabelTtf ("Tap to Play Again", "arial", 22) {
				Position = VisibleBoundsWorldspace.Size.Center,
				Color = new CCColor3B (CCColor4B.Green),
				HorizontalAlignment = CCTextAlignment.Center,
				VerticalAlignment = CCVerticalTextAlignment.Center,
				AnchorPoint = CCPoint.AnchorMiddle,
			};

			AddChild (playAgainLabel);

			AddMonkey ();
		}



		//handle TouchScreen
		void HandleTouchesBegan(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){


			var location = touches [0].LocationOnScreen;
			bool hit =  location.IsNear(ResumeGame.Position, 50.0f) ;
			if (hit)
			{
			//	ResumeGame.Scale *= 1.2f * ResumeGame.Scale;

			}

			hit =  location.IsNear(Restart.Position, 50.0f) ;
			if (hit) {
			//	Restart.Scale *= 1.2f * Restart.Scale;
			}

			hit =  location.IsNear(MainMenu.Position, 50.0f) ;

			if (hit) {
				//MainMenu.Scale *= 1.2f * MainMenu.Scale;
			}


			//BUG: calling walkRepeat separately as it doesn't run when called in RunActions or CCSpawn


		}

		void HandleTouchesEnded(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){

			var location = touches [0].LocationOnScreen;
			bool hit =  location.IsNear(ResumeGame.Position, 50.0f) ;
			if (hit)
			{
				//ResumeGame.Scale =  ResumeGame.Scale/1.2f;

			}

			hit =  location.IsNear(Restart.Position, 50.0f) ;
			if (hit) {
				//Restart.Scale = Restart.Scale/1.2f;
			}

			hit =  location.IsNear(MainMenu.Position, 50.0f) ;

			if (hit) {
				//MainMenu.Scale = MainMenu.Scale/1.2f;
			}

			//BUG: calling walkRepeat separately as it doesn't run when called in RunActions or CCSpawn


		}
	}

}