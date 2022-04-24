namespace Voyage.Models.Entities
{
    public class TripImage:BaseEntity
    {
        public string ImageURL { get; set; }
        public bool IsMain { get; set; }
        public int? Order { get; set; }
        public Trip Trip { get; set; }

    }
}
