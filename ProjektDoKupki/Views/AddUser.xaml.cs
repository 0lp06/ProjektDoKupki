using ProjektDoKupki.Services;
using ProjektDoKupki.ViewModels;
using System.Diagnostics;

namespace ProjektDoKupki.Views;

public partial class AddUser : ContentPage
{
	private readonly static IUserService UserService = new UserService();
	AddUserViewModel viewModel =new AddUserViewModel(UserService);


    public AddUser()
	{
        InitializeComponent();
		this.BindingContext = viewModel;
    }

	/*
    public AddUser(AddUserViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}*/
}