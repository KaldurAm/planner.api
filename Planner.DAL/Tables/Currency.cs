using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Planner.DAL.Tables
{
    [Table("Currency")]
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Code { get; set; }

        [StringLength(10)]
        public string Name { get; set; }
    }
}
