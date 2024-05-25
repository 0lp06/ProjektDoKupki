using Microsoft.Extensions.Logging;
using ProjektMAUI.Models;
using ProjektMAUI.Services;
using ProjektMAUI.ViewModels;
using ProjektMAUI.Views;

namespace ProjektMAUI
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
            builder.Services.AddTransient<UpdateUserDetail>();

            //View Model
            builder.Services.AddSingleton<UserListPageViewModel>();
            builder.Services.AddSingleton<UpdateUserDetailViewModel>();



#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
