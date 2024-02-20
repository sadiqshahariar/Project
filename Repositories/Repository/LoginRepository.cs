using FirstWebProject.Models;
using FirstWebProject.Repositories.Interface;
using Microsoft.EntityFrameworkCore;


namespace FirstWebProject.Repositories.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly RazorWebContext _dbContext;

        public LoginRepository(RazorWebContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool LoginUser(string email, string password)
        {
            try
            {
                var user =   _dbContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
                if (user == null)
                {
                    return false;
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
