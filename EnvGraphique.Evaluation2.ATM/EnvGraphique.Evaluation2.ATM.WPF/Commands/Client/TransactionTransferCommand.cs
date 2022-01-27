using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Transactions;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Client
{
    public class TransactionTransferCommand : CommandBase
    {
        private readonly MainViewModel mainViewModel;
        private readonly ClientTransferViewModel clientTransferViewModel;
        private readonly TransactionService transactionService;

        public TransactionTransferCommand(MainViewModel mainViewModel, ClientTransferViewModel clientTransferViewModel, ITransactionService transactionService)
        {
            this.mainViewModel = mainViewModel;
            this.clientTransferViewModel = clientTransferViewModel;
            this.transactionService = (TransactionService)transactionService;

            clientTransferViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !String.IsNullOrEmpty(clientTransferViewModel.Amount) &&
                clientTransferViewModel.SelectedSourceAccount != null &&
                clientTransferViewModel.SelectedTargetAccount != null &&
                base.CanExecute(parameter);
        }

        protected override void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(ClientTransferViewModel.Amount) ||
                args.PropertyName == nameof(ClientTransferViewModel.SelectedSourceAccount) ||
                args.PropertyName == nameof(ClientTransferViewModel.SelectedTargetAccount))
            {
                OnCanExecutedChanged();
            }
        }

        public async override void Execute(object parameter)
        {
            AccountDTO sourceAccountDTO = clientTransferViewModel.SelectedSourceAccount;
            AccountDTO targetAccountDTO = clientTransferViewModel.SelectedTargetAccount;
            decimal amount;

            decimal.TryParse(clientTransferViewModel.Amount, out amount);

            try
            {
                await transactionService.Transfer(sourceAccountDTO, targetAccountDTO, amount);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                    "Veuillez selectionner un compte source et un compte cible.",
                    "Échec de la transaction - Transfert");
                return;
            }
            catch (TransactionAccountTypeException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                    "Le compte source selectionné n'est pas du bon type.\nVous ne pouvez que faire des retrait à partir d'un compte chèque ou épargne.",
                    "Échec de la transaction - Transfert");
                return;
            }
            catch (TransactionInvalidAmountException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                   "Le montant entré est invalide.",
                   "Échec de la transaction - Transfert");
                return;
            }
            catch (TransactionInsufficientFundsException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                                   "Vous n'avez pas suffisamment de fond dans le compte source.",
                                   "Échec de la transaction - Transfert");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show(Application.Current.MainWindow,
                                    "Une erreur est survenue lors de la transaction.\nVeuillez contacter un administrateur.",
                                    "Échec de la transaction - Transfert - Erreur 406");
                return;
            }

            MessageBox.Show(Application.Current.MainWindow,
                                   "Transfert terminée avec succès!",
                                   "Transaction authorisée");

            clientTransferViewModel.SelectedTargetAccount = null;
            clientTransferViewModel.SelectedSourceAccount = null;
            clientTransferViewModel.Amount = String.Empty;
        }
    }
}
