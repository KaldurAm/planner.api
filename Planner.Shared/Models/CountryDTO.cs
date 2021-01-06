using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.Shared.Models
{
    public class CountryDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}