using EnvGraphique.Evaluation2.ATM.Domain.Models;
using EnvGraphique.Evaluation2.ATM.Domain.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Threading.Tasks;

namespace EnvGraphique.Evaluation2.ATM.Domain.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly ATMEntities atmEntities;

        public UserDataService(ATMEntities atmEntities)
        {
            this.atmEntities = atmEntities;
        }

        public async Task<UserDTO> Create(string firstName, string lastName, string phone, string email, string nip, string username, int idUserType, bool enabled = true)
        {
            User user = new User();
            user.FirstName = firstName;
            user.LastName = lastName;
            user.Phone = phone;
            user.Email = email;
            user.Nip = nip;
            user.Username = username;
            user.IdUserType = idUserType;
            user.Enabled = enabled;

            var createdUser = atmEntities.Set<User>().Add(user);
            UserDTO userDTO = null;

            try
            {
                await atmEntities.SaveChangesAsync();

                if (createdUser != null)
                {
                    userDTO = new UserDTO(user);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return userDTO;
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userToUpdate = await atmEntities.Set<User>().FindAsync(userDTO.Id);

            if (userToUpdate != null)
            {
                atmEntities.Entry(userToUpdate).CurrentValues.SetValues(userDTO);

                try
                {
                    await atmEntities.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return userDTO;
        }

        public async Task<bool> Delete(UserDTO user)
        {
            var userToDelete = await atmEntities.Set<User>().FindAsync(user.Id);

            if (userToDelete != null)
            {
                atmEntities.Set<User>().Remove(userToDelete);

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

        public async Task<UserDTO> Get(int id)
        {
            var userToGet = await atmEntities.Set<User>().FindAsync(id);
            UserDTO userDTO = null;

            if (userToGet != null)
            {
                userDTO = new UserDTO(userToGet);
            }

            return userDTO;
        }
        public async Task<ObservableCollection<UserDTO>> GetAll()
        {
            ObservableCollection<UserDTO> usersDTO = new ObservableCollection<UserDTO>();

            IEnumerable<User> users = await atmEntities.Set<User>().ToListAsync();

            foreach (User user in users)
            {
                usersDTO.Add(new UserDTO(user));
            }

            return usersDTO;
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            User userToGet = await atmEntities.Users.FirstOrDefaultAsync(user => user.Email == email);
            UserDTO userDTO = null;

            if (userToGet != null)
            {
                userDTO = new UserDTO(userToGet);
            }

            return userDTO;
        }

        public async Task<UserDTO> GetByUsername(string username)
        {
            User userToGet = await atmEntities.Users.FirstOrDefaultAsync(user => user.Username == username);
            UserDTO userDTO = null;

            if (userToGet != null)
            {
                userDTO = new UserDTO(userToGet);
            }

            return userDTO;
        }
    }
}
