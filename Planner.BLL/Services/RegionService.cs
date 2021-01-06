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

namespace Planner.BLL.Services
{
    public class RegionService : IRegionService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<RegionService> _logger;

        public RegionService(ApplicationDbContext db,
            IMapper mapper,
            ILogger<RegionService> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CreateResponse<RegionDTO>> Create(RegionDTO model)
        {
            var region = _mapper.Map<Region>(model);
            try
            {
                await _db.Regions.AddAsync(region);
                await _db.SaveChangesAsync();
                return new CreateResponse<RegionDTO>
                {
                    Response = _mapper.Map<RegionDTO>(region),
                    Result = ResponseResultEnum.Created
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, model);
                return new CreateResponse<RegionDTO>
                {
                    Response = null,
                    Result = ResponseResultEnum.Error
                };
            }
        }

        public async Task<ResponseResultEnum> Delete(RegionDTO model)
        {
            var region = _mapper.Map<Region>(model);
            try
            {
                _db.Regions.Remove(region);
                await _db.SaveChangesAsync();
                return ResponseResultEnum.Deleted;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, model);
                return ResponseResultEnum.Error;
            }
        }

        public IQueryable<RegionDTO> Get()
        {
            return _mapper.Map<IQueryable<RegionDTO>>(_db.Regions);
        }

        public IEnumerable<RegionDTO> Get(Expression<Func<Region, bool>> predicate)
        {
            var regions = _db.Regions.Where(predicate);
            return _mapper.Map<IEnumerable<RegionDTO>>(regions);
        }

        public async Task<RegionDTO> GetById(int Id)
        {
            var region = await _db.Regions.FindAsync(Id);
            return _mapper.Map<RegionDTO>(region);
        }

        public Task<RegionDTO> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Query(string query)
        {
            return await _db.Database.ExecuteSqlRawAsync(query);
        }

        public Task<ResponseResultEnum> Update(RegionDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
