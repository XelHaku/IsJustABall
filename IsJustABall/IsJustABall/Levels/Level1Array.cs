using System;

namespace IsJustABall
{
	public class Level1Array
	{//public void StartEngine() {/* Method statements here */ }
					public float[,]  PosArray(){
			float[,] PivotPosArray = new float[100,2];
			/*X UP TO DOWN*/            /*Y LEFT TO RIGHT*/      
			PivotPosArray[0,0] = 0.5f; PivotPosArray[0,1] =0.3f; 
			PivotPosArray[1,0] = 0.2f; PivotPosArray[1,1] =0.6f; 
			PivotPosArray[2,0] = 0.8f; PivotPosArray[2,1] =0.6f; 
			PivotPosArray[3,0] = 0.2f; PivotPosArray[3,1] =0.9f; 
			PivotPosArray[4,0] = 0.8f; PivotPosArray[4,1] =0.9f; 

			PivotPosArray[5,0] = 0.5f; PivotPosArray[5,1] =1.4f; 
			PivotPosArray[6,0] = 0.5f; PivotPosArray[6,1] =1.5f;
			PivotPosArray[7,0] = 0.2f; PivotPosArray[7,1] =1.5f;
			PivotPosArray[8,0] = 0.8f; PivotPosArray[8,1] =1.5f;
		/*	PivotPosArray[9,0] = 0.15f; PivotPosArray[9,1] =1.75f;
			PivotPosArray[10,0] = 0.85f; PivotPosArray[10,1] =1.75f;

			PivotPosArray[11,0] = 0.15f; PivotPosArray[11,1] =2.0f;
			PivotPosArray[12,0] = 0.85f; PivotPosArray[12,1] =2.0f;
			PivotPosArray[13,0] = 0.15f; PivotPosArray[13,1] =2.25f;
			PivotPosArray[14,0] = 0.85f; PivotPosArray[14,1] =2.25f;
			PivotPosArray[15,0] = 0.5f; PivotPosArray[15,1] =2.5f;
			PivotPosArray[16,0] = 0.15f; PivotPosArray[16,1] =2.75f;
			PivotPosArray[17,0] = 0.85f; PivotPosArray[17,1] =2.75f;
*/
			return PivotPosArray;
		              }

		public String[]  moveArray(){
			String[] PivotMoveType = new String[100]; 
			PivotMoveType [0] = "STATIC"; 
			PivotMoveType [1] = "STATIC";
			PivotMoveType [2] = "STATIC";
			PivotMoveType [3] = "UP";
			PivotMoveType [4] = "DOWN";
			PivotMoveType [5] = "LEFT"; 
			PivotMoveType [6] = "RIGHT";
			PivotMoveType [7] = "STATIC";
			PivotMoveType [8] = "STATIC";
			/*PivotMoveType [9] = "RIGHT";
			PivotMoveType [10] = "STATIC"; 
			PivotMoveType [12] = "UP";
			PivotMoveType [13] = "DOWN";
			PivotMoveType [13] = "LEFT";
			PivotMoveType [14] = "RIGHT";
			PivotMoveType [15] = "DOWN";
			PivotMoveType [16] = "LEFT";
			PivotMoveType [17] = "RIGHT";
*/
			return PivotMoveType;
		}

		////////JEWELS
		public float[,]  JewelPosArray(){
			float[,] JewelPosArray = new float[100,2];
			/*X UP TO DOWN*/            /*Y LEFT TO RIGHT*/      
			JewelPosArray[0,0] = 0.7f; JewelPosArray[0,1] =0.3f; 
			JewelPosArray[1,0] = 0.7f; JewelPosArray[1,1] =0.6f; 
			JewelPosArray[2,0] = 0.7f; JewelPosArray[2,1] =0.9f; 
			JewelPosArray[3,0] = 0.7f; JewelPosArray[3,1] =1.2f; 
			JewelPosArray[4,0] = 0.3f; JewelPosArray[4,1] =1.5f; 
			JewelPosArray[5,0] = 0.7f; JewelPosArray[5,1] =1.8f; 
			JewelPosArray[6,0] = 0.2f; JewelPosArray[6,1] =2.1f; 
			JewelPosArray[7,0] = 0.7f; JewelPosArray[7,1] =2.4f; 
			JewelPosArray[8,0] = 0.4f; JewelPosArray[8,1] =2.7f; 
			JewelPosArray[9,0] = 0.1f; JewelPosArray[9,1] =3.0f; 

			return JewelPosArray;
		
		}
}

}