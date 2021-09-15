using System.ComponentModel.DataAnnotations;

namespace Sms.App.Models.Master
{
    public class RoleModel : BaseModel
    {
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
