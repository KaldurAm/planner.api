using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Planner.DAL.Tables
{
    [Table("ObjectPartnerMap")]
    public class ObjectPartnerMap
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual UserInfo User { get; set; }

        public int ObjectId { get; set; }
        [ForeignKey(nameof(ObjectId))]
        public virtual BuildingObject BuildingObject { get; set; }
    }
}
