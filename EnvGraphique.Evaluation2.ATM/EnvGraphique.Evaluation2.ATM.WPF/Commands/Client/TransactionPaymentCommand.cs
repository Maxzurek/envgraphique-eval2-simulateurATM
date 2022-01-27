using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Transactions;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Client
{
    public class TransactionPaymentCommand : CommandBase
    {
        private readonly ClientPaymentViewModel clientPaymentViewModel;
        private readonly TransactionService transactionService;

        public TransactionPaymentCommand(ClientPaymentViewModel clientPaymentViewModel, ITransactionService transactionService)
        {
            this.clientPaymentViewModel = clientPaymentViewModel;
            this.transactionService = (TransactionService)transactionService;

            clientPaymentViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !String.IsNullOrEmpty(clientPaymentViewModel.Amount) &&
                clientPaymentViewModel.SelectedSourceAccount != null &&
                !String.IsNullOrEmpty(clientPaymentViewModel.InvoiceNumber) &&
                base.CanExecute(parameter);
        }

        protected override void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(ClientPaymentViewModel.Amount) ||
                args.PropertyName == nameof(ClientPaymentViewModel.InvoiceNumber) ||
                args.PropertyName == nameof(ClientPaymentViewModel.SelectedSourceAccount))
            {
                OnCanExecutedChanged();
            }
        }

        public async override void Execute(object parameter)
        {
            AccountDTO sourceAccountDTO = clientPaymentViewModel.SelectedSourceAccount;
            decimal amount;

            decimal.TryParse(clientPaymentViewModel.Amount, out amount);

            try
            {
                await transactionService.Payment(sourceAccountDTO, amount);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                       "Veuillez sélectionner un compte source.",
                       "Échec de la transaction - Paiement");
                return;
            }
            catch (TransactionAccountTypeException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                    "Le compte source sélectionné n'est pas du bon type.\nVous ne pouvez que faire des retrait à partir d'un compte chèque ou épargne.",
                    "Échec de la transaction - Paiement");
                return;
            }
            catch (TransactionInvalidAmountException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                    "Le montant entré est invalide.",
                    "Échec de la transaction - Paiement");
                return;
            }
            catch (TransactionInsufficientFundsException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                                   "Vous n'avez pas suffisamment de fond dans le compte source.\n(Des frais de $" + sourceAccountDTO.InvoicePaymentFee + " s'applique)",
                                   "Échec de la transaction - Paiement");
                return;
            }
            catch (Exception)
            {
                MessageBox.Show(Application.Current.MainWindow,
                                    "Une erreur est survenué lors de la transaction.\nVeuillez contacter un administrateur.",
                                    "Échec de la transaction - Paiement - Erreur 406");
            }

            MessageBox.Show(Application.Current.MainWindow,
                                   "Paiement terminé avec succès!",
                                   "Transaction authorisée");

            clientPaymentViewModel.SelectedSourceAccount = null;
            clientPaymentViewModel.InvoiceNumber = String.Empty;
            clientPaymentViewModel.Amount = String.Empty;
        }
    }
}
