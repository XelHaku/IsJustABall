/*
float dRadius_X = ballSprite.PositionX- pivotSprite.PositionX;
float dRadius_Y = ballSprite.PositionY- pivotSprite.PositionY;
Math.Pow(value, power)
float Radius = Math.Pow(dRadius_X,2) + Math.Pow(dRadius_Y,2);
Radius = Math.Pow(Radius,0.5d);

float ballSpeed =Math.Pow(ballXVelocity,2) + Math.Pow(ballYVelocity,2);
ballSpeed = Math.pow(ballSpeed,0.5d);

float CosThetaZero = dRadius_X/Radius;
float SinThetaZero = dRadius_Y/Radius;

float CosAlpha =(dRadius_X*ballXVelocity + dRadius_Y*ballYVelocity)/(Radius*ballSpeed);

if( Math.Pow(CosAlpha,2) < 0.05){
	CosAlpha = (0.05)^(0.5);
	}
float SinAlpha = (1 - Math.Pow(CosAlpha,2);
	SinAlpha = Math.Pow(SinAlpha,0.5f);

double theta=0;
float Multiplier =1.0;
float wZero = ballSpeed/Radius;

float ballSpeedFinal = Radius*Multiplier*wZero*SinAlpha;

if(SinThetaZero <0){
	CosThetaZero = 2*Math.PI - CosThetaZero;
	}
//Above is calculated Once on Touch


// below is the iteration over time
theta = (double)(CosThetaZero + Multiplier*wZero*SinAlpha*frameTimeInSeconds);

ballSprite.PositionX = Radius*Math.Cos(theta) + pivotSprite.PositionX;
ballSprite.PositionY = Radius*Math.Sin(theta) + pivotSprite.PositionY;
//ConsolePrint
Console.WriteLine( "\n Math.Sin({0} deg) == {1:E16}\n" + "Math.Cos({0} deg) == {2:E16}", degrees, Math.Sin(theta), Math.Cos(theta) );

ballXVelocity = ballSpeedFinal*Math.Sin(theta);
ballYVelocity = ballSpeedFinal*Math.Cos(theta);




*/