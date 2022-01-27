using EnvGraphique.Evaluation2.ATM.Domain.Services.Admin;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Data;
using EnvGraphique.Evaluation2.ATM.WPF.Commands.Authentication;
using EnvGraphique.Evaluation2.ATM.WPF.Commands.Navigation;
using System.Windows.Input;

namespace EnvGraphique.Evaluation2.ATM.WPF.ViewModels.NavigationBars
{
    public enum EAdminView
    {
        Home,
        CreateUser,
        CreateAccount,
        Transactions,
        Withdraw
    }

    public class AdminNavigationBarViewModel : ViewModelBase
    {
        private readonly ITransactionDataService transactionDataService;
        private readonly IAdminManagementService adminManagementService;

        public ICommand LogoutCommand { get; }

        public ICommand ChangeAdminViewCommand { get; }

        public AdminNavigationBarViewModel
            (MainViewModel mainViewModel,
            ITransactionDataService transactionDataService,
            IAdminManagementService adminManagementService,
            IAccountDataService accountDataService)
        {
            this.transactionDataService = transactionDataService;
            this.adminManagementService = adminManagementService;

            LogoutCommand = new LogoutCommand(mainViewModel);
            ChangeAdminViewCommand = new ChangeAdminViewCommand(mainViewModel, transactionDataService, adminManagementService, accountDataService);
        }

    }
}
