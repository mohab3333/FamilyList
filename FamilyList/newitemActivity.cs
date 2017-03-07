
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
	[Activity(Label = "newitemActivity")]
	public class newitemActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.newitemLayout);
			Spinner sp = FindViewById<Spinner>(Resource.Id.spinner1);
			sp.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(sp_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource(
				this, Resource.Array.Importance_array, Android.Resource.Layout.SimpleSpinnerItem);
			adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			sp.Adapter = adapter;
			// Create your application here
		}
		private void sp_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{
			//when item selected
		}
	}
}

