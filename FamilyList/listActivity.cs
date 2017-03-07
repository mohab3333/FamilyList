
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
	[Activity(Label = "listActivity")]
	public class listActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.listLayout);
			//List<shoppinglist> ls;
			//adabterlist ad = new adabterlist(ls,this);
			//ListView lv = FindViewById<ListView>(Resource.Id.shoppinglistview);
			//lv.Adapter = ad;

		}
	}
}

