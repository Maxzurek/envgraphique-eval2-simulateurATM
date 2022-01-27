using EnvGraphique.Evaluation2.ATM.Domain.Services;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Authentication;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Data;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Transactions;
using EnvGraphique.Evaluation2.ATM.WPF.Commands.Authentication;
using System.Windows;
using System.Windows.Input;

namespace EnvGraphique.Evaluation2.ATM.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; }

        public LoginViewModel(
            MainViewModel mainViewModel,
            ILoginService loginService,
            IAccountDataService accountDataService,
            ITransactionService transactionService,
            ITransactionDataService transactionDataService,
            IUserDataService userDataService)
        {
            LoginCommand = new LoginCommand(mainViewModel, this, loginService, accountDataService, userDataService);
            LoginTooltipVisibility = Visibility.Hidden;
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

        private string password;

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private string loginTooltip;
        public string LoginTooltip
        {
            get
            {
                return loginTooltip;
            }
            set
            {
                loginTooltip = value;
                OnPropertyChanged(nameof(LoginTooltip));
            }
        }

        private Visibility loginTooltipVisibility;
        public Visibility LoginTooltipVisibility
        {
            get
            {
                return loginTooltipVisibility;
            }
            set
            {
                loginTooltipVisibility = value;
                OnPropertyChanged(nameof(loginTooltipVisibility));
            }
        }
    }
}
