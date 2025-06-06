﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NetflixCloneMAUI.Models;
using NetflixCloneMAUI.Services;

namespace NetflixCloneMAUI.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly TmdbService _tmdbService;

        public HomeViewModel(TmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }
        [ObservableProperty]
        private Media _trendingMovie;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ShowMovieInfoBox))]
        private Media? selectedMedia;

        public bool ShowMovieInfoBox => selectedMedia is not null;

        public ObservableCollection<Media> TopRated {  get; set; } = new();
        public ObservableCollection<Media> Trending {  get; set; } = new();
        public ObservableCollection<Media> NetflixOriginals { get; set; } = new();
        public ObservableCollection<Media> ActionMovies {  get; set; } = new();

        public async Task InitializeAsync()
        {
            var trendingListTask = _tmdbService.GetTrendingAsync();
            var netflixOriginalsListTask = _tmdbService.GetNetflixOriginalAsync();
            var topRatedListTask = _tmdbService.GetTopRatedAsync();
            var actionListTask = _tmdbService.GetActionAsync();

            var medias = await Task.WhenAll(trendingListTask,
                                            netflixOriginalsListTask,
                                            topRatedListTask,
                                            actionListTask);

            var trendingList = medias[0];
            var netflixOriginalsList = medias[1];
            var topRatedList = medias[2];
            var actionList = medias[3];


            //setting random trending movie from Trending List to the Trending Movie
            TrendingMovie = trendingList.OrderBy(t => Guid.NewGuid()).
                                 FirstOrDefault(t =>
                                 !string.IsNullOrWhiteSpace(t.DisplayTitle)
                                 && !string.IsNullOrWhiteSpace(t.Thumbnail));

            SetMediaCollection(trendingList, Trending);
            SetMediaCollection(netflixOriginalsList, NetflixOriginals);
            SetMediaCollection(topRatedList, TopRated);
            SetMediaCollection(actionList, ActionMovies);

            //SelectedMedia == TrendingMovie;
        }

        private void SetMediaCollection(IEnumerable<Media> medias, ObservableCollection<Media> collection)
        {
            collection.Clear();
            foreach (var media in medias)
            {
                collection.Add(media);
            }
        }
        [RelayCommand]
        private void SelectMedia(Media? media = null)
        {
            if (media is not null)
            {
                if(media.Id == SelectedMedia?.Id)
                {
                    media = null;
                }
            }
            SelectedMedia = media;
        }
    }
}
