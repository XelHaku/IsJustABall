//http://programmers.stackexchange.com/questions/196579/storing-data-in-code
using System;
using CocosSharp;
using System.Collections.Generic;
using CocosDenshion;
using System.Linq;
namespace IsJustABall.Android
{
	public class StarsLevelIndex
	{
		#region STARSLEVEL MAKER
		public class StarsLevelScore
		{
			public String LevelName { get; set; }
			public int starScore1 { get; set; }
			public int starScore2 { get; set; }
			public int starScore3 { get; set; }
	

		}

		public  List<StarsLevelScore> GENERALMaker()
		{
			List<StarsLevelScore> StarScoreList = new List<StarsLevelScore>();
			StarScoreList.Add ( new StarsLevelScore { LevelName = "tutorial", starScore1 = 10, starScore2 = 20 ,starScore3=30});
			StarScoreList.Add ( new StarsLevelScore { LevelName = "railgun", starScore1 = 10, starScore2 = 20 ,starScore3=30});
			StarScoreList.Add ( new StarsLevelScore { LevelName = "minefield", starScore1 = 10, starScore2 = 20 ,starScore3=30});
			StarScoreList.Add ( new StarsLevelScore { LevelName = "blackhole", starScore1 = (int)(158*10*0.30f), starScore2 = (int)(158*10*0.50f) ,starScore3=(int)(158*10*0.80f)});
			StarScoreList.Add ( new StarsLevelScore { LevelName = "testgrounds", starScore1 = 10, starScore2 = 20 ,starScore3=30});


			return StarScoreList;
		}

		#endregion
	}
}

