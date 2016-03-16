using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Runtime;
using Android.Views;

namespace TaskyAndroid
{
	/// <summary>
	/// Main ListView screen displays a list of tasks, plus an [Add] button
	/// </summary>
	[Activity (Label = "Tasky",  
		Icon="@drawable/icon",
		MainLauncher = true)]
	
	public class HomeScreen : Activity 
	{
		List<TableItem> tableItems = new List<TableItem>();
		ListView listView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.HomeScreen);
			listView = FindViewById<ListView>(Resource.Id.TaskList);

			tableItems.Add(new TableItem() { Heading = "Vegetables", SubHeading = "65 items"});
			tableItems.Add(new TableItem() { Heading = "Fruits", SubHeading = "17 items"});
			tableItems.Add(new TableItem() { Heading = "Flower Buds", SubHeading = "5 items"});
			tableItems.Add(new TableItem() { Heading = "Legumes", SubHeading = "33 items"});
			tableItems.Add(new TableItem() { Heading = "Bulbs", SubHeading = "18 items"});
			tableItems.Add(new TableItem() { Heading = "Tubers", SubHeading = "43 items"});

			listView.Adapter = new HomeScreenAdapter(this, tableItems);

			listView.ItemClick += OnListItemClick;

		}

		void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var listView = sender as ListView;
			var t = tableItems[e.Position];
			Android.Widget.Toast.MakeText(this, t.Heading, Android.Widget.ToastLength.Short).Show();
		}
	}
}