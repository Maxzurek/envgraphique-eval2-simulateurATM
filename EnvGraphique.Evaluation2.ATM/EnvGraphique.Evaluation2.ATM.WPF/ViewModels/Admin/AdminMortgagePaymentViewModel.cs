using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Admin;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Data;
using EnvGraphique.Evaluation2.ATM.WPF.Commands.Admin;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs.AccountDTO;

namespace EnvGraphique.Evaluation2.ATM.WPF.ViewModels
{
    public class AdminMortgagePaymentViewModel : ViewModelBase
    {
        private MainViewModel MainViewModel { get; }

        public ICommand AdminWithdrawalCommand { get; }

        public AdminMortgagePaymentViewModel(MainViewModel mainViewModel, IAdminManagementService adminManagementService, IAccountDataService accountDataService)
        {
            MainViewModel = mainViewModel;
            AdminWithdrawalCommand = new AdminMortgagePaymentCommand(mainViewModel, this, adminManagementService, accountDataService);

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

            foreach (AccountDTO account in MainViewModel.SystemAccounts)
            {
                switch (account.IdAccountType)
                {
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
