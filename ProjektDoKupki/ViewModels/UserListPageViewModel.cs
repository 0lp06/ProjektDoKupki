using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ProjektMAUI.Models;
using ProjektMAUI.Services;
using ProjektMAUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektMAUI.ViewModels
{
    public partial class UserListPageViewModel : ObservableObject
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        private readonly IUserService _userService;

        public UserListPageViewModel(IUserService userService) { 
            
            _userService = userService;
        }

        [ICommand]
        private async void GetUserList()
        {
            var UserList = await _userService.GetUserService(); //pobiera elementy z tablicy
            if (UserList?.Count >0) {
                Users.Clear();

                foreach (var user in UserList)
                {

                    Users.Add(user);
                }
            }
        }
        [ICommand]
        public async void AddUserPage()
        {
            await AppShell.Current.GoToAsync(nameof(AddUser));
        }

        [ICommand]
        public async void DisplayAction(User user)
        {

            var response =  await AppShell.Current.DisplayActionSheet("Czy na pewno chcesz usunąć elemnt z tablicy? ", "anuluj", null, "tak", "nie");
           

            if(response == "tak")
            {
               var delResponse =  await _userService.DeleteUser(user);

                if(delResponse>0)
                {
                    GetUserList();
                }
            }
        }
    }
}
