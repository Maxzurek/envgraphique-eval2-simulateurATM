using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Admin;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Data;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Admin
{
    public class AdminMortgagePaymentCommand : CommandBase
    {
        private readonly MainViewModel mainViewModel;
        private readonly AdminMortgagePaymentViewModel adminWithdrawViewModel;
        private readonly AccountDataService accountDataService;
        private readonly AdminManagementService adminManagementService;

        public AdminMortgagePaymentCommand(
            MainViewModel mainViewModel,
            AdminMortgagePaymentViewModel adminWithdrawViewModel,
            IAdminManagementService adminManagementService,
            IAccountDataService accountDataService)
        {
            this.mainViewModel = mainViewModel;
            this.adminWithdrawViewModel = adminWithdrawViewModel;
            this.accountDataService = (AccountDataService)accountDataService;
            this.adminManagementService = (AdminManagementService)adminManagementService;

            adminWithdrawViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return adminWithdrawViewModel.SelectedSourceAccount != null &&
                !String.IsNullOrEmpty(adminWithdrawViewModel.Amount) &&
                base.CanExecute(parameter);
        }

        public async override void Execute(object parameter)
        {
            AccountDTO selectedSourceAccount = adminWithdrawViewModel.SelectedSourceAccount;
            decimal amount;
            decimal.TryParse(adminWithdrawViewModel.Amount, out amount);
            ObservableCollection<AccountDTO> userAccounts = null;

            if (selectedSourceAccount != null)
            {
                userAccounts = new ObservableCollection<AccountDTO>(
                    mainViewModel.SystemAccounts.Where(account => account.IdUser == selectedSourceAccount.IdUser));
            }

            try
            {
                if (!await adminManagementService.MortgagePayment(userAccounts, amount))
                {
                    MessageBox.Show(Application.Current.MainWindow,
                   "Une erreur est survenue.\nL'utilisateur n'a pas de compte marge pour couvrir le manque de fond dans le compte hypothécaire.",
                   "Échec de l'opération - Prélèvement hypothécaire");

                    return;
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                                    "Une erreur est survenue lors de l'opération.\nVeuillez contacter un administrateur.",
                                    "Échec de l'opération - Prélèvement hypothécaire - Erreur 506");
            }
            catch (TransactionInvalidAmountException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                   "Le montant entré est invalide.",
                   "Échec de l'opération - Prélèvement hypothécaire");

                return;
            }

            MessageBox.Show(Application.Current.MainWindow,
                   "Prélèvement hypothécaire terminé avec succès.",
                   "Opération terminée - Prélèvement hypothécaire");

            adminWithdrawViewModel.SelectedSourceAccount = null;
            adminWithdrawViewModel.Amount = String.Empty;
        }

        protected override void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(adminWithdrawViewModel.SelectedSourceAccount) ||
                args.PropertyName == nameof(adminWithdrawViewModel.Amount))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
