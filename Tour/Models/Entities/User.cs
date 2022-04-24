using Microsoft.AspNetCore.Identity;

namespace Voyage.Models.Entities
{
    public class User: IdentityUser
    {
        public string FullName { get; set; }
        public string ImageURL { get; set; }
    }
}
