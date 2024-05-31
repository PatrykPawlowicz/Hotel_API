using Hotel_API.Models;
using System.Threading.Tasks;

namespace Hotel_API.Data
{

    public interface IAuthRepository
    {
        public Task<ServiceResponse<int>> Register(User user, string password);
        public Task<ServiceResponse<string>> Login(string email, string password);
        public Task<bool> UserExists(string email);
    }

}
