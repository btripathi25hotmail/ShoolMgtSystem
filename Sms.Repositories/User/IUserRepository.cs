using Sms.BusinessObjects.User;
using System.Threading.Tasks;

namespace Sms.Repositories.User
{
    public interface IUserRepository
    {
        Task<LoginDetailBo> ValidateAsync<LoginDetailBo>(LoginBo login);
    }
}