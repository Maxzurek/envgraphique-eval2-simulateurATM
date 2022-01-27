using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using static EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs.AccountDTO;

namespace EnvGraphique.Evaluation2.ATM.WPF.Controls
{
    /// <summary>
    /// Interaction logic for AccountCard.xaml
    /// </summary>
    public partial class AccountCard : UserControl
    {

        public AccountCard()
        {
            InitializeComponent();
        }

        private void initializeImageSource()
        {
            AccountDTO accountDTO;

            if (DataContext is AccountDTO)
            {
                accountDTO = (AccountDTO)DataContext;

                switch (accountDTO.IdAccountType)
                {
                    case (int)EAccountType.Checking:
                        image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/checkingAccount-removebg.png"));
                        break;
                    case (int)EAccountType.Saving:
                        image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/savingAccount-removebg.png"));
                        break;
                    case (int)EAccountType.Mortgage:
                        image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/mortgageAccount-removebg.png"));
                        break;
                    case (int)EAccountType.Margin:
                        image.Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Images/marginAccount-removebg.png"));
                        break;
                    default:
                        break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (listViewTransactionsDetail.Visibility == Visibility.Visible)
            {
                listViewTransactionsDetail.Visibility = Visibility.Collapsed;
            }
            else
            {
                listViewTransactionsDetail.Visibility = Visibility.Visible;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            initializeImageSource();
        }
    }
}
