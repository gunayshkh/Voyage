namespace Voyage.Models.Entities
{
    public class AboutCompany:BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string AdditionalInfo { get; set; }
        public Team Team { get; set; }
    }
}
