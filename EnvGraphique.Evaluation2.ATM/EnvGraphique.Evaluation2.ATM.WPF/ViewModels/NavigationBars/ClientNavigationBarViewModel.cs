using EnvGraphique.Evaluation2.ATM.Domain.Services.Transactions;
using EnvGraphique.Evaluation2.ATM.WPF.Commands.Authentication;
using EnvGraphique.Evaluation2.ATM.WPF.Commands.Navigation;
using System.Windows.Input;

namespace EnvGraphique.Evaluation2.ATM.WPF.ViewModels.NavigationBars
{
    public enum EClientView
    {
        Home,
        Deposit,
        Withdraw,
        Payment,
        Transfert
    }

    public class ClientNavigationBarViewModel : ViewModelBase
    {
        public ICommand ChangeClientViewCommand { get; }

        public ICommand LogoutCommand { get; }

        public ClientNavigationBarViewModel(MainViewModel mainViewModel, ITransactionService transactionService)
        {
            ChangeClientViewCommand = new ChangeClientViewCommand(mainViewModel, transactionService);
            LogoutCommand = new LogoutCommand(mainViewModel);
        }

    }
}
