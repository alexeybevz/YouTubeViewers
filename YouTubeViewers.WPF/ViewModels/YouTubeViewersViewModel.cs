using System.Windows.Input;
using YouTubeViewers.WPF.Commands;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersViewModel : ViewModelBase
    {
        public YouTubeViewersListingViewModel YouTubeViewersListingViewModel { get; }
        public YouTubeViewersDetailsViewModel YouTubeViewersDetailsViewModel { get; }

        private bool _isLoading;
        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ICommand AddYouTubeViewersCommand { get; }
        public ICommand LoadYouTubeViewersCommand { get; set; }

        public YouTubeViewersViewModel(YouTubeViewersStore _youTubeViewersStore, SelectedYouTubeViewerStore _selectedYouTubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewersListingViewModel = new YouTubeViewersListingViewModel(_youTubeViewersStore, _selectedYouTubeViewerStore, modalNavigationStore);
            YouTubeViewersDetailsViewModel = new YouTubeViewersDetailsViewModel(_selectedYouTubeViewerStore);

            LoadYouTubeViewersCommand = new LoadYouTubeViewersCommand(this, _youTubeViewersStore);
            AddYouTubeViewersCommand = new OpenAddYouTubeViewerCommand(_youTubeViewersStore, modalNavigationStore);
        }

        public static YouTubeViewersViewModel LoadViewModel(YouTubeViewersStore youTubeViewersStore, SelectedYouTubeViewerStore selectedYouTubeViewerStore, ModalNavigationStore modalNavigationStore)
        {
            YouTubeViewersViewModel viewModel = new YouTubeViewersViewModel(youTubeViewersStore, selectedYouTubeViewerStore, modalNavigationStore);
            viewModel.LoadYouTubeViewersCommand.Execute(null);
            return viewModel;
        }
    }
}
