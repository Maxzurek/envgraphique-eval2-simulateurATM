using System.Windows.Controls;

namespace EnvGraphique.Evaluation2.ATM.WPF.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public delegate void DelegateDisplayUsernameEmptyError(string message);
        public static DelegateDisplayUsernameEmptyError DelUserNameEmpty;

        public delegate void DelegateRemoveUsernameEmptyError();
        public static DelegateRemoveUsernameEmptyError DelRemoveUsernameEmptyError;

        public delegate void DelegateDisplayPasswordEmptyError(string message);
        public static DelegateDisplayPasswordEmptyError DelPasswordEmpty;

        public delegate void DelegateRemovePasswordEmptyError();
        public static DelegateRemovePasswordEmptyError DelRemovePasswordEmptyError;

        public LoginView()
        {
            InitializeComponent();
            DelUserNameEmpty = DisplayUsernameEmptyError;
            DelRemoveUsernameEmptyError = RemoveUsernameEmptyError;
            DelPasswordEmpty = DisplayPasswordEmptyError;
            DelRemovePasswordEmptyError = RemovePasswordEmptyError;
        }

        public void DisplayUsernameEmptyError(string message)
        {
            inputFieldUser.displayError(message);
        }

        public void DisplayPasswordEmptyError(string message)
        {
            inputFieldPassword.displayError(message);
        }

        public void RemoveUsernameEmptyError()
        {
            inputFieldUser.removeError();
        }

        public void RemovePasswordEmptyError()
        {
            inputFieldPassword.removeError();
        }
    }
}
