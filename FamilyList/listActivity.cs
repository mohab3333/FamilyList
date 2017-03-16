
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
using KinveyXamarin;

namespace FamilyList
{
	[Activity(Label = "listActivity", Theme = "@android:style/Theme.DeviceDefault.Light.NoActionBar")]
	public class listActivity : Activity
	{
		protected  async override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.listLayout);

			List<shoppinglist> ls = new List<shoppinglist> { };
			connection con = new connection();
			await con.Initialize();
			ls = await con.GetItems();
			adabterlist listAdapter = new adabterlist(ls, this);
			ListView lv = FindViewById<ListView>(Resource.Id.shoppinglistview);
			lv.Adapter = listAdapter;
			Button additem = FindViewById<Button>(Resource.Id.btnadditems);
			additem.Click += delegate {
				StartActivity(typeof(newitemActivity));
};
		}
	}
}

