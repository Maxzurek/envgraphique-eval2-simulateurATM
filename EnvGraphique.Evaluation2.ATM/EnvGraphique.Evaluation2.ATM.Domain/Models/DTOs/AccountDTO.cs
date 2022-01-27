using System;
using System.Collections.ObjectModel;

namespace EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs
{
    public class AccountDTO : ObservableObject, IComparable<AccountDTO>
    {
        /**********************************************************************************************************
        * Public enum
        ***********************************************************************************************************/
        public enum EAccountType : int
        {
            Checking = 1,
            Saving = 2,
            Mortgage = 3,
            Margin = 4,
        }

        /**********************************************************************************************************
        * Properties
        ***********************************************************************************************************/
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(nameof(Id)); }
        }

        private int idUser;

        public int IdUser
        {
            get { return idUser; }
            set { idUser = value; OnPropertyChanged(nameof(IdUser)); }
        }

        private int idAccountType;

        public int IdAccountType
        {
            get { return idAccountType; }
            set { idAccountType = value; OnPropertyChanged(nameof(IdAccountType)); }
        }

        private decimal balance;

        public decimal Balance
        {
            get { return balance; }
            set { balance = value; OnPropertyChanged(nameof(Balance)); }
        }

        private double? interestRate;

        public double? InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; OnPropertyChanged(nameof(InterestRate)); }
        }

        private decimal? invoicePaymentFee;

        public decimal? InvoicePaymentFee
        {
            get { return invoicePaymentFee; }
            set { invoicePaymentFee = value; OnPropertyChanged(nameof(InvoicePaymentFee)); }
        }

        private decimal? maxWithdrawalAmount;

        public decimal? MaxWithdrawalAmount
        {
            get { return maxWithdrawalAmount; }
            set { maxWithdrawalAmount = value; OnPropertyChanged(nameof(MaxWithdrawalAmount)); }
        }

        private AccountType accountType;

        public virtual AccountType AccountType
        {
            get { return accountType; }
            set { accountType = value; OnPropertyChanged(nameof(AccountType)); }
        }

        private UserDTO user;

        public virtual UserDTO User
        {
            get { return user; }
            set { user = value; OnPropertyChanged(nameof(User)); }
        }

        private ObservableCollection<TransactionDTO> transactions = new ObservableCollection<TransactionDTO>();

        public ObservableCollection<TransactionDTO> Transactions
        {
            get { return transactions; }
            private set { transactions = value; OnPropertyChanged(nameof(Transactions)); }
        }

        private ObservableCollection<TransactionDTO> targetAccountTransactions = new ObservableCollection<TransactionDTO>();

        public ObservableCollection<TransactionDTO> TargetAccountTransactions
        {
            get { return targetAccountTransactions; }
            private set { targetAccountTransactions = value; OnPropertyChanged(nameof(TargetAccountTransactions)); }
        }


        /**********************************************************************************************************
        * Constructors
        ***********************************************************************************************************/
        private AccountDTO()
        {
        }

        public AccountDTO(Account account)
        {
            Id = account.Id;
            IdUser = account.IdUser;
            IdAccountType = account.IdAccountType;
            Balance = account.Balance;
            InterestRate = account.InterestRate;
            InvoicePaymentFee = account.InvoicePaymentFee;
            MaxWithdrawalAmount = account.MaxWithdrawalAmount;
            AccountType = account.AccountType;

            if (User != null)
            {
                User = new UserDTO(account.User);
            }

            foreach (Transaction transaction in account.Transactions)
            {

                Transactions.Add(new TransactionDTO(transaction));
            }

            foreach (Transaction transaction in account.Transactions1)
            {
                TargetAccountTransactions.Add(new TransactionDTO(transaction));
            }
        }

        public AccountDTO(
            int idUser, int idAccountType, decimal balance, double? interestRate = null,
            decimal? invoicePaymentFee = null, decimal? maxWithdrawalAmount = null)
        {
            IdUser = idUser;
            IdAccountType = idAccountType;
            Balance = balance;
            InterestRate = interestRate;
            InvoicePaymentFee = invoicePaymentFee;
            MaxWithdrawalAmount = maxWithdrawalAmount;
        }


        /**********************************************************************************************************
        * Interface implementation
        ***********************************************************************************************************/
        public int CompareTo(AccountDTO other)
        {
            if (IdAccountType < other.IdAccountType)
            {
                return -1;
            }
            if (IdAccountType == other.IdAccountType)
            {
                return 0;
            }

            return 1;
        }
    }
}
