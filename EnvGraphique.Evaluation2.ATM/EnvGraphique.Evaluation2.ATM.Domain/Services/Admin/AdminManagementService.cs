using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Data;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using static EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs.AccountDTO;
using static EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs.TransactionDTO;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Admin
{
    public class AdminManagementService : IAdminManagementService
    {
        private readonly UserDataService userDataService;
        private readonly AccountDataService accountDataService;
        private readonly TransactionDataService transactionDataService;

        public AdminManagementService(IUserDataService userDataService, IAccountDataService accountDataService, ITransactionDataService transactionDataService)
        {
            this.userDataService = (UserDataService)userDataService;
            this.accountDataService = (AccountDataService)accountDataService;
            this.transactionDataService = (TransactionDataService)transactionDataService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="idAccountType"></param>
        /// <param name="balance"></param>
        /// <param name="interestRate"></param>
        /// <param name="invoicePaymentFee"></param>
        /// <param name="maxWithdrawalAmount"></param>
        /// <returns></returns>
        /// <exception cref="UserDataNotFoundException"></exception>
        public async Task<AccountDTO> CreateAccount(int idUser, int idAccountType, decimal balance, double? interestRate = null, decimal? invoicePaymentFee = null, decimal? maxWithdrawalAmount = null)
        {
            if (await userDataService.Get(idUser) == null)
            {
                throw new UserDataNotFoundException();
            }

            ObservableCollection<AccountDTO> userAccountsDTO = await accountDataService.getUserAccounts(idUser);

            if (userAccountsDTO.Where(accounts => accounts.IdAccountType == (int)EAccountType.Checking).FirstOrDefault() == null && idAccountType != (int)EAccountType.Checking)
            {
                throw new AdminCreateAccountNoCheckingAccountException();
            }

            return await accountDataService.Create(idUser, idAccountType, balance, interestRate, invoicePaymentFee, maxWithdrawalAmount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="phone"></param>
        /// <param name="email"></param>
        /// <param name="nip"></param>
        /// <param name="username"></param>
        /// <param name="idUserType"></param>
        /// <param name="enabled"></param>
        /// <returns></returns>
        /// <exception cref="ExistingUsernameException"></exception>
        public async Task<UserDTO> CreateUser(string firstName, string lastName, string phone, string email, string nip, string username, int idUserType, bool enabled = true)
        {
            UserDTO existingUser = await userDataService.GetByUsername(username);

            if (existingUser != null)
            {
                throw new ExistingUsernameException();
            }

            return await userDataService.Create(firstName, lastName, phone, email, nip, username, idUserType, enabled);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="systemAccounts"></param>
        /// <param name="percentageToIncrease"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="TransactionInvalidAmountException"></exception>
        public async Task<bool> IncreaseAllMarginAccountsBalance(ObservableCollection<AccountDTO> systemAccounts, decimal percentageToIncrease)
        {
            if (systemAccounts == null)
            {
                throw new ArgumentNullException(nameof(systemAccounts));
            }

            if (percentageToIncrease <= 0)
            {
                throw new TransactionInvalidAmountException(nameof(percentageToIncrease));
            }

            IEnumerable<AccountDTO> marginAccountsDTO = systemAccounts.Where(x => x.IdAccountType == (int)EAccountType.Margin);

            foreach (AccountDTO accountDTO in marginAccountsDTO)
            {
                decimal amountToIncrease = Math.Abs(accountDTO.Balance * percentageToIncrease);

                accountDTO.Balance += amountToIncrease;

                try
                {
                    TransactionDTO transactionDTO = await transactionDataService.Create((int)ETransactionType.Interest, amountToIncrease, DateTime.Now, accountDTO.Id);
                    accountDTO.Transactions.Add(transactionDTO);
                    await accountDataService.Update(accountDTO);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAccountsDTO"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="TransactionInvalidAmountException"></exception>
        public async Task<bool> MortgagePayment(ObservableCollection<AccountDTO> userAccountsDTO, decimal amount)
        {
            if (userAccountsDTO == null)
            {
                throw new ArgumentNullException(nameof(userAccountsDTO));
            }
            if (amount <= 0)
            {
                throw new TransactionInvalidAmountException(nameof(amount));
            }

            AccountDTO mortgageAccountDTO = userAccountsDTO.Where(x => x.IdAccountType == (int)EAccountType.Mortgage).SingleOrDefault();

            if (mortgageAccountDTO.Balance - amount < 0)
            {
                foreach (AccountDTO accountDTO in userAccountsDTO)
                {
                    if (accountDTO.IdAccountType == (int)EAccountType.Margin)
                    {
                        decimal amountToWithdrawFromMortgageAccount = mortgageAccountDTO.Balance;
                        decimal amountToIncreaseMargin = amount - mortgageAccountDTO.Balance;

                        mortgageAccountDTO.Balance = 0;
                        accountDTO.Balance += amountToIncreaseMargin;

                        TransactionDTO mortgageTransactionDTO;

                        if (amountToWithdrawFromMortgageAccount > 0)
                        {
                            mortgageTransactionDTO = await transactionDataService.Create((int)ETransactionType.Mortgage, amountToWithdrawFromMortgageAccount, DateTime.Now, mortgageAccountDTO.Id);
                            mortgageAccountDTO.Transactions.Add(mortgageTransactionDTO);
                        }

                        TransactionDTO marginTransactionDTO = await transactionDataService.Create((int)ETransactionType.Mortgage, amountToIncreaseMargin, DateTime.Now, accountDTO.Id);
                        accountDTO.Transactions.Add(marginTransactionDTO);

                        await accountDataService.Update(mortgageAccountDTO);
                        await accountDataService.Update(accountDTO);

                        return true;
                    }
                }
            }
            else
            {
                mortgageAccountDTO.Balance -= amount;

                TransactionDTO mortgageTransactionDTO = await transactionDataService.Create((int)ETransactionType.Mortgage, amount, DateTime.Now, mortgageAccountDTO.Id);
                mortgageAccountDTO.Transactions.Add(mortgageTransactionDTO);
                await accountDataService.Update(mortgageAccountDTO);

                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="systemAccounts"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<bool> PayAllSavingAccountsInterests(ObservableCollection<AccountDTO> systemAccounts)
        {
            if (systemAccounts == null)
            {
                throw new ArgumentNullException(nameof(systemAccounts));
            }

            IEnumerable<AccountDTO> savingAccountsDTO = systemAccounts.Where(x => x.IdAccountType == (int)EAccountType.Saving);

            foreach (AccountDTO accountDTO in savingAccountsDTO)
            {
                if (accountDTO.InterestRate == null)
                {
                    continue;
                }

                decimal interestAmount = accountDTO.Balance * ((decimal)accountDTO.InterestRate / 100); // Account interests is in %, divide by 100

                accountDTO.Balance += interestAmount;

                try
                {
                    TransactionDTO transactionDTO = await transactionDataService.Create((int)ETransactionType.Interest, interestAmount, DateTime.Now, accountDTO.Id);
                    accountDTO.Transactions.Add(transactionDTO);
                    await accountDataService.Update(accountDTO);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<UserDTO> SetUserAccountDisabled(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                throw new ArgumentNullException(nameof(userDTO));
            }

            userDTO.Enabled = false;
            await userDataService.Update(userDTO);

            return userDTO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<UserDTO> SetUserAccountEnabled(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                throw new ArgumentNullException(nameof(userDTO));
            }

            userDTO.Enabled = true;
            await userDataService.Update(userDTO);

            return userDTO;
        }
    }
}
