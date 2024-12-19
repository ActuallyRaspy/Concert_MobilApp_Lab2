using CommunityToolkit.Maui;
//using CommunityToolkit.Maui.Markup;
using Microsoft.Extensions.Logging;
using Todo.MAUI.Services;
using Todo.MAUI.ViewModels;
using Todo.MAUI.Views;

namespace Todo.MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
        .UseMauiApp<App>()
        .UseMauiCommunityToolkit()
        //.UseMauiCommunityToolkitMarkup()
        .ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });
#if DEBUG
        builder.Logging.AddDebug();
#endif
        // Services
        builder.Services.AddSingleton<IHttpsClientHandlerService, HttpsClientHandlerService>();
        builder.Services.AddSingleton<IRestService, RestService>();
        builder.Services.AddSingleton<IConcertService, ConcertService>();
        builder.Services.AddSingleton<IPerformanceService, PerformanceService>();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        //builder.Services.AddAutoMapper(typeof(TodoItemProfile));

        // Pages
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<ConcertPage>();
        builder.Services.AddSingleton<ConcertDetailsPage>();
        builder.Services.AddSingleton<BookPerformancePage>();
        builder.Services.AddSingleton<BookingsPage>();


        // ViewModels
        builder.Services.AddSingleton<MainPageVM>();
        builder.Services.AddSingleton<ConcertPageVM>();
        builder.Services.AddSingleton<ConcertDetailsPageVM>();
        builder.Services.AddSingleton<BookPerformancePageVM>();
        builder.Services.AddSingleton<BookingsPageVM>();

        return builder.Build();
    }
}