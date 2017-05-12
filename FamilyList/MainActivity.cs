using Android.App;
using Android.Widget;
using Android.OS;
using KinveyXamarin;
using System.Collections.Generic;

namespace FamilyList
{
	[Activity(Label = "Family List", MainLauncher = true, Icon = "@mipmap/icon",Theme="@android:style/Theme.DeviceDefault.Light.NoActionBar")]
	public class MainActivity : Activity
	{ 
		public static string CurrentUsername;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
			Button loginbtn = FindViewById<Button>(Resource.Id.btnlogin);
			Button Signbtn = FindViewById<Button>(Resource.Id.btnsignup);
			EditText username = FindViewById<EditText>(Resource.Id.txtusername);
			EditText password = FindViewById<EditText>(Resource.Id.txtpassword);
			loginbtn.Click +=  async delegate
			{
				CurrentUsername = username.Text;
				userConnection usercon = new userConnection();
				 usercon.Initialize();
				List<user> userlist = await usercon.GetUsers();
				if (userlist.Count != 0 && userlist[0].password == password.Text)
				{ 
					StartActivity(typeof(listActivity)); 
					Finish();
				}
				else
				Toast.MakeText(this, "Wrong username or password", ToastLength.Short).Show();											
};
			Signbtn.Click += delegate {
				StartActivity(typeof(signupActivity));
};
		}
	}
}


