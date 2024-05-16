using ProjektDoKupki.Views;

namespace ProjektDoKupki
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddUser),typeof(AddUser));
           // Routing.RegisterRoute(nameof(AddUpdateStudentDetail),typeof(AddUpdateStudentDetail));
        }
    }
}
