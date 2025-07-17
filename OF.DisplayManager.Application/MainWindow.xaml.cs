using System.Windows;

namespace OF.DisplayManager.Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainViewModel _vm = new MainViewModel();
        public MainViewModel VM => _vm;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = VM;
        }

        private void RefreshCurrentButton_Click(object sender, RoutedEventArgs e)
        {
            VM.RefreshCurrentConfig();
        }

        private void SaveProfileButton_Click(object sender, RoutedEventArgs e)
        {
            VM.StoreCurrentConfigsAsProfile();
        }
    }
}