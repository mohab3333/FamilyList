using Android.App;
using Android.Widget;
using Android.OS;
using KinveyXamarin;

namespace FamilyList
{
	[Activity(Label = "Family List", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.Main);
			Button loginbtn = FindViewById<Button>(Resource.Id.btnlogin);
			EditText username = FindViewById<EditText>(Resource.Id.txtusername);
			EditText password = FindViewById<EditText>(Resource.Id.txtpassword);
			loginbtn.Click += async delegate {
				User user = await connection.con().User().LoginAsync(username.Text, password.Text);
				if (user != null)
					StartActivity(typeof(listActivity));
				else
					Toast.MakeText(this, "wrong name or password", ToastLength.Short).Show();
};
		}
	}
}


