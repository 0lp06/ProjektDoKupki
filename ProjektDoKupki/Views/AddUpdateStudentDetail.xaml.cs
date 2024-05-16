using ProjektDoKupki.ViewModels;

namespace ProjektDoKupki.Views;

public partial class AddUpdateStudentDetail : ContentPage
{
	public AddUpdateStudentDetail(AddUpdateStudentDetailViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}