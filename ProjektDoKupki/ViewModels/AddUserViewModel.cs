using Android.Util;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProjektDoKupki.Models;
using ProjektDoKupki.Services;
using ProjektDoKupki.Views;

namespace ProjektDoKupki.ViewModels
{
    [QueryProperty(nameof(UserDetail), "User Detail:")]
    public partial class AddUserViewModel : ObservableObject
    {
        [ObservableProperty]
        private User _UserDetail = new User();
        private AddUser addUser = new AddUser();



        private readonly IUserService _studentService;

        public AddUserViewModel(IUserService studentService)
        {
            this._studentService = studentService;
        }

        [ICommand]
        public async void AddUser()
        {

            //Trace.WriteLine("First NAme:", UserDetail.FirstName.ToString());
            await Shell.Current.DisplayAlert("Record Added", "Record  to Student Table","OK");


            await _studentService.AddStudent(new Models.User
                {
                    
                    FirstName = UserDetail.FirstName,
                    LastName = UserDetail.LastName,
                    Email = addUser.getEmail(),
                });
                await Shell.Current.DisplayAlert("Record Added", "Record  to Student Table", "OK");


        }
    }
}
