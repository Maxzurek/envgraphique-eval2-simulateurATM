using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Data
{
    public interface ITransactionDataService : IDataService<TransactionDTO>
    {
        Task<TransactionDTO> Create(int idTransactionType, decimal amount, DateTime date, int sourceAccountId, int? targetAccountId = null);
        Task<ObservableCollection<TransactionDTO>> GetAllBySourceAccountId(int sourceAccountId);
    }
}
