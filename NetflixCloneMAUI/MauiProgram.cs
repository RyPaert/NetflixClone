﻿using Microsoft.Extensions.Logging;
using NetflixCloneMAUI.Pages;
using NetflixCloneMAUI.Services;
using NetflixCloneMAUI.ViewModels;
using CommunityToolkit.Maui;

namespace NetflixCloneMAUI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("Poppins-Regular.ttf", "PoppinsRegular");
                fonts.AddFont("Poppins-Semibold.ttf", "PoppinsSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif
        builder.Services.AddHttpClient(TmdbService.TmdbHttpClientName,
            httpClient => httpClient.BaseAddress = new Uri("https://api.themoviedb.org"));

        builder.Services.AddSingleton<TmdbService>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<HomeViewModel>();

		builder.Services.AddSingleton<CategoriesPage>();
		builder.Services.AddSingleton<CategoriesViewModel>();

        builder.Services.AddTransientWithShellRoute<DetailsPage, DetailsViewModel>(nameof(DetailsPage));
        return builder.Build();
	}
}
