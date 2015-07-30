//http://programmers.stackexchange.com/questions/196579/storing-data-in-code
using System;
using CocosSharp;
using System.Collections.Generic;
using CocosDenshion;
using System.Linq;


namespace IsJustABall
{
	public class Multi4Level1
	{
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
			PivotList.Add(new Pivot{ PosX =0.2f, PosY =0.2f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.2f, PosY =0.8f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.8f, PosY =0.2f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.8f, PosY =0.8f, MoveType = "STATIC" });
			PivotList.Add(new Pivot{ PosX =0.2f, PosY =0.5f, MoveType = "DOWN" });
	


		return PivotList;
		}
		#endregion PIVOT MAKER
		//JEWELS
		#region JEWEL MAKER
		public class Jewel
		{
			public float PosX { get; set; }
			public float PosY { get; set; }
			public string JewelType { get; set; }
			public float Time { get; set; }
			public bool Displayed { get; set; }
		}

		public  List<Jewel> JewelMaker()
		{
			List<Jewel> JewelList = new List<Jewel>();
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.2f, JewelType = "RUBY", Time = 0.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.8f, JewelType = "RUBY", Time = 0.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.15f, JewelType = "RUBY", Time = 0.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.25f, JewelType = "RUBY", Time = 0.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.75f, JewelType = "RUBY", Time = 0.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.85f, JewelType = "RUBY", Time = 0.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.2f, JewelType = "RUBY", Time = 0.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.8f, JewelType = "RUBY", Time = 0.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.2f, JewelType = "RUBY", Time = 0.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.8f, JewelType = "RUBY", Time = 0.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.15f, JewelType = "RUBY", Time = 0.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.25f, JewelType = "RUBY", Time = 0.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.75f, JewelType = "RUBY", Time = 0.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.85f, JewelType = "RUBY", Time = 0.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.2f, JewelType = "RUBY", Time = 0.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.8f, JewelType = "RUBY", Time = 0.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.5f, JewelType = "RUBY", Time = 5.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.45f, JewelType = "RUBY", Time = 5.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.55f, JewelType = "RUBY", Time = 5.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.5f, JewelType = "RUBY", Time = 5.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.2f, JewelType = "RUBY", Time = 5.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.8f, JewelType = "RUBY", Time = 5.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.15f, JewelType = "RUBY", Time = 5.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.25f, JewelType = "RUBY", Time = 5.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.75f, JewelType = "RUBY", Time = 5.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.85f, JewelType = "RUBY", Time = 5.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.5f, JewelType = "RUBY", Time = 5.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.45f, JewelType = "RUBY", Time = 5.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.55f, JewelType = "RUBY", Time = 5.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.5f, JewelType = "RUBY", Time = 5.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.1f, JewelType = "RUBY", Time = 10.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.2f, JewelType = "RUBY", Time = 10.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.3f, JewelType = "RUBY", Time = 10.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.15f, JewelType = "RUBY", Time = 10.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.25f, JewelType = "RUBY", Time = 10.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.1f, JewelType = "RUBY", Time = 10.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.2f, JewelType = "RUBY", Time = 10.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.3f, JewelType = "RUBY", Time = 10.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.9f, JewelType = "RUBY", Time = 10.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.8f, JewelType = "RUBY", Time = 10.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.7f, JewelType = "RUBY", Time = 10.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.85f, JewelType = "RUBY", Time = 10.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.75f, JewelType = "RUBY", Time = 10.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.7f, JewelType = "RUBY", Time = 10.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.8f, JewelType = "RUBY", Time = 10.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.9f, JewelType = "RUBY", Time = 10.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.9f, JewelType = "RUBY", Time = 15.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.8f, JewelType = "RUBY", Time = 15.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.7f, JewelType = "RUBY", Time = 15.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.85f, JewelType = "RUBY", Time = 15.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.75f, JewelType = "RUBY", Time = 15.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.9f, JewelType = "RUBY", Time = 15.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.8f, JewelType = "RUBY", Time = 15.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.7f, JewelType = "RUBY", Time = 15.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.1f, JewelType = "RUBY", Time = 15.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.2f, JewelType = "RUBY", Time = 15.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.3f, JewelType = "RUBY", Time = 15.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.15f, JewelType = "RUBY", Time = 15.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.25f, JewelType = "RUBY", Time = 15.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.3f, JewelType = "RUBY", Time = 15.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.2f, JewelType = "RUBY", Time = 15.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.1f, JewelType = "RUBY", Time = 15.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.4f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.4f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.4f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.4f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.4f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.4f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.5f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.5f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.5f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.5f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.5f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.5f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.6f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.6f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.6f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.6f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.6f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.6f, JewelType = "RUBY", Time = 20.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.1f, JewelType = "RUBY", Time = 25.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.2f, JewelType = "RUBY", Time = 25.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.3f, JewelType = "RUBY", Time = 25.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.15f, JewelType = "RUBY", Time = 25.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.25f, JewelType = "RUBY", Time = 25.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.1f, JewelType = "RUBY", Time = 25.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.2f, JewelType = "RUBY", Time = 25.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.3f, JewelType = "RUBY", Time = 25.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.9f, JewelType = "RUBY", Time = 30.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.8f, JewelType = "RUBY", Time = 30.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.7f, JewelType = "RUBY", Time = 30.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.85f, JewelType = "RUBY", Time = 30.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.75f, JewelType = "RUBY", Time = 30.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.7f, JewelType = "RUBY", Time = 30.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.8f, JewelType = "RUBY", Time = 30.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.9f, JewelType = "RUBY", Time = 30.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.9f, JewelType = "RUBY", Time = 35.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.8f, JewelType = "RUBY", Time = 35.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.7f, JewelType = "RUBY", Time = 35.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.85f, JewelType = "RUBY", Time = 35.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.75f, JewelType = "RUBY", Time = 35.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.9f, JewelType = "RUBY", Time = 35.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.8f, JewelType = "RUBY", Time = 35.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.7f, JewelType = "RUBY", Time = 35.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.1f, JewelType = "RUBY", Time = 40.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.2f, JewelType = "RUBY", Time = 40.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.3f, JewelType = "RUBY", Time = 40.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.15f, JewelType = "RUBY", Time = 40.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.25f, JewelType = "RUBY", Time = 40.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.3f, JewelType = "RUBY", Time = 40.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.2f, JewelType = "RUBY", Time = 40.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.1f, JewelType = "RUBY", Time = 40.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.3f, JewelType = "RUBY", Time = 45.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.4f, JewelType = "RUBY", Time = 45.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.5f, JewelType = "RUBY", Time = 45.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.6f, JewelType = "RUBY", Time = 45.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.7f, JewelType = "RUBY", Time = 45.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.3f, JewelType = "RUBY", Time = 45.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.4f, JewelType = "RUBY", Time = 45.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.5f, JewelType = "RUBY", Time = 45.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.6f, JewelType = "RUBY", Time = 45.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.7f, JewelType = "RUBY", Time = 45.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.2f, JewelType = "RUBY", Time = 45.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.2f, JewelType = "RUBY", Time = 45.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.2f, JewelType = "RUBY", Time = 45.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.8f, JewelType = "RUBY", Time = 45.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.8f, JewelType = "RUBY", Time = 45.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.8f, JewelType = "RUBY", Time = 45.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.3f, JewelType = "RUBY", Time = 50.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.7f, JewelType = "RUBY", Time = 50.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.4f, JewelType = "RUBY", Time = 50.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.6f, JewelType = "RUBY", Time = 50.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.5f, JewelType = "RUBY", Time = 50.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.4f, JewelType = "RUBY", Time = 50.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.6f, JewelType = "RUBY", Time = 50.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.3f, JewelType = "RUBY", Time = 50.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.7f, JewelType = "RUBY", Time = 50.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.1f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.2f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.3f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.15f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.25f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.1f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.2f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.3f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.9f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.8f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.7f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.85f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.75f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.7f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.8f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.9f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.9f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.8f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.7f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.85f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.75f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.9f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.8f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.7f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.1f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.2f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.3f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.15f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.25f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.3f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.2f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.1f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.4f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.5f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.6f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.4f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.5f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.6f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.45f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.55f, JewelType = "RUBY", Time = 55.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.3f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.4f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.5f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.6f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.7f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.3f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.4f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.5f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.6f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.7f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.2f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.2f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.2f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.8f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.8f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.8f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.3f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.7f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.4f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.6f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.5f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.4f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.6f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.3f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.7f, JewelType = "RUBY", Time = 60.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.1f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.2f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.3f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.15f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.25f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.1f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.2f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.3f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.9f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.8f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.7f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.85f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.75f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.7f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.8f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.9f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.9f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.8f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.7f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.85f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.75f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.9f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.8f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.7f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.1f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.2f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.3f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.15f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.25f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.3f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.2f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.1f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.4f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.5f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.6f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.4f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.5f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.6f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.45f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.55f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.4f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.5f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.1f, PosY =0.6f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.45f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.2f, PosY =0.55f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.4f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.5f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.3f, PosY =0.6f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.1f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.2f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.3f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.7f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.8f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.4f, PosY =0.9f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.1f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.2f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.3f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.7f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.8f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.6f, PosY =0.9f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.15f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.25f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.85f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.25f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.4f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.5f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.7f, PosY =0.6f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.45f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.8f, PosY =0.55f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.4f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.5f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.9f, PosY =0.6f, JewelType = "RUBY", Time = 65.0f,Displayed = false});
			JewelList.Add(new Jewel{ PosX =0.5f, PosY =0.5f, JewelType = "DIAMOND", Time = 70.0f,Displayed = false});


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

