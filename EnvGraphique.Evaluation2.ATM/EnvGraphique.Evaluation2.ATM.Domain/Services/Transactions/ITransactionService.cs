using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Transactions
{
    public interface ITransactionService
    {
        Task<AccountDTO> Deposit(AccountDTO accountDTO, decimal amount);
        Task<AccountDTO> Withdraw(AccountDTO accountDTO, decimal amount, decimal atmRemainingAmount);
        Task<bool> WithdrawFromMargin(AccountDTO sourceAccountDTO, AccountDTO marginAccount, decimal amount, decimal atmRemainingAmount);
        AccountDTO CanWithdrawFromMargin(ObservableCollection<AccountDTO> accountsDTO, decimal amount);
        Task<bool> Transfer(AccountDTO accountDTOSource, AccountDTO accountDTOTarget, decimal amount);
        Task<AccountDTO> Payment(AccountDTO accountDTO, decimal amount);
    }
}
