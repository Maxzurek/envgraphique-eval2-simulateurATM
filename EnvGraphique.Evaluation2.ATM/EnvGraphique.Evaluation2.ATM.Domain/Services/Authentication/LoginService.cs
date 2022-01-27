using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using EnvGraphique.Evaluation2.ATM.Domain.Services.Exceptions;
using System.Threading.Tasks;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services.Authentication
{
    public class LoginService : ILoginService
    {
        private readonly IUserDataService userDataService;

        public LoginService(IUserDataService userDataService)
        {
            this.userDataService = userDataService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="nip"></param>
        /// <returns></returns>
        /// <exception cref="DbConnectionFailedException"></exception>
        public async Task<UserDTO> Login(string username, string nip)
        {
            UserDTO user = await userDataService.GetByUsername(username);

            if (user != null)
            {
                if (user.Nip == nip)
                {
                    return user;
                }
            }

            return null;
        }
    }
}
