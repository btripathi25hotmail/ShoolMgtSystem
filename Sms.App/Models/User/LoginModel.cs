using System.ComponentModel.DataAnnotations;

namespace Sms.App.Models.Users
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Enter email address")]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [DataType(DataType.Password)]
        [MinLength(5, ErrorMessage = "Password should not be less than 5 characters.")]
        [MaxLength(15, ErrorMessage = "Password should not be greater than 15 characters.")]
        public string Password { get; set; }


    }
}