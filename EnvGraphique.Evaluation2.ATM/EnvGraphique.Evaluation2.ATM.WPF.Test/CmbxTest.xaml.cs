using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF.Test
{
    /// <summary>
    /// Interaction logic for CmbxTest.xaml
    /// </summary>
    public partial class CmbxTest : Window, INotifyPropertyChanged
    {
        public CmbxTest()
        {
            InitializeComponent();

            init();
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private UserDTO selected;

        public UserDTO Selected
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                OnPropertyChanged(nameof(Selected));
            }
        }

        private ObservableCollection<UserDTO> users;
        public ObservableCollection<UserDTO> Users
        {
            get
            {
                return users;
            }
            set
            {
                users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private async void init()
        {
            UserDataService userDataService = new UserDataService(new Domain.Models.ATMEntities());

            ObservableCollection<UserDTO> systemUsers = await userDataService.GetAll();
            cmbx.ItemsSource = systemUsers;
        }

        private void reset_Click(object sender, RoutedEventArgs e)
        {
            Selected = null;
        }

        private void OnPropertyChanged(string propname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
        }
    }
}
