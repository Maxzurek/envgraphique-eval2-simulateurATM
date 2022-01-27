using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Data
{
    public interface IAccountDataService : IDataService<AccountDTO>
    {
        Task<AccountDTO> Create(
            int idUser,
            int idAccountType,
            decimal balance,
            double? interestRate = null,
            decimal? invoicePaymentFee = null,
            decimal? maxWithdrawalAmount = null);

        Task<ObservableCollection<AccountDTO>> getUserAccounts(int userId);
    }
}
