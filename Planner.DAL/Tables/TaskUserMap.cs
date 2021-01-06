using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Planner.DAL.Tables
{
    [Table("TaskUserMap")]
    public class TaskUserMap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual UserInfo User { get; set; }

        public int TaskId { get; set; }
        [ForeignKey(nameof(TaskId))]
        public virtual TaskCard Task { get; set; }
    }
}
