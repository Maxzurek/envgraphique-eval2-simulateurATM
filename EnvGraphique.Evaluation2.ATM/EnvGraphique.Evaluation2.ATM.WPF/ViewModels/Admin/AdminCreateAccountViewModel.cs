using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Admin;
using EnvGraphique.Evaluation2.ATM.WPF.Commands.Admin;
using System.Collections.ObjectModel;
using System.Windows.Input;
using static EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs.AccountDTO;

namespace EnvGraphique.Evaluation2.ATM.WPF.ViewModels
{
    public class AdminCreateAccountViewModel : ViewModelBase
    {
        private const decimal DEFAULT_INITIAL_BALANCE = 0;
        private const decimal DEFAULT_MAX_WITHDRAWAL_AMOUNT = 1000;
        private const double DEFAULT_INTEREST_RATE = 1;
        private const decimal DEFAULT_INVOICE_PAYMENT_FEE = 1.25m;

        public ICommand AdminCreateAccountCommand { get; }

        public AdminCreateAccountViewModel(MainViewModel mainViewModel, IAdminManagementService adminManagementService)
        {
            AdminCreateAccountCommand = new AdminCreateAccountCommand(mainViewModel, this, adminManagementService);

            InitialBalance = DEFAULT_INITIAL_BALANCE;
            MaxWithdrawalAmount = DEFAULT_MAX_WITHDRAWAL_AMOUNT;
            InterestRate = DEFAULT_INTEREST_RATE;
            InvoicePaymentFee = DEFAULT_INVOICE_PAYMENT_FEE;
            AvailableUsers = mainViewModel.SystemUsers;
        }

        private ObservableCollection<UserDTO> availableUsers;
        public ObservableCollection<UserDTO> AvailableUsers
        {
            get
            {
                return availableUsers;
            }
            set
            {
                availableUsers = value;
                OnPropertyChanged(nameof(AvailableUsers));
            }
        }

        private UserDTO selectedUser;
        public UserDTO SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        private EAccountType selectedAccountType;
        public EAccountType SelectedAccountType
        {
            get
            {
                return selectedAccountType;
            }
            set
            {
                selectedAccountType = value;
                OnPropertyChanged(nameof(SelectedAccountType));
            }
        }

        private decimal initialBalance;
        public decimal InitialBalance
        {
            get
            {
                return initialBalance;
            }
            set
            {
                initialBalance = value;
                OnPropertyChanged(nameof(InitialBalance));
            }
        }

        private decimal? maxWithdrawalAmount;
        public decimal? MaxWithdrawalAmount
        {
            get
            {
                return maxWithdrawalAmount;
            }
            set
            {
                maxWithdrawalAmount = value;
                OnPropertyChanged(nameof(MaxWithdrawalAmount));
            }
        }

        private double? interestRate;
        public double? InterestRate
        {
            get
            {
                return interestRate;
            }
            set
            {
                interestRate = value;
                OnPropertyChanged(nameof(InterestRate));
            }
        }

        private decimal? invoicePaymentFee;
        public decimal? InvoicePaymentFee
        {
            get
            {
                return invoicePaymentFee;
            }
            set
            {
                invoicePaymentFee = value;
                OnPropertyChanged(nameof(InvoicePaymentFee));
            }
        }
    }
}
