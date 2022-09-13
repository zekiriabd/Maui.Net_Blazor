using BlazorPro.BlazorSize;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Stylesheet.Data;

namespace Stylesheet;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();

		builder.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});


        
        builder.Services.AddMauiBlazorWebView();

		#if DEBUG
			builder.Services.AddBlazorWebViewDeveloperTools();
		#endif
		
		builder.Services.AddSingleton<WeatherForecastService>();
        builder.Services.AddMediaQueryService();

        return builder.Build();
	}
}
