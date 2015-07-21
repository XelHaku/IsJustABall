//http://programmers.stackexchange.com/questions/196579/storing-data-in-code
using System;
using CocosSharp;
using System.Collections.Generic;
using CocosDenshion;
using System.Linq;
namespace IsJustABall

{


	public class LevelTestGrounds{
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
			//0
			PivotList.Add ( new Pivot { PosX = 0.5f, PosY = 0.3f, MoveType = "STATIC" });
			PivotList.Add( new Pivot { PosX = 0.2f, PosY = 0.6f, MoveType = "STATIC" } );
			PivotList.Add( new Pivot { PosX = 0.8f, PosY = 0.6f, MoveType = "STATIC" } );
			PivotList.Add( new Pivot { PosX = 0.2f, PosY = 0.9f, MoveType = "DOWN" } );
			PivotList.Add( new Pivot { PosX = 0.8f, PosY = 0.9f, MoveType = "UP" } );
			//1
			PivotList.Add( new Pivot { PosX = 0.5f, PosY =1.4f, MoveType = "LEFT" } );
			PivotList.Add( new Pivot { PosX = 0.5f, PosY = 1.5f, MoveType = "RIGHT" } );
			PivotList.Add( new Pivot { PosX = 0.2f, PosY =1.5f, MoveType = "STATIC" } );
			PivotList.Add( new Pivot { PosX = 0.8f, PosY =1.5f, MoveType = "STATIC" } );
			//2
			PivotList.Add( new Pivot { PosX = 0.2f, PosY =2.0f, MoveType = "STATIC" } );
			PivotList.Add( new Pivot { PosX = 0.2f, PosY =2.3f, MoveType = "STATIC" } );
			PivotList.Add( new Pivot { PosX = 0.2f, PosY =2.6f, MoveType = "STATIC" } );
			PivotList.Add( new Pivot { PosX = 0.2f, PosY =2.9f, MoveType = "STATIC" } );
			//3
			PivotList.Add( new Pivot { PosX = 0.8f, PosY =3.1f, MoveType = "STATIC" } );
			PivotList.Add( new Pivot { PosX = 0.8f, PosY =3.4f, MoveType = "STATIC" } );
			PivotList.Add( new Pivot { PosX = 0.8f, PosY =3.7f, MoveType = "STATIC" } );
			//4
			PivotList.Add( new Pivot { PosX = 0.8f, PosY =4.0f, MoveType = "STATIC" } );
			PivotList.Add( new Pivot { PosX = 0.2f, PosY =4.2f, MoveType = "STATIC" } );
			PivotList.Add( new Pivot { PosX = 0.8f, PosY =4.5f, MoveType = "STATIC" } );
			PivotList.Add( new Pivot { PosX = 0.2f, PosY =4.8f, MoveType = "STATIC" } );
			//5
			PivotList.Add( new Pivot { PosX = 0.1f, PosY =5.1f, MoveType = "DOWN" } );
			PivotList.Add( new Pivot { PosX = 0.8f, PosY =5.4f, MoveType = "STATIC" } );
			PivotList.Add( new Pivot { PosX = 0.1f, PosY =5.7f, MoveType = "STATIC" } );
			//6
			PivotList.Add( new Pivot { PosX = 0.1f, PosY =6.0f, MoveType = "DOWN" } );
			PivotList.Add( new Pivot { PosX = 0.8f, PosY =6.3f, MoveType = "STATIC" } );
			PivotList.Add( new Pivot { PosX = 0.5f, PosY =6.6f, MoveType = "STATIC" } );
			//7
			PivotList.Add( new Pivot { PosX = 0.3f, PosY =7.0f, MoveType = "RIGHT" } );
			PivotList.Add( new Pivot { PosX = 0.7f, PosY =7.0f, MoveType = "LEFT" } );
			PivotList.Add( new Pivot { PosX = 0.3f, PosY =7.8f, MoveType = "LEFT" } );
			PivotList.Add( new Pivot { PosX = 0.7f, PosY =7.0f, MoveType = "RIGHT" } );
			//8
			PivotList.Add( new Pivot { PosX = 0.2f, PosY =8.2f, MoveType = "DOWN" } );
			PivotList.Add( new Pivot { PosX = 0.8f, PosY =8.6f, MoveType = "UP" } );
			//9
			PivotList.Add( new Pivot { PosX = 0.2f, PosY =9.0f, MoveType = "DOWN" } );
			PivotList.Add( new Pivot { PosX = 0.8f, PosY =9.4f, MoveType = "UP" } );
			PivotList.Add( new Pivot { PosX = 0.5f, PosY =9.7f, MoveType = "STATIC" } );
			//10


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
			JewelList.Add (new Jewel { PosX = 0.3f, PosY = 0.3f, JewelType = "RUBY" });


			JewelList.Add (new Jewel { PosX = 0.5f, PosY = 10.3f, JewelType = "DIAMOND" });



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

			SpikeList.Add ( new Spike { PosX = 0.8f, PosY = 9.2f, MoveType = "STATIC" });
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

			WallList.Add ( new Wall { PosX = 0.4f, PosY = 0.8f, MoveType = "STATIC" });

		
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
			BlackholeList.Add ( new Blackhole { PosX = 0.5f, PosY = 0.6f, MoveType = "STATIC" });
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


