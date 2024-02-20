using FirstWebProject.Models;

namespace FirstWebProject.Repositories.Interface
{
    public interface IAccountRepository
    {
        List<User> GetData();
        Task<int> SaveUserDetails(string username,string email,string phone,string password,DateOnly Dob);
        bool isDelete(int userId);
        Task<bool> UpdateData(int userId,string username,string emial,string phone,DateOnly dob);
    }
}
