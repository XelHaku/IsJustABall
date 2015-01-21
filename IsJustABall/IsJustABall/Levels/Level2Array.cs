//http://programmers.stackexchange.com/questions/196579/storing-data-in-code
using System;
using CocosSharp;
using System.Collections.Generic;
using CocosDenshion;
using System.Linq;
namespace IsJustABall

{


	public class Level2Array{
		//PIVOTS
			public class Pivot
		{
			public float PosX { get; set; }
			public float PosY { get; set; }
			public string MoveType { get; set; }

		}

	    public  List<Pivot> PivotMaker()
		{
		List<Pivot> PivotList = new List<Pivot>();
			PivotList.Add ( new Pivot { PosX = 0.5f, PosY = 0.3f, MoveType = "STATIC" });
			PivotList.Add( new Pivot { PosX = 0.2f, PosY = 0.6f, MoveType = "STATIC" } );
			/*	new Pivot { PosX = 0.5f, PosY = 0.3f, MoveType = "STATIC" },
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

		//JEWELS
		public class Jewel
		{
			public float PosX { get; set; }
			public float PosY { get; set; }
			public string JewelType { get; set; }

		}

		public  List<Jewel> JewelMaker()
		{
			List<Jewel> JewelList = new List<Jewel>();
			JewelList.Add ( new Jewel { PosX = 0.5f, PosY = 0.1f, JewelType = "RUBY" });
			JewelList.Add (new Jewel { PosX = 0.5f, PosY = 0.3f, JewelType = "RUBY" });
			JewelList.Add (new Jewel { PosX = 0.5f, PosY = 0.7f, JewelType = "DIAMOND" });
			/*	new Pivot { PosX = 0.5f, PosY = 0.3f, MoveType = "STATIC" },
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
*/			return JewelList;
		}

		//SPIKES

		public class Spike
		{
			public float PosX { get; set; }
			public float PosY { get; set; }
			public string MoveType { get; set; }

		}

		public  List<Spike> SpikeMaker()
		{
			List<Spike> SpikeList = new List<Spike>();
			SpikeList.Add ( new Spike { PosX = 0.5f, PosY = 0.5f, MoveType = "STATIC" });
			SpikeList.Add( new Spike { PosX = 0.5f, PosY = 0.8f, MoveType = "STATIC" } );
			/*	

*/			return SpikeList;
		}
	}
}


