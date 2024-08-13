namespace YouTubeViewers.WPF.ViewModels
{
    public class YouTubeViewersDetailsViewModel : ViewModelBase
    {
        public string UserName { get; set; }
        public string IsSubscribedDisplay { get; set; }
        public string IsMemberDisplay { get; set; }

        public YouTubeViewersDetailsViewModel()
        {
            UserName = "SingletonSean";
            IsSubscribedDisplay = "Yes";
            IsMemberDisplay = "No";
        }
    }
}
