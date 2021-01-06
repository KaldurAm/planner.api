using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.Shared.Models
{
    public class ObjectDetailDTO
    {
        public ObjectDetailDTO()
        {
            ShortTaskInfo = new List<TaskCardShortInfoDTO>();
            Files = new List<FileDTO>();
            PartnerList = new HashSet<string>();
        }

        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string CadastralNumber { get; set; }

        public double Area { get; set; }

        public AreaPropertyDTO Property { get; set; }

        public decimal Cost { get; set; }

        public CurrencyDTO Currency { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public DistrictDTO District { get; set; }

        public ObjectStatusDTO Status { get; set; }

        public List<TaskCardShortInfoDTO> ShortTaskInfo { get; set; }

        public List<FileDTO> Files { get; set; }

        public IEnumerable<string> PartnerList { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public bool Deleted { get; set; }
    }
}
