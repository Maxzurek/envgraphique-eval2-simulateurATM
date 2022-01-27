using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Admin
{
    public interface IAdminManagementService
    {
        Task<UserDTO> SetUserAccountEnabled(UserDTO userDTO);
        Task<UserDTO> SetUserAccountDisabled(UserDTO userDTO);
        Task<UserDTO> CreateUser(string firstName, string lastName, string phone, string email, string nip, string username, int idUserType, bool enabled = true);
        Task<AccountDTO> CreateAccount(int idUser, int idAccountType, decimal balance, double? interestRate = null, decimal? invoicePaymentFee = null, decimal? maxWithdrawalAmount = null);
        Task<bool> IncreaseAllMarginAccountsBalance(ObservableCollection<AccountDTO> systemAccounts, decimal percentageToIncrease);
        Task<bool> PayAllSavingAccountsInterests(ObservableCollection<AccountDTO> systemAccounts);
        Task<bool> MortgagePayment(ObservableCollection<AccountDTO> userAccountsDTO, decimal amount);
    }
}
