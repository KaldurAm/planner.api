using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DAL.Tables
{
    [Table("TaskStatus")]
    public class TaskStatus
    {
        public TaskStatus()
        {
            TaskCards = new HashSet<TaskCard>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<TaskCard> TaskCards { get; set; }
    }
}