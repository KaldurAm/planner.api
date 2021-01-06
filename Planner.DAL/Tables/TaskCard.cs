using Microsoft.Extensions.ObjectPool;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DAL.Tables
{
    [Table("TaskCard")]
    public class TaskCard
    {
        public TaskCard()
        {
            Files = new HashSet<FileMap>();
            ResponsibleUsers = new HashSet<TaskUserMap>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(450)]
        public string CreatorId { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int ObjectId { get; set; }
        [ForeignKey(nameof(ObjectId))]
        public virtual BuildingObject Object { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<FileMap> Files { get; set; }

        public int StatusId { get; set; }
        public virtual TaskStatus Status { get; set; }

        public int ColorId { get; set; }
        [ForeignKey(nameof(ColorId))]
        public virtual TaskColor Color { get; set; }

        public int DeadlineDays { get; set; }

        public bool Approved { get; set; }

        public string ApplyByUser { get; set; }

        public string LastChangeUser { get; set; }

        public bool Deleted { get; set; }

        public string DeletedByUser { get; set; }

        public virtual IEnumerable<TaskUserMap> ResponsibleUsers { get; set; }
    }
}
