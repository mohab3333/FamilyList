
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
	[Activity(Label = "newitemActivity", Theme = "@android:style/Theme.DeviceDefault.Light.NoActionBar")]
	public class newitemActivity : Activity
	{

		int currentselected=1;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.newitemLayout);

			Button btnadd = FindViewById<Button>(Resource.Id.btnadd);
			Spinner sp = FindViewById<Spinner>(Resource.Id.spinner1);
			sp.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(sp_ItemSelected);
			var adapter = ArrayAdapter.CreateFromResource(
				this, Resource.Array.Importance_array, Android.Resource.Layout.SimpleSpinnerItem);
			adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			sp.Adapter = adapter;
			EditText txtname = FindViewById<EditText>(Resource.Id.txtnewitemname);
			EditText txtprice = FindViewById<EditText>(Resource.Id.txtnewitemprice);

			btnadd.Click += async delegate {
				
				connection con = new connection();
				await con.Initialize();
				await con.Additem(new shoppinglist() {itemname = txtname.Text, price = int.Parse(txtprice.Text), importance = currentselected, IsDone = false, user = MainActivity.CurrentUsername });
};
		}
		private void sp_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
		{			
			currentselected = e.Position+1;
		}
	}
}

