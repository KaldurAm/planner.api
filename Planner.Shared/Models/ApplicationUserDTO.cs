using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Shared.Models
{
    public class ApplicationUserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
