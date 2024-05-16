using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProjektDoKupki.Models;
using ProjektDoKupki.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjektDoKupki.ViewModels
{
    [QueryProperty(nameof(_UserDetail), "User Detail:")]
    public partial class AddUpdateStudentDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private User _UserDetail = new User();

        private readonly IUserService _studentService;

        public AddUpdateStudentDetailViewModel(IUserService studentService)
        {
            this._studentService = studentService;
        }

        [ICommand]
        public async void AddUpdateStudent()
        {
            int response = -1;
            if (_UserDetail.StudentId >0)
            {
                response = await _studentService.UpdateStudent(_UserDetail);
            }
            else
            {
                response = await _studentService.AddStudent(new Models.User
                {
                    FirstName = _UserDetail.FirstName,
                    LastName = _UserDetail.LastName,
                    Email = _UserDetail.Email
                });
            }
            if (response >0)
            {
                await Shell.Current.DisplayAlert("Record Saved", "Record Saved to Student Table", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Record Added", "Record  to Student Table", "OK");
            }
        }
    }
}
