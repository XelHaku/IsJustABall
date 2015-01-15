using System;
using CocosSharp;

namespace IsJustABall
{
	public class GameSceneTest : CCScene
	{
		CCLayer mainLayer;


		CCSprite ballSprite;
		CCSprite pivotSprite;
		CCLabelTtf scoreLabel;

		float ballXVelocity =500 ;
		float ballYVelocity = 500;
		// How much to modify the ball's y velocity per second:
		float gravity = 140;
		//hookTouchBool=!hookTouchBool// to toggle on Touch
		bool hookTouchBool = true;
		int score;
		//Declare variables for HookedParticle Method
		double dRadius_X;
		double dRadius_Y;
		double Radius;
		double ballSpeed;
		double SinThetaZero;
		double CosThetaZero;
		double CosAlpha;
		double SinAlpha;
		double theta=0;
		double ThetaZero=0;
		double Multiplier =1.1f;
		double wZero;
		double ballSpeedFinal;
		bool ClockwiseRotation = true;

		
		/// //////////////////



		CCEventListenerTouchAllAtOnce touchListener;

		public GameSceneTest(CCWindow mainWindow) : base(mainWindow)
		{
			mainLayer = new CCLayer ();
			AddChild (mainLayer);

			var bounds = mainWindow.WindowSizeInPixels;

			addBlueBall(mainWindow);
			addPivot(mainWindow);


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
			if (hookTouchBool == false) {
			//Set values for spped and radius or rotation raound Pivot

				dRadius_X = ballSprite.PositionX- pivotSprite.PositionX;
				dRadius_Y = ballSprite.PositionY- pivotSprite.PositionY;

				Radius = Math.Pow((double)dRadius_X,2) + Math.Pow((double)dRadius_Y,2);
				Radius = Math.Pow(Radius,0.5);

				ballSpeed = Math.Pow(ballXVelocity,2) + Math.Pow(ballYVelocity,2);
				ballSpeed = Math.Pow(ballSpeed,0.5d);

				CosThetaZero = dRadius_X/Radius;
				SinThetaZero = dRadius_Y/Radius;

				CosAlpha =(dRadius_X*ballXVelocity + dRadius_Y*ballYVelocity)/(Radius*ballSpeed);

				if( Math.Pow(CosAlpha,2) < 0.05){
					CosAlpha = Math.Pow(0.05,0.5);
				}
				SinAlpha = (1 - Math.Pow(CosAlpha,2));
				SinAlpha = Math.Pow(SinAlpha,0.5f);


				wZero = ballSpeed/Radius;
				ballSpeedFinal = Radius*Multiplier*wZero*SinAlpha;

				ThetaZero = Math.Acos (CosThetaZero);

				//Second Quadrant
				if(SinThetaZero > 0 && CosThetaZero <0){
					ThetaZero = (1/2)*Math.PI + ThetaZero;
				}
				//Third Quadrant
				if(SinThetaZero <0 && CosThetaZero < 0 ){
					ThetaZero = (2)*Math.PI - ThetaZero;
				}



				//Fourth Quadrant
				if(SinThetaZero <0 && CosThetaZero > 0 ){
					ThetaZero =  - ThetaZero;
				}
				theta=ThetaZero;
				//Define if it is clockwise or anticlockwise rotation

				if ((CosThetaZero <= ballXVelocity / ballSpeed && SinThetaZero > 0) || (CosThetaZero >= ballXVelocity / ballSpeed && SinThetaZero < 0)) {
					ClockwiseRotation = true;
				} else {
					ClockwiseRotation = false;
				}
			
			}
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
			gravity = 0;

			// below is the iteration over time
			theta+= (double)(Multiplier*wZero*SinAlpha*frameTimeInSeconds);

			//ballSprite.PositionX =(float)(Radius*Math.Cos(theta) + pivotSprite.PositionX);
			//ballSprite.PositionY = (float)(Radius*Math.Sin(theta) + pivotSprite.PositionY);
			//ConsolePrint
//			Console.WriteLine( "\n Math.Sin({0} deg) == {1:E16}\n" + "Math.Cos({0} deg) == {2:E16}", Math.Sin(theta), Math.Cos(theta) );
			ballXVelocity = (float)(-ballSpeedFinal * Math.Sin (theta));
			ballYVelocity = (float)(ballSpeedFinal * Math.Cos (theta));

			if (ClockwiseRotation == true) {
				ballSprite.PositionX =(float)(Radius*Math.Cos(theta) + pivotSprite.PositionX);
				ballSprite.PositionY = (float)(Radius*Math.Sin(theta) + pivotSprite.PositionY);


			} else {
				ballSprite.PositionX =(float)(-Radius*Math.Cos(theta) + pivotSprite.PositionX);
				ballSprite.PositionY = (float)(-Radius*Math.Sin(theta) + pivotSprite.PositionY);

						}
				/////////
		}




		void addBlueBall(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			ballSprite = new CCSprite ("blueball");
			ballSprite.Scale = 0.0002f*bounds.Width;
			ballSprite.PositionX = 0.05f*bounds.Width;
			ballSprite.PositionY = 0.05f*bounds.Height;
			mainLayer.AddChild (ballSprite);


		}

		void addPivot(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			pivotSprite = new CCSprite ("pivot");
			pivotSprite.Scale = 0.0002f*bounds.Width;
			pivotSprite.PositionX = 0.5f*bounds.Width;
			pivotSprite.PositionY =0.5f*bounds.Height;
			mainLayer.AddChild (pivotSprite);


		}



	}


}

