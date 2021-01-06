using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DAL.Tables
{
    [Table("TaskColor")]
    public class TaskColor
    {
        [Key]
        public int Id { get; set; }

        [StringLength(15)]
        public string Name { get; set; }

        public string Code { get; set; }
    }
}
