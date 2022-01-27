using EnvGraphique.Evaluation2.ATM.Domain.Models;
using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Data
{
    public class AccountDataService : IAccountDataService
    {
        private readonly ATMEntities atmEntities;

        public AccountDataService(ATMEntities atmEntities)
        {
            this.atmEntities = atmEntities;
        }

        public async Task<AccountDTO> Create(int idUser, int idAccountType, decimal balance, double? interestRate = null, decimal? invoicePaymentFee = null, decimal? maxWithdrawalAmount = null)
        {
            Account account = new Account();
            account.IdUser = idUser;
            account.IdAccountType = idAccountType;
            account.Balance = balance;
            account.InterestRate = interestRate;
            account.InvoicePaymentFee = invoicePaymentFee;
            account.MaxWithdrawalAmount = maxWithdrawalAmount;

            var createdAccount = atmEntities.Set<Account>().Add(account);
            AccountDTO accountDTO = null;

            try
            {
                await atmEntities.SaveChangesAsync();

                if (createdAccount != null)
                {
                    accountDTO = new AccountDTO(account);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return accountDTO;
        }

        public async Task<AccountDTO> Update(AccountDTO accountDTO)
        {
            var accountToUpdate = await atmEntities.Set<Account>().FindAsync(accountDTO.Id);

            if (accountToUpdate != null)
            {
                atmEntities.Entry(accountToUpdate).CurrentValues.SetValues(accountDTO);

                try
                {
                    await atmEntities.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return accountDTO;
        }

        public async Task<bool> Delete(AccountDTO accountDTO)
        {
            var accountToDelete = await atmEntities.Set<Account>().FindAsync(accountDTO.Id);

            if (accountToDelete != null)
            {
                atmEntities.Set<Account>().Remove(accountToDelete);

                try
                {
                    await atmEntities.SaveChangesAsync();

                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return false;
        }
        public async Task<AccountDTO> Get(int id)
        {
            var accountToGet = await atmEntities.Set<Account>().FindAsync(id);
            AccountDTO accountDTO = null;

            if (accountToGet != null)
            {
                accountDTO = new AccountDTO(accountToGet);
            }

            return accountDTO;
        }

        public async Task<ObservableCollection<AccountDTO>> GetAll()
        {
            ObservableCollection<AccountDTO> accountsDTO = new ObservableCollection<AccountDTO>();

            IEnumerable<Account> accounts = await atmEntities.Set<Account>().ToListAsync();

            foreach (Account account in accounts)
            {
                accountsDTO.Add(new AccountDTO(account));
            }

            return accountsDTO;
        }

        public async Task<ObservableCollection<AccountDTO>> getUserAccounts(int userId)
        {
            ObservableCollection<AccountDTO> accountsDTO = new ObservableCollection<AccountDTO>();

            IEnumerable<Account> accounts = await atmEntities.Set<Account>().Where(account => account.IdUser == userId).ToListAsync();

            foreach (Account account in accounts)
            {
                accountsDTO.Add(new AccountDTO(account));
            }

            return accountsDTO;
        }
    }
}
