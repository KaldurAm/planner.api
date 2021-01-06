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
    public class PropertyService : IPropertyService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public PropertyService(ApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IQueryable<AreaPropertyDTO> Get()
        {
            return _mapper.Map<IQueryable<AreaPropertyDTO>>(_db.AreaProperties);
        }

        public IEnumerable<AreaPropertyDTO> Get(Expression<Func<AreaProperty, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AreaPropertyDTO>> GetAll()
        {
            var properties = await _db.AreaProperties.ToListAsync();
            var res = _mapper.Map<IEnumerable<AreaPropertyDTO>>(properties);
            return res;
        }

        public Task<AreaPropertyDTO> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<AreaPropertyDTO> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Query(string query)
        {
            throw new NotImplementedException();
        }

        public Task<CreateResponse<AreaPropertyDTO>> Create(AreaPropertyDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResultEnum> Update(AreaPropertyDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResultEnum> Delete(AreaPropertyDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
