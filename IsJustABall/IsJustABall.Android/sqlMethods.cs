using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using SQLite;

namespace IsJustABall.Android
{
	public class sqlMethods
	{
		///SQL    Create a Database with SQLite Component
		public async Task<string> createDatabase(string path)
		{

			try
			{
				var connection = new SQLiteAsyncConnection(path);

				await connection.CreateTableAsync<LevelRecord>();
				var db = new SQLiteAsyncConnection(path);
				LevelRecord data = new LevelRecord ();
				/*for(int i = 1; i<=10;i++){
					data.ID = i;data.Score= 10;data.Stars = 3;

					switch (i) {
					case 1:
						data.Levelname = "tutorial";
						break;


					case 2:
						data.Levelname= "railgun";
						break;

					case 3:
						data.Levelname= "minefield";
						break;

					case 4:
						data.Levelname= "blackhole";
						break;

					case 5:
						data.Levelname= "testgrounds";
						break;


					default:
						data.Levelname= "noname";
						break;
					}
				

					if (await db.InsertAsync(data) != 0){
						await db.UpdateAsync(data);}
				}
				*///endfor

				return "Database created";
			}
			catch (SQLiteException ex)
			{
				return ex.Message;
			}
		
			//

		}



		public async Task<string> insertUpdateData(LevelRecord data, string path)
		{
			try
			{
				var db = new SQLiteAsyncConnection(path);
				await db.InsertAsync(data);
					
				return "Single data file inserted or updated";

				/*var db = new SQLiteAsyncConnection(path);
				if (await db.InsertAsync(data) != 0)
					await db.UpdateAsync(data);
				return "Single data file inserted or updated";*/
			}
			catch (SQLiteException ex)
			{
				return ex.Message;
			}
		}


		public async Task<int> findNumberRecords(string path)
		{
			try
			{
				var db = new SQLiteAsyncConnection(path);
				// this counts all records in the database, it can be slow depending on the size of the database
				var count = await db.ExecuteScalarAsync<int>("SELECT Count(*) FROM LevelRecord");

				// for a non-parameterless query
				// var count = db.ExecuteScalarAsync<int>("SELECT Count(*) FROM Person WHERE FirstName="Amy");

				return count;
			}
			catch (SQLiteException ex)
			{
				return -1;
			}
		}

		//INITIALIZE DATA
		public async Task<string> initializeDatabase(string path)
		{

			try
			{			
				var db = new SQLiteAsyncConnection(path);
				LevelRecord data = new LevelRecord ();
				for(int i = 1; i<=10;i++){
					

					string dataLevelname;
					switch (i) {
					case 1:
						dataLevelname = "tutorial";
						break;


					case 2:
						dataLevelname= "railgun";
						break;

					case 3:
						dataLevelname= "minefield";
						break;

					case 4:
						dataLevelname= "blackhole";
						break;

					case 5:
						dataLevelname= "testgrounds";
						break;


					default:
						dataLevelname= "noname";
						break;
					}
				
					data = new LevelRecord{ ID = i, Levelname=dataLevelname, Stars = 0,Score  = 0 };


					if (await db.InsertAsync(data) != 0){
						await db.UpdateAsync(data);}
				}
				//endfor

				return "Database created";
			}
			catch (SQLiteException ex)
			{
				return ex.Message;
			}

			//

		}






	



		//

	}
}

/*var docsFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
			var pathToDatabase = System.IO.Path.Combine(docsFolder, "db_sqlcompnet_LevelRecord.db");
			var result = await createDatabase(pathToDatabase);
			*/