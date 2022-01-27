using EnvGraphique.Evaluation2.ATM.Domain.Models;
using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Data;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace EnvGraphique.Evaluation2.ATM.WPF.Test
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ATMEntities atmEntities;
        private UserDataService userDataService;
        private AccountDataService accountDataService;
        private ObservableCollection<UserDTO> usersDTO;
        private ObservableCollection<AccountDTO> accountsDTO = new ObservableCollection<AccountDTO>();

        public MainWindow()
        {
            InitializeComponent();

            atmEntities = new ATMEntities();
            initDataGridItemsSource();
        }

        private async void initDataGridItemsSource()
        {
            userDataService = new UserDataService(atmEntities);
            accountDataService = new AccountDataService(atmEntities);
            usersDTO = await userDataService.GetAll();
            accountsDTO = await accountDataService.GetAll();

            dataGrid.ItemsSource = usersDTO;
            dataGrid2.ItemsSource = accountsDTO;
        }

        private async void ButtonCreateUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserDTO userDTO = await userDataService.Create(
                        firstName.Text, lastName.Text, phone.Text, email.Text, nip.Text, username.Text, int.Parse(userType.Text));
                usersDTO.Add(userDTO);

                MessageBox.Show("Add user successful");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Failed to add user: " + ex.InnerException.Message);
            }
        }

        private async void buttonCreateAccount_Click(object sender, RoutedEventArgs e)
        {
            int idUserInput = int.Parse(idUser.Text);
            int idAccountTypeInput = int.Parse(idAccountType.Text);
            decimal balanceInput = decimal.Parse(balance.Text);
            double interestRateInput = double.Parse(interestRate.Text);
            decimal invoicePaymentFeeInput = decimal.Parse(invoicePaymentFee.Text);
            decimal maxWithdrawalAmountInput = decimal.Parse(maxWithdrawalAmount.Text);

            try
            {
                AccountDTO accountDTO = await accountDataService.Create(
                    idUserInput, idAccountTypeInput, balanceInput, interestRateInput, invoicePaymentFeeInput, maxWithdrawalAmountInput);
                accountsDTO.Add(accountDTO);

                MessageBox.Show("Add account successful");
            }
            catch (Exception)
            {
                MessageBox.Show("Failed to add account");
            }
        }

        private async void buttonDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            UserDTO selectedUserDTO = (UserDTO)dataGrid.SelectedItem;

            if (selectedUserDTO != null)
            {
                try
                {
                    if (await userDataService.Delete(selectedUserDTO))
                    {
                        usersDTO.Remove(selectedUserDTO);
                        MessageBox.Show("User delete successful");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Delete user failed");
                }
            }
            else
            {
                MessageBox.Show("No user selected");
            }
        }

        private async void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            UserDTO selectedUserDTO = (UserDTO)dataGrid.SelectedItem;

            if (selectedUserDTO != null)
            {
                try
                {
                    await userDataService.Update(selectedUserDTO);
                    MessageBox.Show("User update successful");
                }
                catch (Exception)
                {
                    MessageBox.Show("Update user failed");
                }
            }
            else
            {
                MessageBox.Show("No user selected");
            }
        }

        private async void buttonUpdateAccount_Click(object sender, RoutedEventArgs e)
        {
            AccountDTO selectedAccountDTO = (AccountDTO)dataGrid2.SelectedItem;

            if (selectedAccountDTO != null)
            {
                try
                {
                    await accountDataService.Update(selectedAccountDTO);
                    MessageBox.Show("Account update successful");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update user failed: " + ex.InnerException.Message);
                }
            }
            else
            {
                MessageBox.Show("No account selected");
            }
        }

        private async void buttonDeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            AccountDTO selectedAccountDTO = (AccountDTO)dataGrid.SelectedItem;

            if (selectedAccountDTO != null)
            {
                try
                {
                    if (await accountDataService.Delete(selectedAccountDTO))
                    {
                        accountsDTO.Remove(selectedAccountDTO);
                        MessageBox.Show("Account delete successful");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Account user failed");
                }
            }
            else
            {
                MessageBox.Show("No Account selected");
            }
        }
    }
}
