using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Admin;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using EnvGraphique.Evaluation2.ATM.WPF.Views;
using System;
using System.ComponentModel;
using System.Windows;
using static EnvGraphique.Evaluation2.ATM.WPF.Views.AdminCreateUserView;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Admin
{
    public class AdminCreateUserCommand : CommandBase
    {
        private readonly MainViewModel mainViewModel;
        private readonly AdminCreateUserViewModel adminCreateUserViewModel;
        private readonly AdminManagementService adminManagementService;

        public AdminCreateUserCommand(MainViewModel mainViewModel, AdminCreateUserViewModel adminCreateUserViewModel, IAdminManagementService adminManagementService)
        {
            this.mainViewModel = mainViewModel;
            this.adminCreateUserViewModel = adminCreateUserViewModel;
            this.adminManagementService = (AdminManagementService)adminManagementService;

            adminCreateUserViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return
                !string.IsNullOrEmpty(adminCreateUserViewModel.LastName) &&
                !string.IsNullOrEmpty(adminCreateUserViewModel.FirstName) &&
                !string.IsNullOrEmpty(adminCreateUserViewModel.Phone) &&
                !string.IsNullOrEmpty(adminCreateUserViewModel.Username) &&
                !string.IsNullOrEmpty(adminCreateUserViewModel.Nip) &&
                base.CanExecute(parameter);
        }

        public async override void Execute(object parameter)
        {
            string lastName = adminCreateUserViewModel.LastName;
            string firstName = adminCreateUserViewModel.FirstName;
            string phone = adminCreateUserViewModel.Phone;
            string email = adminCreateUserViewModel.Email;
            string userName = adminCreateUserViewModel.Username;
            string nip = adminCreateUserViewModel.Nip;
            int userType = (int)adminCreateUserViewModel.SelectedUserType;
            UserDTO createdUser = null;
            // TODO Regex validation for email/phone?

            try
            {
                createdUser = await adminManagementService.CreateUser(firstName, lastName, phone, email, nip, userName, userType);
                AdminCreateUserView.DelRemoveFieldError(EUserFieldName.Username);
            }
            catch (ExistingUsernameException)
            {

                AdminCreateUserView.DelDisplayFieldError("Ce nom d'utilisateur existe déjà", EUserFieldName.Username);
            }
            catch (Exception)
            {
                MessageBox.Show(Application.Current.MainWindow,
                   "Une erreur est survenue.\n Veuillez contacter un administrateur.",
                   "Échec de l'opération - Créer utilisateur");

                return;
            }

            MessageBox.Show(Application.Current.MainWindow,
                   "Utilisateur créé avec succès.",
                   "Opération terminée - Créer utilisateur");

            if (createdUser != null)
            {
                mainViewModel.SystemUsers.Add(createdUser);
            }

            return;
        }

        protected override void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(adminCreateUserViewModel.LastName) ||
                args.PropertyName == nameof(adminCreateUserViewModel.FirstName) ||
                args.PropertyName == nameof(adminCreateUserViewModel.Phone) ||
                args.PropertyName == nameof(adminCreateUserViewModel.Username) ||
                args.PropertyName == nameof(adminCreateUserViewModel.Nip))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
