using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Admin;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Admin
{
    public class AdminCreateAccountCommand : CommandBase
    {
        private readonly MainViewModel mainViewModel;
        private readonly AdminCreateAccountViewModel adminCreateAccountViewModel;
        private readonly AdminManagementService adminManagementService;

        public AdminCreateAccountCommand(MainViewModel mainViewModel, AdminCreateAccountViewModel adminCreateAccountViewModel, IAdminManagementService adminManagementService)
        {
            this.mainViewModel = mainViewModel;
            this.adminCreateAccountViewModel = adminCreateAccountViewModel;
            this.adminManagementService = (AdminManagementService)adminManagementService;

            adminCreateAccountViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return
                adminCreateAccountViewModel.SelectedUser != null &&
                base.CanExecute(parameter);
        }

        public override async void Execute(object parameter)
        {
            UserDTO selectedUser = adminCreateAccountViewModel.SelectedUser;
            int accountType = (int)adminCreateAccountViewModel.SelectedAccountType;
            decimal initialBalance = adminCreateAccountViewModel.InitialBalance;
            decimal? maxWithdrawlAmount = adminCreateAccountViewModel.MaxWithdrawalAmount;
            double? interestRate = adminCreateAccountViewModel.InterestRate;
            decimal? invoicePaymentFee = adminCreateAccountViewModel.InvoicePaymentFee;
            AccountDTO createdAccount = null;

            try
            {
                createdAccount = await adminManagementService.CreateAccount(selectedUser.Id, accountType, initialBalance, interestRate, invoicePaymentFee, maxWithdrawlAmount);
            }
            catch (UserDataNotFoundException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                   "Une erreur est survenue. L'utilisateur sélectionné n'existe pas.\n Veuillez contacter un administrateur.",
                   "Échec de l'opération - Créer compte");

                return;
            }
            catch (AdminCreateAccountNoCheckingAccountException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                   "Impossible de créer le compte.\nL'utilisateur sélectionné doit avoir obligatoirement 1 compte chèque pour créer un compte d'un autre type.",
                   "Échec de l'opération - Créer compte");

                return;
            }
            catch (Exception)
            {
                MessageBox.Show(Application.Current.MainWindow,
                   "Une erreur est survenue.\n Veuillez contacter un administrateur.",
                   "Échec de l'opération - Créer compte");

                return;
            }

            MessageBox.Show(Application.Current.MainWindow,
                   "Compte créé avec succès.",
                   "Opération terminée - Créer compte");

            if (createdAccount != null)
            {
                mainViewModel.SystemAccounts.Add(createdAccount);
            }

            return;
        }

        protected override void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(adminCreateAccountViewModel.SelectedAccountType) ||
                args.PropertyName == nameof(adminCreateAccountViewModel.SelectedUser))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
