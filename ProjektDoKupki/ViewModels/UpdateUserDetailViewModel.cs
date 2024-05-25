using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProjektMAUI.Models;
using ProjektMAUI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjektMAUI.ViewModels
{

    [QueryProperty(nameof(userDetail), "User Edit: ")]
    public partial class UpdateUserDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        public User userDetail = new User();

        private readonly IUserService _studentService = new UserService();

        public UpdateUserDetailViewModel()
        {
             if (userDetail.FirstName == null) { 
             Shell.Current.DisplayAlert("Konstruktor jest null! ", "Należy Podać Imie!", "OK");
            }
        }


    }
}
