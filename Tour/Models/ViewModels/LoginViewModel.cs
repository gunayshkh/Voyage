using System.ComponentModel.DataAnnotations;

namespace Voyage.Models.ViewModels
{
    public class LoginViewModel
    {
        public string LoginProvider { get; set; }   
        public string ProviderKey { get; set; } = string.Empty; 
        public string ReturnUrl { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]

        public string Password { get; set; }
        public bool isPersistent { get; } = false;
    }
}
