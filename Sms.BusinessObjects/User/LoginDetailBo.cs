namespace Sms.BusinessObjects.User
{
    public class LoginDetailBo
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
        public string Name
        {
            get
            {
                return this.FirstName + " " + this.LastName;
            }
        }
    }
}