using Microsoft.Extensions.Logging;
using MonkeyFinder.Constants;
using MonkeyFinder.Interfaces.Services;
using MonkeyFinder.Services;
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

        Bootstrap( builder );

		return builder.Build();
	}

    private static void Bootstrap( MauiAppBuilder builder)
	{
        
        

		//->Main pages
        builder.Services.AddSingleton<MainPage>();

		//->Monkeys
		builder.Services.AddSingleton<IMonkeyService>(b => new MonkeyService());
        builder.Services.AddTransient<MonkeysViewModel>(b => new MonkeysViewModel
            (
            title: PageTitles.MONKEY_DASHBOARD,
            b.GetRequiredService<IMonkeyService>()
            )
        );

        //->MonkeyDetails
        builder.Services.AddTransient<DetailsPage>();
		builder.Services.AddTransient<MonkeyDetailsViewModel>(b => new MonkeyDetailsViewModel
			(
				title: PageTitles.MONKEY_SELECTED
			)
		);
    }
}
