using System;
using System.Collections;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.IO;
using System.Collections.Generic;

namespace FamilyList
{
	public class connection
	{
		public MobileServiceClient MobileService { get; set; }
		IMobileServiceSyncTable<shoppinglist>itemtable;
		public async Task<bool> Initialize()
		{
			MobileService = new MobileServiceClient("http://mobileshoppinglist.azurewebsites.net");
			string path = "syncstore.db";
			SQLitePCL.Batteries.Init();
			path = Path.Combine(System.Environment
		  .GetFolderPath(System.Environment.SpecialFolder.Personal), path);

			itemtable = MobileService.GetSyncTable<shoppinglist>();

			if (!File.Exists(path))
			{
				File.Create(path).Dispose();
			}
			var store = new MobileServiceSQLiteStore(path);

			store.DefineTable<shoppinglist>();
			await MobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());
			itemtable = MobileService.GetSyncTable<shoppinglist>();
			return true;
		}
		public async Task<List<shoppinglist>> GetItems()
		{
			if (itemtable != null)
			{
				await SyncItems();
				return await itemtable.ToListAsync();
			}
			else
				return new List<shoppinglist>();
		}
		public async Task<bool> Additem(shoppinglist slItem)
		{
			try
			{				
				await itemtable.InsertAsync(slItem);
				await SyncItems();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public async Task<bool> SyncItems()
		{
			try
			{
				await itemtable.PullAsync("allshoppinglist", itemtable.CreateQuery()); // query ID is used for incremental sync
				await MobileService.SyncContext.PushAsync();
				return true;
			}
			catch
			{
				return false;
			}

		}
	}
}

