using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace Planner.DAL.Tables
{
    [Table("BuildObject")]
    public class BuildingObject
    {
        public BuildingObject()
        {
            TaskList = new List<TaskCard>();
            Files = new List<FileMap>();
            Partners = new List<ObjectPartnerMap>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string Code { get; set; }

        [StringLength(100)]
        public string CadastralNumber { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public string Description { get; set; }

        public double Area { get; set; }
        public int PropertyId { get; set; }
        [ForeignKey(nameof(PropertyId))]
        public virtual AreaProperty Property { get; set; }

        public decimal Cost { get; set; }
        public int CurrencyId { get; set; }
        [ForeignKey(nameof(CurrencyId))]
        public virtual Currency Currency { get; set; }

        public int DistrictId { get; set; }
        public virtual District District { get; set; }

        public string Address { get; set; }

        public int ObjectStatusId { get; set; }
        [ForeignKey(nameof(ObjectStatusId))]
        public virtual ObjectStatus Status { get; set; }

        public double? Lat { get; set; }

        public double? Lng { get; set; }

        public string LastChangedUser { get; set; }

        public bool Deleted { get; set; }

        public string DeletedUserId { get; set; }

        public virtual ICollection<TaskCard> TaskList { get; set; }

        public virtual ICollection<FileMap> Files { get; set; }

        public virtual ICollection<ObjectPartnerMap> Partners { get; set; }
    }
}