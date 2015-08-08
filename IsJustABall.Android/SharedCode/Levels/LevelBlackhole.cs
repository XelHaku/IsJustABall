﻿//http://programmers.stackexchange.com/questions/196579/storing-data-in-code
using System;
using CocosSharp;
using System.Collections.Generic;
using CocosDenshion;
using System.Linq;
namespace IsJustABall

{


	public class LevelBlackhole{
		//PIVOTS 
		#region PIVOT MAKER
			public class Pivot
		{
			public float PosX { get; set; }
			public float PosY { get; set; }
			public string MoveType { get; set; }

		}

	    public  List<Pivot> PivotMaker()
		{
		List<Pivot> PivotList = new List<Pivot>();
			PivotList.Add(new Pivot{ PosX =0.7f, PosY =0.3f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.2f, PosY =0.6f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.8f, PosY =1f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.2f, PosY =1.4f, MoveType = "DOWN" });
			PivotList.Add(new Pivot{ PosX =0.8f, PosY =1.8f, MoveType = "UP" });
			PivotList.Add(new Pivot{ PosX =0.5f, PosY =2f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.2f, PosY =2.5f, MoveType = "DOWN" });
			PivotList.Add(new Pivot{ PosX =0.1f, PosY =2.9f, MoveType = "RIGHT" });
			PivotList.Add(new Pivot{ PosX =0.9f, PosY =3f, MoveType = "RIGHT" });
			PivotList.Add(new Pivot{ PosX =0.3f, PosY =3.7f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.7f, PosY =3.7f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.2f, PosY =4.6f, MoveType = "DOWN" });
			PivotList.Add(new Pivot{ PosX =0.2f, PosY =5.3f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.9f, PosY =5.6f, MoveType = "UP" });
			PivotList.Add(new Pivot{ PosX =0.8f, PosY =6.3f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.8f, PosY =6.9f, MoveType = "UP" });
			PivotList.Add(new Pivot{ PosX =0.2f, PosY =7.1f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.8f, PosY =7.1f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.2f, PosY =7.7f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.8f, PosY =7.7f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.5f, PosY =7.8f, MoveType = "RIGHT" });
			PivotList.Add(new Pivot{ PosX =0.5f, PosY =8.8f, MoveType = "LEFT" });
			PivotList.Add(new Pivot{ PosX =0.8f, PosY =9.3f, MoveType = "UP" });
			PivotList.Add(new Pivot{ PosX =0.2f, PosY =9.9f, MoveType = "DOWN" });
			PivotList.Add(new Pivot{ PosX =0.3f, PosY =10.5f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.8f, PosY =10.5f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.3f, PosY =11.2f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.6f, PosY =11.2f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.2f, PosY =11.9f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.8f, PosY =11.9f, MoveType = "STATIC" });


			/*STATIC
			RIGHT
			LEFT
			UP 
		    DOWN
				new Pivot { PosX = 0.5f, PosY = 0.3f, MoveType = "STATIC" },
			new Pivot { PosX = 0.2f, PosY = 0.6f, MoveType = "STATIC" },
			new Pivot { PosX = 0.8f, PosY = 0.6f, MoveType = "STATIC" },
			new Pivot { PosX = 0.2f, PosY = 0.9f, MoveType = "UP" },
			new Pivot { PosX = 0.8f, PosY = 0.9f, MoveType = "DOWN" },
			new Pivot { PosX = 0.5f, PosY = 1.4f, MoveType = "LEFT" },
			new Pivot { PosX = 0.5f, PosY = 1.5f, MoveType = "RIGHT" },
			new Pivot { PosX = 0.2f, PosY = 1.5f, MoveType = "STATIC" },
			new Pivot { PosX = 0.8f, PosY = 1.5f, MoveType = "STATIC" },
			new Pivot { PosX = 0.15f, PosY = 1.75f, MoveType = "RIGHT" },
			new Pivot { PosX = 0.85f, PosY = 1.75f, MoveType = "STATIC" },
			new Pivot { PosX = 0.15f, PosY = 2.0f, MoveType = "UP" },
			new Pivot { PosX = 0.85f, PosY = 2.0f, MoveType = "DOWN" },
			new Pivot { PosX = 0.15f, PosY = 2.25f, MoveType = "LEFT" },
			new Pivot { PosX = 0.85f, PosY = 2.25f, MoveType = "RIGHT" },
			new Pivot { PosX = 0.5f, PosY = 2.5f, MoveType = "DOWN" },
			new Pivot { PosX = 0.15f, PosY = 2.75f, MoveType = "LEFT" },
			new Pivot { PosX = 0.85f, PosY = 2.75f, MoveType = "RIGHT" }
*/			return PivotList;
						}
		#endregion PIVOT MAKER
		//JEWELS
		#region JEWEL MAKER
		public class Jewel
		{
			public float PosX { get; set; }
			public float PosY { get; set; }
			public string JewelType { get; set; }

		}

		public  List<Jewel> JewelMaker()
		{
			List<Jewel> JewelList = new List<Jewel>();

			JewelList.Add(new Jewel{ PosX =0f, PosY =5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =5.1f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =5.8f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =5.9f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.3f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.3f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.8f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.8f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.9f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.9f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =1.5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =1.5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =1.5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =1.5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =1.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =1.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =1.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =1.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =1.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =1.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =1.9f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =2f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =2f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =2.1f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =2.8f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =2.9f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =2.9f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =2.9f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =3f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =3f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =3f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =3f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =3.1f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =3.1f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =3.1f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =3.2f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =3.2f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =3.2f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =3.2f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =3.3f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =3.3f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =3.3f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =3.4f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =3.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =3.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =3.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =3.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =3.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =3.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =3.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =3.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =3.8f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =3.9f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =4f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =4.1f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =4.1f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =4.1f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =4.2f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =4.2f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =4.8f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =4.9f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =1f, PosY =6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =6.1f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =7.9f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =8.4f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =8.5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =8.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =8.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =8.8f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =8.9f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =8.4f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =8.5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =8.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =8.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =8.8f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =8.9f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =8.2f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =8.3f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =8.4f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =8.5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =8.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =8.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =8.2f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =8.3f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =8.4f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =8.5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =8.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =9.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =8.1f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =8.3f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =8.5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =8.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =8.9f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =9.4f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =9.5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =9.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =9.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =9.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =9.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =9.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =10f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =10.1f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =10.2f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =10.2f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =10.2f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =10.3f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =10.4f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =10.4f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =10.5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =10.5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =10.5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =10.5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =10.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =10.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =10.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =10.8f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =10.9f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =10.9f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =10.9f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =11f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =11.1f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =11.4f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =11.45f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =11.5f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =11.55f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =11.6f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =11.65f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =11.7f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =11.75f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =11.8f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =11.8f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =11.8f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =11.75f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =11.75f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =11.75f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =11.75f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =11.75f, JewelType = "RUBY" });
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =11.75f, JewelType = "RUBY" });


			JewelList.Add (new Jewel { PosX = 0.5f, PosY = 12.3f, JewelType = "DIAMOND" });



			return JewelList;
		}
		#endregion JEWEL MAKER
		//SPIKES
		#region SPIKES MAKER
		public class Spike
		{
			public float PosX { get; set; }
			public float PosY { get; set; }
			public string MoveType { get; set; }

		}

		public  List<Spike> SpikeMaker()
		{
			List<Spike> SpikeList = new List<Spike>();
					SpikeList.Add(new Spike{ PosX =0.2f, PosY =1.6f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.8f, PosY =1.6f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.4f, PosY =2.3f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.6f, PosY =2.3f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.1f, PosY =2.7f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.9f, PosY =2.8f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.2f, PosY =4f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.8f, PosY =4f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.2f, PosY =4.1f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.8f, PosY =4.1f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.2f, PosY =4.9f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.2f, PosY =4.9f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.3f, PosY =4.9f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.4f, PosY =4.9f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.9f, PosY =5f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.6f, PosY =5.2f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.7f, PosY =5.2f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.8f, PosY =5.2f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.9f, PosY =5.2f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.6f, PosY =5.9f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.7f, PosY =5.9f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.8f, PosY =5.9f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.9f, PosY =5.9f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.1f, PosY =6f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.3f, PosY =6.9f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.7f, PosY =6.9f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.4f, PosY =7f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.6f, PosY =7f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.1f, PosY =7.3f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.2f, PosY =7.3f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.3f, PosY =7.3f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.7f, PosY =7.3f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.8f, PosY =7.3f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.9f, PosY =7.3f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.8f, PosY =7.9f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.9f, PosY =7.9f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.1f, PosY =8.1f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.2f, PosY =8.1f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.2f, PosY =9.5f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.8f, PosY =9.5f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.2f, PosY =9.6f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.8f, PosY =9.6f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.5f, PosY =10.1f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.5f, PosY =10.2f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.8f, PosY =10.1f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.8f, PosY =10.2f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.2f, PosY =10.8f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.2f, PosY =10.9f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.5f, PosY =10.8f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.5f, PosY =10.9f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.4f, PosY =11.6f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.5f, PosY =11.6f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.6f, PosY =11.6f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.7f, PosY =11.6f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.8f, PosY =11.6f, MoveType = "STATIC" });
					SpikeList.Add(new Spike{ PosX =0.5f, PosY =11.9f, MoveType = "STATIC" });

			return SpikeList;
		}

		#endregion

		#region WALL MAKER
		public class Wall
		{
			public float PosX { get; set; }
			public float PosY { get; set; }
			public string MoveType { get; set; }

		}

		public  List<Wall> WallMaker()
		{
			List<Wall> WallList = new List<Wall>();
					WallList.Add(new Wall{ PosX =0f, PosY =4f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.1f, PosY =4f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.3f, PosY =4f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.4f, PosY =4f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.6f, PosY =4f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.7f, PosY =4f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.9f, PosY =4f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =1f, PosY =4f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0f, PosY =4.05f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.1f, PosY =4.05f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.3f, PosY =4.05f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.4f, PosY =4.05f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.6f, PosY =4.05f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.7f, PosY =4.05f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.9f, PosY =4.05f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =1f, PosY =4.05f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0f, PosY =4.95f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.1f, PosY =4.95f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.2f, PosY =4.95f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.3f, PosY =4.95f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.4f, PosY =4.95f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.5f, PosY =4.95f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.6f, PosY =4.95f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.3f, PosY =5.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.4f, PosY =5.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.5f, PosY =5.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.6f, PosY =5.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.7f, PosY =5.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.8f, PosY =5.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.9f, PosY =5.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =1f, PosY =5.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.4f, PosY =5.95f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.5f, PosY =5.95f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.6f, PosY =5.95f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.7f, PosY =5.95f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.8f, PosY =5.95f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.9f, PosY =5.95f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =1f, PosY =5.95f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0f, PosY =6.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.1f, PosY =6.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.2f, PosY =6.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.3f, PosY =6.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.4f, PosY =6.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.5f, PosY =6.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.6f, PosY =6.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.7f, PosY =6.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.2f, PosY =6.8f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.3f, PosY =6.8f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.4f, PosY =6.8f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.5f, PosY =6.8f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.6f, PosY =6.8f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.7f, PosY =6.8f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.8f, PosY =6.8f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0f, PosY =9.5f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.1f, PosY =9.5f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.3f, PosY =9.5f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.4f, PosY =9.5f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.6f, PosY =9.5f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.7f, PosY =9.5f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.9f, PosY =9.5f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =1f, PosY =9.5f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0f, PosY =9.55f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.1f, PosY =9.55f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.3f, PosY =9.55f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.4f, PosY =9.55f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.6f, PosY =9.55f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.7f, PosY =9.55f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.9f, PosY =9.55f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =1f, PosY =9.55f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0f, PosY =10.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.1f, PosY =10.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.3f, PosY =10.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.4f, PosY =10.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.6f, PosY =10.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.7f, PosY =10.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.9f, PosY =10.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =1f, PosY =10.1f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0f, PosY =10.15f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.1f, PosY =10.15f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.3f, PosY =10.15f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.4f, PosY =10.15f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.6f, PosY =10.15f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.7f, PosY =10.15f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.9f, PosY =10.15f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =1f, PosY =10.15f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0f, PosY =10.8f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.1f, PosY =10.8f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.3f, PosY =10.8f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.4f, PosY =10.8f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.6f, PosY =10.8f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.7f, PosY =10.8f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.9f, PosY =10.8f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =1f, PosY =10.8f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0f, PosY =10.85f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.1f, PosY =10.85f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.3f, PosY =10.85f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.4f, PosY =10.85f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.6f, PosY =10.85f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.7f, PosY =10.85f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.9f, PosY =10.85f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =1f, PosY =10.85f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.2f, PosY =11.6f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.3f, PosY =11.6f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.2f, PosY =11.65f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.3f, PosY =11.65f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.4f, PosY =11.65f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.5f, PosY =11.65f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.6f, PosY =11.65f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.7f, PosY =11.65f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.8f, PosY =11.65f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.2f, PosY =11.7f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.3f, PosY =11.7f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.4f, PosY =11.7f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.5f, PosY =11.7f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.6f, PosY =11.7f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.7f, PosY =11.7f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.8f, PosY =11.7f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.2f, PosY =11.75f, MoveType = "STATIC" });
					WallList.Add(new Wall{ PosX =0.3f, PosY =11.75f, MoveType = "STATIC" });


		
			return WallList;
		}

		#endregion
		#region blackhole MAKER
		public class Blackhole
		{
			public float PosX { get; set; }
			public float PosY { get; set; }
			public string MoveType { get; set; }

		}

		public  List<Blackhole> BlackholeMaker()
		{
			List<Blackhole> BlackholeList = new List<Blackhole>();
			BlackholeList.Add(new Blackhole{ PosX =0.5f, PosY =0.8f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.5f, PosY =1.6f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.3f, PosY =2.8f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.7f, PosY =3f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.3f, PosY =3.2f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.7f, PosY =3.4f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.5f, PosY =4.2f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.7f, PosY =4.9f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.3f, PosY =5.9f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.5f, PosY =6.9f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.2f, PosY =7.5f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.8f, PosY =7.5f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.8f, PosY =8f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.2f, PosY =8.2f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.8f, PosY =8.9f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.2f, PosY =9.1f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.5f, PosY =9.7f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.2f, PosY =10.3f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.8f, PosY =11f, MoveType = "STATIC" });
			BlackholeList.Add(new Blackhole{ PosX =0.2f, PosY =11.5f, MoveType = "STATIC" });

			return BlackholeList;
		}

		#endregion
		#region GENERAL MAKER
		public class GENERAL
		{
			public float PosX { get; set; }
			public float PosY { get; set; }
			public string MoveType { get; set; }

		}

		public  List<GENERAL> GENERALMaker()
		{
			List<GENERAL> GENERALList = new List<GENERAL>();
			GENERALList.Add ( new GENERAL { PosX = 0.5f, PosY = 0.6f, MoveType = "STATIC" });
			return GENERALList;
		}

		#endregion
		/*
		#region Diamond
		public class Emerald
		{
			public float PosX { get; set; }
			public float PosY { get; set; }
			public string JewelType { get; set; }

		}

		public  Emerald EmeraldMaker()
		{
			//List<Emerald> EmeraldList = new List<Emerald>();
			//EmeraldList.Add (new Jewel { PosX = 0.5f, PosY = 1.2f, JewelType = "DIAMOND" });

			Emerald EmeraldPoint = new Emerald();
			EmeraldPoint.PosX = 0.5f;
			EmeraldPoint.PosY = 1.5f;
			EmeraldPoint.JewelType = "DIAMOND" ;

			return EmeraldPoint;
		}

		#endregion
*/
	}
}

