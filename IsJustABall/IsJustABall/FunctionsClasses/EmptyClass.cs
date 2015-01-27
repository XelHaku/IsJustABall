using System;
using CocosSharp;
using System.Collections.Generic;
using CocosDenshion;
using System.Linq;

namespace IsJustABall
{
	public class EmptyClass
	{
		public void addGameBall(int playersCount,CCWindow mainWindow, List<ballPhysics> ballPhysicsList ){
			for (int i = 1; i <= playersCount; i++) {

				ballPhysics ballPhysicsSingle = new ballPhysics ();
				ballPhysicsSingle.index = i;
				ballPhysicsSingle.ballSprite= addBall (mainWindow, i);
				ballPhysicsSingle.ballXVelocity = 0;
				ballPhysicsSingle.ballYVelocity = 300;
				ballPhysicsSingle.hookTouchBool = true;
				ballPhysicsSingle.theta = 0;
				ballPhysicsSingle.ThetaZero = 0;
				ballPhysicsSingle.ClockwiseRotation = true;
				ballPhysicsList.Add (ballPhysicsSingle);



			}		
		}
	

		public	CCSprite addBall(CCWindow mainWindow, int ballColor){
			var bounds = mainWindow.WindowSizeInPixels;
			CCSprite ballSprite;
			switch (ballColor) {
			case 1:
				ballSprite = new CCSprite ("blueball");
				ballSprite.PositionX = 0.2f*bounds.Width;
				ballSprite.PositionY = -0.1f*bounds.Height;
				break;
			case 2:
				ballSprite = new CCSprite ("redball");
				ballSprite.PositionX = 0.4f*bounds.Width;
				ballSprite.PositionY = -0.1f*bounds.Height;
				break;
			case 3:
				ballSprite = new CCSprite ("greenball");
				ballSprite.PositionX = 0.6f*bounds.Width;
				ballSprite.PositionY = -0.1f*bounds.Height;
				break;
			case 4:
				ballSprite = new CCSprite ("yellowball");
				ballSprite.PositionX = 0.8f*bounds.Width;
				ballSprite.PositionY = -0.1f*bounds.Height;
				break;
			default:
				ballSprite = new CCSprite ("blueball");
				ballSprite.PositionX = 0.2f*bounds.Width;
				ballSprite.PositionY = -0.1f*bounds.Height;
				break;
			}
			ballSprite.Scale = 0.0005f*bounds.Width;


			//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
			//mainLayer.AddChild (ballSprite);
			return ballSprite;
		}
	
	
	}
}

