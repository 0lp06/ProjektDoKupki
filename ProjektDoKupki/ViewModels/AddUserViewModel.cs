using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProjektDoKupki.Models;
using ProjektDoKupki.Services;
using ProjektDoKupki.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektDoKupki.ViewModels
{
    [QueryProperty(nameof(UserDetail), "User Detail:")]
    public partial class AddUserViewModel : ObservableObject
    {
        [ObservableProperty]
        private User _UserDetail = new User();

        private readonly IUserService _studentService;

        public AddUserViewModel(IUserService studentService)
        {
            this._studentService = studentService;
        }

        [ICommand]
        public async void AddUser()
        {

                await _studentService.AddStudent(new Models.User
                {
                    FirstName = UserDetail.FirstName,
                    LastName = UserDetail.LastName,
                    Email = UserDetail.Email
                });

                await Shell.Current.DisplayAlert("Record Added", "Record  to Student Table", "OK");

        }
    }
}
