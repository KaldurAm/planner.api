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
    public class CurrencyService : ICurrencyService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public CurrencyService(ApplicationDbContext db,
            IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public IQueryable<CurrencyDTO> Get()
        {
            return _mapper.Map<IQueryable<CurrencyDTO>>(_db.Currencies);
        }

        public IEnumerable<CurrencyDTO> Get(Expression<Func<Currency, bool>> predicate)
        {
            var currencies = _db.Currencies.Where(predicate);
            return _mapper.Map<IEnumerable<CurrencyDTO>>(currencies);
        }

        public async Task<IEnumerable<CurrencyDTO>> GetAll()
        {
            var currencies = await _db.Currencies.ToListAsync();
            var res = _mapper.Map<IEnumerable<CurrencyDTO>>(currencies);
            return res;
        }

        public Task<CurrencyDTO> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<CurrencyDTO> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Query(string query)
        {
            throw new NotImplementedException();
        }

        public Task<CreateResponse<CurrencyDTO>> Create(CurrencyDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResultEnum> Update(CurrencyDTO model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseResultEnum> Delete(CurrencyDTO model)
        {
            throw new NotImplementedException();
        }
    }
}
