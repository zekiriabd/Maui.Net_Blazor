using Microsoft.AspNetCore.Components.WebView.Maui;
using SqliteDemo.Services;
using SqliteDemo.Services.Interfaces;

namespace SqliteDemo;

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

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		#endif


		builder.Services.AddSingleton<IPointService, PointService>();

        return builder.Build();
	}
}
