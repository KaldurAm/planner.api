using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Planner.DAL.Tables
{
    [Table("FileMap")]
    public class FileMap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int? BuildingObjectId { get; set; }
        [ForeignKey(nameof(BuildingObjectId))]
        public virtual BuildingObject BuildingObject { get; set; }

        public int? TaskCardId { get; set; }
        [ForeignKey(nameof(TaskCardId))]
        public virtual TaskCard Card { get; set; }

        public int AttachFileId { get; set; }
        [ForeignKey(nameof(AttachFileId))]
        public virtual AttachFile File { get; set; }
    }
}
