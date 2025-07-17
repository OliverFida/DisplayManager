using OF.Base.ViewModel;
using System.Collections.ObjectModel;

namespace OF.DisplayManager.Application
{
    public class MainViewModel : ViewModelBase
    {
        #region Properties
        private ObservableCollection<DisplayConfiguration> _currentDisplayConfigs = new ObservableCollection<DisplayConfiguration>();
        public ObservableCollection<DisplayConfiguration> CurrentDisplayConfigs
        {
            get => _currentDisplayConfigs;
            private set => SetProperty(ref _currentDisplayConfigs, value);
        }

        public ObservableCollection<DisplayConfiguration> StoredProfiles
        {
            get => new ObservableCollection<DisplayConfiguration>(CurrentApplication.ProfileStorage.StoredProfiles);
        }

        private string _newProfileName = string.Empty;
        public string NewProfileName
        {
            get => _newProfileName;
            set => SetProperty(ref _newProfileName, value);
        }
        #endregion

        #region Constructor
        public MainViewModel() : base("Main")
        {
            RefreshCurrentConfig();
            CurrentApplication.ProfileStorage.PropertyChanged += ConfigStorage_PropertyChanged;
        }
        #endregion

        #region Methods PUBLIC
        public void RefreshCurrentConfig()
        {
            CurrentDisplayConfigs = new ObservableCollection<DisplayConfiguration>(DisplayConfigHelper.GetCurrentDisplayConfigurations());
        }

        public void StoreCurrentConfigsAsProfile()
        {
            CurrentApplication.ProfileStorage.StoreProfile(NewProfileName, CurrentDisplayConfigs.ToList());
            MessageBox.Show("Profile stored!", "DisplayManager", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Methods PRIVATE
        private void ConfigStorage_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CurrentApplication.ProfileStorage.StoredProfiles)) OnPropertyChanged(nameof(StoredProfiles));
        }
        #endregion
    }
}
