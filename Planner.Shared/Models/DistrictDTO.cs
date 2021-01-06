using System.Collections.Generic;

namespace Planner.Shared.Models
{
    public class DistrictDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CityId { get; set; }

        public CityDTO City { get; set; }

        public bool IsOpen { get; set; } = false;
    }
}