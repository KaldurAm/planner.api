using Planner.DAL.Tables;
using Planner.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BLL.Interfaces
{
    public interface IDistrictService : IBaseService<District, DistrictDTO>
    {
        Task<IEnumerable<DistrictDTO>> GetAll();
        Task<IEnumerable<DistrictWithObjectsTree>> GetTree();
    }
}
