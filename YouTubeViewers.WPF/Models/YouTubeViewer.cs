namespace YouTubeViewers.WPF.Models
{
    public class YouTubeViewer
    {
        public string UserName { get; set; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }
        
        public YouTubeViewer(string userName, bool isSubscribed, bool isMember)
        {
            UserName = userName;
            IsSubscribed = isSubscribed;
            IsMember = isMember;
        }
    }
}
