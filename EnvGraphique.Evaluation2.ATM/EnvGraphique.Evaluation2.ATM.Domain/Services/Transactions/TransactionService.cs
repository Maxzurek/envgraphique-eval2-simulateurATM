using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Data;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using static EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs.AccountDTO;
using static EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs.TransactionDTO;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        private readonly IAccountDataService accountDataService;
        private readonly TransactionDataService transactionDataService;

        public TransactionService(IAccountDataService accountDataService, ITransactionDataService transactionDataService)
        {
            this.accountDataService = accountDataService;
            this.transactionDataService = (TransactionDataService)transactionDataService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountDTO"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="TransactionAccountTypeException"></exception>
        /// <exception cref="TransactionInvalidAmountException"></exception>
        public async Task<AccountDTO> Deposit(AccountDTO accountDTO, decimal amount)
        {
            if (accountDTO == null)
            {
                throw new ArgumentNullException(nameof(accountDTO));
            }

            switch (accountDTO.IdAccountType)
            {
                case (int)EAccountType.Margin:
                    throw new TransactionAccountTypeException("Deposit transaction failed. Cannot deposit into a margin account");
                default:
                    break;
            }

            if (amount <= 0)
            {
                throw new TransactionInvalidAmountException("Deposit transaction failed. Amount muste be greater than 0");
            }

            accountDTO.Balance += amount;

            AccountDTO updatedAccountDTO;
            TransactionDTO transactionDTO;
            try
            {
                transactionDTO = await CreateTransaction(ETransactionType.Deposit, amount, accountDTO);
                accountDTO.Transactions.Add(transactionDTO);
                updatedAccountDTO = await accountDataService.Update(accountDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return updatedAccountDTO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountDTO"></param>
        /// <param name="amount"></param>
        /// <param name="atmRemainingAmount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="TransactionAccountTypeException"></exception>
        /// <exception cref="TransactionInvalidAmountException"></exception>
        /// <exception cref="TransactionInvalidDivisibleAmountException"></exception>
        /// <exception cref="TransactionAtmSystemInsufficientFundException"></exception>
        /// <exception cref="TransactionInsufficientFundsException"></exception>
        /// <exception cref="TransactionMaxWithdrawalAmountException"></exception>
        public async Task<AccountDTO> Withdraw(AccountDTO accountDTO, decimal amount, decimal atmRemainingAmount)
        {
            if (accountDTO == null)
            {
                throw new ArgumentNullException(nameof(accountDTO));
            }

            switch (accountDTO.IdAccountType)
            {
                case (int)EAccountType.Mortgage:
                    throw new TransactionAccountTypeException("Withdrawal transaction failed. Cannot withdraw from a mortgage account");
                case (int)EAccountType.Margin:
                    throw new TransactionAccountTypeException("Withdrawal transaction failed. Cannot withdraw from a margin account");
                default:
                    break;
            }

            if (amount <= 0)
            {
                throw new TransactionInvalidAmountException("Withdrawal transaction failed. Amount muste be greater than 0");
            }

            if (amount % 10 != 0)
            {
                throw new TransactionInvalidDivisibleAmountException("Withdrawal transaction failed. Amount muste be a divisible by 10");
            }

            if (amount > atmRemainingAmount)
            {
                throw new TransactionAtmSystemInsufficientFundException();
            }

            if (accountDTO.MaxWithdrawalAmount < amount)
            {
                throw new TransactionMaxWithdrawalAmountException("Withdrawal transaction failed. The amount is great than the max withdrawal amount allowed.");
            }

            if (accountDTO.Balance - amount < 0)
            {
                throw new TransactionInsufficientFundsException("Withdrawal transaction failed. Insufficient funds.");
            }

            accountDTO.Balance -= amount;

            AccountDTO updatedAccountDTO;
            TransactionDTO transactionDTO;
            try
            {
                transactionDTO = await CreateTransaction(ETransactionType.Widthdraw, amount, accountDTO);
                accountDTO.Transactions.Add(transactionDTO);
                updatedAccountDTO = await accountDataService.Update(accountDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return updatedAccountDTO;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceAccountDTO"></param>
        /// <param name="marginAccountDTO"></param>
        /// <param name="amount"></param>
        /// <param name="atmRemainingAmount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="TransactionAccountTypeException"></exception>
        /// <exception cref="TransactionInvalidAmountException"></exception>
        /// <exception cref="TransactionAtmSystemInsufficientFundException"></exception>
        /// <exception cref="TransactionMaxWithdrawalAmountException"></exception>
        public async Task<bool> WithdrawFromMargin(AccountDTO sourceAccountDTO, AccountDTO marginAccountDTO, decimal amount, decimal atmRemainingAmount)
        {
            if (sourceAccountDTO == null)
            {
                throw new ArgumentNullException(nameof(sourceAccountDTO));
            }
            if (marginAccountDTO == null)
            {
                throw new ArgumentNullException(nameof(marginAccountDTO));
            }

            switch (marginAccountDTO.IdAccountType)
            {
                case (int)EAccountType.Margin: // In this case, account must be of type margin
                    break;
                default:
                    throw new TransactionAccountTypeException("Withdrawal transaction from margin failed. Account must but a margin account.");
            }

            if (amount <= 0)
            {
                throw new TransactionInvalidAmountException("Withdrawal transaction failed. Amount muste be greater than 0");
            }

            if (amount % 10 != 0)
            {
                throw new TransactionInvalidAmountException("Withdrawal transaction failed. Amount muste be a divisible by 10");
            }

            if (amount > atmRemainingAmount)
            {
                throw new TransactionAtmSystemInsufficientFundException();
            }

            if (sourceAccountDTO.MaxWithdrawalAmount < amount)
            {
                throw new TransactionMaxWithdrawalAmountException("Withdrawal transaction failed. The amount is great than the max withdrawal amount allowed.");
            }

            decimal amountToIncreaseMargin = amount - sourceAccountDTO.Balance;
            decimal amountToWithdrawFromSourceAccount = sourceAccountDTO.Balance;

            sourceAccountDTO.Balance = 0;
            marginAccountDTO.Balance += amountToIncreaseMargin;

            TransactionDTO sourceTransactionDTO;
            TransactionDTO marginTransactionDTO;
            try
            {
                if (amountToWithdrawFromSourceAccount != 0)
                {
                    sourceTransactionDTO = await CreateTransaction(ETransactionType.Widthdraw, amountToWithdrawFromSourceAccount, sourceAccountDTO);
                    sourceAccountDTO.Transactions.Add(sourceTransactionDTO);
                    await accountDataService.Update(sourceAccountDTO);
                }

                marginTransactionDTO = await CreateTransaction(ETransactionType.Widthdraw, amountToIncreaseMargin, marginAccountDTO);
                marginAccountDTO.Transactions.Add(marginTransactionDTO);
                await accountDataService.Update(marginAccountDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountsDTO"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public AccountDTO CanWithdrawFromMargin(ObservableCollection<AccountDTO> accountsDTO, decimal amount)
        {
            foreach (AccountDTO accountDTO in accountsDTO)
            {
                if (accountDTO.IdAccountType == (int)EAccountType.Margin)
                {
                    return accountDTO;
                }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceAccountDTO"></param>
        /// <param name="targetAccountDTO"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="TransactionAccountTypeException"></exception>
        /// <exception cref="TransactionInvalidAmountException"></exception>
        /// <exception cref="TransactionInsufficientFundsException"></exception>
        public async Task<bool> Transfer(AccountDTO sourceAccountDTO, AccountDTO targetAccountDTO, decimal amount)
        {
            if (sourceAccountDTO == null)
            {
                throw new ArgumentNullException(nameof(sourceAccountDTO));
            }
            if (targetAccountDTO == null)
            {
                throw new ArgumentNullException(nameof(targetAccountDTO));
            }

            switch (sourceAccountDTO.IdAccountType)
            {
                case (int)EAccountType.Checking:
                    break;
                default:
                    throw new TransactionAccountTypeException("Transfert transaction failed. Account source must be of type Checking");
            }

            if (amount <= 0)
            {
                throw new TransactionInvalidAmountException("Withdrawal transaction failed. Amount muste be greater than 0");
            }

            if (sourceAccountDTO.Balance - amount < 0)
            {
                throw new TransactionInsufficientFundsException("Withdrawal transaction failed. Insufficient funds.");
            }

            sourceAccountDTO.Balance -= amount;

            decimal sourceAmount = amount * (-1);
            decimal targetAmount;

            switch (targetAccountDTO.IdAccountType)
            {
                case (int)EAccountType.Margin:
                    targetAccountDTO.Balance -= amount;
                    targetAmount = amount * (-1);
                    break;
                default:
                    targetAccountDTO.Balance += amount;
                    targetAmount = amount;
                    break;
            }

            TransactionDTO sourceTransactionDTO;
            TransactionDTO targetTransactionDTO;
            try
            {
                sourceTransactionDTO = await CreateTransaction(ETransactionType.Transfer, sourceAmount, sourceAccountDTO, targetAccountDTO);
                sourceAccountDTO.Transactions.Add(sourceTransactionDTO);
                await accountDataService.Update(sourceAccountDTO);

                targetTransactionDTO = await CreateTransaction(ETransactionType.Transfer, targetAmount, targetAccountDTO, sourceAccountDTO);
                targetAccountDTO.Transactions.Add(targetTransactionDTO);
                await accountDataService.Update(targetAccountDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountDTO"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="TransactionAccountTypeException"></exception>
        /// <exception cref="TransactionInvalidAmountException"></exception>
        /// <exception cref="TransactionInsufficientFundsException"></exception>
        public async Task<AccountDTO> Payment(AccountDTO accountDTO, decimal amount)
        {
            if (accountDTO == null)
            {
                throw new ArgumentNullException(nameof(accountDTO));
            }

            switch (accountDTO.IdAccountType)
            {
                case (int)EAccountType.Checking:
                    break;
                default:
                    throw new TransactionAccountTypeException("Transfert transaction failed. Account source must be of type Checking");
            }

            if (amount <= 0)
            {
                throw new TransactionInvalidAmountException("Withdrawal transaction failed. Amount muste be greater than 0");
            }

            decimal invoicePaymentFee = (accountDTO.InvoicePaymentFee == null ? 0 : (decimal)accountDTO.InvoicePaymentFee);
            decimal totalAmount = amount + invoicePaymentFee;

            if (accountDTO.Balance - totalAmount < 0)
            {
                throw new TransactionInsufficientFundsException("Withdrawal transaction failed. Insufficient funds.");
            }

            accountDTO.Balance -= totalAmount;

            TransactionDTO transactionDTO;
            try
            {
                transactionDTO = await CreateTransaction(ETransactionType.Payment, totalAmount, accountDTO);
                accountDTO.Transactions.Add(transactionDTO);
                await accountDataService.Update(accountDTO);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return accountDTO;
        }

        private async Task<TransactionDTO> CreateTransaction(ETransactionType transactionType, decimal amount, AccountDTO sourceAccountDTO, AccountDTO targetAccountDTO = null)
        {
            DateTime date = DateTime.Now;
            int idTransactionType = (int)transactionType;
            Nullable<int> idTargetAccount = targetAccountDTO?.Id;

            return await transactionDataService.Create(idTransactionType, amount, date, sourceAccountDTO.Id, idTargetAccount);
        }
    }
}
