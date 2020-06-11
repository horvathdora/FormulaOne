using System.Threading.Tasks;

namespace Formula1_WebApplication.DAL
{
    public interface IUserRepository
    {
        Task SeedUserAsync();
    }
}
