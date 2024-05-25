using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProjektMAUI.Models;
using ProjektMAUI.Services;
using ProjektMAUI.Views;

namespace ProjektMAUI.ViewModels
{
    public partial class AddUserViewModel
    {
        public string name { get; set; } = "";
        public string surname { get; set; } = "";
        public string email { get; set; } = "";

        private readonly IUserService _studentService = new UserService();

        public AddUserViewModel() {
        }

        public async void AddUser()
        {

            if (string.IsNullOrEmpty(name))
            {
                await Shell.Current.DisplayAlert("Brak danych", "Należy Podać Imie!", "OK");
                return;
            }
            if (string.IsNullOrEmpty(surname))
            {
                await Shell.Current.DisplayAlert("Brak danych", "Należy Podać Nazwisko!", "OK");
                return;
            }
            if (string.IsNullOrEmpty(email))
            {
                await Shell.Current.DisplayAlert("Brak danych", "Należy Podać Email!", "OK");
                return;
            }

            await _studentService.AddUser(new User(name,surname,email));

            this.name = "";
            this.surname = "";
            this.email = "";

            await AppShell.Current.GoToAsync("..");

        }
    }
}
