using AutoMapper;
using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.Extensions.Logging;
using Planner.BLL.Interfaces;
using Planner.DAL.Context;
using Planner.DAL.Tables;
using Planner.Shared.Enums;
using Planner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Planner.BLL.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<TaskService> _logger;
        private readonly IMapper _mapper;

        public TaskService(ApplicationDbContext db,
            ILogger<TaskService> logger,
            IMapper mapper)
        {
            _db = db;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateResponse<CardDTO>> Create(CreateCardDTO model)
        {
            var domainTask = _mapper.Map<TaskCard>(model);
            domainTask.Status = _db.TaskStatuses.Find(model.StatusId);
            domainTask.Color = await _db.Colors.FirstOrDefaultAsync(f => f.Id == 1);
            await _db.Tasks.AddAsync(domainTask);
            await _db.SaveChangesAsync();
            return new CreateResponse<CardDTO>
            {
                Response = _mapper.Map<CardDTO>(domainTask),
                Result = ResponseResultEnum.Created
            };
        }

        public Task<CreateResponse<TaskCardShortInfoDTO>> Create(TaskCardShortInfoDTO model)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateTaskStatus(CardDTO card, string user)
        {
            var task = await _db.Tasks.FindAsync(card.Id);
            task.Status = await _db.TaskStatuses.FindAsync(card.Status.Id);
            if (task.Status.Id == (int)TaskStatusEnum.Завершено &&
                task.ApplyByUser == null)
            {
                task.ApplyByUser = user;
            }
            _db.Tasks.Update(task);
            await _db.SaveChangesAsync();
        }

        public Task<ResponseResultEnum> Delete(TaskCardShortInfoDTO model)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseResultEnum> Delete(int taskId, string user)
        {
            try
            {
                var domain = await _db.Tasks.FindAsync(taskId);
                domain.StatusId = 8;
                domain.Deleted = true;
                domain.DeletedByUser = user;
                _db.Tasks.Update(domain);
                await _db.SaveChangesAsync();
                return ResponseResultEnum.Deleted;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Delete error", taskId);
                return ResponseResultEnum.Error;
            }
        }

        public IQueryable<TaskCardShortInfoDTO> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskCardShortInfoDTO> Get(Expression<Func<TaskCard, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<TaskCardShortInfoDTO> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<CardDTO> GetCardById(int Id)
        {
            var domainCard = await _db.Tasks.FindAsync(Id);
            var dtoCard = _mapper.Map<CardDTO>(domainCard);
            dtoCard.Users = domainCard.ResponsibleUsers.Select(s => new String(s.User.Surname + " " + s.User.Name));
            return dtoCard;
        }

        public Task<TaskCardShortInfoDTO> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CardDTO>> GetTaskList(int id)
        {
            var objectTasks = await _db.Tasks.Where(x => x.ObjectId == id && x.StatusId != (int)TaskStatusEnum.Удалено).ToListAsync();
            var taskList = _mapper.Map<IEnumerable<CardDTO>>(objectTasks);
            var taskUserMap = _db.TaskUserMappingList.Where(x => objectTasks.Select(s => s.Id).Contains(x.TaskId));
            foreach (var task in taskList)
            {
                task.Users = taskUserMap.Where(x => x.TaskId == task.Id).Select(s => s.User.UserId).ToList();
            }
            return taskList;
        }

        public async Task<IEnumerable<StatusDTO>> GetTaskStatusList()
        {
            var domainStatusList = await _db.TaskStatuses.Where(x =>
                x.Id == (int)TaskStatusEnum.Назначено ||
                x.Id == (int)TaskStatusEnum.НаИсполнении ||
                x.Id == (int)TaskStatusEnum.Завершено).ToListAsync();
            var statusList = _mapper.Map<IEnumerable<StatusDTO>>(domainStatusList);
            return statusList;
        }

        public async Task<IEnumerable<TaskColorDTO>> GetColors()
        {
            var domainColors = _db.Colors.AsEnumerable();
            var colors = _mapper.Map<IEnumerable<TaskColorDTO>>(domainColors);
            return colors;
        }

        public Task<int> Query(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseResultEnum> Update(CardDTO model, string user)
        {
            var card = _mapper.Map<TaskCard>(model);
            await AddTaskResponsibleUserMap(model.Users, model.Id);
            card.LastChangeUser = user;
            card.Color = await _db.Colors.FindAsync(model.Color.Id);
            try
            {
                _db.Tasks.Update(card);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $@"{nameof(TaskService)}/{nameof(Update)}");
                return ResponseResultEnum.Error;
            }

            return ResponseResultEnum.Updated;
        }

        public Task<ResponseResultEnum> Update(TaskCardShortInfoDTO model)
        {
            throw new NotImplementedException();
        }

        private async Task<IEnumerable<TaskUserMap>> AddTaskResponsibleUserMap(IEnumerable<string> userIdList, int taskId)
        {
            List<TaskUserMap> list = new List<TaskUserMap>();

            List<UserInfo> users = new List<UserInfo>();

            if (userIdList != null)
            {
                users = await _db.UserList.Where(x => userIdList.Contains(x.UserId)).ToListAsync();
            }

            var findUsers = _db.TaskUserMappingList.Where(x => x.TaskId == taskId);

            if (findUsers != null)
            {
                _db.TaskUserMappingList.RemoveRange(findUsers);
                await _db.SaveChangesAsync();
            }

            foreach (var user in users)
            {
                list.Add(new TaskUserMap()
                {
                    TaskId = taskId,
                    UserId = user.Id
                });
            }

            if (users.Count > 0)
            {
                try
                {
                    await _db.TaskUserMappingList.AddRangeAsync(list);
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

            return list;
        }
    }
}
