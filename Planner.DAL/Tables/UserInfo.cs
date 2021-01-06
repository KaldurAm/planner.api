using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.DAL.Tables
{
    [Table("UserInfo")]
    public class UserInfo
    {
        public UserInfo()
        {
            Objects = new List<ObjectPartnerMap>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; }

        [StringLength(150)]
        public string Name { get; set; }

        [StringLength(150)]
        public string Surname { get; set; }

        [StringLength(150)]
        public string Patronym { get; set; }

        public virtual ICollection<TaskUserMap> Tasks { get; set; }

        public virtual ICollection<ObjectPartnerMap> Objects { get; set; }
    }
}
