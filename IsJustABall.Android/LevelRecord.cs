using System;
using SQLite;

/// <summary>
/// /Create a Database with SQLite Component
/// </summary>
public class LevelRecord
{


	//[PrimaryKey, AutoIncrement]
	public int ID { get; set; }
	public string Levelname { get; set; }
	public int Stars { get; set; }
	public int Score { get; set; }



	public override string ToString()
	{
		return string.Format("[LevelRecord: ID={0}, Levelname={1},Stars={2}, Score={3}]", ID, Levelname, Stars, Score);
	}


}