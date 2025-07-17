using OF.Base.ViewModel;
using System.Collections.ObjectModel;

namespace OF.DisplayManager.Application
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<DisplayConfiguration> _currentDisplayConfigs = new ObservableCollection<DisplayConfiguration>();
        public ObservableCollection<DisplayConfiguration> CurrentDisplayConfigs
        {
            get => _currentDisplayConfigs;
            private set => SetProperty(ref _currentDisplayConfigs, value);
        }

        public ObservableCollection<DisplayConfiguration> StoredDisplayConfigs
        {
            get => new ObservableCollection<DisplayConfiguration>(CurrentApplication.ConfigStorage.StoredConfigs);
        }

        public MainViewModel() : base("Main")
        {
            RefreshCurrentConfig();
            CurrentApplication.ConfigStorage.PropertyChanged += ConfigStorage_PropertyChanged;
        }

        private void ConfigStorage_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CurrentApplication.ConfigStorage.StoredConfigs)) OnPropertyChanged(nameof(StoredDisplayConfigs));
        }

        public void RefreshCurrentConfig()
        {
            CurrentDisplayConfigs = new ObservableCollection<DisplayConfiguration>(DisplayConfigHelper.GetCurrentDisplayConfigurationsNEW());
        }
    }
}
