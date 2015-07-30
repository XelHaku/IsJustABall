using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using CocosSharp;
using Android.Content.PM;
using Microsoft.Xna.Framework;
using Com.Airpush.Xamarinlib;


namespace IsJustABall.Android
{
	[Activity(
		Label = "IsJustABall",
		AlwaysRetainTaskState = true,
		Icon = "@drawable/icon",
		Theme = "@android:style/Theme.NoTitleBar",
		LaunchMode = LaunchMode.SingleInstance,
		MainLauncher = true,
		ScreenOrientation = ScreenOrientation.Portrait,
		ConfigurationChanges =  ConfigChanges.Keyboard | 
		ConfigChanges.KeyboardHidden)
	]
	public class MainActivity : AndroidGameActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate(bundle);

			var application = new CCApplication();

			// GameAppDelegate is your class that inherits 
			// from CCApplicationDelegate
			application.ApplicationDelegate = new GameAppDelegate();
			SetContentView(application.AndroidContentView);
			//AIRPUSH
			AirpushSdk air = new AirpushSdk (this);

			air.AirConfig (282083, "1437771158230876985", false, true, 0);



			//
			application.StartGame();
			//air.AirBannerBottomAd ();

			//air.AirBannerTopAd ();

			air.AirSmartWallAd ();
			//air.Banner360 ();


		
		}




	}
}


