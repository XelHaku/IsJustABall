using System;
using CocosSharp;

namespace IsJustABall
{
	public class GameSceneTest : CCScene
	{
		CCLayer mainLayer;


		CCSprite ballSprite;
		CCLabelTtf scoreLabel;

		float ballXVelocity = 600 ;
		float ballYVelocity = 600;
		// How much to modify the ball's y velocity per second:
		float gravity = 140;
		//hookTouchBool=!hookTouchBool// to toggle on Touch
		bool hookTouchBool = true;


		int score;


		CCEventListenerTouchAllAtOnce touchListener;

		public GameSceneTest(CCWindow mainWindow) : base(mainWindow)
		{
			mainLayer = new CCLayer ();
			AddChild (mainLayer);

			var bounds = mainWindow.WindowSizeInPixels;

			addBlueBall(mainWindow);


			scoreLabel = new CCLabelTtf ("Score: 0", "arial", 22);
			scoreLabel.PositionX = mainLayer.VisibleBoundsWorldspace.MinX + 20;
			scoreLabel.PositionY = mainLayer.VisibleBoundsWorldspace.MaxY - 20;
			scoreLabel.AnchorPoint = CCPoint.AnchorUpperLeft;

			mainLayer.AddChild (scoreLabel);

			Schedule (RunGameLogic);

			// New code:
			touchListener = new CCEventListenerTouchAllAtOnce ();
			touchListener.OnTouchesMoved = HandleTouchesMoved; 
			touchListener.OnTouchesBegan = HandleTouchesBegan; 
			AddEventListener (touchListener, this);

		}

		void RunGameLogic(float frameTimeInSeconds)
		{
			if (hookTouchBool == true) {//Void free Particle
				freeParticle (frameTimeInSeconds);
			} else {
				//void HookedParticle
				hookedParticle (frameTimeInSeconds);
			}
		}

		void HandleTouchesMoved (System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent)
		{
			// we only care about the first touch:
			var locationOnScreen = touches [0].LocationOnScreen;
			//paddleSprite.PositionX = locationOnScreen.X;
		}
		void HandleTouchesBegan(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){
			hookTouchBool = !hookTouchBool;//Toggle hook

		}



		void freeParticle(float frameTimeInSeconds){
			gravity = 140;
			// This is a linear approximation, so not 100% accurate
			ballYVelocity += frameTimeInSeconds * -gravity;
			ballSprite.PositionX += ballXVelocity * frameTimeInSeconds;
			ballSprite.PositionY += ballYVelocity * frameTimeInSeconds;



			// New code:
			//score++;
			//scoreLabel.Text = "Score: " + score;



			// Check if the ball is either too far to the right or left:
			float ballRight = ballSprite.BoundingBoxTransformedToParent.MaxX;
			float ballLeft = ballSprite.BoundingBoxTransformedToParent.MinX;

			float screenRight = mainLayer.VisibleBoundsWorldspace.MaxX;
			float screenLeft = mainLayer.VisibleBoundsWorldspace.MinX;

			bool shouldReflectXVelocity = (ballRight > screenRight && ballXVelocity > 0) ||	(ballLeft < screenLeft && ballXVelocity < 0);


			if (shouldReflectXVelocity)
			{
				ballXVelocity *= -1;

			}

			// Check if the ball is either too far to the right or left:

			float ballTop = ballSprite.BoundingBoxTransformedToParent.MaxY;
			float ballBottom = ballSprite.BoundingBoxTransformedToParent.MinY;

			float screenTop = mainLayer.VisibleBoundsWorldspace.MaxY;
			float screenBottom = mainLayer.VisibleBoundsWorldspace.MinY;

			bool shouldReflectYVelocity = (ballTop > screenTop && ballYVelocity > 0) ||	(ballBottom < screenBottom && ballYVelocity < 0);

			if (shouldReflectYVelocity)
			{
				ballYVelocity *= -1;
			}


		}

		void hookedParticle(float frameTimeInSeconds){
			gravity = -140;

			//delete
			// This is a linear approximation, so not 100% accurate
			ballXVelocity += frameTimeInSeconds * -gravity;
			ballSprite.PositionX += ballXVelocity * frameTimeInSeconds;
			ballSprite.PositionY += ballYVelocity * frameTimeInSeconds;



			// New code:
			//score++;
			//scoreLabel.Text = "Score: " + score;



			// Check if the ball is either too far to the right or left:
			float ballRight = ballSprite.BoundingBoxTransformedToParent.MaxX;
			float ballLeft = ballSprite.BoundingBoxTransformedToParent.MinX;

			float screenRight = mainLayer.VisibleBoundsWorldspace.MaxX;
			float screenLeft = mainLayer.VisibleBoundsWorldspace.MinX;

			bool shouldReflectXVelocity = (ballRight > screenRight && ballXVelocity > 0) ||	(ballLeft < screenLeft && ballXVelocity < 0);


			if (shouldReflectXVelocity)
			{
				ballXVelocity *= -1;

			}

			// Check if the ball is either too far to the right or left:

			float ballTop = ballSprite.BoundingBoxTransformedToParent.MaxY;
			float ballBottom = ballSprite.BoundingBoxTransformedToParent.MinY;

			float screenTop = mainLayer.VisibleBoundsWorldspace.MaxY;
			float screenBottom = mainLayer.VisibleBoundsWorldspace.MinY;

			bool shouldReflectYVelocity = (ballTop > screenTop && ballYVelocity > 0) ||	(ballBottom < screenBottom && ballYVelocity < 0);

			if (shouldReflectYVelocity)
			{
				ballYVelocity *= -1;
			}

			/////////
		}




		void addBlueBall(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			ballSprite = new CCSprite ("blueball");
			ballSprite.Scale = bounds.Width/5000;
			ballSprite.PositionX = bounds.Width/5000;
			ballSprite.PositionY = bounds.Height/5000;
			mainLayer.AddChild (ballSprite);


		}

		/*
	        void addPivot(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			ballSprite = new CCSprite ("blueball");
			ballSprite.Scale = bounds.Width/5000;
			ballSprite.PositionX = bounds.Width/5000;
			ballSprite.PositionY = bounds.Height/5000;
			mainLayer.AddChild (ballSprite);


		}
		*/

	}


}

