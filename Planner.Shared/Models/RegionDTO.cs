using System.Collections;
using System.Collections.Generic;

namespace Planner.Shared.Models
{
    public class RegionDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CountryDTO Country { get; set; }
    }
}