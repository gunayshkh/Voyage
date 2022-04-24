namespace Voyage.Models.Entities
{
    public class Booking:BaseEntity
    {
        public User User { get; set; }
        public Trip Trip { get; set; }
    }
}
