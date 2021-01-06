using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Planner.Shared.Models
{
    public class FileDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public FileTypeDTO Type { get; set; }

        public FileExtensionDTO Extension { get; set; }
    }
}