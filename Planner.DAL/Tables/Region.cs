using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DAL.Tables
{
    [Table("Region")]
    public class Region
    {
        public Region()
        {
            Cities = new HashSet<City>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(155)]
        public string Name { get; set; }

        public int CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}