using DataLayer.Context;
using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly MyProjectContext _context;

        public UserRepository(MyProjectContext context) : base(context)
        {
            _context = context;
        }



        public void ChangePassword(int userId, string newPassword)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {

                throw new NotImplementedException("کاربر یافت نشد");
            }
            user.Password = newPassword; // در عمل باید هش شود
            _context.SaveChanges();
        }



        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(x => x.Email == email);
        }

        public User GetByNationalCode(string nationalCode)
        {
            return _context.Users.FirstOrDefault(x => x.NationalCode == nationalCode);
        }

        public User GetByPhone(string phone)
        {
            return _context.Users.FirstOrDefault(x => x.Phone == phone);
        }


        public IEnumerable<User> SearchUsers(string searchTerm)
        {
            return _context.Users
                           .Where(u =>
                               u.FirstName.Contains(searchTerm) ||
                               u.LastName.Contains(searchTerm) ||
                               u.Email.Contains(searchTerm) ||
                               u.Phone.Contains(searchTerm))
                           .ToList();
        }

        //public void Update(User entity)
        //{
        //    var user = _context.Users.Find(entity.UserId);
        //    if (user != null)
        //    {
        //        new NotImplementedException("کاربر یافت نشد");
        //    }

        //    // به‌روزرسانی فیلدهای مجاز
        //    user.FirstName = entity.FirstName;
        //    user.LastName = entity.LastName;
        //    user.Email = entity.Email;
        //    user.NationalCode = entity.NationalCode;
        //    user.Phone = entity.Phone;
        //    user.Gender = entity.Gender;
        //    user.YearBirth = entity.YearBirth;
        //    user.MonthBirth = entity.MonthBirth;
        //    user.DayBirth = entity.DayBirth;

        //    _context.Entry(user).State = EntityState.Modified;
        //}

        //public void UpdateUserProfile(int userId, User updatedUser)
        //{
        //    var user = _context.Users.Find(userId);
        //    if (user == null) return;

        //    // به‌روزرسانی فیلدهای مجاز
        //    user.FirstName = updatedUser.FirstName;
        //    user.LastName = updatedUser.LastName;
        //    user.Email = updatedUser.Email;
        //    user.NationalCode = updatedUser.NationalCode;
        //    user.Phone = updatedUser.Phone;
        //    user.Gender = updatedUser.Gender;
        //    user.YearBirth = updatedUser.YearBirth;
        //    user.MonthBirth = updatedUser.MonthBirth;
        //    user.DayBirth = updatedUser.DayBirth;

        //    _context.Entry(user).State = EntityState.Modified;
        //    // _context.SaveChanges();
        //}

        public bool ValidateUser(string email, string password)
        {
            var user = GetByEmail(email);
            if (user == null) return false;

            return user.Password == password; // در عمل باید از هش استفاده شود
        }

        public async Task<User> GetUserByCredentialsAsync(string email, string hashedPassword)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == hashedPassword);
        }

        public async Task<IEnumerable<User>> GetLastRegisterUserAsync(int take)
        {
            return await _context.Users
                        .Where(u => u.IsAdmin != true)
                        .OrderByDescending(u => u.RegistrationDate)
                        .Take(take)
                        .ToListAsync();
        }

    }
}
