namespace Voyage.Models.Entities
{
    public class TourService : BaseEntity
    {
        public Trip Trip { get; set; }
        public SubService SubService { get; set; }
    }
}
