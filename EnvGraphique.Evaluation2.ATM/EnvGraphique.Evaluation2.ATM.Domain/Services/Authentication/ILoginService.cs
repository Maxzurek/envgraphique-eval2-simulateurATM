using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using System.Threading.Tasks;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Authentication
{
    public interface ILoginService
    {
        Task<UserDTO> Login(string username, string nip);
    }
}
