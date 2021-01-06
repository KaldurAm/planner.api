using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Shared.Models
{
    public class DistrictWithObjectsTree
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsOpen { get; set; }
        public IEnumerable<ActualBuildingObjectTree> Objects { get; set; }
    }
}
