using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Transactions;
using EnvGraphique.Evaluation2.ATM.WPF.Commands.Client;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs.AccountDTO;

namespace EnvGraphique.Evaluation2.ATM.WPF.ViewModels
{
    public class ClientTransferViewModel : ViewModelBase
    {
        private MainViewModel MainViewModel { get; }

        public ICommand TransactionTransferCommand { get; }

        private readonly ITransactionService transactionService;

        public ClientTransferViewModel(MainViewModel mainViewModel, ITransactionService transactionService)
        {
            MainViewModel = mainViewModel;
            this.transactionService = transactionService;

            TransactionTransferCommand = new TransactionTransferCommand(mainViewModel, this, transactionService);

            AvailableSourceAccounts = getAvailableSourceAccounts();
            AvailableTargetAccounts = getAvailableTargetAccounts();
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
                AvailableTargetAccounts = getAvailableTargetAccounts();
                OnPropertyChanged(nameof(SelectedSourceAccount));
            }
        }

        private AccountDTO selectedTargetAccount;
        public AccountDTO SelectedTargetAccount
        {
            get
            {
                return selectedTargetAccount;
            }
            set
            {
                selectedTargetAccount = value;
                OnPropertyChanged(nameof(SelectedTargetAccount));
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

        private ObservableCollection<AccountDTO> availableSourceAccounts;
        public ObservableCollection<AccountDTO> AvailableSourceAccounts
        {
            get
            {
                return availableSourceAccounts;
            }
            set
            {
                availableSourceAccounts = value;
                OnPropertyChanged(nameof(AvailableSourceAccounts));
            }
        }

        private ObservableCollection<AccountDTO> availableTargetAccounts;
        public ObservableCollection<AccountDTO> AvailableTargetAccounts
        {
            get
            {
                return availableTargetAccounts;
            }
            set
            {
                availableTargetAccounts = value;
                OnPropertyChanged(nameof(AvailableTargetAccounts));
            }
        }

        private ObservableCollection<AccountDTO> getAvailableSourceAccounts()
        {
            ObservableCollection<AccountDTO> availableAccounts = new ObservableCollection<AccountDTO>();

            foreach (AccountDTO account in MainViewModel.LoggedInUserAccounts)
            {
                switch (account.IdAccountType)
                {
                    case (int)EAccountType.Checking:
                        availableAccounts.Add(account);
                        break;
                    default:
                        break;
                }
            }

            return availableAccounts;
        }

        private ObservableCollection<AccountDTO> getAvailableTargetAccounts()
        {
            ObservableCollection<AccountDTO> availableAccounts = new ObservableCollection<AccountDTO>();

            foreach (AccountDTO account in MainViewModel.LoggedInUserAccounts)
            {
                if (SelectedSourceAccount != null)
                {
                    if (account.Id != SelectedSourceAccount.Id)
                    {
                        availableAccounts.Add(account);
                    }
                }
                else
                {
                    availableAccounts.Add(account);
                }
            }

            return availableAccounts;
        }
    }
}
