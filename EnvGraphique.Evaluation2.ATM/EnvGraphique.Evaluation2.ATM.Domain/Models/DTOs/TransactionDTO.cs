using System;

namespace EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs
{
    public class TransactionDTO : ObservableObject, IComparable<TransactionDTO>
    {
        /**********************************************************************************************************
        * Public enum
        ***********************************************************************************************************/
        public enum ETransactionType : int
        {
            Deposit = 1,
            Widthdraw = 2,
            Transfer = 3,
            Payment = 4,
            Interest = 5,
            Mortgage = 6,
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

        private int idTransactionType;

        public int IdTransactionType
        {
            get { return idTransactionType; }
            set { idTransactionType = value; OnPropertyChanged(nameof(IdTransactionType)); }
        }

        private decimal amount;

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; OnPropertyChanged(nameof(Amount)); }
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            set { date = value; OnPropertyChanged(nameof(Date)); }
        }

        private int sourceAccountId;

        public int SourceAccountId
        {
            get { return sourceAccountId; }
            set { sourceAccountId = value; OnPropertyChanged(nameof(SourceAccountId)); }
        }

        private Nullable<int> targetAccountId;

        public Nullable<int> TargetAccountId
        {
            get { return targetAccountId; }
            set { targetAccountId = value; OnPropertyChanged(nameof(TargetAccountId)); }
        }

        private Account sourceAccount;

        public Account SourceAccount
        {
            get { return sourceAccount; }
            set { sourceAccount = value; OnPropertyChanged(nameof(SourceAccount)); }
        }

        private Account targetAccount;

        public Account TargetAccount
        {
            get { return targetAccount; }
            set { targetAccount = value; OnPropertyChanged(nameof(TargetAccount)); }
        }

        private TransactionType transactionType;

        public TransactionType TransactionType
        {
            get { return transactionType; }
            set { transactionType = value; OnPropertyChanged(nameof(TransactionType)); }
        }


        /**********************************************************************************************************
        * Constructors
        ***********************************************************************************************************/
        private TransactionDTO()
        {
        }

        public TransactionDTO(Transaction transaction)
        {
            Id = transaction.Id;
            IdTransactionType = transaction.IdTransactionType;
            Amount = transaction.Amount;
            Date = transaction.Date;
            SourceAccountId = transaction.SourceAccountId;
            TargetAccountId = transaction.TargetAccountId;
            SourceAccount = transaction.Account;
            TargetAccount = transaction.Account1;
            TransactionType = transaction.TransactionType;
        }

        public TransactionDTO(
            int id, int idTransactionType, decimal amount, DateTime date,
            int sourceAccountId, int? targetAccountId = null)
        {
            Id = id;
            IdTransactionType = idTransactionType;
            Amount = amount;
            Date = date;
            SourceAccountId = sourceAccountId;
            TargetAccountId = targetAccountId;
        }


        /**********************************************************************************************************
        * Interface implementation
        ***********************************************************************************************************/
        public int CompareTo(TransactionDTO other)
        {
            if (Id < other.Id)
            {
                return -1;
            }
            if (Id == other.Id)
            {
                return 0;
            }

            return 1;
        }
    }
}
