using Microsoft.Extensions.Logging;
using ProjektDoKupki.Models;
using ProjektDoKupki.Services;
using ProjektDoKupki.ViewModels;
using ProjektDoKupki.Views;

namespace ProjektDoKupki
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //Services
            builder.Services.AddSingleton<IUserService, UserService>();

            //View Registration
            builder.Services.AddSingleton<StudentListPage>();
            builder.Services.AddTransient<AddUpdateStudentDetail>();

            //View Model
            builder.Services.AddSingleton<UserListPageViewModel>();
            builder.Services.AddSingleton<AddUpdateStudentDetailViewModel>();



#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
