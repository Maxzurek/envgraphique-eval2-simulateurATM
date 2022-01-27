using EnvGraphique.Evaluation2.ATM.WPF.ViewModels;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF.Commands.Authentication
{
    public class LogoutCommand : CommandBase
    {
        private readonly MainViewModel mainViewModel;

        public LogoutCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            MessageBoxResult messageBoxResult;

            messageBoxResult = MessageBox.Show(Application.Current.MainWindow,
                            "Désirez-vous fermer la session?",
                             "Fermeture de session",
                            MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {
                mainViewModel.LoggedInUser = null;
                mainViewModel.LoggedInUserAccounts = null;
                mainViewModel.Navigator.CurrentNavBarViewModel = null;
                mainViewModel.DisplayLoginViewCommand.Execute(this);
            }
            else
            {
                return;
            }
        }
    }
}
