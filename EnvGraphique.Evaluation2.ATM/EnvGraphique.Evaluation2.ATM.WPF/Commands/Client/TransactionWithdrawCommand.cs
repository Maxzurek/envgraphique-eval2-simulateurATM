using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Transactions;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Client
{
    public class TransactionWithdrawCommand : CommandBase
    {
        private readonly TransactionService transactionService;
        private readonly MainViewModel mainViewModel;
        private readonly ClientWithdrawViewModel clientWithdrawViewModel;

        public TransactionWithdrawCommand(MainViewModel mainViewModel, ClientWithdrawViewModel clientWithdrawViewModel, ITransactionService transactionService)
        {
            this.mainViewModel = mainViewModel;
            this.clientWithdrawViewModel = clientWithdrawViewModel;
            this.transactionService = (TransactionService)transactionService;

            clientWithdrawViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !String.IsNullOrEmpty(clientWithdrawViewModel.Amount) && clientWithdrawViewModel.SelectedSourceAccount != null && base.CanExecute(parameter);
        }

        protected override void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(ClientWithdrawViewModel.Amount) || args.PropertyName == nameof(ClientWithdrawViewModel.SelectedSourceAccount))
            {
                OnCanExecutedChanged();
            }
        }

        public async override void Execute(object parameter)
        {
            AccountDTO sourceAccountDTO = clientWithdrawViewModel.SelectedSourceAccount;
            decimal amount;

            decimal.TryParse(clientWithdrawViewModel.Amount, out amount);

            try
            {
                await transactionService.Withdraw(sourceAccountDTO, amount, mainViewModel.AvailableCurrency);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                    "Veuillez selectionner un compte source.",
                    "Échec de la transaction - Retrait");
                return;
            }
            catch (TransactionAccountTypeException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                    "Le compte source selectionné n'est pas du bon type.\nVous ne pouvez que faire des retrait à partir d'un compte chèque ou épargne.",
                    "Échec de la transaction - Retrait");
                return;
            }
            catch (TransactionInvalidDivisibleAmountException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                    "Le montant entré est invalide.\nCe dernier doit être un multiple de 10.",
                    "Échec de la transaction - Retrait");
                return;
            }
            catch (TransactionInvalidAmountException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                    "Le montant entré est invalide.",
                    "Échec de la transaction - Retrait");
                return;
            }
            catch (TransactionAtmSystemInsufficientFundException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                    "Il n'y a pas assez de fond dans le guichet ATM.\nVeuillez contacter un administrateur.",
                    "Échec de la transaction - Retrait");
                return;
            }
            catch (TransactionMaxWithdrawalAmountException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                    String.Format("Le montant de retrait desiré depasse la limite de retrait du compte.\nLimite de retrait: {0:0.00}.", sourceAccountDTO.MaxWithdrawalAmount),
                    "Échec de la transaction - Retrait");
                return;
            }
            catch (TransactionInsufficientFundsException) // Last exception to catch so we dont have to catch all the exceptions below when withdrawing from margin
            {
                AccountDTO marginAccount = transactionService.CanWithdrawFromMargin(mainViewModel.LoggedInUserAccounts, amount);

                if (marginAccount != null)
                {
                    MessageBoxResult messageBoxResult;

                    messageBoxResult = MessageBox.Show(
                        Application.Current.MainWindow,
                        "Vous n'avez pas suffisamment de fond dans le compte source.\nDésirez-vous retirer de votre marge de credit?.",
                        "Échec de la transaction - Retrait",
                        MessageBoxButton.YesNo);

                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        try
                        {
                            await transactionService.WithdrawFromMargin(sourceAccountDTO, marginAccount, amount, mainViewModel.AvailableCurrency);
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(Application.Current.MainWindow,
                        "Vous n'avez pas suffisamment de fond dans le compte source.",
                        "Échec de la transaction - Retrait");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Application.Current.MainWindow,
                    "Une erreur est survenue lors de la transaction.\nVeuillez contacter un administrateur.",
                    "Échec de la transaction - Retrait - Erreur 206");
                return;
            }

            mainViewModel.AvailableCurrency -= amount;

            MessageBox.Show(Application.Current.MainWindow,
                "Retrait terminé avec succes!",
                "Transaction authorisée");

            clientWithdrawViewModel.SelectedSourceAccount = null;
            clientWithdrawViewModel.Amount = String.Empty;
        }
    }
}
