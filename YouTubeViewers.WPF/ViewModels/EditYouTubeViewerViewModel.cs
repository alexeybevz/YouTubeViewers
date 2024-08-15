namespace YouTubeViewers.WPF.ViewModels
{
    public class EditYouTubeViewerViewModel : ViewModelBase
    {
        private YouTubeViewerDetailsFormViewModel YouTubeViewerDetailsFormViewModel { get; set; }

        public EditYouTubeViewerViewModel()
        {
            YouTubeViewerDetailsFormViewModel = new YouTubeViewerDetailsFormViewModel();
        }
    }
}
