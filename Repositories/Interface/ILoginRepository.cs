namespace FirstWebProject.Repositories.Interface
{
    public interface ILoginRepository
    {
        bool LoginUser(string email, string password);
    }
}
