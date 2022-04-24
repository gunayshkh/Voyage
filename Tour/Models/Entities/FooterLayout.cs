using System.ComponentModel.DataAnnotations;

namespace Voyage.Models.Entities
{
    public class FooterLayout : BaseEntity
    {
        public string Description { get; set; }
        public string SocialLinks { get; set; }
        public string UsefulLinks { get; set; }
        [DataType("Email")]
        public string Email { get; set; }
        public string Phone { get; set; }
        public HeaderLayout Logo { get; set; }

    }
}
