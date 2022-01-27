using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using System.Threading.Tasks;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services
{
    public interface IUserDataService : IDataService<UserDTO>
    {
        Task<UserDTO> Create(string firstName, string lastName, string phone, string email, string nip, string username, int idUserType, bool enabled = true);
        Task<UserDTO> GetByUsername(string username);
        Task<UserDTO> GetByEmail(string email);
    }
}
