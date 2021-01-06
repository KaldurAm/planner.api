using Planner.DAL.Tables;
using Planner.Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Planner.BLL.Interfaces
{
    public interface ICountryService : IBaseService<Country, CountryDTO>
    {
        public Task<IEnumerable<CountryDTO>> GetCountriesWithObjects();
    }
}
