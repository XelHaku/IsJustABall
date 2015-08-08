


	#region CHECK COLLISION
	//Remove jewel and and Score Counter
		void checkJewel(){
		foreach (var ruby in visibleJewels) {
			foreach (var ballPhysicsSingle in ballPhysicsList) {
				bool hit = ruby.BoundingBoxTransformedToParent.IntersectsRect (ballPhysicsSingle.ballSprite.BoundingBoxTransformedToParent);
				if (hit) {
					hitJewels.Add (ruby);
					//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
					//Explode(banana.Position);
					ruby.RemoveFromParent (true);
					visibleJewels.Remove (ruby);
					ballPhysicsSingle.score += 10;
					DisplayScore (ballPhysicsSingle.score);
					break;

				}
			}
		}

		}
	
		void checkTrap(){
			foreach (var spikeSprite in visibleTraps) {
				foreach (var ballPhysicsSingle in ballPhysicsList) {

					bool hit = spikeSprite.BoundingBoxTransformedToParent.IntersectsRect (ballPhysicsSingle.ballSprite.BoundingBoxTransformedToParent);
					if (hit) {


						//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
						Explode (spikeSprite.Position);
						spikeSprite.RemoveFromParent (true);
						visibleTraps.Remove (spikeSprite);


						//hitJewels.Add(ruby);
						//CCSimpleAudioEngine.SharedEngine.PlayEffect("Sounds/tap");
						//Explode(banana.Position);
						//ruby.RemoveFromParent();
						ballPhysicsSingle.score -= 50;
						DisplayScore (ballPhysicsSingle.score);

						//ShouldEndGame ();
						break;
					}
				}
				break;
			}

		}
		#endregion
	#region PARTICLE EFFECTS
		void Explode (CCPoint pt)
		{
			var explosion = new CCParticleExplosion (pt); //TODO: manage "better" for performance when "many" particles
			explosion.TotalParticles = 18;
			explosion.AutoRemoveOnFinish = true;
			mainLayer.AddChild (explosion);
		}

		#endregion
		//ENDGAME
		#region LEVEL HANDLERS
		void ShouldEndGame (){
			//if (score <= -100) {
				//EndGame ();
		//	}


		}
		void EndGame(){
			MainMenuScene gameScene = new MainMenuScene (mainWindowAux);
			mainWindowAux.RunWithScene (gameScene);

		}

		void DisplayScore(float score ){

			scoreLabel.Text = "Score: " + score;
			//
		}
		#endregion
	}

}




