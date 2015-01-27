
	void addGameBall(int playersCount){
		for (int i = 1; i <= playersCount; i++) {

			ballPhysics ballPhysicsSingle = new ballPhysics ();
			ballPhysicsSingle.index = i;
			ballPhysicsSingle.ballSprite= addBall (mainWindowAux, i);
			ballPhysicsSingle.ballXVelocity = 0;
			ballPhysicsSingle.ballYVelocity = 300;
			ballPhysicsSingle.hookTouchBool = true;
			ballPhysicsSingle.theta = 0;
			ballPhysicsSingle.ThetaZero = 0;
			ballPhysicsSingle.ClockwiseRotation = true;
			ballPhysicsList.Add (ballPhysicsSingle);

		}		
	}
