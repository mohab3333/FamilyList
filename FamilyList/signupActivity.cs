using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace FamilyList
{
	[Activity(Label = "signupActivity",Theme = "@android:style/Theme.DeviceDefault.Light.NoActionBar")]
	public class signupActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.signupLayout);

			Button signbtn = FindViewById<Button>(Resource.Id.btnadduser);
			EditText username = FindViewById<EditText>(Resource.Id.txtnewusername);
			EditText password = FindViewById<EditText>(Resource.Id.txtnewpassword);
			EditText confirmPassword = FindViewById<EditText>(Resource.Id.txtnewpassword);

			signbtn.Click += async delegate {
				if (password.Text == confirmPassword.Text)
				{
					userConnection con = new userConnection();
					 con.Initialize();
					bool flag = await con.Adduser(new user() {username=username.Text,password=password.Text});
					if (userConnection.isSigned)
						Finish();
					else if(!flag)
						Toast.MakeText(this, "Connection Error !", ToastLength.Short).Show();
					else
						Toast.MakeText(this, "User already exists", ToastLength.Short).Show();
				}
				else
					Toast.MakeText(this,"Password doesn't match",ToastLength.Short).Show();

};
		}
	}
}

