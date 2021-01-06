using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DAL.Tables
{
    [Table("Country")]
    public class Country
    {
        public Country()
        {
            Regions = new HashSet<Region>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(155)]
        public string Name { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}