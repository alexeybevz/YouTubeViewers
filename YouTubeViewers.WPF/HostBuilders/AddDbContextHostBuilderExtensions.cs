using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Queries;
using YouTubeViewers.EntityFramework;
using YouTubeViewers.EntityFramework.Commands;
using YouTubeViewers.EntityFramework.Queries;
using YouTubeViewers.WPF.Stores;

namespace YouTubeViewers.WPF.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
            {
                string connectionString = context.Configuration.GetConnectionString("sqlite");

                services.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);
                services.AddSingleton<YouTubeViewersDbContextFactory>();

                services.AddSingleton<IGetAllYouTubeViewersQuery, GetAllYouTubeViewersQuery>();
                services.AddSingleton<ICreateYouTubeViewerCommand, CreateYouTubeViewerCommand>();
                services.AddSingleton<IUpdateYouTubeViewerCommand, UpdateYouTubeViewerCommand>();
                services.AddSingleton<IDeleteYouTubeViewerCommand, DeleteYouTubeViewerCommand>();

                services.AddSingleton<ModalNavigationStore>();
                services.AddSingleton<YouTubeViewersStore>();
                services.AddSingleton<SelectedYouTubeViewerStore>();
            });

            return hostBuilder;
        }
    }
}
