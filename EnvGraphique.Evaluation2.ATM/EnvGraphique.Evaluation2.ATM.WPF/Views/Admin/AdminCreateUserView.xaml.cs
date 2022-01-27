using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs.UserDTO;

namespace EnvGraphique.Evaluation2.ATM.WPF.Views
{
    /// <summary>
    /// Interaction logic for AdminCreateUserView.xaml
    /// </summary>
    public partial class AdminCreateUserView : UserControl
    {
        public enum EUserFieldName
        {
            LastName,
            Firstname,
            Phone,
            Email,
            Username,
            Nip,
        }

        public delegate void DelegateDisplayFieldError(string message, EUserFieldName fieldName);
        public static DelegateDisplayFieldError DelDisplayFieldError;

        public delegate void DelegateRemoveFielddError(EUserFieldName fieldName);
        public static DelegateRemoveFielddError DelRemoveFieldError;

        public AdminCreateUserView()
        {
            InitializeComponent();

            DelDisplayFieldError = DisplayfieldError;
            DelRemoveFieldError = RemoveFieldError;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxUserTypes.ItemsSource = Enum.GetValues(typeof(EUserType)).Cast<EUserType>();
        }

        private void DisplayfieldError(string message, EUserFieldName fieldName)
        {
            switch (fieldName)
            {
                case EUserFieldName.LastName:
                    lastName.displayError(message);
                    break;
                case EUserFieldName.Firstname:
                    firstName.displayError(message);
                    break;
                case EUserFieldName.Phone:
                    phone.displayError(message);
                    break;
                case EUserFieldName.Email:
                    email.displayError(message);
                    break;
                case EUserFieldName.Username:
                    username.displayError(message);
                    break;
                case EUserFieldName.Nip:
                    nip.displayError(message);
                    break;
                default:
                    break;
            }
        }

        private void RemoveFieldError(EUserFieldName fieldName)
        {
            switch (fieldName)
            {
                case EUserFieldName.LastName:
                    lastName.removeError();
                    break;
                case EUserFieldName.Firstname:
                    firstName.removeError();
                    break;
                case EUserFieldName.Phone:
                    phone.removeError();
                    break;
                case EUserFieldName.Email:
                    email.removeError();
                    break;
                case EUserFieldName.Username:
                    username.removeError();
                    break;
                case EUserFieldName.Nip:
                    nip.removeError();
                    break;
                default:
                    break;
            }
        }
    }
}
