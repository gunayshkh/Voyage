using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Voyage.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required, MaxLength(100), MinLength(5, ErrorMessage = "Cannot be less than 5 characters")]
        public string FullName { get; set; }

        [Required, MaxLength(100), MinLength(5, ErrorMessage = "Cannot be less than 5 characters")]
        public string UserName { get; set; }

        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

      
        public IFormFile Image { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

    }
}
