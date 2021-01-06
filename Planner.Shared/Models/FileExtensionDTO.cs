using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.Shared.Models
{
    public class FileExtensionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}