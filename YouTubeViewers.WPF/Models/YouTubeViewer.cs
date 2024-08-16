using System;

namespace YouTubeViewers.WPF.Models
{
    public class YouTubeViewer
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }
        
        public YouTubeViewer(Guid id, string userName, bool isSubscribed, bool isMember)
        {
            Id = id;
            UserName = userName;
            IsSubscribed = isSubscribed;
            IsMember = isMember;
        }
    }
}
