using Sms.BusinessObjects.User;
using System.Threading.Tasks;

namespace Sms.Services.User
{
    public interface IUserService
    {
        Task<LoginDetailBo> ValidateAsync<LoginDetailBo>(LoginBo login);
    }
}