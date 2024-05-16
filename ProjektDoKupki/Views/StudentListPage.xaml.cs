using ProjektDoKupki.ViewModels;

namespace ProjektDoKupki.Views;

public partial class StudentListPage : ContentPage
{
	private UserListPageViewModel _viewModel;

	public StudentListPage(UserListPageViewModel viewModel)
	{
		InitializeComponent();
		this._viewModel = viewModel;
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		_viewModel.GetStudentListCommand.Execute(this);
    }
}