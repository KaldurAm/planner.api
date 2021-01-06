using Planner.DAL.Tables;
using Planner.Shared.Enums;
using Planner.Shared.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Planner.BLL.Interfaces
{
    public interface IObjectService : IBaseService<BuildingObject, ObjectDTO>
    {
        IQueryable<BuildingObject> Get();
        Task<IEnumerable<ObjectStatusDTO>> GetStatusList();
        Task<IEnumerable<DisplayObjectDTO>> GetForDisplayAsync(Expression<Func<BuildingObject, bool>> predicate);
        Task<IEnumerable<DisplayObjectDTO>> GetForDisplayAsync(Expression<Func<BuildingObject, bool>> predicate, int userId);
        Task<IEnumerable<ActualBuildingObjectTree>> GetObjectsTree();
        Task<ObjectDetailDTO> GetForDetail(int Id);
        Task<IEnumerable<CardDTO>> GetTaskList(int id);
        Task<IEnumerable<StatusDTO>> GetTaskStatusList();
        Task<ResponseResultEnum> Delete(int id);
        IEnumerable<ObjectSelection> GetObjectsForSelect();
    }
}
