using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Transactions;
using EnvGraphique.Evaluation2.ATM.WPF.Commands.Client;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs.AccountDTO;

namespace EnvGraphique.Evaluation2.ATM.WPF.ViewModels
{
    public class ClientDepositViewModel : ViewModelBase
    {
        public MainViewModel MainViewModel { get; }

        public ICommand TransactionDepositCommand { get; }

        public ClientDepositViewModel(MainViewModel mainViewModel, ITransactionService transactionService)
        {
            this.MainViewModel = mainViewModel;
            TransactionDepositCommand = new TransactionDepositCommand(this, transactionService);

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
                if (value != selectedSourceAccount)
                {
                    selectedSourceAccount = value;
                    OnPropertyChanged(nameof(SelectedSourceAccount));
                }
            }
        }

        private string amount;
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
                    case (int)EAccountType.Mortgage:
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
