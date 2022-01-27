using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Transactions;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Client
{
    public class TransactionDepositCommand : CommandBase
    {
        private readonly ClientDepositViewModel clientDepositViewModel;
        private readonly TransactionService transactionService;

        public TransactionDepositCommand(ClientDepositViewModel clientDepositViewModel, ITransactionService transactionService)
        {
            this.clientDepositViewModel = clientDepositViewModel;
            this.transactionService = (TransactionService)transactionService;

            clientDepositViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !String.IsNullOrEmpty(clientDepositViewModel.Amount) &&
                clientDepositViewModel.SelectedSourceAccount != null &&
                base.CanExecute(parameter);
        }

        protected override void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(ClientDepositViewModel.Amount) || args.PropertyName == nameof(ClientDepositViewModel.SelectedSourceAccount))
            {
                OnCanExecutedChanged();
            }
        }

        public async override void Execute(object parameter)
        {
            AccountDTO sourceAccountDTO = clientDepositViewModel.SelectedSourceAccount;
            decimal amount;

            decimal.TryParse(clientDepositViewModel.Amount, out amount);

            try
            {
                await transactionService.Deposit(sourceAccountDTO, amount);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                    "Veuillez sélectionner un compte source.",
                    "Échec de la transaction - Depot");
                return;
            }
            catch (TransactionAccountTypeException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                    "Le compte source sélectionné n'est pas du bon type.\nVous ne pouvez que faire des retrait à partir d'un compte chèque ou épargne.",
                    "Échec de la transaction - Dépôt");
                return;
            }
            catch (TransactionInvalidAmountException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                    "Le montant entré est invalide.",
                    "Échec de la transaction - Dépôt");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show(Application.Current.MainWindow,
                                    "Une erreur est survenue lors de la transaction.\nVeuillez contacter un administrateur.",
                                    "Échec de la transaction - Dépôt - Erreur 306");
                return;
            }

            MessageBox.Show(Application.Current.MainWindow,
                                   "Dépôt terminé avec succes!",
                                   "Transaction authorisée");

            clientDepositViewModel.SelectedSourceAccount = null;
            clientDepositViewModel.Amount = String.Empty;
        }
    }
}
