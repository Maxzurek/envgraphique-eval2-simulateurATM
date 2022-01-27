using EnvGraphique.Evaluation2.ATM.Domain.Services.Admin;
using EnvGraphique.Evaluation2.ATM.WPF.Commands.Admin;
using System.Windows.Input;
using static EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs.UserDTO;

namespace EnvGraphique.Evaluation2.ATM.WPF.ViewModels
{
    public class AdminCreateUserViewModel : ViewModelBase
    {
        public ICommand AdminCreateUserCommand { get; }

        public AdminCreateUserViewModel(MainViewModel mainViewModel, IAdminManagementService adminManagementService)
        {
            AdminCreateUserCommand = new AdminCreateUserCommand(mainViewModel, this, adminManagementService);
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string phone;
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string nip;
        public string Nip
        {
            get
            {
                return nip;
            }
            set
            {
                nip = value;
                OnPropertyChanged(nameof(Nip));
            }
        }

        private EUserType selectedUserType;
        public EUserType SelectedUserType
        {
            get
            {
                return selectedUserType;
            }
            set
            {
                selectedUserType = value;
                OnPropertyChanged(nameof(SelectedUserType));
            }
        }
    }
}
