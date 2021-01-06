using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DAL.Tables
{
    [Table("District")]
    public class District
    {
        public District()
        {
            Objects = new HashSet<BuildingObject>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(155)]
        public string Name { get; set; }

        public int CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; }

        public virtual ICollection<BuildingObject> Objects { get; set; }
    }
}