using EnvGraphique.Evaluation2.ATM.Domain.Services.Transactions;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels.NavigationBars;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Navigation
{
    public class ChangeClientViewCommand : CommandBase
    {
        private readonly MainViewModel mainViewModel;
        private readonly ITransactionService transactionService;

        public ChangeClientViewCommand(MainViewModel mainViewModel, ITransactionService transactionService)
        {
            this.mainViewModel = mainViewModel;
            this.transactionService = transactionService;
        }

        public override void Execute(object parameter)
        {
            if (parameter is EClientView)
            {
                EClientView clientView = (EClientView)parameter;

                switch (clientView)
                {
                    case EClientView.Home:
                        ClientHomeViewModel clientHomeViewModel = new ClientHomeViewModel(mainViewModel);
                        mainViewModel.Navigator.CurrentViewModel = clientHomeViewModel;
                        break;
                    case EClientView.Deposit:
                        ClientDepositViewModel clientDepositViewModel = new ClientDepositViewModel(mainViewModel, transactionService);
                        mainViewModel.Navigator.CurrentViewModel = clientDepositViewModel;
                        break;
                    case EClientView.Withdraw:
                        ClientWithdrawViewModel clientWithdrawViewModel = new ClientWithdrawViewModel(mainViewModel, transactionService);
                        mainViewModel.Navigator.CurrentViewModel = clientWithdrawViewModel;
                        break;
                    case EClientView.Payment:
                        ClientPaymentViewModel clientPaymentViewModel = new ClientPaymentViewModel(mainViewModel, transactionService);
                        mainViewModel.Navigator.CurrentViewModel = clientPaymentViewModel;
                        break;
                    case EClientView.Transfert:
                        ClientTransferViewModel clientTransferViewModel = new ClientTransferViewModel(mainViewModel, transactionService);
                        mainViewModel.Navigator.CurrentViewModel = clientTransferViewModel;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
