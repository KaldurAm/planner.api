using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Shared.Models
{
    public class TaskCardShortInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DeadlineDays { get; set; }
        public StatusDTO Status { get; set; }
        public List<string> Users { get; set; }
    }
}
