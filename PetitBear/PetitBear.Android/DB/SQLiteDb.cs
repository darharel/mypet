using System;
using System.IO;
using SQLite;
using Xamarin.Forms;
using HelloWorld.Droid;
using PetitBear.DB;

[assembly: Dependency(typeof(SQLiteDb))]

namespace HelloWorld.Droid
{
	public class SQLiteDb : ISQLiteDB
	{
		public SQLiteAsyncConnection GetConnection()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			var path = Path.Combine(documentsPath, "PetitBear.db03");

			return new SQLiteAsyncConnection(path);
		}
	}
}

