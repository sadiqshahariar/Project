using FirstWebProject.Models;
using FirstWebProject.Repositories.Interface;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace FirstWebProject.Repositories.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly RazorWebContext _dbContext;

        public AccountRepository(RazorWebContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<User> GetData()
        {
            List<User> users = _dbContext.Users.OrderByDescending(u => u.Id).ToList();
            return users;
        }

        public bool isDelete(int userId)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<int> SaveUserDetails(string Username, string Email, string Phone, string Password, DateOnly Dob)
        {
            try
            {
                var userDetail = new User
                {
                    UserName = Username,
                    Email = Email,
                    Phone = Phone,
                    Password = Password,
                    Dob = Dob
                };
                await _dbContext.AddAsync(userDetail);
                await _dbContext.SaveChangesAsync();
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public async Task<bool> UpdateData(int userId, string username, string email, string phone,DateOnly dob)
        {
            try
            {
                var user = _dbContext.Users.FirstOrDefault(u => u.Id == userId);
                if(user != null)
                {
                    user.UserName = username;
                    user.Email = email;
                    user.Phone = phone;
                    user.Dob = dob;

                    // Save changes to the database
                    _dbContext.Users.Update(user);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch(Exception ex)
            {
                return false;
            }
         
        }

    }
}
