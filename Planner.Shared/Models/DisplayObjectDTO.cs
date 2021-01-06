using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Shared.Models
{
    public class DisplayObjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DistrictDTO District { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
    }
}
