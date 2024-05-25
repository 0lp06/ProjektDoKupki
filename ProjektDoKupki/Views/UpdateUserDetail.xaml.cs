using ProjektMAUI.Models;
using ProjektMAUI.ViewModels;

namespace ProjektMAUI.Views;

public partial class UpdateUserDetail : ContentPage
{
    private readonly UpdateUserDetailViewModel viewModel;
    public static User user = new User();

	public UpdateUserDetail()
	{
		InitializeComponent();

        FirstName.Text = user.FirstName;
        LastName.Text = user.LastName;
        Email.Text = user.Email;
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(user.FirstName))
        {
            Shell.Current.DisplayAlert("B³¹d", "Nie wpisa³eœ imienia!", "Ok");
            return;
        }
        if (string.IsNullOrEmpty(user.LastName))
        {
            Shell.Current.DisplayAlert("B³¹d", "Nie wpisa³eœ nazwiska!", "Ok");
            return;
        }
        if(string.IsNullOrEmpty(user.Email))
        {
            Shell.Current.DisplayAlert("B³¹d", "Nie wpisa³eœ Email!", "Ok");
            return;
        }
        co1s();
        user.FirstName = FirstName.Text;
        user.LastName = LastName.Text;
        user.Email = Email.Text;
    }
    public async void co1s()
    {
       await Shell.Current.DisplayAlert(user.FirstName, "Nie wpisa³eœ Email!", "Ok");

    }
}