using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {

        //Task<bool> CreateUser(User user);
        //Task<bool> DeleteUser(int id);

        User GetByEmail(string email);
        User GetByPhone(string phone);
        User GetByNationalCode(string nationalCode);
        IEnumerable<User> SearchUsers(string searchTerm);
        bool ValidateUser(string username, string password);
        //void UpdateUserProfile(int userId, User updatedUser);
        void ChangePassword(int userId, string newPassword);
        Task<User> GetUserByCredentialsAsync(string email, string hashedPassword);
        Task<IEnumerable<User>> GetLastRegisterUserAsync(int take);
    }
}
