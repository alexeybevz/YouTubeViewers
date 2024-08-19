using System;

namespace YouTubeViewers.EntityFramework.DTOs
{
    public class YouTubeViewerDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public bool IsSubscribed { get; }
        public bool IsMember { get; }
    }
}
