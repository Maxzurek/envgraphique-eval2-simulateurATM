using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs.AccountDTO;

namespace EnvGraphique.Evaluation2.ATM.WPF.Views
{
    /// <summary>
    /// Interaction logic for AdminCreateAccountView.xaml
    /// </summary>
    public partial class AdminCreateAccountView : UserControl
    {
        public enum EAccountFieldName
        {
            InitialBalance,
            MaxWithdrawal,
            InterestRate,
            InvoicePaymentFee
        }

        public delegate void DelegateDisplayFieldError(string message, EAccountFieldName fieldName);
        public static DelegateDisplayFieldError DelDisplayFieldError;

        public delegate void DelegateRemoveFielddError(EAccountFieldName fieldName);
        public static DelegateRemoveFielddError DelRemoveFieldError;

        public AdminCreateAccountView()
        {
            InitializeComponent();

            DelDisplayFieldError = DisplayfieldError;
            DelRemoveFieldError = RemoveFieldError;
        }

        private void DisplayfieldError(string message, EAccountFieldName fieldName)
        {
            switch (fieldName)
            {
                case EAccountFieldName.InitialBalance:
                    initialBalance.displayError(message);
                    break;
                case EAccountFieldName.MaxWithdrawal:
                    maxWithdrawal.displayError(message);
                    break;
                case EAccountFieldName.InterestRate:
                    interestRate.displayError(message);
                    break;
                case EAccountFieldName.InvoicePaymentFee:
                    invoicePaymentFee.displayError(message);
                    break;
            }
        }

        private void RemoveFieldError(EAccountFieldName fieldName)
        {
            switch (fieldName)
            {
                case EAccountFieldName.InitialBalance:
                    initialBalance.removeError();
                    break;
                case EAccountFieldName.MaxWithdrawal:
                    maxWithdrawal.removeError();
                    break;
                case EAccountFieldName.InterestRate:
                    interestRate.removeError();
                    break;
                case EAccountFieldName.InvoicePaymentFee:
                    invoicePaymentFee.removeError();
                    break;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            comboBoxAccountType.ItemsSource = Enum.GetValues(typeof(EAccountType)).Cast<EAccountType>();
        }
    }
}
