using EnvGraphique.Evaluation2.ATM.Domain.Services.Admin;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Admin
{
    public class AdminPayInterestCommand : CommandBase
    {
        private readonly MainViewModel mainViewModel;
        private readonly AdminHomeViewModel adminHomeViewModel;
        private readonly AdminManagementService adminManagementService;

        public AdminPayInterestCommand(MainViewModel mainViewModel, AdminHomeViewModel adminHomeViewModel, IAdminManagementService adminManagementService)
        {
            this.mainViewModel = mainViewModel;
            this.adminHomeViewModel = adminHomeViewModel;
            this.adminManagementService = (AdminManagementService)adminManagementService;
        }

        public async override void Execute(object parameter)
        {
            await adminManagementService.PayAllSavingAccountsInterests(mainViewModel.SystemAccounts);

            MessageBox.Show(Application.Current.MainWindow,
                   "Les intérêts accrus des comptes épargnes du système ont été payés avec succès.",
                   "Opération terminé - Payer intérêts accrus");
        }
    }
}
