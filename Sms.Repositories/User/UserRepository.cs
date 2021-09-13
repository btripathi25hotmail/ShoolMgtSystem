using Dapper;
using Sms.BusinessObjects.User;
using Sms.DataSource;
using System.Threading.Tasks; 

namespace Sms.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataOperations _db;
        public UserRepository(IDataOperations db)
        {
            _db = db;
        }

        public async Task<LoginDetailBo> ValidateAsync<LoginDetailBo>(LoginBo login)
        {
            var parameter = new DynamicParameters();
            parameter.Add("@uname", login.Email);
            parameter.Add("@pwd", login.Password);
            var userDetail = await _db.GetDetailAsync<LoginDetailBo>("usp_validation", parameter);
            return userDetail;
        }
    }
}