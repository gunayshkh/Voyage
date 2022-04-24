namespace Voyage.Models.Entities
{
    public class SubService : BaseEntity
    {
        public string Name { get; set; }
        public Service Services { get; set; }
        

    }
}
