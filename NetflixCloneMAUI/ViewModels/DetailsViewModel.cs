using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NetflixCloneMAUI.Models;
using NetflixCloneMAUI.Pages;
using NetflixCloneMAUI.Services;
using System.Collections.ObjectModel;


namespace NetflixCloneMAUI.ViewModels
{
    [QueryProperty(nameof(Media), nameof(Media))]
    public partial class DetailsViewModel : ObservableObject
    {
        private readonly TmdbService _tmdbService;

        public DetailsViewModel(TmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }
        [ObservableProperty]
        private Media _media;

        [ObservableProperty]
        private string _mainTrailerUrl;

        [ObservableProperty]
        private bool _isBusy;

        public async Task InitializeAsync()
        {
            IsBusy = true;

            var trailerTeasers = await _tmdbService.GetTrailersAsync(Media.Id, Media.MediaType);
            try
            {
                if (trailerTeasers?.Any() == true)
                {
                    var trailer = trailerTeasers.FirstOrDefault(t => t.type == "Trailer");
                    if (trailer == null)
                    {
                        trailer = trailerTeasers.First();
                    }
                    MainTrailerUrl = GenerateYoutueUrl(trailer.key);
                }
                else
                {
                    await Shell.Current.DisplayAlert("Not Found", "No videos found", "Ok");
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
        private static string GenerateYoutueUrl(string videoKey) =>
            $"https://www.youtube.com/embed/{videoKey}";
    }
}
