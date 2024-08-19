using Microsoft.EntityFrameworkCore;
using System.Windows;
using YouTubeViewers.Domain.Commands;
using YouTubeViewers.Domain.Queries;
using YouTubeViewers.EntityFramework;
using YouTubeViewers.EntityFramework.Commands;
using YouTubeViewers.EntityFramework.Queries;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ModalNavigationStore _modelNavigationStore;
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;
        private readonly YouTubeViewersStore _youTubeViewersStore;

        private readonly YouTubeViewersDbContextFactory _youTubeViewersDbContextFactory;

        private readonly IGetAllYouTubeViewersQuery _getAllYouTubeViewersQuery;
        private readonly ICreateYouTubeViewerCommand _createYouTubeViewerCommand;
        private readonly IUpdateYouTubeViewerCommand _updateYouTubeViewerCommand;
        private readonly IDeleteYouTubeViewerCommand _deleteYouTubeViewerCommand;

        public App()
        {
            string connectionString = "Data Source=YouTubeViewers.db";

            _youTubeViewersDbContextFactory = new YouTubeViewersDbContextFactory(new DbContextOptionsBuilder().UseSqlite(connectionString).Options);

            _getAllYouTubeViewersQuery = new GetAllYouTubeViewersQuery(_youTubeViewersDbContextFactory);
            _createYouTubeViewerCommand = new CreateYouTubeViewerCommand(_youTubeViewersDbContextFactory);
            _updateYouTubeViewerCommand = new UpdateYouTubeViewerCommand(_youTubeViewersDbContextFactory);
            _deleteYouTubeViewerCommand = new DeleteYouTubeViewerCommand(_youTubeViewersDbContextFactory);

            _modelNavigationStore = new ModalNavigationStore();
            _youTubeViewersStore = new YouTubeViewersStore(
                _getAllYouTubeViewersQuery,
                _createYouTubeViewerCommand,
                _updateYouTubeViewerCommand,
                _deleteYouTubeViewerCommand);
            _selectedYouTubeViewerStore = new SelectedYouTubeViewerStore(_youTubeViewersStore);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            using (YouTubeViewersDbContext context = _youTubeViewersDbContextFactory.Create())
            {
                context.Database.Migrate();
            }

            YouTubeViewersViewModel youTubeViewersViewModel = new YouTubeViewersViewModel(
                _youTubeViewersStore,
                _selectedYouTubeViewerStore,
                _modelNavigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modelNavigationStore, youTubeViewersViewModel)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
