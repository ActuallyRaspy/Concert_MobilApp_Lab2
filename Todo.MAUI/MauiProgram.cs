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
        builder.Services.AddSingleton<ITodoService, TodoService>();
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        //builder.Services.AddAutoMapper(typeof(TodoItemProfile));

        // Pages
        builder.Services.AddSingleton<TodoListPage>();
        builder.Services.AddTransient<TodoItemPage>();

        // ViewModels
        builder.Services.AddSingleton<TodoListViewModel>();
        builder.Services.AddTransient<TodoItemViewModel>();
        return builder.Build();
    }
}