using Planner.DAL.Tables;
using Planner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.BLL.Interfaces
{
    public interface ICurrencyService : IBaseService<Currency, CurrencyDTO>
    {
        Task<IEnumerable<CurrencyDTO>> GetAll();
    }
}
