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
    public class TransactionDataService : ITransactionDataService
    {
        private readonly ATMEntities atmEntities;

        public TransactionDataService(ATMEntities atmEntities)
        {
            this.atmEntities = atmEntities;
        }

        public async Task<TransactionDTO> Create(int idTransactionType, decimal amount, DateTime date, int sourceAccountId, int? targetAccountId = null)
        {
            Transaction transaction = new Transaction();
            transaction.IdTransactionType = idTransactionType;
            transaction.Amount = amount;
            transaction.Date = date;
            transaction.SourceAccountId = sourceAccountId;
            transaction.TargetAccountId = targetAccountId;

            var createdTransaction = atmEntities.Set<Transaction>().Add(transaction);
            TransactionDTO transactionDTO = null;

            try
            {
                await atmEntities.SaveChangesAsync();

                if (createdTransaction != null)
                {
                    transactionDTO = new TransactionDTO(transaction);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return transactionDTO;
        }

        public async Task<TransactionDTO> Update(TransactionDTO transactionDTO)
        {
            var transactionToUpdate = await atmEntities.Set<Transaction>().FindAsync(transactionDTO.Id);

            if (transactionToUpdate != null)
            {
                atmEntities.Entry(transactionToUpdate).CurrentValues.SetValues(transactionDTO);

                try
                {
                    await atmEntities.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return transactionDTO;
        }

        public async Task<bool> Delete(TransactionDTO transactionDTO)
        {
            var transactionToDelete = await atmEntities.Set<Transaction>().FindAsync(transactionDTO.Id);

            if (transactionToDelete != null)
            {
                atmEntities.Set<Transaction>().Remove(transactionToDelete);

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

        public async Task<TransactionDTO> Get(int id)
        {
            var transactionToGet = await atmEntities.Set<Transaction>().FindAsync(id);
            TransactionDTO transactionDTO = null;

            if (transactionToGet != null)
            {
                transactionDTO = new TransactionDTO(transactionToGet);
            }

            return transactionDTO;
        }

        public async Task<ObservableCollection<TransactionDTO>> GetAll()
        {
            ObservableCollection<TransactionDTO> transactionsDTO = new ObservableCollection<TransactionDTO>();

            IEnumerable<Transaction> transactions = await atmEntities.Set<Transaction>().ToListAsync();

            foreach (Transaction transaction in transactions)
            {
                transactionsDTO.Add(new TransactionDTO(transaction));
            }

            return transactionsDTO;
        }

        public async Task<ObservableCollection<TransactionDTO>> GetAllBySourceAccountId(int sourceAccountId)
        {
            ObservableCollection<TransactionDTO> transactionsDTO = new ObservableCollection<TransactionDTO>();

            IEnumerable<Transaction> transactions = await atmEntities.Set<Transaction>().Where(transaction => transaction.SourceAccountId == sourceAccountId).ToListAsync();

            foreach (Transaction transaction in transactions)
            {
                transactionsDTO.Add(new TransactionDTO(transaction));
            }

            return transactionsDTO;
        }
    }
}
