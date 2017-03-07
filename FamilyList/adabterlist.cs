using System;
using System.Collections.Generic;
using Android.Widget;
using System.Runtime.Remoting.Contexts;
using Android.Views;
using Android.Graphics.Drawables;
using Android.Content;
using Android.App;
using Android.Content.PM;

namespace FamilyList
{
	public class adabterlist : BaseAdapter<shoppinglist>
	{
		List<shoppinglist> itemlist;
		Android.Content.Context context;
		public adabterlist(List<shoppinglist> listview, Android.Content.Context context)
		{
			this.itemlist = listview;
			this.context = context;
		}
		public override shoppinglist this[int position]
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override int Count
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public override long GetItemId(int position)
		{
			throw new NotImplementedException();
		}

		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			View view = convertView;
			if (view == null)
				view = LayoutInflater.From(context).Inflate(Resource.Layout.customlistview, null, false);
			TextView txtname = view.FindViewById<TextView>(Resource.Id.itemname);
			txtname.Text = itemlist[position].itemname;
			TextView txtprice = view.FindViewById<TextView>(Resource.Id.price);
			txtprice.Text = itemlist[position].price.ToString();
			TextView txtper = view.FindViewById<TextView>(Resource.Id.importance);
			txtper.Text = itemlist[position].importance.ToString();
			return view;

		}
	}
}

