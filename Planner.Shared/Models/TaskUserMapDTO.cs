using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Planner.Shared.Models
{
    public class TaskUserMapDTO
    {
        public int Id { get; set; }

        public virtual UserDTO User { get; set; }

        public virtual CardDTO Task { get; set; }
    }
}
