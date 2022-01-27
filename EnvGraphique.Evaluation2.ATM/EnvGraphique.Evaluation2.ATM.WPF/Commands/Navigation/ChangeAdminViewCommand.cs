using EnvGraphique.Evaluation2.ATM.Domain.Services.Admin;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Data;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels.NavigationBars;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Navigation
{
    public class ChangeAdminViewCommand : CommandBase
    {
        private readonly MainViewModel mainViewModel;
        private readonly ITransactionDataService transactionDataService;
        private readonly IAdminManagementService adminManagementService;
        private readonly IAccountDataService accountDataService;

        public ChangeAdminViewCommand(
            MainViewModel mainViewModel,
            ITransactionDataService transactionDataService,
            IAdminManagementService adminManagementService,
            IAccountDataService accountDataService)
        {
            this.mainViewModel = mainViewModel;
            this.transactionDataService = transactionDataService;
            this.adminManagementService = adminManagementService;
            this.accountDataService = accountDataService;
        }

        public override void Execute(object parameter)
        {
            if (parameter is EAdminView)
            {
                EAdminView clientView = (EAdminView)parameter;

                switch (clientView)
                {
                    case EAdminView.Home:
                        AdminHomeViewModel adminHomeViewModel = new AdminHomeViewModel(mainViewModel, adminManagementService);
                        mainViewModel.Navigator.CurrentViewModel = adminHomeViewModel;
                        break;
                    case EAdminView.CreateUser:
                        AdminCreateUserViewModel adminCreateUserViewModel = new AdminCreateUserViewModel(mainViewModel, adminManagementService);
                        mainViewModel.Navigator.CurrentViewModel = adminCreateUserViewModel;
                        break;
                    case EAdminView.CreateAccount:
                        AdminCreateAccountViewModel adminCreateAccountViewModel = new AdminCreateAccountViewModel(mainViewModel, adminManagementService);
                        mainViewModel.Navigator.CurrentViewModel = adminCreateAccountViewModel;
                        break;
                    case EAdminView.Transactions:
                        AdminTransactionsViewModel adminTransactionsViewModel = new AdminTransactionsViewModel(mainViewModel, transactionDataService);
                        mainViewModel.Navigator.CurrentViewModel = adminTransactionsViewModel;
                        break;
                    case EAdminView.Withdraw:
                        AdminMortgagePaymentViewModel adminWithdrawViewModel = new AdminMortgagePaymentViewModel(mainViewModel, adminManagementService, accountDataService);
                        mainViewModel.Navigator.CurrentViewModel = adminWithdrawViewModel;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
