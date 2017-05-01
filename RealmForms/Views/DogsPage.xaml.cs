using System.Collections.ObjectModel;
using RealmForms.Models;
using Realms;
using Xamarin.Forms;

namespace RealmForms.Views
{
	public partial class DogsPage : ContentPage
	{
		public DogsPage()
		{
			InitializeComponent();
			//Add button here
			var addToolbarItem = new ToolbarItem
			{
				Text = "Add"
			};
			addToolbarItem.Command = new Command(() => Navigation.PushAsync(new AddOwnerPage(), true));
			ToolbarItems.Add(addToolbarItem);
			//Let's keep it simple: Call a method to construct the data from Realm
			LoadLocaldata();
			//Also, subscribe a Message to refresh the ListView when We add a new Owner and Dog
			MessagingCenter.Subscribe<object>(this as object, "UpdateListView", subscriber => LoadLocaldata());
		}

		private void LoadLocaldata()
		{
			var collection = new ObservableCollection<Dog>();
			dogsListView.ItemsSource = collection;
			var realm = Realm.GetInstance();
			var dogsStored = realm.All<Dog>();
			foreach (var item in dogsStored)
			{
				collection.Add(item);
			}
		}
	}
}
