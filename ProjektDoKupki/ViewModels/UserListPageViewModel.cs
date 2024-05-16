using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProjektDoKupki.Models;
using ProjektDoKupki.Services;
using ProjektDoKupki.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektDoKupki.ViewModels
{
    public partial class UserListPageViewModel : ObservableObject
    {
        public ObservableCollection<User> Students { get; set; } = new ObservableCollection<User>();

        private readonly IUserService _studentService;

        public UserListPageViewModel(IUserService studentService) { 
            
            _studentService = studentService;
        }

        [ICommand]
        private async void GetStudentList()
        {
            var StudentList = await _studentService.GetStudentService();
            if (StudentList?.Count >0) {
                Students.Clear();

                foreach (var student in StudentList)
                {

                    Students.Add(student);
                }
            }
        }
        [ICommand]
        public async void AddUserPage()
        {
            await AppShell.Current.GoToAsync(nameof(AddUser));
        }

        [ICommand]
        public async void DisplayAction(User student)
        {

            var response =  await AppShell.Current.DisplayActionSheet("Select Option: ", "OK", null, "Edit", "Delete");

            if (response == "Edit")
            {
                var navParam =new Dictionary<string , object>();

                navParam.Add("Student Detail: ", student);

                await AppShell.Current.GoToAsync(nameof(AddUpdateStudentDetail), navParam);
            }

            else if(response =="Delete")
            {
               var delResponse =  await _studentService.DeleteStudent(student);

                if(delResponse>0)
                {
                    GetStudentList();
                }
            }
        }
    }
}
