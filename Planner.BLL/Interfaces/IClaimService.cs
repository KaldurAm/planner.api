using Planner.DAL.Tables;
using Planner.Shared.Models;
using System.Threading.Tasks;

namespace Planner.BLL.Interfaces
{
    public interface IClaimService
    {
        Task<UserManagerResponse> GetClaims(ApplicationUser user, params string[] roles);
    }
}
