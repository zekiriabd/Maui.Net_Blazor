using MauiFrontendApp.Services.Interfaces;
using Refit;

namespace MauiFrontendApp;

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
			});

        builder.Services.AddRefitClient<IRefitServices>().ConfigureHttpClient(
           c => c.BaseAddress = new Uri("http://localhost:5067"));

        builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		#endif


		//builder.Services.AddSingleton<IPointService, PointService>();

        return builder.Build();
	}
}
