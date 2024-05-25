using ProjektMAUI.ViewModels;
using ProjektMAUI.Views;

namespace ProjektMAUI
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddUser),typeof(AddUser));
            Routing.RegisterRoute(nameof(UpdateUserDetail),typeof(UpdateUserDetail));
            Routing.RegisterRoute(nameof(UpdateUserDetailViewModel),typeof(UpdateUserDetailViewModel));

        }
    }
}
