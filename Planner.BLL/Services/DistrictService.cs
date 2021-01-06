using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class DistrictService : IDistrictService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public DistrictService(ApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IQueryable<DistrictDTO> Get()
        {
            return _mapper.Map<IQueryable<DistrictDTO>>(_db.Districts);
        }

        public async Task<IEnumerable<DistrictDTO>> GetAll()
        {
            var response = await _db.Districts.ToListAsync();
            var res = _mapper.Map<IEnumerable<DistrictDTO>>(response);
            return res;
        }

        public async Task<IEnumerable<DistrictWithObjectsTree>> GetTree()
        {
            var districts = await _db.Districts.Where(x => x.Objects.Any()).ToListAsync();
            var response = _mapper.Map<IEnumerable<DistrictWithObjectsTree>>(districts);
            return response;
        }

        public IEnumerable<DistrictDTO> Get(Expression<Func<District, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<DistrictDTO> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<DistrictDTO> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Query(string query)
        {
            throw new NotImplementedException();
        }

        public Task<CreateResponse<DistrictDTO>> Create(DistrictDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResultEnum> Update(DistrictDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResultEnum> Delete(DistrictDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
