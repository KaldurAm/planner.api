using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DAL.Tables
{
    [Table("FileType")]
    public class FileType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}