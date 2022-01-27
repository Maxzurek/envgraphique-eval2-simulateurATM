using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Admin;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Authentication;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Data;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Transactions;
using EnvGraphique.Evaluation2.ATM.WPF.Commands.Authentication;
using EnvGraphique.Evaluation2.ATM.WPF.Commands.Main;
using EnvGraphique.Evaluation2.ATM.WPF.State;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EnvGraphique.Evaluation2.ATM.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand DisplayLoginViewCommand { get; }
        public ICommand DisplayClientViewCommand { get; }
        public ICommand DisplayAdminViewCommand { get; }

        private Navigator navigator;

        public MainViewModel(
           Navigator navigator,
           ILoginService loginService,
           IAccountDataService accountDataService,
           ITransactionService transactionService,
           ITransactionDataService transactionDataService,
           IUserDataService userDataService,
           IAdminManagementService adminManagementService)
        {
            this.navigator = navigator;

            DisplayLoginViewCommand = new DisplayLoginViewCommand(this, loginService, accountDataService, transactionService, transactionDataService, userDataService);
            DisplayClientViewCommand = new DisplayClientViewCommand(this, transactionService);
            DisplayAdminViewCommand = new DisplayAdminViewCommand(this, transactionDataService, adminManagementService, accountDataService);

            DisplayLoginViewCommand.Execute(null);  // Set the login view as the default view at runtime
            availableCurrency = 20000;              // Default ATM currency available
        }

        public Navigator Navigator
        {
            get { return navigator; }
            private set { navigator = value; }
        }

        private ObservableCollection<UserDTO> systemUsers;
        public ObservableCollection<UserDTO> SystemUsers
        {
            get
            {
                return systemUsers;
            }
            set
            {
                systemUsers = value;
                OnPropertyChanged(nameof(SystemUsers));
            }
        }

        private ObservableCollection<AccountDTO> systemAccounts;
        public ObservableCollection<AccountDTO> SystemAccounts
        {
            get
            {
                return systemAccounts;
            }
            set
            {
                systemAccounts = value;
                OnPropertyChanged(nameof(SystemAccounts));
            }
        }

        private UserDTO loggedInUser;
        public UserDTO LoggedInUser
        {
            get
            {
                return loggedInUser;
            }
            set
            {
                loggedInUser = value;
                OnPropertyChanged(nameof(LoggedInUser));
            }
        }

        private ObservableCollection<AccountDTO> loggedInUserAccounts;
        public ObservableCollection<AccountDTO> LoggedInUserAccounts
        {
            get
            {
                return loggedInUserAccounts;
            }
            set
            {
                loggedInUserAccounts = value;
                OnPropertyChanged(nameof(LoggedInUserAccounts));
            }
        }

        private decimal availableCurrency;
        public decimal AvailableCurrency
        {
            get
            {
                return availableCurrency;
            }
            set
            {
                availableCurrency = value;
                OnPropertyChanged(nameof(AvailableCurrency));
            }
        }
    }
}
