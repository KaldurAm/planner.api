using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Shared.Models
{
    public class ObjectPartnerMapDTO
    {
        public int Id { get; set; }
        public UserDTO User { get; set; }
        public ObjectDetailDTO BuildingObject { get; set; }
    }
}
