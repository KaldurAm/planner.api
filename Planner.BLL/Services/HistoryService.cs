using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Planner.BLL.Interfaces;
using Planner.DAL.Context;
using Planner.DAL.Tables;

namespace Planner.BLL.Services
{
    public class HistoryService<TModel> : IHistoryService<TModel>
    {
        private readonly ILogger<HistoryService<TModel>> _logger;
        private readonly ApplicationDbContext _db;

        public HistoryService(ILogger<HistoryService<TModel>> logger,
            ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task Create(
            string controller = null, 
            string action = null, 
            string parameters = null, 
            string userId = null, 
            string description = null)
        {
            if (typeof(TModel) == typeof(TaskHistory))
            {
                var taskHistory = new TaskHistory
                {
                    CreateDate = DateTime.Now,
                    Controller = controller,
                    Action = action,
                    Parameters = parameters,
                    Description = description,
                    UserId = userId
                };

                _db.TaskHistoryList.Add(taskHistory);
                await _db.SaveChangesAsync();
            }

            if (typeof(TModel) == typeof(ObjectHistory))
            {
                var objectHistory = new ObjectHistory
                {
                    CreateDate = DateTime.Now,
                    Controller = controller,
                    Action = action,
                    Parameters = parameters,
                    Description = description,
                    UserId = userId
                };

                _db.ObjectHistoryList.Add(objectHistory);
                await _db.SaveChangesAsync();
            }
        }
    }
}
