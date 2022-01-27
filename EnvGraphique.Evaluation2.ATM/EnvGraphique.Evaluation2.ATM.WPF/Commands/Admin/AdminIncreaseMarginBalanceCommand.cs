using EnvGraphique.Evaluation2.ATM.Domain.Services.Admin;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using System;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Admin
{
    public class AdminIncreaseMarginBalanceCommand : CommandBase
    {
        private readonly MainViewModel mainViewModel;
        private readonly AdminHomeViewModel adminHomeViewModel;
        private readonly AdminManagementService adminManagementService;

        public AdminIncreaseMarginBalanceCommand(MainViewModel mainViewModel, AdminHomeViewModel adminHomeViewModel, IAdminManagementService adminManagementService)
        {
            this.mainViewModel = mainViewModel;
            this.adminHomeViewModel = adminHomeViewModel;
            this.adminManagementService = (AdminManagementService)adminManagementService;
        }

        public async override void Execute(object parameter)
        {
            const decimal MARGIN_PERCENTAGE_INCREASE = 0.05m;

            await adminManagementService.IncreaseAllMarginAccountsBalance(mainViewModel.SystemAccounts, MARGIN_PERCENTAGE_INCREASE);

            MessageBox.Show(Application.Current.MainWindow,
                    String.Format("Les soldes de tous les comptes marges du système ont été augmentées de {0}% avec succès.", (MARGIN_PERCENTAGE_INCREASE * 100)),
                    "Opération terminé - Augmenter soldes marges");
        }
    }
}
