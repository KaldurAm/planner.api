using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
using System.Threading.Tasks;

namespace Planner.BLL.Services.GetInfo
{
    public class ObjectService : IObjectService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<RegionService> _logger;

        public ObjectService(ApplicationDbContext db,
            IMapper mapper,
            ILogger<RegionService> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        public IQueryable<BuildingObject> Get()
        {
            return _db.Objects;
        }

        public IEnumerable<ObjectDTO> Get(Expression<Func<BuildingObject, bool>> predicate)
        {
            var objects = _db.Objects.Where(predicate);
            return _mapper.Map<IEnumerable<ObjectDTO>>(objects);
        }

        public async Task<IEnumerable<DisplayObjectDTO>> GetForDisplayAsync(Expression<Func<BuildingObject, bool>> predicate)
        {
            var objects = await _db.Objects.Where(predicate)
                .OrderBy(o => o.ReleaseDate)
                .ToListAsync();
            var result = _mapper.Map<IEnumerable<DisplayObjectDTO>>(objects);
            return result;
        }

        public async Task<IEnumerable<DisplayObjectDTO>> GetForDisplayAsync(Expression<Func<BuildingObject, bool>> predicate, int userId)
        {
            var objects = await _db.Objects.Where(predicate)
                .OrderBy(o => o.ReleaseDate)
                .ToListAsync();
            var result = _mapper.Map<IEnumerable<DisplayObjectDTO>>(objects);
            return result;
        }

        public async Task<IEnumerable<ActualBuildingObjectTree>> GetObjectsTree()
        {
            var objects = await _db.Objects.Where(x => !x.Deleted)
                .OrderBy(o => o.ReleaseDate)
                .ToListAsync();
            var result = _mapper.Map<IEnumerable<ActualBuildingObjectTree>>(objects);
            return result;
        }

        public async Task<IEnumerable<ObjectStatusDTO>> GetStatusList()
        {
            var statusList = await _db.ObjectStatuses.ToListAsync();
            return _mapper.Map<IEnumerable<ObjectStatusDTO>>(statusList);
        }

        public async Task<IEnumerable<CardDTO>> GetTaskList(int id)
        {
            var objectRealty = await _db.Objects.FirstOrDefaultAsync(x => x.Id == id);
            var taskList = _mapper.Map<IEnumerable<CardDTO>>(objectRealty.TaskList);
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

        public async Task<ObjectDTO> GetById(int Id)
        {
            var building = await _db.Objects.FindAsync(Id);
            return _mapper.Map<ObjectDTO>(building);
        }

        public async Task<ObjectDetailDTO> GetForDetail(int Id)
        {
            var building = await _db.Objects.FindAsync(Id);
            var buildingDetail = _mapper.Map<ObjectDetailDTO>(building);
            buildingDetail.ShortTaskInfo = _mapper.Map<List<TaskCardShortInfoDTO>>(building.TaskList);
            foreach (var task in buildingDetail.ShortTaskInfo)
            {
                var taskMapListCollection = building.TaskList.Select(s => s.ResponsibleUsers);
                foreach (var taskMapList in taskMapListCollection)
                {
                    task.Users = taskMapList.Select(s => new String(s.User.Surname + " " + s.User.Name)).ToList();
                }
            }
            buildingDetail.PartnerList = building.Partners.Select(s => new String(s.User.Surname + " " + s.User.Name));
            return buildingDetail;
        }

        public Task<ObjectDTO> GetById(string Id)
        {
            throw new Exception();
        }

        public IEnumerable<ObjectSelection> GetObjectsForSelect()
        {
            var objects = Get().Where(w => !w.Deleted).Select(s => new ObjectSelection { Id = s.Id, Name = s.Name });
            return objects;
        }

        public async Task<int> Query(string query)
        {
            return await _db.Database.ExecuteSqlRawAsync(query);
        }

        public async Task<CreateResponse<ObjectDTO>> Create(ObjectDTO model)
        {
            var building = _mapper.Map<BuildingObject>(model);
            building.ObjectStatusId = (int)ObjectStatusEnum.Инициализировано;
            try
            {
                await _db.Objects.AddAsync(building);
                await _db.SaveChangesAsync();
                return new CreateResponse<ObjectDTO>
                {
                    Response = _mapper.Map<ObjectDTO>(building),
                    Result = ResponseResultEnum.Created
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, model);
                return new CreateResponse<ObjectDTO>
                {
                    Response = null,
                    Result = ResponseResultEnum.Error
                };
            }
        }

        public async Task<ResponseResultEnum> Delete(int id)
        {
            try
            {
                var domain = await _db.Objects.FindAsync(id);
                domain.Deleted = true;
                _db.Objects.Update(domain);
                await _db.SaveChangesAsync();
                return ResponseResultEnum.Deleted;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, id);
                return ResponseResultEnum.Error;
            }
        }

        public async Task<ResponseResultEnum> Delete(ObjectDTO model)
        {
            throw new Exception();
        }

        public async Task<ResponseResultEnum> Update(ObjectDTO model)
        {
            var building = _mapper.Map<BuildingObject>(model);
            try
            {
                _db.Objects.Update(building);
                await _db.SaveChangesAsync();
                return ResponseResultEnum.Updated;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, model);
                return ResponseResultEnum.Error;
            }
        }
    }
}
