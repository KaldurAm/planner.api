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
    public class CountryService : ICountryService
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly ILogger<CountryService> _logger;

        public CountryService(ApplicationDbContext db,
            IMapper mapper,
            ILogger<CountryService> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<CountryDTO>> GetCountriesWithObjects()
        {
            var objects = _db.Objects.Select(s => s.DistrictId);
            var districts = _db.Districts.Where(x => objects.Contains(x.Id)).Select(s => s.CityId);
            var cities = _db.Cities.Where(x => districts.Contains(x.Id)).Select(x => x.RegionId);
            var regions = _db.Regions.Where(x => cities.Contains(x.Id)).Select(x => x.CountryId);
            var countriesWithObjects = await _db.Countries.Where(x => regions.Contains(x.Id)).ToListAsync();
            var countriesDTO = _mapper.Map<IEnumerable<CountryDTO>>(countriesWithObjects);
            return countriesDTO;
        }

        public IQueryable<CountryDTO> Get()
        {
            return _mapper.Map<IQueryable<CountryDTO>>(_db.Countries);
        }

        public IEnumerable<CountryDTO> Get(Expression<Func<Country, bool>> predicate)
        {
            var countries = _db.Countries.Where(predicate);
            return _mapper.Map<IEnumerable<CountryDTO>>(countries);
        }

        public async Task<int> Query(string query)
        {
            return await _db.Database.ExecuteSqlRawAsync(query);
        }

        public async Task<CountryDTO> GetById(int Id)
        {
            var country = await _db.Countries.FindAsync(Id);
            return _mapper.Map<CountryDTO>(country);
        }

        public Task<CountryDTO> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public async Task<CreateResponse<CountryDTO>> Create(CountryDTO model)
        {
            var country = _mapper.Map<Country>(model);
            try
            {
                await _db.Countries.AddAsync(country);
                await _db.SaveChangesAsync();
                return new CreateResponse<CountryDTO>
                {
                    Response = _mapper.Map<CountryDTO>(country),
                    Result = ResponseResultEnum.Created
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, model);
                return new CreateResponse<CountryDTO>
                {
                    Response = null,
                    Result = ResponseResultEnum.Error
                };
            }
        }

        public async Task<ResponseResultEnum> Update(CountryDTO model)
        {
            var country = _mapper.Map<Country>(model);
            try
            {
                _db.Countries.Update(country);
                await _db.SaveChangesAsync();
                return ResponseResultEnum.Updated;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, model);
                return ResponseResultEnum.Error;
            }
        }

        public async Task<ResponseResultEnum> Delete(CountryDTO model)
        {
            var country = _mapper.Map<Country>(model);
            try
            {
                _db.Countries.Remove(country);
                await _db.SaveChangesAsync();
                return ResponseResultEnum.Deleted;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message, model);
                return ResponseResultEnum.Error;
            }
        }
    }
}
