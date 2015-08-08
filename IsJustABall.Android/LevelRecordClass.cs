using System;
using System.Data; 
using Mono.Data.Sqlite;
using SQLite;

/// <summary>
/// /Create a Database with SQLite Component
/// </summary>
namespace IsJustABall.Android
{
	public class LevelRecordClass
	{
				


				[PrimaryKey, AutoIncrement]
				public int ID { get; set; }
				public int Stars { get; set; }
				public int Score { get; set; }



				public override string ToString()
				{
					return string.Format("[Person: LevelID={0}, Stars={1}, Score={2}]", ID, Stars, Score);
				}




	}
}

