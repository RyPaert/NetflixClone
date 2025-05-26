using CommunityToolkit.Mvvm.ComponentModel;
using NetflixCloneMAUI.Models;
using NetflixCloneMAUI.Services;

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

        public Media Media { get; set; }
    }
}
