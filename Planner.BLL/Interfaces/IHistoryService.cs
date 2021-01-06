using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.BLL.Interfaces
{
    public interface IHistoryService<TModel>
    {
        Task Create(string controller = null, string action = null, string parameters = null, string userId = null, string descriptioin = null);
    }
}
