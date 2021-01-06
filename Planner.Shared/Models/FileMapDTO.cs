using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Shared.Models
{
    public class FileMapDTO
    {
        public int Id { get; set; }
        public ObjectDetailDTO BuildingObject { get; set; }
        public TaskCardShortInfoDTO Card { get; set; }
        public FileDTO File { get; set; }
    }
}
