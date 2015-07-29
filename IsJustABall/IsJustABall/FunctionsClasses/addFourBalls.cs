using System;
using CocosSharp;
using System.Collections.Generic;
using CocosDenshion;
using System.Linq;

namespace IsJustABall
{
	public class addFourBalls
	{
		public void addGameBall(int playersCount,CCWindow mainWindow, List<ballPhysics> ballPhysicsList ){
			int speed = 90;
			for (int i = 1; i <= playersCount; i++) {

				ballPhysics ballPhysicsSingle = new ballPhysics ();
				ballPhysicsSingle.index = i;
				ballPhysicsSingle.ballSprite= addBall (mainWindow, i);
				ballPhysicsSingle.playerSpriteButton= addPlayerButton (mainWindow, i);
				switch (i) {
				case 1:
					ballPhysicsSingle.ballXVelocity = speed;
					ballPhysicsSingle.ballYVelocity = speed;
					break;
				case 2:
					ballPhysicsSingle.ballXVelocity = -speed;
					ballPhysicsSingle.ballYVelocity = -speed;
					break;
				case 3:
					ballPhysicsSingle.ballXVelocity = -speed;
					ballPhysicsSingle.ballYVelocity = speed;
					break;
				case 4:
					ballPhysicsSingle.ballXVelocity = speed;
					ballPhysicsSingle.ballYVelocity = -speed;
					break;
				default:
					break;
				}
				ballPhysicsSingle.hookTouchBool = true;
				ballPhysicsSingle.theta = 0;
				ballPhysicsSingle.ThetaZero = 0;
				ballPhysicsSingle.ClockwiseRotation = true;
				ballPhysicsSingle.Score = 0;
				ballPhysicsList.Add (ballPhysicsSingle);

							}		

		
		}
	

		public	CCSprite addBall(CCWindow mainWindow, int ballColor){
			var bounds = mainWindow.WindowSizeInPixels;
			CCSprite ballSprite;
			switch (ballColor) {
			case 1:
				ballSprite = new CCSprite ("blueball");
				ballSprite.PositionX =- 0.2f*bounds.Width;
				ballSprite.PositionY = -0.2f*bounds.Height;
				break;
			case 2:
				ballSprite = new CCSprite ("redball");
				ballSprite.PositionX = 1.2f*bounds.Width;
				ballSprite.PositionY = 1.2f*bounds.Height;
				break;
			case 3:
				ballSprite = new CCSprite ("greenball");
				ballSprite.PositionX = 1.2f*bounds.Width;
				ballSprite.PositionY = -0.2f*bounds.Height;
				break;
			case 4:
				ballSprite = new CCSprite ("yellowball");
				ballSprite.PositionX = -0.2f*bounds.Width;
				ballSprite.PositionY = 1.2f*bounds.Height;
				break;
			default:
				ballSprite = new CCSprite ("blueball");
				ballSprite.PositionX = -0.2f*bounds.Width;
				ballSprite.PositionY = -0.2f*bounds.Height;
				break;

			}
			ballSprite.Scale = 0.0003f*bounds.Width;
			return ballSprite;
		}
	
		CCSprite addPlayerButton(CCWindow mainwindow, int playerCount){
			var bounds = mainwindow.WindowSizeInPixels;
			float scale = 0.002f * bounds.Width;
			CCSprite buttonSprite = new CCSprite ();
			for (int i = 1; i <= playerCount; i++) {
				switch (i) {
				case 1:
					buttonSprite = new CCSprite ("blueball");
					buttonSprite.PositionX = 0.0f * bounds.Width;
					buttonSprite.PositionY = 0.0f * bounds.Height;
					CCScaleTo scaleAction = new CCScaleTo(0.5f,0.45f* mainwindow.WindowSizeInPixels.Width/buttonSprite.BoundingBoxTransformedToWorld.Size.Width);
					buttonSprite.RunAction (scaleAction);
					buttonSprite.Opacity = 150;

					break;
				case 2:
					buttonSprite = new CCSprite ("redball");
					buttonSprite.PositionX = 1.0f * bounds.Width;
					buttonSprite.PositionY = 1.0f * bounds.Height;
					scaleAction = new CCScaleTo(0.5f,0.45f* mainwindow.WindowSizeInPixels.Width/buttonSprite.BoundingBoxTransformedToWorld.Size.Width);
					buttonSprite.RunAction (scaleAction);
					buttonSprite.Opacity = 150;

					break;
				case 3:
					buttonSprite = new CCSprite ("greenball");
					buttonSprite.PositionX = 1.0f * bounds.Width;
					buttonSprite.PositionY = 0.0f * bounds.Height;
					 scaleAction = new CCScaleTo(0.5f,0.45f* mainwindow.WindowSizeInPixels.Width/buttonSprite.BoundingBoxTransformedToWorld.Size.Width);
					buttonSprite.RunAction (scaleAction);
					buttonSprite.Opacity = 150;

					break;
				case 4:
					buttonSprite = new CCSprite ("yellowball");
					buttonSprite.PositionX = 0.0f * bounds.Width;
					buttonSprite.PositionY = 1.0f * bounds.Height;
					 scaleAction = new CCScaleTo(0.5f,0.45f* mainwindow.WindowSizeInPixels.Width/buttonSprite.BoundingBoxTransformedToWorld.Size.Width);
					buttonSprite.RunAction (scaleAction);
					buttonSprite.Opacity =150;

					break;
				default:
					break;
				}


			}

			return buttonSprite;
		}
	
	}
}

