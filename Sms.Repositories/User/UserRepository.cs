using System.Threading.Tasks;
using Sms.BusinessObjects.User;
using Dapper;

namespace Sms.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbOperations _db;
        public UserRepository(IDbOperations db)
        {
            _db = db;
        }

        public async Task<LoginDetailBo> Validate<LoginDetailBo>(LoginBo login)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@uname", login.Email);
            parameter.Add("@pwd", login.Password);
            var userDetail = await _db.GetDetail<LoginDetailBo>("usp_validation", parameter);
            return userDetail;
        }
    }
}