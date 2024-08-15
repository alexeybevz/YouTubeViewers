namespace YouTubeViewers.WPF.ViewModels
{
    public class AddYouTubeViewerViewModel : ViewModelBase
    {
        private YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; set; }

        public AddYouTubeViewerViewModel()
        {
            YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel();
        }
    }
}
