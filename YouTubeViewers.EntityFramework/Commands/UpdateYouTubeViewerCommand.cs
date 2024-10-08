﻿using System.Threading.Tasks;
using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Models;
using YouTubeViewers.EntityFramework.DTOs;

namespace YouTubeViewers.EntityFramework.Commands
{
    public class  UpdateYouTubeViewerCommand : IUpdateYouTubeViewerCommand
    {
        private readonly YouTubeViewersDbContextFactory _contextFactory;

        public UpdateYouTubeViewerCommand(YouTubeViewersDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(YouTubeViewer youTubeViewer)
        {
            await Task.Delay(2000);

            using (YouTubeViewersDbContext context = _contextFactory.Create())
            {
                var youTubeViewersDto = new YouTubeViewerDto()
                {
                    Id = youTubeViewer.Id,
                    UserName = youTubeViewer.UserName,
                    IsSubscribed = youTubeViewer.IsSubscribed,
                    IsMember = youTubeViewer.IsMember
                };

                context.YouTubeViewers.Update(youTubeViewersDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
