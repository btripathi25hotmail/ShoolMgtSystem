using System.Threading.Tasks;
using Sms.BusinessObjects.User;

namespace Sms.Repositories.User
{
    public interface IUserRepository
    {
        Task<LoginDetailBo> Validate<LoginDetailBo>(LoginBo login);
    }
}