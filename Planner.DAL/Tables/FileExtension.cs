using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DAL.Tables
{
    [Table("FileExtension")]
    public class FileExtension
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}