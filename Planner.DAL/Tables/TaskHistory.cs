using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Planner.DAL.Tables
{
    [Table("TaskHistory")]
    public class TaskHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Parameters { get; set; }
        public string Description { get; set; }
    }
}
