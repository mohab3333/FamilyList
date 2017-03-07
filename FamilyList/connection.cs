using System;
using KinveyXamarin;

namespace FamilyList
{
	public class connection
	{
		static Client connect;
		public static Client con()
		{
			if (connect == null)
			{
				connect = new Client.Builder("kid_H1Z-Xnr9l", "9373d584548c419d8a258bcf49e6eb33")
				.setLogger(delegate (string msg) { Console.WriteLine(msg); })
				.setFilePath(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal))
				                    .setOfflinePlatform(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid()).build();
			}
			return connect;
		}

	}
}

