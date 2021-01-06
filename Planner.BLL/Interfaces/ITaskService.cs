using Planner.DAL.Tables;
using Planner.Shared.Enums;
using Planner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.BLL.Interfaces
{
    public interface ITaskService : IBaseService<TaskCard, TaskCardShortInfoDTO>
    {
        Task<CreateResponse<CardDTO>> Create(CreateCardDTO model);
        public Task<CardDTO> GetCardById(int Id);
        Task<ResponseResultEnum> Update(CardDTO model, string user);
        Task<IEnumerable<CardDTO>> GetTaskList(int id);
        Task<IEnumerable<StatusDTO>> GetTaskStatusList();
        Task UpdateTaskStatus(CardDTO card, string user);
        Task<ResponseResultEnum> Delete(int taskId, string user);
        Task<IEnumerable<TaskColorDTO>> GetColors();
    }
}
