using System;
using RealmForms.Models;
using Xamarin.Forms;
using Realms;

namespace RealmForms.Views
{
	public partial class AddOwnerPage : ContentPage
	{
		public AddOwnerPage()
		{
			InitializeComponent();
		}

		private async void SaveButton_Clicked(object sender, EventArgs e)
		{
			var owner = new Person();
			var dog = new Dog();
			//Retrieve Owner data
			owner.Name = ownerName.Text;
			//Retrieve Dog data
			dog.Name = dogName.Text;
			dog.Age = Convert.ToInt32(dogAge.Text);
			//Get the Realm instance
			var realm = Realm.GetInstance();
			realm.Write(() =>
			{
				//Add Owner object to Realm
				realm.Add(owner);
				//Add Owner object that is persisted on Realm
				dog.Owner = owner;
				//Add Dog object to Realm with a relationship with owner
				realm.Add(dog);
			});
			await DisplayAlert("Dogs", "The owner and dog information has been saved", "Ok");
			//After writting on Realm, let's update the ListView on DogsPage
			MessagingCenter.Send(this as object, "UpdateListView");
			//Return to DogPage
			await Navigation.PopAsync(true);
		}
	}
}
