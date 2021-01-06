using Microsoft.EntityFrameworkCore;
using Planner.BLL.Interfaces;
using Planner.DAL.Context;
using Planner.DAL.Tables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.BLL.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly ApplicationDbContext _db;

        public UserInfoService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<UserInfo>> GetAll()
        {
            return await _db.UserList.ToListAsync();
        }

        public async Task<UserInfo> GetById(string id)
        {
            return await _db.UserList.FirstOrDefaultAsync(x => x.UserId == id);
        }
    }
}
