using System;
using CocosSharp;
using System.Collections.Generic;
using CocosDenshion;
using System.Linq;
namespace IsJustABall.Android
{
	public class TriangleClass
	{
		public class TriangleCoordinates
		{
			public float V1X { get; set; }
			public float V1Y { get; set; }
			public float V2X { get; set; }
			public float V2Y { get; set; }
			public float V3X { get; set; }
			public float V3Y { get; set; }
			//public string MoveType { get; set; }

		}

		public  List<TriangleCoordinates> RedTriangleMaker()
		{
			List<TriangleCoordinates> GENERALList = new List<TriangleCoordinates>();
			GENERALList.Add ( new TriangleCoordinates {  V1X =0f,V1Y = 0f,V2X =0.1f,V2Y =0.1f,V3X =0.2f,V3Y = 0f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 0f,V2X =0.3f,V2Y =0.1f,V3X =0.2f,V3Y = 0.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 0.2f,V2X =0.5f,V2Y =0.1f,V3X =0.6f,V3Y = 0.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 0f,V2X =0.8f,V2Y =0.2f,V3X =0.9f,V3Y = 0.1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0f,V1Y = 0.2f,V2X =0.1f,V2Y =0.3f,V3X =0f,V3Y = 0.4f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 0.2f,V2X =0.5f,V2Y =0.3f,V3X =0.4f,V3Y = 0.4f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 0.4f,V2X =0.7f,V2Y =0.3f,V3X =0.8f,V3Y = 0.4f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.9f,V1Y = 0.3f,V2X =1f,V2Y =0.2f,V3X =1f,V3Y = 0.4f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.1f,V1Y = 0.4f,V2X =0.1f,V2Y =0.6f,V3X =0.2f,V3Y = 0.5f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 0.5f,V2X =0.7f,V2Y =0.4f,V3X =0.7f,V3Y = 0.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.7f,V1Y = 0.5f,V2X =0.8f,V2Y =0.4f,V3X =0.8f,V3Y = 0.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.1f,V1Y = 0.7f,V2X =0.2f,V2Y =0.6f,V3X =0.2f,V3Y = 0.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 0.8f,V2X =0.5f,V2Y =0.7f,V3X =0.6f,V3Y = 0.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.5f,V1Y = 0.9f,V2X =0.6f,V2Y =0.8f,V3X =0.6f,V3Y = 1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.7f,V1Y = 0.9f,V2X =0.8f,V2Y =0.8f,V3X =0.8f,V3Y = 1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.9f,V1Y = 0.8f,V2X =0.9f,V2Y =1f,V3X =1f,V3Y = 0.9f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0f,V1Y = 1f,V2X =0f,V2Y =1.2f,V3X =0.1f,V3Y = 1.1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 1f,V2X =0.2f,V2Y =1f,V3X =0.3f,V3Y = 1.1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.9f,V1Y = 1.1f,V2X =1f,V2Y =1f,V3X =1f,V3Y = 1.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0f,V1Y = 1.2f,V2X =0.1f,V2Y =1.3f,V3X =0.2f,V3Y = 1.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0f,V1Y = 1.3f,V2X =0.1f,V2Y =1.4f,V3X =0.2f,V3Y = 1.3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.5f,V1Y = 1.2f,V2X =0.5f,V2Y =1.4f,V3X =0.6f,V3Y = 1.3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.3f,V1Y = 1.5f,V2X =0.4f,V2Y =1.4f,V3X =0.4f,V3Y = 1.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 1.4f,V2X =0.6f,V2Y =1.6f,V3X =0.5f,V3Y = 1.5f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 1.6f,V2X =1f,V2Y =1.6f,V3X =0.9f,V3Y = 1.5f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =1f,V1Y = 1.6f,V2X =0.9f,V2Y =1.7f,V3X =0.8f,V3Y = 1.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 1.6f,V2X =0.7f,V2Y =1.7f,V3X =0.8f,V3Y = 1.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 1.8f,V2X =0.5f,V2Y =1.7f,V3X =0.4f,V3Y = 1.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 1.6f,V2X =0.2f,V2Y =1.8f,V3X =0.1f,V3Y = 1.7f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =1f,V1Y = 1.8f,V2X =0.9f,V2Y =1.9f,V3X =1f,V3Y = 2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 1.8f,V2X =0.5f,V2Y =1.9f,V3X =0.6f,V3Y = 2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 2f,V2X =0.3f,V2Y =1.9f,V3X =0.2f,V3Y = 2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.1f,V1Y = 1.9f,V2X =0f,V2Y =1.8f,V3X =0f,V3Y = 2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.9f,V1Y = 2f,V2X =0.9f,V2Y =2.2f,V3X =0.8f,V3Y = 2.1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 2.1f,V2X =0.3f,V2Y =2f,V3X =0.3f,V3Y = 2.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.3f,V1Y = 2.1f,V2X =0.2f,V2Y =2f,V3X =0.2f,V3Y = 2.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.9f,V1Y = 2.3f,V2X =0.8f,V2Y =2.2f,V3X =0.8f,V3Y = 2.4f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 2.4f,V2X =0.5f,V2Y =2.3f,V3X =0.4f,V3Y = 2.4f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.5f,V1Y = 2.5f,V2X =0.4f,V2Y =2.4f,V3X =0.4f,V3Y = 2.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.3f,V1Y = 2.5f,V2X =0.2f,V2Y =2.4f,V3X =0.2f,V3Y = 2.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.1f,V1Y = 2.4f,V2X =0.1f,V2Y =2.6f,V3X =0f,V3Y = 2.5f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =1f,V1Y = 2.6f,V2X =1f,V2Y =2.8f,V3X =0.9f,V3Y = 2.7f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 2.6f,V2X =0.8f,V2Y =2.6f,V3X =0.7f,V3Y = 2.7f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.1f,V1Y = 2.7f,V2X =0f,V2Y =2.6f,V3X =0f,V3Y = 2.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =1f,V1Y = 2.8f,V2X =0.9f,V2Y =2.9f,V3X =0.8f,V3Y = 2.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =1f,V1Y = 2.9f,V2X =0.9f,V2Y =3f,V3X =0.8f,V3Y = 2.9f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.5f,V1Y = 2.8f,V2X =0.5f,V2Y =3f,V3X =0.4f,V3Y = 2.9f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.7f,V1Y = 3.1f,V2X =0.6f,V2Y =3f,V3X =0.6f,V3Y = 3.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 3f,V2X =0.4f,V2Y =3.2f,V3X =0.5f,V3Y = 3.1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 3.2f,V2X =0f,V2Y =3.2f,V3X =0.1f,V3Y = 3.1f  });


			return GENERALList;
		}

		public  List<TriangleCoordinates> BlueTriangleMaker()
		{
			List<TriangleCoordinates> GENERALList = new List<TriangleCoordinates>();
			GENERALList.Add ( new TriangleCoordinates {  V1X =0f,V1Y = 0.1f,V2X =0.1f,V2Y =0.2f,V3X =0.2f,V3Y = 0.1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 0f,V2X =0.3f,V2Y =0.1f,V3X =0.4f,V3Y = 0.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 0f,V2X =0.5f,V2Y =0.1f,V3X =0.6f,V3Y = 0f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 0f,V2X =0.7f,V2Y =0.1f,V3X =0.6f,V3Y = 0.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 0.2f,V2X =0.3f,V2Y =0.3f,V3X =0.4f,V3Y = 0.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.5f,V1Y = 0.2f,V2X =0.5f,V2Y =0.4f,V3X =0.6f,V3Y = 0.3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 0.2f,V2X =0.9f,V2Y =0.3f,V3X =0.8f,V3Y = 0.4f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0f,V1Y = 0.5f,V2X =0.1f,V2Y =0.4f,V3X =0.1f,V3Y = 0.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 0.4f,V2X =0.3f,V2Y =0.5f,V3X =0.2f,V3Y = 0.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 0.5f,V2X =0.5f,V2Y =0.6f,V3X =0.6f,V3Y = 0.5f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.9f,V1Y = 0.5f,V2X =1f,V2Y =0.4f,V3X =1f,V3Y = 0.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 0.7f,V2X =0.3f,V2Y =0.8f,V3X =0.4f,V3Y = 0.7f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 0.7f,V2X =0.7f,V2Y =0.8f,V3X =0.7f,V3Y = 0.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 0.7f,V2X =0.9f,V2Y =0.6f,V3X =1f,V3Y = 0.7f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0f,V1Y = 0.8f,V2X =0f,V2Y =1f,V3X =0.1f,V3Y = 0.9f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 1f,V2X =0.3f,V2Y =0.9f,V3X =0.4f,V3Y = 1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 0.8f,V2X =0.6f,V2Y =1f,V3X =0.7f,V3Y = 0.9f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 0.9f,V2X =0.9f,V2Y =0.8f,V3X =0.9f,V3Y = 1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.1f,V1Y = 1.1f,V2X =0.2f,V2Y =1f,V3X =0.2f,V3Y = 1.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 1f,V2X =0.5f,V2Y =1.1f,V3X =0.6f,V3Y = 1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.7f,V1Y = 1.1f,V2X =0.8f,V2Y =1f,V3X =0.8f,V3Y = 1.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 1.3f,V2X =0.3f,V2Y =1.4f,V3X =0.4f,V3Y = 1.3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 1.3f,V2X =0.5f,V2Y =1.2f,V3X =0.5f,V3Y = 1.4f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 1.2f,V2X =0.6f,V2Y =1.4f,V3X =0.7f,V3Y = 1.3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 1.2f,V2X =0.8f,V2Y =1.4f,V3X =0.9f,V3Y = 1.3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.1f,V1Y = 1.4f,V2X =0.1f,V2Y =1.6f,V3X =0.2f,V3Y = 1.5f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 1.5f,V2X =0.8f,V2Y =1.5f,V3X =0.7f,V3Y = 1.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =1f,V1Y = 1.7f,V2X =0.9f,V2Y =1.8f,V3X =0.8f,V3Y = 1.7f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 1.6f,V2X =0.7f,V2Y =1.7f,V3X =0.6f,V3Y = 1.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 1.6f,V2X =0.5f,V2Y =1.7f,V3X =0.4f,V3Y = 1.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 1.6f,V2X =0.3f,V2Y =1.7f,V3X =0.4f,V3Y = 1.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 1.8f,V2X =0.7f,V2Y =1.9f,V3X =0.6f,V3Y = 1.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.5f,V1Y = 1.8f,V2X =0.5f,V2Y =2f,V3X =0.4f,V3Y = 1.9f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 1.8f,V2X =0.1f,V2Y =1.9f,V3X =0.2f,V3Y = 2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =1f,V1Y = 2.1f,V2X =0.9f,V2Y =2f,V3X =0.9f,V3Y = 2.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 2f,V2X =0.7f,V2Y =2.1f,V3X =0.8f,V3Y = 2.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 2.1f,V2X =0.5f,V2Y =2.2f,V3X =0.4f,V3Y = 2.1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.1f,V1Y = 2.1f,V2X =0f,V2Y =2f,V3X =0f,V3Y = 2.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 2.3f,V2X =0.7f,V2Y =2.4f,V3X =0.6f,V3Y = 2.3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 2.3f,V2X =0.3f,V2Y =2.4f,V3X =0.3f,V3Y = 2.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 2.3f,V2X =0.1f,V2Y =2.2f,V3X =0f,V3Y = 2.3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =1f,V1Y = 2.4f,V2X =1f,V2Y =2.6f,V3X =0.9f,V3Y = 2.5f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 2.6f,V2X =0.7f,V2Y =2.5f,V3X =0.6f,V3Y = 2.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 2.4f,V2X =0.4f,V2Y =2.6f,V3X =0.3f,V3Y = 2.5f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 2.5f,V2X =0.1f,V2Y =2.4f,V3X =0.1f,V3Y = 2.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.9f,V1Y = 2.7f,V2X =0.8f,V2Y =2.6f,V3X =0.8f,V3Y = 2.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 2.6f,V2X =0.5f,V2Y =2.7f,V3X =0.4f,V3Y = 2.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.3f,V1Y = 2.7f,V2X =0.2f,V2Y =2.6f,V3X =0.2f,V3Y = 2.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 2.9f,V2X =0.7f,V2Y =3f,V3X =0.6f,V3Y = 2.9f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 2.9f,V2X =0.5f,V2Y =2.8f,V3X =0.5f,V3Y = 3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 2.8f,V2X =0.4f,V2Y =3f,V3X =0.3f,V3Y = 2.9f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 2.8f,V2X =0.2f,V2Y =3f,V3X =0.1f,V3Y = 2.9f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.9f,V1Y = 3f,V2X =0.9f,V2Y =3.2f,V3X =0.8f,V3Y = 3.1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 3.1f,V2X =0.2f,V2Y =3.1f,V3X =0.3f,V3Y = 3.2f  });

			return GENERALList;
		}

		public  List<TriangleCoordinates> PurpleTriangleMaker()
		{
			List<TriangleCoordinates> GENERALList = new List<TriangleCoordinates>();
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.7f,V1Y = 0.1f,V2X =0.8f,V2Y =0f,V3X =0.8f,V3Y = 0.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.9f,V1Y = 0f,V2X =0.9f,V2Y =0.2f,V3X =1f,V3Y = 0.1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.1f,V1Y = 0.3f,V2X =0.2f,V2Y =0.2f,V3X =0.2f,V3Y = 0.4f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 0.4f,V2X =0.3f,V2Y =0.3f,V3X =0.4f,V3Y = 0.4f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 0.2f,V2X =0.7f,V2Y =0.3f,V3X =0.8f,V3Y = 0.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.3f,V1Y = 0.4f,V2X =0.3f,V2Y =0.6f,V3X =0.4f,V3Y = 0.5f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 0.5f,V2X =0.5f,V2Y =0.4f,V3X =0.6f,V3Y = 0.5f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 0.4f,V2X =0.8f,V2Y =0.6f,V3X =0.9f,V3Y = 0.5f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0f,V1Y = 0.6f,V2X =0f,V2Y =0.8f,V3X =0.1f,V3Y = 0.7f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 0.7f,V2X =0.3f,V2Y =0.6f,V3X =0.4f,V3Y = 0.7f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 0.7f,V2X =0.5f,V2Y =0.6f,V3X =0.6f,V3Y = 0.7f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.7f,V1Y = 0.7f,V2X =0.8f,V2Y =0.6f,V3X =0.8f,V3Y = 0.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 0.7f,V2X =0.9f,V2Y =0.8f,V3X =1f,V3Y = 0.7f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.1f,V1Y = 0.9f,V2X =0.2f,V2Y =0.8f,V3X =0.2f,V3Y = 1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 0.8f,V2X =0.3f,V2Y =0.9f,V3X =0.4f,V3Y = 0.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 0.9f,V2X =0.5f,V2Y =1f,V3X =0.5f,V3Y = 0.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.3f,V1Y = 1f,V2X =0.3f,V2Y =1.2f,V3X =0.4f,V3Y = 1.1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 1.2f,V2X =0.5f,V2Y =1.1f,V3X =0.6f,V3Y = 1.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 1f,V2X =0.6f,V2Y =1.2f,V3X =0.7f,V3Y = 1.1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 1f,V2X =0.8f,V2Y =1.2f,V3X =0.9f,V3Y = 1.1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 1.2f,V2X =0.4f,V2Y =1.2f,V3X =0.3f,V3Y = 1.3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.7f,V1Y = 1.2f,V2X =0.7f,V2Y =1.4f,V3X =0.8f,V3Y = 1.3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.9f,V1Y = 1.3f,V2X =1f,V2Y =1.2f,V3X =1f,V3Y = 1.4f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0f,V1Y = 1.5f,V2X =0.1f,V2Y =1.4f,V3X =0.1f,V3Y = 1.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 1.5f,V2X =0.3f,V2Y =1.4f,V3X =0.3f,V3Y = 1.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 1.4f,V2X =0.4f,V2Y =1.6f,V3X =0.5f,V3Y = 1.5f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 1.5f,V2X =0.8f,V2Y =1.5f,V3X =0.7f,V3Y = 1.4f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 1.5f,V2X =1f,V2Y =1.5f,V3X =0.9f,V3Y = 1.4f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.3f,V1Y = 1.7f,V2X =0.2f,V2Y =1.6f,V3X =0.2f,V3Y = 1.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.1f,V1Y = 1.6f,V2X =0.1f,V2Y =1.8f,V3X =0f,V3Y = 1.7f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.9f,V1Y = 1.9f,V2X =0.8f,V2Y =1.8f,V3X =0.8f,V3Y = 2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 2f,V2X =0.7f,V2Y =1.9f,V3X =0.6f,V3Y = 2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 1.8f,V2X =0.3f,V2Y =1.9f,V3X =0.2f,V3Y = 1.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.7f,V1Y = 2f,V2X =0.7f,V2Y =2.2f,V3X =0.6f,V3Y = 2.1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 2.1f,V2X =0.5f,V2Y =2f,V3X =0.4f,V3Y = 2.1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 2f,V2X =0.2f,V2Y =2.2f,V3X =0.1f,V3Y = 2.1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =1f,V1Y = 2.2f,V2X =1f,V2Y =2.4f,V3X =0.9f,V3Y = 2.3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 2.3f,V2X =0.7f,V2Y =2.2f,V3X =0.6f,V3Y = 2.3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 2.3f,V2X =0.5f,V2Y =2.2f,V3X =0.4f,V3Y = 2.3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.3f,V1Y = 2.3f,V2X =0.2f,V2Y =2.2f,V3X =0.2f,V3Y = 2.4f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 2.3f,V2X =0.1f,V2Y =2.4f,V3X =0f,V3Y = 2.3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.9f,V1Y = 2.5f,V2X =0.8f,V2Y =2.4f,V3X =0.8f,V3Y = 2.6f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 2.4f,V2X =0.7f,V2Y =2.5f,V3X =0.6f,V3Y = 2.4f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 2.5f,V2X =0.5f,V2Y =2.6f,V3X =0.5f,V3Y = 2.4f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.7f,V1Y = 2.6f,V2X =0.7f,V2Y =2.8f,V3X =0.6f,V3Y = 2.7f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 2.8f,V2X =0.5f,V2Y =2.7f,V3X =0.4f,V3Y = 2.8f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 2.6f,V2X =0.4f,V2Y =2.8f,V3X =0.3f,V3Y = 2.7f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 2.6f,V2X =0.2f,V2Y =2.8f,V3X =0.1f,V3Y = 2.7f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 2.8f,V2X =0.6f,V2Y =2.8f,V3X =0.7f,V3Y = 2.9f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.3f,V1Y = 2.8f,V2X =0.3f,V2Y =3f,V3X =0.2f,V3Y = 2.9f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.1f,V1Y = 2.9f,V2X =0f,V2Y =2.8f,V3X =0f,V3Y = 3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =1f,V1Y = 3.1f,V2X =0.9f,V2Y =3f,V3X =0.9f,V3Y = 3.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.8f,V1Y = 3.1f,V2X =0.7f,V2Y =3f,V3X =0.7f,V3Y = 3.2f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.6f,V1Y = 3f,V2X =0.6f,V2Y =3.2f,V3X =0.5f,V3Y = 3.1f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.4f,V1Y = 3.1f,V2X =0.2f,V2Y =3.1f,V3X =0.3f,V3Y = 3f  });
			GENERALList.Add ( new TriangleCoordinates {  V1X =0.2f,V1Y = 3.1f,V2X =0f,V2Y =3.1f,V3X =0.1f,V3Y = 3f  });

			return GENERALList;
		}

	}
}

