using Planner.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Planner.BLL.Interfaces
{
    public interface IAuthService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterRequest request);
        Task<UserManagerResponse> LoginUserAsync(LoginRequest request);
    }
}
