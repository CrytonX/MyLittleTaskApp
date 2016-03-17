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
		MainLauncher = true,
		Theme = "@android:style/Theme.Holo.Light.NoActionBar.Fullscreen")]
	
	public class HomeScreen : Activity 
	{
		List<TableItem> tableItems = new List<TableItem>();
		ListView listView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.HomeScreen);
			listView = FindViewById<ListView>(Resource.Id.TaskList);

			tableItems.Add(new TableItem() { Heading = "Today", SubHeading = "April 18th 2016"});
			tableItems.Add(new TableItem() { Heading = "Tomorrow", SubHeading = "April 19th 2016"});
			tableItems.Add(new TableItem() { Heading = "Thursday", SubHeading = "April 20th 2016"});
			tableItems.Add(new TableItem() { Heading = "Friday", SubHeading = "April 21st 2016"});
			tableItems.Add(new TableItem() { Heading = "Saturday", SubHeading = "April 22nd 2016"});
			tableItems.Add(new TableItem() { Heading = "Sunday", SubHeading = "April 23rd 2016"});

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