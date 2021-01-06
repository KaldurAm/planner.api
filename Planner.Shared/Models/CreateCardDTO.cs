using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Planner.Shared.Models
{
    public class CreateCardDTO
    {
        public int Id { get; set; }

        public string CreatorId { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int ObjectId { get; set; }

        [Required]
        public string Name { get; set; }

        public int StatusId { get; set; }

        public string Description { get; set; }

        public List<FileDTO> Files { get; set; }

        public int DeadlineDays { get; set; } = 1;

        public bool Approved { get; set; }

        public bool Deleted { get; set; }

        public IEnumerable<string> Users { get; set; }
    }
}
