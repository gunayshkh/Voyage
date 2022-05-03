namespace Voyage.Models.Entities
{
    public class Team: BaseEntity
    {
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public string? ImageURL { get; set; }
    }
}
