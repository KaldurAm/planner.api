using Planner.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.BLL.Interfaces
{
    public interface IUserInfoService
    {
        Task<UserInfo> GetById(string userId);
        Task<IEnumerable<UserInfo>> GetAll();
    }
}
