
using Prueba.ViewModels;
using Prueba.Services;
using Prueba.Services.CAD_PROYECTO2.Services;

namespace Prueba;

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

        builder.Services.AddSingleton<InterfazBDD, BDD>();

        builder.Services.AddSingleton<ImageList>();
        builder.Services.AddSingleton<ImageListModel>();

        return builder.Build();
    }
}
