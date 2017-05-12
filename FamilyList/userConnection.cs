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
	public class userConnection
	{
		
		 static MobileServiceClient MobileService { get; set; }
		IMobileServiceTable<user> usertable;
		public static List<user> ListOfUsers = new List<user>();
		public static bool isSigned;
		public  void Initialize()
		{

			MobileService = GetClient();
			usertable = MobileService.GetTable<user>();
		}
		public MobileServiceClient GetClient()
		{
			if (MobileService != null)
				return MobileService;
			else
				return new MobileServiceClient("https://mobileshoppinglist.azurewebsites.net");
			}
		public async Task<List<user>> GetUsers()
		{
			if (usertable != null)
			{
				List<user> userlist = await usertable.Where(x=> x.username == MainActivity.CurrentUsername).ToListAsync();
				return userlist;
			}
			else
				return new List<user>();
		}
		public async Task<bool> Adduser(user newuser)
		{
			isSigned = false;
			if (await Checkuser(newuser))

			{
				try
				{
					await usertable.InsertAsync(newuser);
		
					isSigned = true;
					return true;
				}
				catch (Exception e)
				{
					return false;
				}
			}
			return false;
		}
		async Task<bool> Checkuser(user newuser)
		{
			ListOfUsers = await usertable.Where(x => x.username == newuser.username).ToListAsync();
			if (ListOfUsers.Count > 0)
				return false;
			return true;
		}

	}
	}

