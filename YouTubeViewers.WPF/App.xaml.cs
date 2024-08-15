using System.Windows;
using YouTubeViewers.WPF.Stores;
using YouTubeViewers.WPF.ViewModels;

namespace YouTubeViewers.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly SelectedYouTubeViewerStore _selectedYouTubeViewerStore;

        public App()
        {
            _modelNavigationStore = new ModelNavigationStore();
            _selectedYouTubeViewerStore = new SelectedYouTubeViewerStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            YouTubeViewersViewModel youTubeViewersViewModel = new YouTubeViewersViewModel(_selectedYouTubeViewerStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_modelNavigationStore, youTubeViewersViewModel)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
