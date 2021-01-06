using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DAL.Tables
{
    [Table("AttachFile")]
    public class AttachFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public int FileTypeId { get; set; }
        [ForeignKey(nameof(FileTypeId))]
        public virtual FileType Type { get; set; }

        public int FileExtensionId { get; set; }
        [ForeignKey(nameof(FileExtensionId))]
        public virtual FileExtension Extension { get; set; }
    }
}