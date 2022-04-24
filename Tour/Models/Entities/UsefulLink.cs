namespace Voyage.Models.Entities
{
    public class UsefulLink : BaseEntity
    {
        public string Name { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
