using System;
using CocosSharp;
using System.Collections.Generic;
using CocosDenshion;
using System.Linq;
namespace IsJustABall
{
	public class IJABScrollerScene : CCScene
	{
		CCLayer mainLayer;
		//CCParticleGalaxy particleEffetOnBall;


		CCSprite ballSprite;
		List<CCSprite> visiblePivots;
		CCSprite pivotSprite;
		CCLabelTtf scoreLabel;

		float ballXVelocity =600 ;
		float ballYVelocity = 800;
		// How much to modify the ball's y velocity per second:
		float gravity = 140;
		//hookTouchBool=!hookTouchBool// to toggle on Touch
		bool hookTouchBool = true;

		//Declare variables for HookedParticle Method
		double dRadius_X;
		double dRadius_Y;
		double Radius;
		double temp;
		double ballSpeed;
		double SinThetaZero;
		double CosThetaZero;
		double CosAlpha;
		double SinAlpha;
		double theta=0;
		double ThetaZero=0;
		double Multiplier =1.5f;
		double wZero;
		double ballSpeedFinal;
		bool ClockwiseRotation = true;
		float minRotationRadius;

		
		/// //////////////////
		//needed for multiple Pivots
		float hookedPivotPosX,hookedPivotPosY;
		/// 



		CCEventListenerTouchAllAtOnce touchListener;

		public IJABScrollerScene(CCWindow mainWindow) : base(mainWindow)
		{

			mainLayer = new CCLayer ();
			AddChild (mainLayer);
			visiblePivots = new List<CCSprite> ();
			var bounds = mainWindow.WindowSizeInPixels;
			minRotationRadius = 0.20f*bounds.Width;

			addBlueBall(mainWindow);

			//addPivot(mainWindow);
			visiblePivots.Add (AddPivots (mainWindow,0.15f*bounds.Width,0.25f*bounds.Height,0.0002f*bounds.Width));
			visiblePivots.Add (AddPivots (mainWindow,0.85f*bounds.Width,0.75f*bounds.Height,0.0002f*bounds.Width));
			visiblePivots.Add (AddPivots (mainWindow,0.15f*bounds.Width,0.75f*bounds.Height,0.0002f*bounds.Width));
			visiblePivots.Add (AddPivots (mainWindow,0.85f*bounds.Width,0.25f*bounds.Height,0.0002f*bounds.Width));
			visiblePivots.Add (AddPivots (mainWindow,0.5f*bounds.Width,0.5f*bounds.Height,0.0002f*bounds.Width));



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
			//var locationOnScreen = touches [0].LocationOnScreen;
			//paddleSprite.PositionX = locationOnScreen.X;
		}
		void HandleTouchesBegan(System.Collections.Generic.List<CCTouch> touches, CCEvent touchEvent){
			double closestPivot = 10000;
			foreach (var pivotSprite in visiblePivots) {
				dRadius_X = ballSprite.PositionX - pivotSprite.PositionX;
				dRadius_Y = ballSprite.PositionY - pivotSprite.PositionY;


				temp = Math.Pow ((double)dRadius_X, 2) + Math.Pow ((double)dRadius_Y, 2);
				temp = Math.Pow (temp, 0.5);

				if (temp < closestPivot) {
					hookedPivotPosX = pivotSprite.PositionX;
					hookedPivotPosY = pivotSprite.PositionY;
					closestPivot = temp;
				
				
				}

			
			}

			if (closestPivot < minRotationRadius && hookTouchBool == true) {
				hookTouchBool = false;//Toggle hook
				scoreLabel.Text = "temp:" + temp.ToString () + " \nCircleRadius: " + minRotationRadius.ToString () + " \nball: " + ballSprite.Position.ToString () + " \npivot: " + pivotSprite.Position.ToString ();

			} else if (hookTouchBool == false) {
				hookTouchBool = true;
				scoreLabel.Text = "Free";
			}







				if (hookTouchBool == false) {
					//Set values for spped and radius or rotation raound Pivot

				dRadius_X = ballSprite.PositionX - hookedPivotPosX;
				dRadius_Y = ballSprite.PositionY - hookedPivotPosY;

					Radius = Math.Pow ((double)dRadius_X, 2) + Math.Pow ((double)dRadius_Y, 2);
					Radius = Math.Pow (Radius, 0.5);


					ballSpeed = Math.Pow (ballXVelocity, 2) + Math.Pow (ballYVelocity, 2);
					ballSpeed = Math.Pow (ballSpeed, 0.5d);

					CosThetaZero = dRadius_X / Radius;
					SinThetaZero = dRadius_Y / Radius;

					CosAlpha = (dRadius_X * ballXVelocity + dRadius_Y * ballYVelocity) / (Radius * ballSpeed);

					if (Math.Pow (CosAlpha, 2) < 0.5) {
						CosAlpha = Math.Pow (0.5, 0.5);
					}
					SinAlpha = (1 - Math.Pow (CosAlpha, 2));
					SinAlpha = Math.Pow (SinAlpha, 0.5f);


					wZero = ballSpeed / Radius;
					ballSpeedFinal = Radius * Multiplier * wZero * SinAlpha;

					ThetaZero = Math.Acos (CosThetaZero);

					//Second Quadrant
					if (SinThetaZero > 0 && CosThetaZero < 0) {
						ThetaZero = (1 / 2) * Math.PI + ThetaZero;
					}
					//Third Quadrant
					if (SinThetaZero < 0 && CosThetaZero < 0) {
						ThetaZero = (2) * Math.PI - ThetaZero;
					}



					//Fourth Quadrant
					if (SinThetaZero < 0 && CosThetaZero > 0) {
						ThetaZero = -ThetaZero;
					}
					theta = ThetaZero;
					//Define if it is clockwise or anticlockwise rotation

					if (dRadius_X * ballYVelocity - dRadius_Y * ballXVelocity <= 0) {
						ClockwiseRotation = false;
						scoreLabel.Text += "ClockwiseRotation: false";
					} else {
						ClockwiseRotation = true;
						scoreLabel.Text += "ClockwiseRotation: true";

					}
				}
			
		}



		void freeParticle(float frameTimeInSeconds){
			gravity = 140;
			// This is a linear approximation, so not 100% accurate
			ballXVelocity += frameTimeInSeconds * gravity;
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

			//particle
		//	CCPoint ParticleBallPoint = new CCPoint (ballSprite.PositionX, ballSprite.PositionY);
			//BlueStella (ParticleBallPoint);

		}

		void hookedParticle(float frameTimeInSeconds){
			gravity = 0;

			// below is the iteration over time


			//ballSprite.PositionX =(float)(Radius*Math.Cos(theta) + pivotSprite.PositionX);
			//ballSprite.PositionY = (float)(Radius*Math.Sin(theta) + pivotSprite.PositionY);
			//ConsolePrint
//			Console.WriteLine( "\n Math.Sin({0} deg) == {1:E16}\n" + "Math.Cos({0} deg) == {2:E16}", Math.Sin(theta), Math.Cos(theta) );

			if (ClockwiseRotation == true) {
				theta+= (double)(Multiplier*wZero*SinAlpha*frameTimeInSeconds);

				ballXVelocity = (float)(-ballSpeedFinal * Math.Sin (theta));
				ballYVelocity = (float)(ballSpeedFinal * Math.Cos (theta));
							}
			else {
				theta-= (double)(Multiplier*wZero*SinAlpha*frameTimeInSeconds);

				ballXVelocity = (float)(ballSpeedFinal * Math.Sin (theta));
				ballYVelocity = (float)(-ballSpeedFinal * Math.Cos (theta));
										}
				/////////
		    ballSprite.PositionX =(float)(Radius*Math.Cos(theta) + hookedPivotPosX);
			ballSprite.PositionY = (float)(Radius*Math.Sin(theta) + hookedPivotPosY);

			//CCPoint ParticleBallPoint = new CCPoint (ballSprite.PositionX, ballSprite.PositionY);
		//	BlueStella (ParticleBallPoint);
		}




		void addBlueBall(CCWindow mainWindow){
			var bounds = mainWindow.WindowSizeInPixels;

			ballSprite = new CCSprite ("blueball");
			ballSprite.Scale = 0.0002f*bounds.Width;
			ballSprite.PositionX = 0.05f*bounds.Width;
			ballSprite.PositionY = 0.05f*bounds.Height;
		
			//particleEffetOnBall(ballSprite.PositionX,ballSprite.PositionY);
			mainLayer.AddChild (ballSprite);



		}
	

		CCSprite AddPivots (CCWindow mainWindow,float pivotPosX,float pivotPosY,float scale)
		{
			pivotSprite = new CCSprite ("pivot");
			pivotSprite.Scale = scale;
			pivotSprite.PositionX = pivotPosX;
			pivotSprite.PositionY = pivotPosY;
			var galaxy = new CCParticleGalaxy (pivotSprite.Position); //TODO: manage "better" for performance when "many" particles
			//galaxy.TotalParticles = 1;
			galaxy.AutoRemoveOnFinish = true;

			mainLayer.AddChild (galaxy);
			mainLayer.AddChild (pivotSprite);

			var CircleDraw = new CCDrawNode();
			var BlueColor = new CCColor4B (0, 0, 255, 1);
			/* DrawCircle(CCPoint, float, CCColor4B)
			)*/
			CircleDraw.DrawCircle (pivotSprite.Position, minRotationRadius,BlueColor);
			mainLayer.AddChild (CircleDraw);
			//////Particle effect

			return pivotSprite;
		}

	/*	void BlueStella (CCPoint pt)
		{
			var galaxy = new CCParticleFireworks (pt); //TODO: manage "better" for performance when "many" particles
			galaxy.TotalParticles = 1;
			galaxy.AutoRemoveOnFinish = true;
			AddChild (galaxy);
		}*/

		/*foreach (var banana in visibleBananas)
			{
				bool hit = banana.BoundingBoxTransformedToParent.IntersectsRect(monkey.BoundingBoxTransformedToParent);
				if (hit)
				{
					hitBananas.Add(banana);
					CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
					Explode(banana.Position);
					banana.RemoveFromParent();
				}
			}
*/
	



	}


}

