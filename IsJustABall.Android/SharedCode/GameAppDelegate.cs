﻿using System;
using CocosSharp;
using CocosDenshion;

namespace IsJustABall.Android
{
	public class GameAppDelegate : CCApplicationDelegate
	{
		public override void ApplicationDidFinishLaunching (CCApplication application, CCWindow mainWindow)
		{
			application.PreferMultiSampling = false;
			application.ContentRootDirectory = "Content";

			//application.ContentSearchPaths.Add("hd");

		//	CCSimpleAudioEngine.SharedEngine.PreloadEffect ("Sounds/tap");
			CCSimpleAudioEngine.SharedEngine.PreloadBackgroundMusic ("Sounds/intro");
			CCSimpleAudioEngine.SharedEngine.PlayBackgroundMusic("Sounds/intro",true);

			var bounds = mainWindow.WindowSizeInPixels;
			CCScene.SetDefaultDesignResolution(bounds.Width, bounds.Height, CCSceneResolutionPolicy.ShowAll);

			//IJABScrollerScene gameScene = new IJABScrollerScene (mainWindow);


			//ScrollerSceneTest gameScene = new ScrollerSceneTest (mainWindow);
			//mainWindow.RunWithScene (gameScene);

			MainMenuScene gameScene = new MainMenuScene (mainWindow);
			mainWindow.RunWithScene (gameScene);



			//CCSize winSize = mainWindow.WindowSizeInPixels;
			//mainWindow.SetDesignResolutionSize(winSize.Width, winSize.Height, CCSceneResolutionPolicy.ExactFit);
			//CCScene scene = GameStartLayer.GameStartLayerScene(mainWindow);
			//mainWindow.RunWithScene (scene);

			/*


*/

		}

		public override void ApplicationDidEnterBackground (CCApplication application)
		{
			// stop all of the animation actions that are running.
			application.Paused = true;

			// if you use SimpleAudioEngine, your music must be paused
			CCSimpleAudioEngine.SharedEngine.PauseBackgroundMusic ();
		}

		public override void ApplicationWillEnterForeground (CCApplication application)
		{
			application.Paused = false;

			// if you use SimpleAudioEngine, your background music track must resume here. 
			CCSimpleAudioEngine.SharedEngine.ResumeBackgroundMusic ();

		}
	}
}

