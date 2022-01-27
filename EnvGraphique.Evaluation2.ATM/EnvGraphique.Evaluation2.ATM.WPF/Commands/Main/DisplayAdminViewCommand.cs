using EnvGraphique.Evaluation2.ATM.Domain.Services.Admin;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Data;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels.NavigationBars;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Main
{
    public class DisplayAdminViewCommand : CommandBase
    {
        private readonly MainViewModel mainViewModel;
        private readonly ITransactionDataService transactionDataService;
        private readonly IAdminManagementService adminManagementService;
        private readonly IAccountDataService accountDataService;

        public DisplayAdminViewCommand
            (MainViewModel mainViewModel,
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
            Application.Current.MainWindow.Height = 550;
            Application.Current.MainWindow.Width = 750;

            AdminHomeViewModel adminHomeViewModel = new AdminHomeViewModel(mainViewModel, adminManagementService);
            mainViewModel.Navigator.CurrentViewModel = adminHomeViewModel;

            AdminNavigationBarViewModel adminNavigationBarViewModel = new AdminNavigationBarViewModel(mainViewModel, transactionDataService, adminManagementService, accountDataService);
            mainViewModel.Navigator.CurrentNavBarViewModel = adminNavigationBarViewModel;
            adminNavigationBarViewModel.ChangeAdminViewCommand.Execute(EAdminView.Home);
        }
    }
}
