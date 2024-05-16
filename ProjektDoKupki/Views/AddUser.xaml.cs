using ProjektDoKupki.ViewModels;

namespace ProjektDoKupki.Views;

public partial class AddUser : ContentPage
{
	public AddUser(AddUserViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}