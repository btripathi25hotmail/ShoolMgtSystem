using Sms.BusinessObjects.User;
using Sms.Repositories.User;
using System.Threading.Tasks;

namespace Sms.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        } 

        public async Task<LoginDetailBo> ValidateAsync<LoginDetailBo>(LoginBo login)
        {
            return await _userRepository.ValidateAsync<LoginDetailBo>(login);
        }
    }
}
