using System;
using System.Collections.Generic;

namespace Planner.Shared.Models
{
    public class CardDTO
    {
        public int Id { get; set; }

        public string CreatorId { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int ObjectId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<FileDTO> Files { get; set; }

        public StatusDTO Status { get; set; }

        public TaskColorDTO Color { get; set; }

        public int DeadlineDays { get; set; }

        public bool Approved { get; set; }

        public bool Deleted { get; set; }

        public IEnumerable<string> Users { get; set; }
    }
}
