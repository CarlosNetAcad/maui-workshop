using Microsoft.Extensions.Logging;
using MonkeyFinder.Interfaces.Services;
using MonkeyFinder.View;

namespace MonkeyFinder;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<IMonkeyService>();

		builder.Services.AddTransient<MonkeysViewModel>( b => new MonkeysViewModel
			(
			"Monkey Finder",
			b.GetRequiredService<IMonkeyService>()
			)
		);

		builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
