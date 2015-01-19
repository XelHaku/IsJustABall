using System;

namespace IsJustABall
{
	public class Level1Array
	{//public void StartEngine() {/* Method statements here */ }
					public float[,]  PosArray(){
			float[,] PivotPosArray = new float[100,2];
			PivotPosArray[0,0] = 0.5f; PivotPosArray[0,1] =0.25f; 
			PivotPosArray[1,0] = 0.15f; PivotPosArray[1,1] =0.5f; 
			PivotPosArray[2,0] = 0.85f; PivotPosArray[2,1] =0.5f; 
			PivotPosArray[3,0] = 0.5f; PivotPosArray[3,1] =0.75f; 
			PivotPosArray[4,0] = 0.15f; PivotPosArray[4,1] =1.0f; 
			PivotPosArray[5,0] = 0.85f; PivotPosArray[5,1] =1.0f; 
			PivotPosArray[6,0] = 0.15f; PivotPosArray[6,1] =1.25f;
			PivotPosArray[7,0] = 0.85f; PivotPosArray[7,1] =1.25f;
			PivotPosArray[8,0] = 0.5f; PivotPosArray[8,1] =1.5f;
			PivotPosArray[9,0] = 0.15f; PivotPosArray[9,1] =1.75f;
			PivotPosArray[10,0] = 0.85f; PivotPosArray[10,1] =1.75f;

			PivotPosArray[11,0] = 0.15f; PivotPosArray[11,1] =2.0f;
			PivotPosArray[12,0] = 0.85f; PivotPosArray[12,1] =2.0f;
			PivotPosArray[13,0] = 0.15f; PivotPosArray[13,1] =2.25f;
			PivotPosArray[14,0] = 0.85f; PivotPosArray[14,1] =2.25f;
			PivotPosArray[15,0] = 0.5f; PivotPosArray[15,1] =2.5f;
			PivotPosArray[16,0] = 0.15f; PivotPosArray[16,1] =2.75f;
			PivotPosArray[17,0] = 0.85f; PivotPosArray[17,1] =2.75f;

			return PivotPosArray;
		              }

		public String[]  moveArray(){
			String[] PivotMoveType = new String[100]; 
			PivotMoveType [0] = "STATIC"; 
			PivotMoveType [1] = "UP";
			PivotMoveType [2] = "DOWN";
			PivotMoveType [3] = "LEFT";
			PivotMoveType [4] = "RIGHT";
			PivotMoveType [5] = "STATIC"; 
			PivotMoveType [6] = "UP";
			PivotMoveType [7] = "DOWN";
			PivotMoveType [8] = "LEFT";
			PivotMoveType [9] = "RIGHT";
			PivotMoveType [10] = "STATIC"; 
			PivotMoveType [12] = "UP";
			PivotMoveType [13] = "DOWN";
			PivotMoveType [13] = "LEFT";
			PivotMoveType [14] = "RIGHT";
			PivotMoveType [15] = "DOWN";
			PivotMoveType [16] = "LEFT";
			PivotMoveType [17] = "RIGHT";

			return PivotMoveType;
		}
		
		
		
		}
}

