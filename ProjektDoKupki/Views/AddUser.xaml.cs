using ProjektMAUI.Models;
using ProjektMAUI.Services;
using ProjektMAUI.ViewModels;
using System.Diagnostics;

namespace ProjektMAUI.Views;

public partial class AddUser : ContentPage
{

    private readonly AddUserViewModel viewModel;


    public AddUser()
	{
        InitializeComponent();
        this.viewModel = (AddUserViewModel)BindingContext;
        FirstNameEntry.Text = viewModel.name;
        LastNameEntry.Text = viewModel.surname;
        EmailEntry.Text = viewModel.email;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        this.viewModel.AddUser();
    }

    private void OnDataChange(object sender, TextChangedEventArgs e)
    {

        viewModel.name = FirstNameEntry.Text;
        viewModel.surname = LastNameEntry.Text;
        viewModel.email = EmailEntry.Text;
    }
}