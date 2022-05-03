using System.Collections.Generic;

namespace Voyage.Models.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public List<Trip> Trips { get; set; }
        public Country Country { get; set; }
    }
}
