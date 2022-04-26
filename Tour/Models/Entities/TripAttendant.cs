using Voyage.DATA.Enum;

namespace Voyage.Models.Entities
{
    public class TripAttendant:BaseEntity
    {
        public string  FullName { get; set; }
        public ClientType Client { get; set;}

    }
}
