using Realms;
namespace RealmForms.Models
{
	public class Dog : RealmObject
	{
		public string Name { get; set; }
		public int Age { get; set; }
		public Person Owner { get; set; }
	}
}