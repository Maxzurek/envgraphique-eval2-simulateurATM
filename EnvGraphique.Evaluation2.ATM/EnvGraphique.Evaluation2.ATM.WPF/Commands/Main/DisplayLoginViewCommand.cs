using EnvGraphique.Evaluation2.ATM.Domain.Services;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Authentication;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Data;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Transactions;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Authentication
{
    public class DisplayLoginViewCommand : CommandBase
    {
        private readonly MainViewModel mainViewModel;
        private readonly ILoginService loginService;
        private readonly IAccountDataService accountDataService;
        private readonly ITransactionService transactionService;
        private readonly ITransactionDataService transactionDataService;
        private readonly IUserDataService userDataService;

        public DisplayLoginViewCommand(
            MainViewModel mainViewModel,
            ILoginService loginService,
            IAccountDataService accountDataService,
            ITransactionService transactionService,
            ITransactionDataService transactionDataService,
            IUserDataService userDataService)
        {
            this.mainViewModel = mainViewModel;
            this.loginService = loginService;
            this.accountDataService = accountDataService;
            this.transactionService = transactionService;
            this.transactionDataService = transactionDataService;
            this.userDataService = userDataService;
        }

        public override void Execute(object parameter)
        {
            Application.Current.MainWindow.Height = 450;
            Application.Current.MainWindow.Width = 650;

            mainViewModel.Navigator.CurrentViewModel = new LoginViewModel(mainViewModel, loginService, accountDataService, transactionService, transactionDataService, userDataService);
        }
    }
}
