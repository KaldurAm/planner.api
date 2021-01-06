using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DAL.Tables
{
    [Table("City")]
    public class City
    {
        public City()
        {
            Districts = new HashSet<District>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(155)]
        public string Name { get; set; }

        public int? RegionId { get; set; }
        [ForeignKey(nameof(RegionId))]
        public virtual Region Region { get; set; }

        public virtual ICollection<District> Districts { get; set; }
    }
}