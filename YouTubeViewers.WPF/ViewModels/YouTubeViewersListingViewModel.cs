﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using YouTubeViewers.WPF.Models;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<YouTubeViewersListingItemViewModel> _youTubeViewersListingItemViewModels;
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;

        public IEnumerable<YouTubeViewersListingItemViewModel> YouTubeViewersListingItemViewModels => _youTubeViewersListingItemViewModels;

        private YouTubeViewersListingItemViewModel _selectedYouTubeViewerListingItemViewModel;

        public YouTubeViewersListingItemViewModel SelectedYouTubeViewerListingItemViewModel
        {
            get { return _selectedYouTubeViewerListingItemViewModel; }
            set
            {
                _selectedYouTubeViewerListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedYouTubeViewerListingItemViewModel));

                _selectedYouTubeViewerStore.SelectedYouTubeViewer = _selectedYouTubeViewerListingItemViewModel?.YouTubeViewer;
            }
        }

        public YouTubeViewersListingViewModel(SelectedYouTubeViewerStore selectedYouTubeViewerStore)
        {
            _youTubeViewersListingItemViewModels = new ObservableCollection<YouTubeViewersListingItemViewModel>();

            _youTubeViewersListingItemViewModels.Add(new YouTubeViewersListingItemViewModel(new YouTubeViewer("Mary", true, false)));
            _youTubeViewersListingItemViewModels.Add(new YouTubeViewersListingItemViewModel(new YouTubeViewer("Sean", true, false)));
            _youTubeViewersListingItemViewModels.Add(new YouTubeViewersListingItemViewModel(new YouTubeViewer("Alan", true, false)));

            _selectedYouTubeViewerStore = selectedYouTubeViewerStore;
        }
    }
}
