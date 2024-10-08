﻿using System;
using System.Threading.Tasks;
using YouTubeViewers.Domain.Commands;
using YouTubeViewers.EntityFramework.DTOs;

namespace YouTubeViewers.EntityFramework.Commands
{
    public class DeleteYouTubeViewerCommand : IDeleteYouTubeViewerCommand
    {
        private readonly YouTubeViewersDbContextFactory _contextFactory;

        public DeleteYouTubeViewerCommand(YouTubeViewersDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {
            await Task.Delay(2000);

            using (YouTubeViewersDbContext context = _contextFactory.Create())
            {
                var youTubeViewersDto = new YouTubeViewerDto()
                {
                    Id = id,
                };

                context.YouTubeViewers.Remove(youTubeViewersDto);
                await context.SaveChangesAsync();
            }
        }
    }
}
