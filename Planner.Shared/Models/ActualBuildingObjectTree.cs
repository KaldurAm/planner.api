using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Shared.Models
{
    public class ActualBuildingObjectTree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public bool Deleted { get; set; }
    }
}
