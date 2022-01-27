using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Admin;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Admin
{
    public class AdminUnblockUserCommand : CommandBase
    {
        private readonly MainViewModel mainViewModel;
        private readonly AdminHomeViewModel adminHomeViewModel;
        private readonly AdminManagementService adminManagementService;

        public AdminUnblockUserCommand(MainViewModel mainViewModel, AdminHomeViewModel adminHomeViewModel, IAdminManagementService adminManagementService)
        {
            this.mainViewModel = mainViewModel;
            this.adminHomeViewModel = adminHomeViewModel;
            this.adminManagementService = (AdminManagementService)adminManagementService;

            adminHomeViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return adminHomeViewModel.SelectedUserToUnblock != null && base.CanExecute(parameter);
        }

        public async override void Execute(object parameter)
        {
            UserDTO userDTOToBlock = adminHomeViewModel.SelectedUserToUnblock;

            try
            {
                await adminManagementService.SetUserAccountEnabled(userDTOToBlock);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show(Application.Current.MainWindow,
                   "Veuillez sélectionner un utilisateur à débloquer.",
                   "Échec de l'opération - Débloquer utilisateur");

                return;
            }

            MessageBox.Show(Application.Current.MainWindow,
                   "L'utilisateur " + userDTOToBlock.ToString() + " à été débloqué avec succès.",
                   "Opération terminé - Débloquer utilisateur");

            adminHomeViewModel.UnblockedUsers = null;
            adminHomeViewModel.BlockedUsers = null;
            adminHomeViewModel.SelectedUserToUnblock = null;
        }

        protected override void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(AdminHomeViewModel.SelectedUserToUnblock))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
