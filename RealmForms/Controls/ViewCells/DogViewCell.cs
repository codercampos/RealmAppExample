using Xamarin.Forms;

namespace RealmForms.Controls.ViewCells
{
	public class DogViewCell : TextCell
	{
		public DogViewCell()
		{
			SetBinding(TextProperty, new Binding("Name"));
			SetBinding(DetailProperty, new Binding("Owner.Name", BindingMode.Default, null, "Owner: {0}"));
			TextColor = Color.Black;
			DetailColor = Color.Black;
		}
	}
}
