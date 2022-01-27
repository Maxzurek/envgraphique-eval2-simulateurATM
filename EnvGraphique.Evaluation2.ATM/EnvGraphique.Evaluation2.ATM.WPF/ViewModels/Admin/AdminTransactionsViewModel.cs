using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EnvGraphique.Evaluation2.ATM.WPF.ViewModels
{
    public class AdminTransactionsViewModel : ViewModelBase
    {
        private readonly TransactionDataService transactionDataService;
        private ObservableCollection<TransactionDTO> initialSystemTransactions;

        public AdminTransactionsViewModel(MainViewModel mainViewModel, ITransactionDataService transactionDataService)
        {
            this.transactionDataService = (TransactionDataService)transactionDataService;

            InitializeSystemTransactions();

            FilterType = "Id";
        }

        private string filter;
        public string Filter
        {
            get
            {
                return filter;
            }
            set
            {
                filter = value;
                ApplyFilterToTransactions();
                OnPropertyChanged(nameof(Filter));
            }
        }

        private string filterType;
        public string FilterType
        {
            get
            {
                return filterType;
            }
            set
            {
                filterType = value;
                ApplyFilterToTransactions();
                OnPropertyChanged(nameof(FilterType));
            }
        }

        private ObservableCollection<TransactionDTO> systemTransactions;
        public ObservableCollection<TransactionDTO> SystemTransactions
        {
            get
            {
                return systemTransactions;
            }
            set
            {
                systemTransactions = value;
                OnPropertyChanged(nameof(SystemTransactions));
            }
        }

        private async void InitializeSystemTransactions()
        {
            initialSystemTransactions = await transactionDataService.GetAll();
            SystemTransactions = initialSystemTransactions;
        }

        private void ApplyFilterToTransactions()
        {
            if (String.IsNullOrEmpty(Filter))
            {
                SystemTransactions = initialSystemTransactions;
                return;
            }

            IEnumerable<TransactionDTO> filteredTransactions = new List<TransactionDTO>();

            switch (FilterType)
            {
                case "Id":
                    filteredTransactions = initialSystemTransactions.Where(transaction => transaction.Id.ToString().ToLower().Contains(Filter.ToLower()));
                    break;
                case "Transaction type":
                    filteredTransactions = initialSystemTransactions.Where(transaction => transaction.TransactionType.Designation.ToLower().Contains(Filter.ToLower()));
                    break;
                case "Montant":
                    filteredTransactions = initialSystemTransactions.Where(transaction => transaction.Amount.ToString().ToLower().Contains(Filter.ToLower()));
                    break;
                case "Date":
                    filteredTransactions = initialSystemTransactions.Where(transaction => transaction.Date.ToString().ToLower().Contains(Filter.ToLower()));
                    break;
                case "Id compte source":
                    filteredTransactions = initialSystemTransactions.Where(transaction => transaction.SourceAccountId.ToString().ToLower().Contains(Filter.ToLower()));
                    break;
                case "Id compte cible":
                    filteredTransactions = initialSystemTransactions.Where(transaction => transaction.TargetAccountId.ToString().ToLower().Contains(Filter.ToLower()));
                    break;
                default:
                    break;
            }

            if (filteredTransactions == null)
            {
                SystemTransactions = initialSystemTransactions;
            }
            else
            {
                SystemTransactions = new ObservableCollection<TransactionDTO>(filteredTransactions);
            }
        }
    }
}
