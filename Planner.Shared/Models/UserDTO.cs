using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.Shared.Models
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Patronym { get; set; }

        public string FullName => $@"{Surname} {Name}";
    }
}
