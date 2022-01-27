using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Transactions;
using EnvGraphique.Evaluation2.ATM.WPF.Commands.Client;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs.AccountDTO;

namespace EnvGraphique.Evaluation2.ATM.WPF.ViewModels
{
    public class ClientWithdrawViewModel : ViewModelBase
    {
        private MainViewModel MainViewModel { get; }

        public ICommand TransactionWithdrawCommand { get; }

        public ClientWithdrawViewModel(MainViewModel mainViewModel, ITransactionService transactionService)
        {
            MainViewModel = mainViewModel;
            TransactionWithdrawCommand = new TransactionWithdrawCommand(mainViewModel, this, transactionService);

            AvailableAccounts = getAvailableAccounts();
        }

        private AccountDTO selectedSourceAccount;
        public AccountDTO SelectedSourceAccount
        {
            get
            {
                return selectedSourceAccount;
            }
            set
            {
                selectedSourceAccount = value;
                OnPropertyChanged(nameof(SelectedSourceAccount));
            }
        }

        private string amount; // TODO Change all amount property type in client view models to string, update commands (try catch to make sure there are no typos)
        public string Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        private ObservableCollection<AccountDTO> availableAccounts;
        public ObservableCollection<AccountDTO> AvailableAccounts
        {
            get
            {
                return availableAccounts;
            }
            set
            {
                availableAccounts = value;
                OnPropertyChanged(nameof(AvailableAccounts));
            }
        }

        private ObservableCollection<AccountDTO> getAvailableAccounts()
        {
            ObservableCollection<AccountDTO> availableAccounts = new ObservableCollection<AccountDTO>();

            foreach (AccountDTO account in MainViewModel.LoggedInUserAccounts)
            {
                switch (account.IdAccountType)
                {
                    case (int)EAccountType.Checking:
                    case (int)EAccountType.Saving:
                        availableAccounts.Add(account);
                        break;
                    default:
                        break;
                }
            }

            return availableAccounts;
        }
    }
}
