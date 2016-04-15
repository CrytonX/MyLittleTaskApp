using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Runtime;
using Android.Views;
using TaskyAndroid;
using Tasky.Shared;

namespace TaskyAndroid.Screens
{
	/// <summary>
	/// Main ListView screen displays a list of tasks, plus an [Add] button
	/// </summary>
	[Activity (Label = "Tasky",  
		Icon="@drawable/icon",
		MainLauncher = true,
		Theme = "@android:style/Theme.Holo.Light.NoActionBar")]
	
	public class HomeScreen : Activity 
	{
		List<TableItem> tableItems = new List<TableItem>();
		ListView listView;
		ImageButton addButton;
		IList<TodoItem> tasks;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView(Resource.Layout.HomeScreen);
			tasks = TodoItemManager.GetTasks ();

			foreach (TodoItem task in tasks) 
			{
				tableItems.Add(new TableItem() { Heading = task.Name, SubHeading = task.Date});
			}

			listView = FindViewById<ListView>(Resource.Id.TaskList);
			listView.Adapter = new HomeScreenAdapter(this, tableItems);
			listView.ItemClick += OnListItemClick;

			addButton = FindViewById<ImageButton> (Resource.Id.addButton);

			if (addButton != null) {
				addButton.Click += (sender, e) => {
					StartActivity (typeof(TodoItemScreen));
				};
			}
		}

		void OnListItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var listView = sender as ListView;
			var t = tableItems[e.Position];
			Android.Widget.Toast.MakeText(this, t.Heading, Android.Widget.ToastLength.Short).Show();
		}

		void OnAddTaskClick()
		{
			
		}

		protected override void OnResume() 
		{
			base.OnResume ();

			tasks = TodoItemManager.GetTasks ();
			tableItems.Clear ();
			foreach (TodoItem task in tasks) 
			{
				tableItems.Add(new TableItem() { Heading = task.Name, SubHeading = task.Date});
			}
		}
	}
}