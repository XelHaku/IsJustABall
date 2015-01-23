using System;
using CocosSharp;
namespace IsJustABall
{
	public class ballPhysics
	{		  
			public int index{ get; set; }
		public CCSprite ballSprite{ get; set; }

		public float PosY { get; set; }
			public string MoveType { get; set; }

			public	float ballXVelocity { get; set; }
			public	float ballYVelocity { get; set; }
			//hookTouchBool=!hookTouchBool// to toggle on Touch
			public	bool hookTouchBool { get; set; }
			//Speed for scroller level

			//Declare variables for HookedParticle Method
			    public double dRadius_X{ get; set; }
				public double dRadius_Y{ get; set; }
				public double Radius { get; set; }
				public double temp{ get; set; }
				public double ballSpeed{ get; set; }
				public double SinThetaZero{ get; set; }
				public double CosThetaZero{ get; set; }
				public double CosAlpha{ get; set; }
				public double SinAlpha{ get; set; }
				public double theta{ get; set; }
				public double ThetaZero{ get; set; }
				public double Multiplier { get; set; }
				public double wZero{ get; set; }
				public double ballSpeedFinal{ get; set; }
				public bool ClockwiseRotation{ get; set; }
				public float minRotationRadius{ get; set; }
			/// //////////////////
			//needed for multiple Pivots

			public int indexHookPivot;
		public int score;
		
	}
}

