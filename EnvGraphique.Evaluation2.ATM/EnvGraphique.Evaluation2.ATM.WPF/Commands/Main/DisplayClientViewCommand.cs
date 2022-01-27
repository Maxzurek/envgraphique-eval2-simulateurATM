using EnvGraphique.Evaluation2.ATM.Domain.Services.Transactions;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels.NavigationBars;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Main
{
    public class DisplayClientViewCommand : CommandBase
    {
        private readonly MainViewModel mainViewModel;
        private readonly ITransactionService transactionService;

        public DisplayClientViewCommand(MainViewModel mainViewModel, ITransactionService transactionService)
        {
            this.mainViewModel = mainViewModel;
            this.transactionService = transactionService;
        }

        public override void Execute(object parameter)
        {
            Application.Current.MainWindow.Height = 550;
            Application.Current.MainWindow.Width = 750;

            ClientHomeViewModel clientHomeViewModel = new ClientHomeViewModel(mainViewModel);
            mainViewModel.Navigator.CurrentViewModel = clientHomeViewModel;

            ClientNavigationBarViewModel clientNavigationBarViewModel = new ClientNavigationBarViewModel(mainViewModel, transactionService);
            mainViewModel.Navigator.CurrentNavBarViewModel = clientNavigationBarViewModel;
            clientNavigationBarViewModel.ChangeClientViewCommand.Execute(EClientView.Home);
        }
    }
}
