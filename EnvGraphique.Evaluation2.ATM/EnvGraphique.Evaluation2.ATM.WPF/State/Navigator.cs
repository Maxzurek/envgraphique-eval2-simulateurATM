using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using System.ComponentModel;

namespace EnvGraphique.Evaluation2.ATM.WPF.State
{
    public class Navigator : INotifyPropertyChanged
    {
        private ViewModelBase currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => currentViewModel;
            set
            {
                currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
        private ViewModelBase currentNavBarViewModel;

        public ViewModelBase CurrentNavBarViewModel
        {
            get => currentNavBarViewModel;
            set
            {
                currentNavBarViewModel = value;
                OnPropertyChanged(nameof(CurrentNavBarViewModel));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
