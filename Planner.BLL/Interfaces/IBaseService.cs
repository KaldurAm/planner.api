using Planner.Shared.Enums;
using Planner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Planner.BLL.Interfaces
{
    public interface IBaseService<DomainModel, DTOModel>
    {
        public IEnumerable<DTOModel> Get(Expression<Func<DomainModel, bool>> predicate);
        public Task<int> Query(string query);
        public Task<DTOModel> GetById(int Id);
        public Task<DTOModel> GetById(string Id);
        public Task<CreateResponse<DTOModel>> Create(DTOModel model);
        public Task<ResponseResultEnum> Update(DTOModel model);
        public Task<ResponseResultEnum> Delete(DTOModel model);
    }
}
