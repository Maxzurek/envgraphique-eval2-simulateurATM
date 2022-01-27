using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Authentication;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Data;
using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using EnvGraphique.Evaluation2.ATM.WPF.Views;
using System;
using System.Collections.ObjectModel;
using static EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs.UserDTO;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Authentication
{
    public class LoginCommand : CommandBase
    {
        public delegate void DelegateDisplayUsernameEmptyError(string message);

        private readonly MainViewModel mainViewModel;
        private readonly LoginViewModel loginViewModel;
        private readonly ILoginService loginService;
        private readonly IAccountDataService accountDataService;
        private readonly IUserDataService userDataService;

        private bool attemptingToLog;
        public bool AttemptingToLog
        {
            get
            {
                return attemptingToLog;
            }
            set
            {
                attemptingToLog = value;
                OnCanExecutedChanged();
            }
        }

        public LoginCommand(
            MainViewModel mainViewModel,
            LoginViewModel loginViewModel,
            ILoginService loginService,
            IAccountDataService accountDataService,
            IUserDataService userDataService)
        {
            this.mainViewModel = mainViewModel;
            this.loginViewModel = loginViewModel;
            this.loginService = loginService;
            this.accountDataService = accountDataService;
            this.userDataService = userDataService;
        }

        public override bool CanExecute(object parameter)
        {
            return !attemptingToLog && base.CanExecute(parameter);
        }

        public async override void Execute(object parameter)
        {
            UserDTO userDTO;
            bool emptyFields = false;

            if (loginViewModel.Username == string.Empty || loginViewModel.Username == null)
            {
                LoginView.DelUserNameEmpty?.Invoke("Veuillez entrer le nom d'utilisateur.");

                emptyFields = true;
            }
            else
            {
                LoginView.DelRemoveUsernameEmptyError?.Invoke();
            }
            if (loginViewModel.Password == string.Empty || loginViewModel.Password == null)
            {
                LoginView.DelPasswordEmpty?.Invoke("Veuillez entrer le NIP.");

                emptyFields = true;
            }
            else
            {
                LoginView.DelRemovePasswordEmptyError?.Invoke();
            }
            if (emptyFields)
            {
                return;
            }

            try
            {
                AttemptingToLog = true;
                loginViewModel.LoginTooltipVisibility = System.Windows.Visibility.Hidden;
                userDTO = await loginService.Login(loginViewModel.Username, loginViewModel.Password);
            }
            catch (Exception)
            {
                loginViewModel.LoginTooltip = "Échec de connection.\nLa connection au serveur a échouée.\nVeuillez contacter un administrateur si le problème persiste.";
                loginViewModel.LoginTooltipVisibility = System.Windows.Visibility.Visible;
                AttemptingToLog = false;

                return;
            }

            AttemptingToLog = false;

            if (userDTO != null)
            {
                if (userDTO.Enabled == false)
                {
                    loginViewModel.LoginTooltip = "Échec de connection.\nLe compte est présentement vérouillé.\nVeuillez contacter un administrateur.";
                    loginViewModel.LoginTooltipVisibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    if (userDTO.IdUserType == (int)EUserType.Admin)
                    {
                        ObservableCollection<AccountDTO> systemAccountsDTO = await accountDataService.GetAll();
                        ObservableCollection<UserDTO> systemUsersDTO = await userDataService.GetAll();
                        mainViewModel.LoggedInUser = userDTO;
                        mainViewModel.SystemAccounts = systemAccountsDTO;
                        mainViewModel.SystemUsers = systemUsersDTO;
                        mainViewModel.DisplayAdminViewCommand.Execute(null);
                    }
                    else if (userDTO.IdUserType == (uint)EUserType.Client)
                    {
                        ObservableCollection<AccountDTO> userAccountsDTO = await accountDataService.getUserAccounts(userDTO.Id);
                        mainViewModel.LoggedInUser = userDTO;
                        mainViewModel.LoggedInUserAccounts = userAccountsDTO;
                        mainViewModel.DisplayClientViewCommand.Execute(null);
                    }
                }
            }
            else
            {
                loginViewModel.LoginTooltip = "Échec de connection.\nLe nom d'utilisateur ou le mot de passe entré est invalide.";
                loginViewModel.Password = "";
                LoginView.DelPasswordEmpty?.Invoke("Veuillez entrer le NIP.");

                loginViewModel.LoginTooltipVisibility = System.Windows.Visibility.Visible;
            }
        }
    }
}
