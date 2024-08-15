using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ModelNavigationStore _modalNavigationStore;

        public YouTubeViewersViewModel YouTubeViewersViewModel { get; }

        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public bool IsModalOpen => _modalNavigationStore.IsOpen;

        public MainViewModel(ModelNavigationStore modalNavigationStore, YouTubeViewersViewModel youTubeViewersViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            YouTubeViewersViewModel = youTubeViewersViewModel;

            _modalNavigationStore.CurrentViewModelChanged += ModalNavigationStore_CurrentViewModelChanged;
        }

        private void ModalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }

        protected override void Dispose()
        {
            _modalNavigationStore.CurrentViewModelChanged -= ModalNavigationStore_CurrentViewModelChanged;

            base.Dispose();
        }
    }
}
